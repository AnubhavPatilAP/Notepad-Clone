using System.IO;
using System.Net.Mail;

namespace Notepad
{
    public partial class Form1 : Form
    {
        string filepath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filepath = "";
            richTextBox1.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader streamReader = new StreamReader(ofd.FileName))
                    {
                        filepath = ofd.FileName;
                        Task<string> text = streamReader.ReadToEndAsync();
                        richTextBox1.Text = text.Result;
                    }
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                using(SaveFileDialog sfd =  new SaveFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true)
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using(StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLineAsync(richTextBox1.Text); 
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    sw.WriteLineAsync(richTextBox1.Text);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLineAsync(richTextBox1.Text);
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}