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
    public partial class ViewCollection : Form
    {

        private string _id;
        private string _password;
        private TextCollection _collection;
        public ViewCollection(string IdCollection, string PasswordCollection)
        {
            _id = IdCollection;
            _password = PasswordCollection;
            _collection = ClientAPI.getCollection(IdCollection).Result;
            InitializeComponent();
        }

        public void RefreshData()
        {
            _collection = ClientAPI.getCollection(_id).Result;
            this.textBox2.Text = _collection.title;
            this.label5.Text = _collection.id;
            
            for (int i = 0; i < _collection.contents.Count; i++)
            {
                this.textBox3.Text += _collection.id + " - " + _collection.title + "\n";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ViewCollection_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
