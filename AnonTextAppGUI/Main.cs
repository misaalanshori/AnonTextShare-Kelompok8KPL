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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                IController.s_ControllerGUI.MenuToViewDocument(textBox1.Text, textBox2.Text);
            }
            else if (radioButton2.Checked)
            {
                IController.s_ControllerGUI.MenuToViewCollection(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("Please select the type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                IController.s_ControllerGUI.MenuToCreateDocument();
            }
            else if (radioButton2.Checked)
            {
                IController.s_ControllerGUI.MenuToCreateCollection();
            }
            else
            {
                MessageBox.Show("Please select the type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}