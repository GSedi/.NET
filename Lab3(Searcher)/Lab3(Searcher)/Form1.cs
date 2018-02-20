using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace Lab3_Searcher_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // richTextBox1.GotFocus += new EventHandler(RemoveText);

            richTextBox1.Enabled = true;
            if (checkBox1.Checked) {
                
            }
           

        }
        List<FileSystemInfo> searchedFsis = new List<FileSystemInfo>();
        
        public void RemoveText(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
         

        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && richTextBox1.Text != "Find files")
            {
                button1.BackgroundImage = Properties.Resources.if_Delete_1493279;
                button1.FlatAppearance.MouseOverBackColor = Color.Aqua;

            }
            else {
                button1.BackgroundImage = Properties.Resources.if_icon_111_search_314689__1_;
                button1.FlatAppearance.MouseOverBackColor = Color.White;
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                richTextBox1.Text = "Find files";
            richTextBox1.SelectionStart = 0;
           
            
        }
        void Search(string s, DirectoryInfo dir)
        {
            string pattern = s + @"\.(jpg|JPG|gif|GIF|doc|DOC|pdf|PDF|txt|TXT|xml|XML)";
            try
            {
                FileSystemInfo[] fsi = dir.GetFileSystemInfos();
                foreach (FileSystemInfo fs in fsi)
                {
                    if (fs is FileInfo)
                    {
                        if (Regex.IsMatch(fs.Name, s)) searchedFsis.Add(fs);
                    }
                    else if (fs is DirectoryInfo) Search(s, fs as DirectoryInfo);
                }
            }
            catch (Exception e) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }


        /* private void label1_Click(object sender, EventArgs e)
         {
             string s = richTextBox1.Text;

             string pattern = s + @"\.(jpg|JPG|gif|GIF|doc|DOC|pdf|PDF|txt|TXT|xml|XML)";

             //System.Diagnostics.Debug.Write(pattern);

              DirectoryInfo dir = new DirectoryInfo(@"D:\");
             //System.Diagnostics.Debug.Write(dir.FullName);




          // listBox1.DataSource = searchedFsis;



         }
         */
    }
}
