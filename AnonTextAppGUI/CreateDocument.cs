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
    public partial class CreateDocument : Form
    {
        public CreateDocument()
        {
            InitializeComponent();
            button1.BackColor = Color.Gray;
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
                MessageBox.Show("Fill the document first!");
                button1.BackColor = Color.Gray;
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.BackColor = Color.Green;

                TextDocument document = new TextDocument();
                // Set title and contents to API
                document.title = textBox1.Text;
                document.contents = richTextBox1.Text;
                MessageBox.Show("Submited");
                // Reset String
                textBox1.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                button1.BackColor = Color.White;
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); // Split text to words
            if (words.Length > 32)
            {
                // Get the first 32 words and join them back into a string
                string limitedText = string.Join(" ", words.Take(32));
                textBox1.Text = limitedText;

                // Set the cursor position at the end of the text box
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
            // Changing word counter label
            string text2 = textBox1.Text.Trim();
            int wordCount = 0;
            if (!string.IsNullOrEmpty(text2))
            {
                string[] words2 = text2.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); // Split text to words
                wordCount = words2.Length;
            }
            label4.Text = "" + wordCount + "/32";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); // Split text to words
            if (words.Length > 128)
            {
                // Get the first 128 words and join them back into a string
                string limitedText = string.Join(" ", words.Take(128));
                richTextBox1.Text = limitedText;

                // Set the cursor position at the end of the text box
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionLength = 0;
            }

            // Changing word counter label
            string text2 = richTextBox1.Text.Trim();
            int wordCount = 0;
            if (!string.IsNullOrEmpty(text2))
            {
                string[] words2 = text2.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); // Split text to words
                wordCount = words2.Length;
            }
            label5.Text = "" + wordCount + "/128";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
