using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hours_Tracker
{
    public partial class HoursTracker : Form
    {
        string activeFilePath;
        string configFilePath;
        List<Project> allProjects = new List<Project>();
        string header = "";
        Project activeProject;

        public HoursTracker()
        {
            InitializeComponent();
        }

        /* UI Event Methods */

        //
        // Window Loading
        //
        private void HoursTracker_Load(object sender, EventArgs e)
        {
            projectToolStripMenuItem.Enabled = false;
            projectSelector.Enabled = false;
            renameProjectToolStripMenuItem.Enabled = false;
            deleteProjectToolStripMenuItem.Enabled = false;
            clockInButton.Enabled = false;
            clockOutButton.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            headerLabel.Visible = false;
            createProjectButton.Visible = false;
            projectTitleLabel.Visible = false;
            treeView1.Enabled = false;

            configFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\hourstracker.config";

            if (File.Exists(configFilePath))
            {
                string[] configText = File.ReadAllLines(configFilePath);

                foreach (string line in configText)
                {
                    if (line.Contains("Last Opened ="))
                    {
                        int first = line.IndexOf("*") + 1;
                        int last = line.LastIndexOf("*");
                        string latestProject = line.Substring(first, last - first);
                        activeFilePath = latestProject;
                        if (File.Exists(activeFilePath))
                        {
                            LoadFile(latestProject);
                            break;
                        }

                    }

                }
            }
        }

        //
        // Project DropDown
        //
        private void ProjectSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Project project in allProjects)
            {
                if (projectSelector.SelectedItem.ToString() == project.projectName)
                {
                    activeProject = project;
                    projectTitleLabel.Text = project.projectName;
                    PrintProject(project);

                    SetButtons(project);
                }
            }
        }

        //
        // OpenFile
        //
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        //
        // New File
        //
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        //
        // New Project
        //
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();
            createProjectButton.Visible = false;
        }

        //
        // Set Start Time and save file
        //
        private void ClockIn_Click(object sender, EventArgs e)
        {
            if (activeProject != null)
                activeProject.OpenNewSession(DateTime.Now);
            PrintProject(activeProject);
            SetButtons(activeProject);
            SaveFile();
        }

        //
        // Set Stop Time and save file
        //
        private void ClockOut_Click(object sender, EventArgs e)
        {
            if (activeProject != null)
                activeProject.CloseSession(DateTime.Now);
            PrintProject(activeProject);
            SetButtons(activeProject);
            SaveFile();
        }

        //
        // Save file or overwrite another
        //
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Projects Files| *.pjf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == string.Empty)
                    return;

                activeFilePath = saveFileDialog1.FileName;
                SaveFile();
            }
        }

        //
        // Button for Creating Project, when file contains no projects
        //
        private void CreateProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        //
        // Rename a project
        //
        private void renameProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] activeProjectNames = new string[allProjects.Count];
            for (int i = 0; i < allProjects.Count; i++)
            {
                activeProjectNames[i] = allProjects[i].projectName;
            }

            TextDialogBox textInput = new TextDialogBox();
            textInput.SetToRename();
            textInput.SetActiveNames(activeProjectNames);
            DialogResult = textInput.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                activeProject.RenameProject(textInput.newProjectName);
                RefreshProjectSelector();
            }
        }

        /* Helper Methods */

        //
        // Activate File Manipulation Elements
        //
        void ActivateItems()
        {
            projectSelector.Enabled = true;
            clockInButton.Enabled = false;
            clockOutButton.Enabled = false;
            if (activeProject != null)
                SetButtons(activeProject);
            projectToolStripMenuItem.Enabled = true;
            deleteProjectToolStripMenuItem.Enabled = true;
            renameProjectToolStripMenuItem.Enabled = true;
            treeView1.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            headerLabel.Visible = true;
            headerLabel.Text = header;
            projectTitleLabel.Visible = true;
            if (activeProject != null)
                projectTitleLabel.Text = activeProject.projectName;
            openFileButton.Visible = false;
            createFileButton.Visible = false;
        }
        //
        // Open a File
        //
        private void OpenFile()
        {
            openFileDialog1.Filter = "Projects Files| *.pjf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog1.CheckFileExists)
                    return;

                activeFilePath = openFileDialog1.FileName;

                LoadFile(activeFilePath);
            }
        }

        private void LoadFile(string path)
        {
            string[] fileText = File.ReadAllLines(activeFilePath);

            ParseFileContents(fileText);
            projectSelector.Items.Clear();

            if (allProjects.Count > 0)
                activeProject = allProjects[0];
            else
                DisplayCreateProject();

            RefreshProjectSelector();
            ActivateItems();

            string buffer = "Last Opened = *" + activeFilePath + "*";

            WriteToFile(buffer, configFilePath);
        }

        //
        // Create a file
        //
        private void CreateFile()
        {
            saveFileDialog1.Filter = "Projects Files| *.pjf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == string.Empty)
                    return;

                activeFilePath = saveFileDialog1.FileName;

                FileStream fs = File.Create(activeFilePath);
                string fileHeader = "File Created by " + System.Environment.UserName + " - on " + DateTime.Now.Date.ToShortDateString() + "\n";
                header = fileHeader;
                byte[] buffer = new UTF8Encoding(true).GetBytes(fileHeader);

                fs.Write(buffer, 0, buffer.Length);

                fs.Close();
                ActivateItems();

                DisplayCreateProject();

            }
        }

        //
        // Creates a new project
        //
        private void NewProject()
        {
            string[] activeProjectNames = new string[allProjects.Count];
            for (int i = 0; i < allProjects.Count; i++)
            {
                activeProjectNames[i] = allProjects[i].projectName;
            }

            TextDialogBox textInput = new TextDialogBox();
            textInput.SetActiveNames(activeProjectNames);
            DialogResult = textInput.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                activeProject = new Project(textInput.newProjectName);
                allProjects.Add(activeProject);

                projectSelector.Items.Clear();
                foreach (Project project in allProjects)
                {
                    int index = projectSelector.Items.Add(project.projectName);
                    if (project == activeProject)
                        projectSelector.SelectedItem = projectSelector.Items[index];
                }

                ActivateItems();
                createProjectButton.Visible = false;
            }
            else if (DialogResult == DialogResult.Ignore)
            {
                foreach (Project project in allProjects)
                {
                    if (project.projectName == textInput.newProjectName)
                    {
                        allProjects.Remove(project);
                        projectSelector.Items.Clear();
                        break;
                    }
                }


                activeProject = new Project(textInput.newProjectName);
                allProjects.Add(activeProject);

                projectSelector.Items.Clear();
                foreach (Project project in allProjects)
                {
                    int index = projectSelector.Items.Add(project.projectName);
                    if (project == activeProject)
                        projectSelector.SelectedItem = projectSelector.Items[index];
                }

                ActivateItems();
                createProjectButton.Visible = false;
            }
        }

        //
        // Shows Button when a file contains no project
        //
        void DisplayCreateProject()
        {
            projectTitleLabel.Visible = true;
            projectTitleLabel.Text = "Click Create Project to get started.";
            createProjectButton.Visible = true;


            projectSelector.Enabled = false;
            clockInButton.Enabled = false;
            clockOutButton.Enabled = false;
            projectToolStripMenuItem.Enabled = true;
            deleteProjectToolStripMenuItem.Enabled = false;
            renameProjectToolStripMenuItem.Enabled = false;
            newProjectToolStripMenuItem1.Enabled = true;
            treeView1.Nodes.Clear();
            treeView1.Enabled = false;
            saveAsToolStripMenuItem.Enabled = true;
            headerLabel.Visible = true;
            headerLabel.Text = header;
            openFileButton.Visible = false;
            createFileButton.Visible = false;
        }

        //
        // Set Buttons Active/Inactive
        //
        void SetButtons(Project project)
        {
            if (project.IsActive())
            {
                clockInButton.Enabled = false;
                clockOutButton.Enabled = true;
            }
            else
            {
                clockOutButton.Enabled = false;
                clockInButton.Enabled = true;
            }
        }

        //
        // Parse .psf file
        //
        void ParseFileContents(string[] fileText)
        {
            int y = 0;
            if (fileText[0].Contains("File Created by"))
            {
                header = fileText[0] + "\n";
                y = 1;
            }
            allProjects.Clear();
            for (int i = y; i < fileText.Length; i++)
            {
                if (fileText[i].Contains("Project ="))
                {
                    int first = fileText[i].IndexOf("*") + 1;
                    int last = fileText[i].LastIndexOf("*");
                    string name = fileText[i].Substring(first, last - first);
                    for (int j = i + 1; j < fileText.Length; j++)
                    {
                        if (fileText[j].Contains("END"))
                        {
                            int projectDataCount = j - i - 1;

                            string[] projectData = new string[projectDataCount];

                            for (int x = 0; x < projectData.Length; x++)
                            {
                                projectData[x] = fileText[i + x + 1];
                            }

                            Project currentProject = new Project(name, projectData);
                            allProjects.Add(currentProject);
                            i = j - 1;
                            j = fileText.Length;

                        }

                    }
                }
            }
        }

        //
        // Save .psf file
        //
        void SaveFile()
        {
            string buffer = "";

            buffer += header;

            foreach (Project project in allProjects)
            {
                foreach (string line in project.GetSaveData())
                {
                    buffer += line;
                }
            }

            WriteToFile(buffer, activeFilePath);
        }

        void WriteToFile(string buffer, string path)
        {
            FileStream fs = File.OpenWrite(path);
            fs.SetLength(0);
            byte[] data = new UTF8Encoding(true).GetBytes(buffer);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        //
        // Print Project to Text Box
        //
        private void PrintProject(Project project)
        {
            treeView1.Nodes.Clear();

            List<Session> sessions = project.GetSessions();
            for (int i = 0; i < sessions.Count; i++)
            {
                treeView1.Nodes.Add("Session " + (i + 1).ToString());
                treeView1.Nodes[i].Nodes.Add("Start Time");
                treeView1.Nodes[i].Nodes[0].Nodes.Add(sessions[i].GetStartTime());
                treeView1.Nodes[i].Nodes.Add("Stop Time");
                treeView1.Nodes[i].Nodes[1].Nodes.Add(sessions[i].GetStopTime());
                treeView1.Nodes[i].Nodes.Add("Total Session Time: " + sessions[i].GetTotalSessionTime());
            }
            treeView1.Nodes.Add("Total Logged Time: " + project.GetTotalTime());
        }

        //
        // Refresh list of projects
        //
        void RefreshProjectSelector()
        {
            projectSelector.Items.Clear();
            foreach(Project project in allProjects)
            {
                int index = projectSelector.Items.Add(project.projectName);
                if (activeProject != null)
                {
                    if (project == activeProject)
                        projectSelector.SelectedItem = projectSelector.Items[index];
                }
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void deleteProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteProject verifyWindow = new DeleteProject();
            verifyWindow.SetLabel(activeProject.projectName);

            DialogResult = verifyWindow.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                allProjects.Remove(activeProject);
                if (allProjects.Count > 0)
                {
                    activeProject = allProjects[0];
                    RefreshProjectSelector();
                }
                else
                    DisplayCreateProject();

                SaveFile();
            }
        }
    }
}
