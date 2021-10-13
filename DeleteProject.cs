using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hours_Tracker
{
    public partial class DeleteProject : Form
    {
        public DeleteProject()
        {
            InitializeComponent();
        }
        public void SetLabel(string name)
        {
            string labelText = "Are you sure you want to delete \"" + name + "\"?";
            label1.Text = labelText;
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DeleteProject_Load(object sender, EventArgs e)
        {
            
        }
    }
}
