using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace lab2_spell_corrector_
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Deserialize();
            checkBox1.Checked = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            Serialize();
        }

        

        
        static List<string> words = null;
        static List<string> answers = new List<string>();
        static List<string> temps_w = new List<string>();
        static List<string> temps_c = new List<string>();
        static Dictionary<string, int> wds = new Dictionary<string, int>();



        int mini, position = 0;
        int[,] pd = null;
        bool ok = false;
        char ch = '$';
        string signs = "$.!?";
        string selected = "";

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = "";
            string word = "";
            int lol = 0, n;
            if (richTextBox1.Text.Length > position) position = richTextBox1.Text.Length;
            else {
                position = richTextBox1.Text.Length + 1;
                textBox1.Text = "";
            }
            if (text == richTextBox1.Text) return;
            text = richTextBox1.Text;

            n = richTextBox1.SelectionStart;

            richTextBox1.SelectionColor = Color.Black;

            System.Diagnostics.Debug.WriteLine(richTextBox1.SelectionStart);


            if (n - 1 > 0 && text != "" && !Char.IsLetter(text[n - 1]) && !char.IsDigit(text[n-1]))
            {

                for (int i = n - 2; i >= 0; i--)
                {

                    if (i == 0) {
                        word = text.Substring(i, n - i - 1);

                        break;

                    }
                    if (!Char.IsLetter(text[i])  && !char.IsDigit(text[i])) {
                        word = text.Substring(i + 1, n - i - 2);

                        lol = i;
                        break;
                    }

                }
                if (word == "") return;
                text = text.Replace(word, word.ToLower());
                
                word =  word.ToLower();
                
                if (words.Contains(word) || char.IsNumber(word[0]))
                {
                    textBox1.Text = "";
                    //richTextBox1.Text = text;
                    richTextBox1.SelectionStart = n;
                    return;

                }
                else
                {

                    if (checkBox1.Checked)
                    {
                        c_Checked(text, word, n, lol);

                    }
                    else {

                        c_NotChecked(word, n);


                    }
                }

                
            }




        }

        public void c_Checked(string text, string word, int n, int lol) {
            string ans = FindTheMinEditDistance(word);
            
            for (int i = 0; i < signs.Length; i++)
            {
                if (lol - 1 > 0 && signs[i] == text[lol - 1]) ok = true;
            }
            if (ok && char.IsLetter(ans[0]) || lol == 0)
            {
                ans = FirstToUpperCase(ans);
                ok = false;
            }

            text = ReplaceWord(text, word, ans, n-word.Length-1);
            FindBackTrace(word, ans);
            if (text[text.Length - 1] != 32) text += " ";
            else if (lol == 0 || text[lol] == 32 && !char.IsLetter(text[lol - 1])) text += " ";
            richTextBox1.Text = text;
            if (text[n - word.Length + ans.Length - 1] != 32) richTextBox1.SelectionStart = n - word.Length + ans.Length + 1;
            else richTextBox1.SelectionStart = n - word.Length + ans.Length;
        }

        public void c_NotChecked(string word, int n) {
            
            temps_w.Add(word);
            temps_c.Add(FindTheMinEditDistance(word));
            richTextBox1.SelectionStart = n - word.Length - 1;
            richTextBox1.SelectionLength = word.Length;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionStart = n;
            richTextBox1.SelectionLength = 0;

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string FindTheMinEditDistance(string word)
        {
            string s_comp, ans = "";
            mini = 1000;
            int[,] dp = null;
            wds.Clear();
            for (int k = 0; k < words.Count; k++) {
                s_comp = words[k];
                dp = new int[word.Length + 1, s_comp.Length + 1];
                for (int i = 0; i <= word.Length; i++)
                {
                    dp[i, 0] = i;
                }
                for (int j = 0; j <= s_comp.Length; j++)
                {
                    dp[0, j] = j;
                }

                for (int i = 1; i <= word.Length; i++)
                {
                    for (int j = 1; j <= s_comp.Length; j++)
                    {
                        if (word[i - 1] == s_comp[j - 1])
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + 2);
                        }
                    }
                }
                wds.Add(s_comp, dp[word.Length, s_comp.Length]);
                
                if (dp[word.Length, s_comp.Length] <= mini)
                {
                    mini = dp[word.Length, s_comp.Length];
                    ans = s_comp;
                    pd = dp;
                    if (mini <= 5)
                    {
                        answers.Add(ans);
                    }
                }




            }

            
            return ans;
        }

        public void FindBackTrace(string word, string ans) {
            textBox1.Text = "";
            textBox1.Text += mini.ToString() + "\n";

            List<string> path = new List<string>();

            int temp = mini;
            int dpi = word.Length, dpj = ans.Length;
            while (true)
            {

                if (dpi != 0 && dpj != 0)
                {
                    if (pd[dpi - 1, dpj - 1] == temp && word[dpi - 1] == ans[dpj - 1])
                    {

                        dpi -= 1;
                        dpj -= 1;

                        path.Add("Do nothing with \"" + word[dpi] + "\"");



                    }
                    else
                    {
                        temp = Math.Min(Math.Min(pd[dpi - 1, dpj], pd[dpi, dpj - 1]), pd[dpi - 1, dpj - 1]);
                        if (temp == pd[dpi - 1, dpj])
                        {
                            dpi -= 1;

                            path.Add("Delete the \"" + word[dpi] + "\"");
                        }
                        else if (temp == pd[dpi, dpj - 1])
                        {
                            dpj -= 1;

                            path.Add("Insert the \"" + ans[dpj] + "\"");
                        }
                        else
                        {
                            dpi -= 1;
                            dpj -= 1;

                            path.Add("Substitute the \"" + word[dpi] + "\" with \"" + ans[dpj] + "\"");
                        }
                    }
                }
                else if (dpi == 0 && dpj == 0) break;
                else if (dpi == 0)
                {
                    dpj -= 1;

                    path.Add("Insert the \"" + ans[dpj] + "\"");
                }
                else if (dpj == 0)
                {
                    dpi -= 1;

                    path.Add("Delete the \"" + word[dpi] + "\"");
                }




            }

            path.Reverse();
            for (int i = 0; i < path.Count; i++)
            {
                textBox1.Text += "\r\n" + path[i];



            }

        }

        public string FirstToUpperCase(string s) {
            char c = char.ToUpper(s[0]);
            string ans = "";
            ans += c;
            for (int j = 1; j < s.Length; j++) {
                ans += s[j];
            }

            return ans;
        }

        public string ReplaceWord(string text, string word, string ans, int n) {
            int i = n;
            string s = text.Remove(n, word.Length);

            string k = s.Insert(n, ans);
            return k;
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Visible = false;
                button2.Visible = false;
                string text = richTextBox1.Text;
                if (temps_c.Count > 0) {
                    for (int i = 0; i < temps_c.Count; i++) {
                        text = text.Replace(temps_w[i], temps_c[i]);
                        System.Diagnostics.Debug.Write(temps_w[i]);
                    }
                }
                
                richTextBox1.Text = text;
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionLength = 0;
                temps_c.Clear();
                temps_w.Clear();
            }
            else {
                button2.Visible = true;
                button1.Visible = true;
                textBox1.Text = "";
                
            }

        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            richTextBox1.AutoWordSelection = true;
            string word = richTextBox1.SelectedText;
            selected = word;
            if (word.Contains(" ")) word.Remove(word.Length-1, 1);
            contextMenuStrip1.Items.Clear();
            int n = richTextBox1.SelectionStart + word.Length;
            int lol = richTextBox1.SelectionStart;
            string text = richTextBox1.Text;
            answers.Clear();
            string lg = FindTheMinEditDistance(word);
            if (answers.Count > 0) {
                for (int i = 0; i < answers.Count; i++)
                {
                    contextMenuStrip1.Items.Add(answers[i]);
                }
            }
            if (contextMenuStrip1.Items.Count == 0) contextMenuStrip1.Items.Add(lg);

            contextMenuStrip1.Show(Cursor.Position);
            
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clicked = e.ClickedItem.Text;

            contextMenuStrip1.Visible = true;
            string text = richTextBox1.Text;
            int n = richTextBox1.SelectionStart;
            
            //char ch = text[n + richTextBox1.SelectionLength];
            //clicked += ch;
            string word = richTextBox1.SelectedText.Remove(richTextBox1.SelectionLength - 1, 1);
            
            text = ReplaceWord(text, word, clicked, n);
            richTextBox1.Text = text;
            richTextBox1.Select(n, clicked.Length);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionStart = n + clicked.Length;
            richTextBox1.SelectionLength = 0;
            
            System.Diagnostics.Debug.Write( clicked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            words.Add(selected);

            
            //System.Diagnostics.Debug.Write(richTextBox1.SelectedText);
            richTextBox1.SelectionColor = Color.Black;
            selected = "";
            words.Sort();
        }

        #region serdeser
        static void Deserialize()
        {
            
            FileStream fs = new FileStream("serwords.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

            
                words = (List<string>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                System.Diagnostics.Debug.Write("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Serialize();
            this.Close();
        }

        

        static void Serialize()
        {
            
            
            FileStream fs = new FileStream("serwords.dat", FileMode.Create);

            
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, words);
            }
            catch (SerializationException e)
            {
                
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        #endregion

    }
}
