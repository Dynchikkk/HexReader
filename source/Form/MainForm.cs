using HexReader.Script.CustomStream;

namespace HexReader
{
    public partial class MainForm : Form
    {
        private long _currentOffset = 0;
        private string _filePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void PathTextBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FilePathTextBox.Text = fileDialog.FileName;
            FilePathTextBox.TextAlign = HorizontalAlignment.Left;
            UpdateReadButton(false);
        }

        private void ReadHexButton_Click(object sender, EventArgs e)
        {
            if (!IsFilePathValid(FilePathTextBox.Text))
            {
                return;
            }
            _filePath = FilePathTextBox.Text;
            UpdateReadButton(true);
            using (HexStream hexStream = new HexStream(_filePath, ChunkSize, BytesPerLine))
            {
                HexStreamTextBox.Clear();
                HexStreamTextBox.Text = hexStream.ReadChunk();
                _currentOffset = hexStream.Offset;
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (!IsFilePathValid(_filePath))
            {
                return;
            }
            using (HexStream hexStream = new HexStream(_filePath, ChunkSize, BytesPerLine))
            {
                hexStream.Shift(_currentOffset);
                HexStreamTextBox.Clear();
                HexStreamTextBox.Text = hexStream.ReadChunk();
                _currentOffset = hexStream.Offset;
            }
        }

        private void PrevPageButton_Click(object sender, EventArgs e)
        {
            if (!IsFilePathValid(_filePath))
            {
                return;
            }
            using (HexStream hexStream = new HexStream(_filePath, ChunkSize, BytesPerLine))
            {
                _currentOffset = Math.Max(_currentOffset - ChunkSize * 2, 0);
                hexStream.Shift(_currentOffset);
                HexStreamTextBox.Clear();
                HexStreamTextBox.Text = hexStream.ReadChunk();
                _currentOffset = hexStream.Offset;
            }
        }

        private bool IsFilePathValid(string filePath)
        {
            return filePath.Contains('\\') && !string.IsNullOrEmpty(filePath);
        }

        private void UpdateReadButton(bool isReading)
        {
            ReadHexButton.Text = isReading ? "Reading..." : "Read";
        }

        private int ChunkSize => Convert.ToInt32(ChunkSizeComboBox.SelectedItem);
        private int BytesPerLine => Convert.ToInt32(BytesPerLineComboBox.SelectedItem);
    }
}
