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
        public void ClientAPISetter() {
            CreateDocument createDocument = new CreateDocument();
            string titleText = createDocument.title;
            string descText = createDocument.description;
            string passText = createDocument.password;
            ClientAPI.AddContents(titleText, descText, passText);
        }

        public void showCreateDocument() {
            CreateDocument cd = new CreateDocument();
            cd.ShowDialog();
        }
    }
}
