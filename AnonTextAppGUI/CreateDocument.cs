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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnonTextAppGUI
{
    public partial class CreateDocument : Form
    {
        public CreateDocument()
        {
            InitializeComponent();
            while (string.IsNullOrWhiteSpace(textBox1.Text)&& string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.BackColor = Color.Gray;
            };
            while(!string.IsNullOrWhiteSpace(textBox1.Text)&& !string.IsNullOrWhiteSpace(richTextBox1.Text))
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
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
