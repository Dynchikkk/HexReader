using HexReader.UI.MainForm;

namespace HexReader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            MainFormModel model = new MainFormModel("", "");
            MainFormView view = new MainFormView(model);
            MainFormController controller = new MainFormController(model, view);

            Application.Run(view);
        }
    }
}