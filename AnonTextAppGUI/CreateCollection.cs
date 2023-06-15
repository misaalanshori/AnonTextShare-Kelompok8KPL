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
                MessageBox.Show("An Error Occured", "Collection title is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("An Error Occured", "Collection contents is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Debug.WriteLine("Submitting");
                List<string> listOfCodes = new();
                string[] codes = textBox3.Text.Split('\n');
                foreach (string code in codes)
                {
                    listOfCodes.Add(code.Trim());
                }
                Debug.WriteLine("Submittedp2");
                string collectionCode = await ClientAPI.createCollection(title, password, listOfCodes);
                Debug.WriteLine("Submitted");
                textBox4.Text = collectionCode;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox4.Text);
        }
    }
}
