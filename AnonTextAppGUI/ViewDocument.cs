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
    public partial class ViewDocument : Form, IController
    {
        private string _idDocument;
        private string _password;
        private TextDocument _document;
        public ViewDocument()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void SetDocument(string id, string password, TextDocument document)
        {
            _idDocument = id;
            _password = password;
            _document = document;
        }

        private void ViewDocument_Load(object sender, EventArgs e)
        {
            textBox1.Text = _document.Title;
            textBox2.Text = _document.Kategori;
            richTextBox1.Rtf = _document.Contents;
            foreach (var comment in _document.Comments)
            {
                listBox1.Items.Add(comment);
            }
        }
    }
}
