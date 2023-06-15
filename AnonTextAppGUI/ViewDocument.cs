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
        public ViewDocument()
        {
            InitializeComponent();
        }

        public void SetDocument(string id, string password)
        {
            _idDocument = id;
            _password = password;
        }
    }
}
