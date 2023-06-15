using AnonTextAppConsoleUI;
using AnonTextShareAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnonTextAppGUI
{
    public partial class CreateDocument : Form
    {
        // Creating Runtime config for max title and text
        RuntimeConfig rc = new RuntimeConfig(32, 128);

        public CreateDocument()
        {
            InitializeComponent();
            button1.BackColor = Color.Gray;
            checkBox1.Checked = false;

            // Reset String
            textBox1.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            checkBox1.Checked = false;
        }

        private void CreateDocument_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Button turned red if there is nothing
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.BackColor = Color.Red;

                // Show dialog box status
                MessageBox.Show("Fill the document first!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);

                button1.BackColor = Color.Gray;
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.BackColor = Color.Green;

                // Set document to Client API
                ClientAPI.AddContents(textBox1.Text,richTextBox1.Text,textBox2.Text);

                // Show dialog box status
                MessageBox.Show("Submited", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset String
                textBox1.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                checkBox1.Checked = false;

                button1.BackColor = Color.White;
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Changing word counter label
            int wordCount = textBox1.TextLength;
            label4.Text = "" + wordCount + "/" + rc.MaxTitleChars;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Changing word counter label
            int wordCount = richTextBox1.TextLength;
            label5.Text = "" + wordCount + "/" + rc.MaxTextChars;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the length of the text exceeds the maximum length
            if (textBox1.TextLength >= rc.MaxTitleChars && e.KeyChar != '\b')
            {
                // Cancel the input by marking it as handled
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the length of the text exceeds the maximum length
            if (richTextBox1.TextLength >= rc.MaxTextChars && e.KeyChar != '\b')
            {
                // Cancel the input by marking it as handled
                e.Handled = true;
            }
        }

        public string title { get { return textBox1.Text; } }
        public string description { get { return richTextBox1.Text; } }
        public string password { get { return textBox2.Text; } }
    }
}
