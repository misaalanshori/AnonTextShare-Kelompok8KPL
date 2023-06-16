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

        private async void button1_Click(object sender, EventArgs e)
        {
            // Get input values
            string title = textBox1.Text.Trim();
            string text = richTextBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string kategori = textBox3.Text.Trim();

            // Check if the required fields are empty
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(kategori))
            {
                // Show dialog box status if not filled
                MessageBox.Show("Fill the document first!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check password length if provided
            if (!string.IsNullOrEmpty(password) && password.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters long!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set optional password
            string isiPassword = string.IsNullOrEmpty(password) ? null : password;

            // Set document to Client API
            ClientAPI.createDocument(title, text, kategori, isiPassword);

            // Set button color to indicate submission
            button1.BackColor = Color.Green;

            // Copy ID this document
            string ID = await ClientAPI.createDocument(title, text, kategori, isiPassword);

            // Show dialog box status
            MessageBox.Show("Published", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Docs ID: " + ID, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(ID);

            // Reset form
            textBox1.Clear();
            richTextBox1.Clear();
            textBox2.Clear();
            checkBox1.Checked = false;
            textBox3.Clear();

            // Reset button color
            button1.BackColor = Color.White;

            this.Close();
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
            // Go back to main menu through exit window
            IController.s_ControllerGUI.CreateDocumentToMenu();
            e.Cancel = true;
        }

        public string title { get { return textBox1.Text; } }
        public string description { get { return richTextBox1.Text; } }
        public string password { get { return textBox2.Text; } }
    }
}
