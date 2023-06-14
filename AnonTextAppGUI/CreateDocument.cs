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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnonTextAppGUI
{
    public partial class CreateDocument : Form
    {
        public CreateDocument()
        {
            InitializeComponent();
            // Button turned gray if there is nothing
            while (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.BackColor = Color.Gray;
            };
            while (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.BackColor = Color.White;
            };
        }

        private void CreateDocument_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button1.BackColor = Color.White;

            TextDocument document = new TextDocument();
            // Set title and contents to API
            document.title = textBox1.Text;
            document.contents = richTextBox1.Text;
            MessageBox.Show("Submited");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 32)
            {
                // Get the first 32 words and join them back into a string
                string limitedText = string.Join(" ", words.Take(100));
                textBox1.Text = limitedText;

                // Set the cursor position at the end of the text box
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 128)
            {
                // Get the first 128 words and join them back into a string
                string limitedText = string.Join(" ", words.Take(100));
                richTextBox1.Text = limitedText;

                // Set the cursor position at the end of the text box
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionLength = 0;
            }
        }
    }
}
