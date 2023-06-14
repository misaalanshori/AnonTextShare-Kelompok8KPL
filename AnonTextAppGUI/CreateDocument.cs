﻿using AnonTextAppConsoleUI;
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

                // Set title and contents
                AnonTextShareAPI.TextDocument document = new AnonTextShareAPI.TextDocument();
                document.title = textBox1.Text;
                document.contents = richTextBox1.Text;

                // Set document to Client API
                CreateDocumentController controller = new CreateDocumentController();
                controller.ClientAPISetter();

                MessageBox.Show("Submited");
                // Reset String
                textBox1.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                button1.BackColor = Color.White;
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Creating Runtime config for max title and text
            RuntimeConfig rc = new RuntimeConfig(32, 128);

            // Make a word cap in textBox
            string text = textBox1.Text;
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); // Split text to words
            if (words.Length > rc.MaxTitleChars)
            {
                // Get the first 32 words and join them back into a string
                string limitedText = string.Join(" ", words.Take(rc.MaxTitleChars));
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
            // Creating Runtime config for max title and text
            RuntimeConfig rc = new RuntimeConfig(32, 128);

            // Make a word cap in richTextBox
            string text = richTextBox1.Text;
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); // Split text to words
            if (words.Length > rc.MaxTextChars)
            {
                // Get the first 128 words and join them back into a string
                string limitedText = string.Join(" ", words.Take(rc.MaxTextChars));
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        public string title { get { return textBox1.Text; } }
        public string description { get { return richTextBox1.Text; } }
        public string password { get { return textBox2.Text; } }
    }
}
