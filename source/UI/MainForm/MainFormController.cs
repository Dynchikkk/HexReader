using HexReader.Script.CustomStream;
using System.Diagnostics;

namespace HexReader.UI.MainForm
{
    public class MainFormController : IDisposable
    {
        private const string ERROR_STRING = "ERROR";

        private const int MAX_DISPLAY_CHUNK = 3;
        private const int CHUNK_SIZE = 1024;
        private const int BYTES_PER_LINE = 16;

        private readonly MainFormModel _model;
        private readonly MainFormView _view;

        private string _currentFilePath = "";
        // Offsets
        private long _minOffset;
        private long _maxOffset;

        public MainFormController(MainFormModel model, MainFormView view)
        {
            _model = model;
            _view = view;

            _minOffset = 0;
            _maxOffset = 0;

            Sub();
        }

        ~MainFormController()
        {
            Dispose();
        }

        private void Sub()
        {
            if (_view == null)
            {
                return;
            }
            _view.OnUpdatePath += ReadPath;
            _view.OnRead += ReadFile;
            _view.OnShift += ShiftTo;
            _view.OnTextScroll += HandleScroll;
        }

        private void UnSub()
        {
            if (_view == null)
            {
                return;
            }
            _view.OnUpdatePath -= ReadPath;
            _view.OnRead -= ReadFile;
            _view.OnShift -= ShiftTo;
            _view.OnTextScroll -= HandleScroll;
        }

        private void ReadPath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.RestoreDirectory = true;
            _currentFilePath = fileDialog.ShowDialog() != DialogResult.OK ? ERROR_STRING : fileDialog.FileName;
            _model.UpdateFilePath(_currentFilePath);
        }

        private void ReadFile()
        {
            ReadFile(_currentFilePath, 0);
        }

        private void ShiftTo(long offset)
        {
            ReadFile(_currentFilePath, offset);
        }

        private void ReadFile(string filePath, long offset)
        {
            if (!IsFilePathValid(filePath))
            {
                return;
            }
            string displayString = ERROR_STRING;
            using (HexStream hexStream = new HexStream(filePath, CHUNK_SIZE, BYTES_PER_LINE))
            {
                hexStream.Shift(offset);
                displayString = hexStream.ReadChunk() + "\n";
                _maxOffset = hexStream.Offset;
                _minOffset = hexStream.Offset;
            }
            _model.UpdateDisplayString(displayString, ScrollbarPosition.TOP);
        }

        private void HandleScroll(float value)
        {
            if (!IsFilePathValid(_model.FilePath))
            {
                return;
            }
            if (value > 0.9f)
            {
                LoadNextChunk();
            }
            else if (value < 0.1f && _minOffset > CHUNK_SIZE)
            {
                LoadPrevChunk();
            }
        }

        private void LoadNextChunk()
        {
            string displayString = _model.DisplayString;
            using (HexStream hexStream = new HexStream(_model.FilePath, CHUNK_SIZE, BYTES_PER_LINE))
            {
                hexStream.Shift(_maxOffset);
                if (hexStream.IsFileEnd)
                {
                    return;
                }
                displayString = TrimText(displayString + hexStream.ReadChunk() + "\n", true);
                _maxOffset = hexStream.Offset;
            }
            _model.UpdateDisplayString(displayString, ScrollbarPosition.MIDDLE);
        }

        private void LoadPrevChunk()
        {
            string displayString = _model.DisplayString;
            using (HexStream hexStream = new HexStream(_model.FilePath, CHUNK_SIZE, BYTES_PER_LINE))
            {
                _minOffset = Math.Max(_minOffset - CHUNK_SIZE * 2, 0);
                hexStream.Shift(_minOffset);
                if (hexStream.IsFileEnd)
                {
                    return;
                }
                displayString = TrimText(hexStream.ReadChunk() + "\n" + displayString, false);
                _minOffset = hexStream.Offset;
            }
            _model.UpdateDisplayString(displayString, ScrollbarPosition.MIDDLE);
        }

        private bool IsFilePathValid(string filePath)
        {
            return filePath.Contains('\\') && !string.IsNullOrEmpty(filePath);
        }

        private string TrimText(string text, bool scrollDown)
        {
            int chunkCount = (text.Split('\n').Length - 1) * BYTES_PER_LINE / CHUNK_SIZE;
            if (chunkCount < MAX_DISPLAY_CHUNK)
            {
                return text;
            }
            int textOffset = text.Length / (MAX_DISPLAY_CHUNK + 1);
            if (scrollDown)
            {
                _minOffset = Math.Max(_maxOffset - (MAX_DISPLAY_CHUNK - 1) * CHUNK_SIZE, 0);
                return text[textOffset..];
            }
            else
            {
                _maxOffset = Math.Max(_maxOffset - CHUNK_SIZE, CHUNK_SIZE);
                return text[..(textOffset * MAX_DISPLAY_CHUNK)];
            }
        }

        public void Dispose()
        {
            UnSub();
        }
    }
}
