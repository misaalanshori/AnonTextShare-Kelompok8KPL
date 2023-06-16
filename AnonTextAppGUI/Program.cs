namespace AnonTextAppGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ControllerGUI controllerGUI = new ControllerGUI();
            controllerGUI.Init();
        }
    }
}