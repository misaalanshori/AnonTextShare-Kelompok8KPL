using AnonTextAppConsoleUI;
using Microsoft.VisualBasic;
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
        private string _idCollection;
        private string _password;
        public ViewCollection()
        {
            InitializeComponent();
        }

        public void SetCollection(string id, string password)
        {
            _idCollection = id;
            _password = password;
        }
    }
}
