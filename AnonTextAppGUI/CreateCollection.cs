using AnonTextAppConsoleUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonTextAppGUI
{
    public partial class CreateCollection : Form, IController
    {
        public CreateCollection()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Collection title is empty", "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Collection contents is empty", "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string title = textBox1.Text.Trim();
                string? password = textBox2.Text.Trim();
                if (password.Equals(""))
                {
                    password = null;
                }
                List<string> listOfCodes = new();
                string[] codes = textBox3.Text.Split('\n');
                foreach (string code in codes)
                {
                    listOfCodes.Add(code.Trim());
                }
                string collectionCode = await ClientAPI.CreateCollection(title, password, listOfCodes);
                textBox4.Text = collectionCode;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox4.Text);
        }

        private void CreateCollection_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox2.PasswordChar = '*';
            IController.s_ControllerGUI.CreateCollectionToMenu();
            e.Cancel = true;
        }

        private void CreateCollection_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox2.PasswordChar.Equals('*'))
            {
                textBox2.PasswordChar = '*';
                button3.Text = "Show";
            } else
            {
                textBox2.PasswordChar = '\0';
                button3.Text = "Hide";
            }
        }
    }
}
