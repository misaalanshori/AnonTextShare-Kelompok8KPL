using AnonTextAppConsoleUI;
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
    public partial class CreateDocument : Form, IController
    {
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
            textBox3.Text = string.Empty;
        }

        private void CreateDocument_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Variable
            string title = textBox1.Text.Trim();
            string text = richTextBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string kategori = textBox3.Text.Trim();
            string isiPassword = "";

            // Button turned red if there is nothing
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(text))
            {
                button1.BackColor = Color.Red;

                // Show dialog box status
                MessageBox.Show("Fill the document first!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);

                button1.BackColor = Color.Gray;
            }
            else if (!string.IsNullOrEmpty(password))
            {
                if (password.Length >= 5)
                {
                    isiPassword = password;
                }
                else
                {
                    MessageBox.Show("Password must be 5 characters or more!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(text))
            {
                button1.BackColor = Color.Green;

                // Set Password as null if not filled
                isiPassword = null;

                // Set category
                string isiKategori = kategori;

                // Set document to Client API
                ClientAPI.AddContents(title, text, isiPassword);

                // Show dialog box status
                MessageBox.Show("Submited", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset String
                title = string.Empty;
                text = string.Empty;
                password = string.Empty;
                checkBox1.Checked = false;
                kategori = string.Empty;

                button1.BackColor = Color.White;
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Changing word counter label
            int wordCount = textBox1.TextLength;
            label4.Text = "" + wordCount + "/" + 32;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Changing word counter label
            int wordCount = richTextBox1.TextLength;
            label5.Text = "" + wordCount + "/" + 128;
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
            if (textBox1.TextLength >= 32 && e.KeyChar != '\b')
            {
                // Cancel the input by marking it as handled
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the length of the text exceeds the maximum length
            if (richTextBox1.TextLength >= 128 && e.KeyChar != '\b')
            {
                // Cancel the input by marking it as handled
                e.Handled = true;
            }
        }

        private void CreateDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            IController.s_ControllerGUI.CreateDocumentToMenu();
            e.Cancel = true;
        }

        public string title { get { return textBox1.Text; } }
        public string description { get { return richTextBox1.Text; } }
        public string password { get { return textBox2.Text; } }
    }
}
