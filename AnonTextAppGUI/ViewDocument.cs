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

namespace AnonTextAppGUI
{
    public partial class ViewDocument : Form
    {
        public ViewDocument()
        {
            InitializeComponent();
            TextDocument td = new TextDocument("1", "2", "3");
            textBox1.Text = td.Title;
            textBox2.Text = td.Kategori;
            //richTextBox1 = td.Contents;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;

        }
    }
}
