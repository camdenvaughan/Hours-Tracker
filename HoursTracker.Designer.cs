
namespace Hours_Tracker
{
    partial class HoursTracker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.projectSelector = new System.Windows.Forms.ComboBox();
            this.clockInButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockOutButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.projectTitleLabel = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.deleteProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // projectSelector
            // 
            this.projectSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectSelector.FormattingEnabled = true;
            this.projectSelector.Location = new System.Drawing.Point(369, 64);
            this.projectSelector.Name = "projectSelector";
            this.projectSelector.Size = new System.Drawing.Size(219, 23);
            this.projectSelector.TabIndex = 3;
            this.projectSelector.SelectedIndexChanged += new System.EventHandler(this.ProjectSelector_SelectedIndexChanged);
            // 
            // clockInButton
            // 
            this.clockInButton.Location = new System.Drawing.Point(369, 300);
            this.clockInButton.Name = "clockInButton";
            this.clockInButton.Size = new System.Drawing.Size(219, 30);
            this.clockInButton.TabIndex = 5;
            this.clockInButton.Text = "Clock In";
            this.clockInButton.UseVisualStyleBackColor = true;
            this.clockInButton.Click += new System.EventHandler(this.ClockIn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.newFileToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem1,
            this.renameProjectToolStripMenuItem,
            this.deleteProjectToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newProjectToolStripMenuItem1
            // 
            this.newProjectToolStripMenuItem1.Name = "newProjectToolStripMenuItem1";
            this.newProjectToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.newProjectToolStripMenuItem1.Text = "New Project";
            this.newProjectToolStripMenuItem1.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // renameProjectToolStripMenuItem
            // 
            this.renameProjectToolStripMenuItem.Name = "renameProjectToolStripMenuItem";
            this.renameProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameProjectToolStripMenuItem.Text = "Rename Project";
            this.renameProjectToolStripMenuItem.Click += new System.EventHandler(this.renameProjectToolStripMenuItem_Click);
            // 
            // clockOutButton
            // 
            this.clockOutButton.Location = new System.Drawing.Point(369, 336);
            this.clockOutButton.Name = "clockOutButton";
            this.clockOutButton.Size = new System.Drawing.Size(219, 30);
            this.clockOutButton.TabIndex = 9;
            this.clockOutButton.Text = "Clock Out";
            this.clockOutButton.UseVisualStyleBackColor = true;
            this.clockOutButton.Click += new System.EventHandler(this.ClockOut_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(12, 373);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(64, 15);
            this.headerLabel.TabIndex = 10;
            this.headerLabel.Text = "Created By";
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(369, 93);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(219, 30);
            this.createProjectButton.TabIndex = 11;
            this.createProjectButton.Text = "Create Project";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.CreateProject_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 64);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(339, 302);
            this.treeView1.TabIndex = 12;
            // 
            // projectTitleLabel
            // 
            this.projectTitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.projectTitleLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.projectTitleLabel.Location = new System.Drawing.Point(13, 27);
            this.projectTitleLabel.Name = "projectTitleLabel";
            this.projectTitleLabel.Size = new System.Drawing.Size(575, 34);
            this.projectTitleLabel.TabIndex = 13;
            this.projectTitleLabel.Text = "Project Title";
            this.projectTitleLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(369, 229);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(219, 30);
            this.openFileButton.TabIndex = 14;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(369, 265);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(219, 29);
            this.createFileButton.TabIndex = 15;
            this.createFileButton.Text = "Create File";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new System.EventHandler(this.CreateFileButton_Click);
            // 
            // deleteProjectToolStripMenuItem
            // 
            this.deleteProjectToolStripMenuItem.Name = "deleteProjectToolStripMenuItem";
            this.deleteProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteProjectToolStripMenuItem.Text = "Delete Project";
            this.deleteProjectToolStripMenuItem.Click += new System.EventHandler(this.deleteProjectToolStripMenuItem_Click);
            // 
            // HoursTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 398);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.projectTitleLabel);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.clockOutButton);
            this.Controls.Add(this.clockInButton);
            this.Controls.Add(this.projectSelector);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HoursTracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hours Tracker";
            this.Load += new System.EventHandler(this.HoursTracker_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox projectSelector;
        private System.Windows.Forms.Button clockInButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem1;
        private System.Windows.Forms.Button clockOutButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button createProjectButton;
        private System.Windows.Forms.ToolStripMenuItem renameProjectToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label projectTitleLabel;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.ToolStripMenuItem deleteProjectToolStripMenuItem;
    }
}

