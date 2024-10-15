namespace HexReader.UI.MainForm
{
    public class MainFormModel
    {
        public event Action<string> OnFilePathUpdate = delegate { };
        public event Action<string> OnDisplayStringUpdate = delegate { };

        // Temp Values
        public string FilePath { get; private set; }
        public string DisplayString { get; private set; }

        public MainFormModel(string filePath, string displayPath)
        {
            FilePath = filePath;
            DisplayString = displayPath;
        }

        public void UpdateFilePath(string path)
        {
            FilePath = path;
            OnFilePathUpdate?.Invoke(FilePath);
        }

        public void UpdateDisplayString(string displayString)
        {
            DisplayString = displayString;
            OnDisplayStringUpdate?.Invoke(DisplayString);
        }
    }
}
