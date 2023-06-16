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
            button4.Visible = false;
            button6.Visible = false;
            textBox1.Text = _document.Title;
            if (_document.IsExplicit)
            {
                label5.Text = "NSFW";
            }
            else
            {
                label5.Text = "SFW";
            }
            label6.Text = $"Total Report: {_document.ReportCount}";
            label7.Text = $"Report Status: {_document.ReportState}";
            textBox1.Enabled = false;
            textBox2.Text = _document.Kategori;
            textBox2.Enabled = false;
            richTextBox1.Text = _document.Contents;
            richTextBox1.Enabled = false;
            foreach (var comment in _document.Comments)
            {
                listBox1.Items.Add(comment);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            await ClientAPI.LockDocument(_idDocument, _password);
            button4.Visible = true;
            button6.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            richTextBox1.Enabled = true;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await ClientAPI.ChangeTitle(_idDocument, _password, textBox1.Text);
            await ClientAPI.UpdateCategory(_idDocument, _password, textBox2.Text);
            await ClientAPI.UpdateContent(_idDocument, _password, richTextBox1.Text);
            await ClientAPI.UnblockDocument(_idDocument, _password);
            await ClientAPI.UnlockDocument(_idDocument, _password);
            button4.Visible = false;
            button6.Visible = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await ClientAPI.ReportDocument(_idDocument);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await ClientAPI.CreateComment(_idDocument, textBox4.Text);
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await ClientAPI.DeleteDocument(_idDocument, _password);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IController.s_ControllerGUI.CreateDocumentToMenu();
        }
    }
}
