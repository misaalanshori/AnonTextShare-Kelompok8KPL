using AnonTextAppConsoleUI;
using System;
using System.Windows.Forms;

namespace AnonTextAppGUI
{
    public class ControllerGUI
    {
        private Main _main;
        private CreateDocument _createDocument;
        private CreateCollection _createCollection;
        private ViewDocument _viewDocument;
        private ViewCollection _viewCollection;

        public ControllerGUI()
        {
            _main = new Main();
            _createDocument = new CreateDocument();
            _createCollection = new CreateCollection();
            _viewDocument = new ViewDocument();
            _viewCollection = new ViewCollection();
        }

        public void Init()
        {
            _main.SetController(this);
            Application.Run(_main);
        }

        public void MenuToCreateDocument()
        {
            _createDocument.Show();
            _main.Hide();
        }

        public void MenuToCreateCollection()
        {
            _createCollection.Show();
            _main.Hide();
        }

        public void CreateDocumentToMenu()
        {
            _main.Show();
            _createDocument.Hide();
        }

        public void CreateCollectionToMenu()
        {
            _main.Show();
            _createCollection.Hide();
        }

        public void MenuToViewDocument(string id, string password)
        {
            _viewDocument.SetDocument(id, password);
            _viewDocument.Show();
            _main.Hide();
        }

        public void MenuToViewCollection(string id, string password)
        {
            _viewCollection.SetCollection(id, password);
            _viewCollection.Show();
            _main.Hide();
        }

        public void ViewDocumentToMenu()
        {
            _main.Show();
            _viewDocument.Hide();
        }

        public void ViewCollectionToMenu()
        {
            _main.Show();
            _viewCollection.Hide();
        }
    }
}
