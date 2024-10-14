using HexReader.Script.CustomStream;
using System.Windows.Forms;

namespace HexReader.UI.MainForm
{
    public partial class MainFormView : Form
    {
        private const int MAX_DISPLAY_CHUNK = 3;
        private const int CHUNK_SIZE = 1024;
        private const int BYTES_PER_LINE = 16;

        private long _currentOffset = 0;
        private string _filePath = "";
        private string _displayString = "";

        public MainFormView()
        {
            InitializeComponent();
            SplitContainer.Panel1.AutoScroll = true;
            SplitContainer.Panel1.HorizontalScroll.Enabled = false;
            SplitContainer.Panel1.HorizontalScroll.Visible = false;

            SplitContainer.Panel1.MouseWheel += (s, e) => {
                HandleScroll(s, null);
            };
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
            using (HexStream hexStream = new HexStream(_filePath, CHUNK_SIZE, BYTES_PER_LINE))
            {
                _displayString = hexStream.ReadChunk() + "\n";
                _currentOffset = hexStream.Offset;
            }
            UpdateHexText(_displayString);
        }

        private void LoadNextChunk()
        {
            if (!IsFilePathValid(_filePath))
            {
                return;
            }
            using (HexStream hexStream = new HexStream(_filePath, CHUNK_SIZE, BYTES_PER_LINE))
            {
                hexStream.Shift(_currentOffset);
                _displayString = TrimText(_displayString + hexStream.ReadChunk() + "\n", true);
                _currentOffset = hexStream.Offset;
            }
            UpdateHexText(_displayString);
        }

        private void LoadPrevChunk()
        {
            if (!IsFilePathValid(_filePath))
            {
                return;
            }
            using (HexStream hexStream = new HexStream(_filePath, CHUNK_SIZE, BYTES_PER_LINE))
            {
                _currentOffset = Math.Max(_currentOffset - CHUNK_SIZE * 2, 0);
                hexStream.Shift(_currentOffset);
                _displayString = TrimText(hexStream.ReadChunk() + "\n" + _displayString, false);
                _currentOffset = hexStream.Offset;
            }
            UpdateHexText(_displayString);
        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            float scrollValue = (HexStreamVScrollBar.Value * 1f / (HexStreamVScrollBar.Maximum - HexStreamVScrollBar.LargeChange));
            if (scrollValue > 0.9f)
            {
                LoadNextChunk();
            }
            else if (scrollValue < 0.1f && _currentOffset > CHUNK_SIZE)
            {
                LoadPrevChunk();
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

        private void UpdateHexText(string text)
        {
            HexStreamText.Text = text;
            SplitContainer.Panel1.PerformLayout();
        }

        private string TrimText(string text, bool isUp)
        {
            int chunkCount = (text.Split('\n').Length - 1) * BYTES_PER_LINE / CHUNK_SIZE;
            if (chunkCount < MAX_DISPLAY_CHUNK)
            {
                return text;
            }
            int textOffset = text.Length / (MAX_DISPLAY_CHUNK + 1);
            string result = isUp ? text[textOffset..] : text[..(textOffset * MAX_DISPLAY_CHUNK)];
            return result;
        }

        private VScrollProperties HexStreamVScrollBar => SplitContainer.Panel1.VerticalScroll;
    }
}
