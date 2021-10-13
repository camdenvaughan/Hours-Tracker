using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hours_Tracker
{
    public partial class TextDialogBox : Form
    {
        public string newProjectName { get; private set; }

        private string[] activeProjectNames;

        private bool canOverwrite = true;

        public TextDialogBox()
        {
            InitializeComponent();
            newProjectName = textBox1.Text;
        }

        public void SetToRename()
        {
            canOverwrite = false;
            button1.Text = "Rename";
        }

        public void SetActiveNames(string[] activeNames)
        {
            activeProjectNames = activeNames;

            foreach (string name in activeProjectNames)
            {
                if (name == newProjectName)
                {
                    ChangeNameToAvoidOverwrite();
                    break;
                }
            }
           
        }

        private void CreateProject_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            foreach (string name in activeProjectNames)
            {
                if (name == newProjectName && canOverwrite)
                {
                    Overwrite overwriteWindow = new Overwrite();
                    overwriteWindow.SetLabel(newProjectName);

                    DialogResult = overwriteWindow.ShowDialog();
                    if (DialogResult == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.Ignore;
                        break;
                    }
                    else if (DialogResult == DialogResult.Cancel)
                    {
                        textBox1.Focus();
                        return;
                    }
                }
                else if (name == newProjectName && !canOverwrite)
                {
                    textBox1.Focus();
                    label1.Visible = true;
                    return;
                }
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == string.Empty)
            {
                textBox1.Text = newProjectName;
            }

            newProjectName = textBox1.Text;
        }

        private void ChangeNameToAvoidOverwrite()
        {
            bool nameIsSame = true;
            string tempName = "";
            int i = 1;
            while (nameIsSame)
            {
                tempName = newProjectName + i++.ToString();

                foreach (string name in activeProjectNames)
                {
                    nameIsSame = false;
                    if (name == tempName)
                    {
                        nameIsSame = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            newProjectName = tempName;
            textBox1.Text = newProjectName;
        }

        private void TextDialogBox_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
