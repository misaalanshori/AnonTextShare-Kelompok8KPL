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
    public partial class CreateDocument : Form, IController
    {
        public CreateDocument()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IController.s_ControllerGUI.CreateDocumentToMenu();
        }
    }
}
