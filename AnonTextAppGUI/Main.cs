namespace AnonTextAppGUI
{
    public partial class Main : Form, IController
    {
        public Main()
        {
            InitializeComponent();
        }

        public void SetController(ControllerGUI controllerGUI)
        {
            IController.s_ControllerGUI = controllerGUI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IController.s_ControllerGUI.MenuToCreateDocument();
        }
    }
}