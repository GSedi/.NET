using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("wedwedwedwedwedwed");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fdb = new FolderBrowserDialog();

            fdb.Description = "Folder Browser Dialog Control in C#";

            fdb.RootFolder = Environment.SpecialFolder.Desktop;

            fdb.ShowDialog();

            if (fdb.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog1.SelectedPath);
            }
            


        }

    }
}
