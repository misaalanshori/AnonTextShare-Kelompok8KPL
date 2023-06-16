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
    public partial class ViewCollection : Form, IController
    {

        private string _id;
        private string _password;
        private TextCollection _collection;
        public ViewCollection()
        {
            InitializeComponent();
        }

        public void SetCollection(string id, string password)
        {
            _id = id;
            _password = password;
        }

        public async void RefreshData()
        {
            _collection = await ClientAPI.GetCollection(_id);
            this.textBox2.Text = _collection.Title;
            this.label5.Text = _collection.Id;

            for (int i = 0; i < _collection.Contents.Count; i++)
            {
                string text = $"{_collection.Contents[i].Id} - {_collection.Contents[i].Title}";
                this.textBox3.Text += text + Environment.NewLine;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ViewCollection_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        private async void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                await ClientAPI.ChangeCollectionsTitle(_id, _password, textBox2.Text);
            }
            RefreshData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                await ClientAPI.AddContents(_id, _password, textBox4.Text);
            }
            RefreshData();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                await ClientAPI.DeleteContent(_id, _password, textBox4.Text);
            }
            RefreshData();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewCollection_FormClosing(object sender, FormClosingEventArgs e)
        {
            IController.s_ControllerGUI.ViewCollectionToMenu();
            e.Cancel = true;
        }
    }
}
