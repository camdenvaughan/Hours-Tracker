using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hours_Tracker
{
    public partial class Overwrite : Form
    {
        public Overwrite()
        {
            InitializeComponent();
        }

        public void SetLabel(string name)
        {
            string label = "Would you like to Overwrite \"" + name + "\"?";
            label1.Text = label;
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


    }
}
