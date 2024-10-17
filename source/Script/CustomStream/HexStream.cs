using System.IO;
using System.Text;

namespace HexReader.Script.CustomStream
{
    public class HexStream : IDisposable
    {
        private const string END_OF_FILE = "END_OF_FILE";
        private const int DEFAULT_CHUNK_SIZE = 256;
        private const int DEFAULT_BYTES_PER_LINE = 16;

        // Streams
        private readonly FileStream _fileStream;
        private readonly BinaryReader _binaryReader;

        private readonly int _chunkSize;
        private readonly int _bytesPerLine;

        private long _offset = 0;

        public HexStream(string filePath) :
            this(filePath, DEFAULT_CHUNK_SIZE, DEFAULT_BYTES_PER_LINE)
        {
        }

        public HexStream(string filePath, int chunkSize, int bytesPerLine)
        {
            if (chunkSize % 2 != 0 || bytesPerLine % 2 != 0 || chunkSize % bytesPerLine != 0)
            {
                throw new Exception("Wrong chunk size or bytes per line");
            }

            try
            {
                _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                _binaryReader = new BinaryReader(_fileStream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _fileStream?.Close();
                _binaryReader?.Close();
                throw new Exception("Error while opening file");
            }
            _chunkSize = chunkSize;
            _bytesPerLine = bytesPerLine;
        }

        public void Shift(long offset)
        {
            if (offset == -1)
            {
                offset = _fileStream.Length - _chunkSize;
            }
            _fileStream.Seek(offset, SeekOrigin.Begin);
            _offset += offset;
        }

        public string ReadChunk()
        {
            StringBuilder displayString = new StringBuilder();
            int lineCount = _chunkSize / _bytesPerLine;
            for (int i = 0; i < lineCount - 1; i++)
            {
                string line = ReadLine();
                displayString.Append(line + '\n');
                if (line == END_OF_FILE)
                {
                    return displayString.ToString();
                }
            }
            displayString.Append(ReadLine());
            return displayString.ToString();
        }

        public string ReadLine()
        {
            byte[] bytesLine = new byte[_bytesPerLine];
            if (_offset > _fileStream.Length)
            {
                return END_OF_FILE;
            }
            _binaryReader.Read(bytesLine, 0, _bytesPerLine);
            int halfBytesPerLine = _bytesPerLine / 2;

            StringBuilder displayString = new StringBuilder($"{_offset:X8}   ");
            for (int i = 0; i < halfBytesPerLine; i++)
            {
                displayString.Append($"{bytesLine[i]:X2} ");
            }
            displayString.Append("| ");
            for (int i = halfBytesPerLine; i < _bytesPerLine; i++)
            {
                displayString.Append($"{bytesLine[i]:X2} ");
            }
            displayString.Append("  ");
            for (int i = 0; i < _bytesPerLine; i++)
            {
                byte b = bytesLine[i];
                char symbol = b < 32 || b > 126 ? '.' : (char)b;
                displayString.Append(symbol);
            }

            _offset += _bytesPerLine;
            return displayString.ToString();
        }

        public void Dispose()
        {
            _fileStream?.Close();
            _binaryReader?.Close();
        }

        public bool IsFileEnd => _offset > _fileStream.Length;
        public long Offset => _offset;
        public long Position => _binaryReader.BaseStream.Position;
        public long Length => _binaryReader.BaseStream.Length;
    }
}
