using AnonTextAppConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonTextAppGUI
{
    internal class CreateDocumentController
    {
        public void showCreateDocument() {
            CreateDocument cd = new CreateDocument();
            cd.ShowDialog();
        }
    }
}
