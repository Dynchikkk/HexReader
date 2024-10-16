﻿using System.Diagnostics;

namespace HexReader.UI.MainForm
{
    public partial class MainFormView : Form
    {
        private const string READING_TEXT = "Reading...";
        private const string READ_TEXT = "Read";
        private const string ZERO_HEX_TEXT = "00000000";

        public event Action OnUpdatePath = delegate { };
        public event Action OnRead = delegate { };
        public event Action<float> OnTextScroll = delegate { };
        public event Action<long> OnShift = delegate { };
        public event Action OnReset = delegate { };

        private readonly MainFormModel _model;

        public MainFormView(MainFormModel model)
        {
            InitializeComponent();
            SplitContainer.Panel1.AutoScroll = true;
            SplitContainer.Panel1.HorizontalScroll.Enabled = false;
            SplitContainer.Panel1.HorizontalScroll.Visible = false;

            _model = model;
            Sub();
        }

        ~MainFormView()
        {
            UnSub();
        }

        private void Sub()
        {
            SplitContainer.Panel1.MouseWheel += (s, e) =>
            {
                HandleScroll(s, null);
            };

            _model.OnDisplayStringUpdate += UpdateDisplayText;
            _model.OnFilePathUpdate += UpdateFilePathText;
        }

        private void UnSub()
        {
            _model.OnDisplayStringUpdate -= UpdateDisplayText;
            _model.OnFilePathUpdate -= UpdateFilePathText;
        }

        private void PathTextBox_DoubleClick(object sender, EventArgs e)
        {
            OnUpdatePath?.Invoke();
        }

        private void ReadHexButton_Click(object sender, EventArgs e)
        {
            OnRead?.Invoke();
            UpdateReadButton(true);
        }

        private void ShiftToStartButton_Click(object sender, EventArgs e)
        {
            OnShift?.Invoke(0);
            SplitContainer.Panel1.VerticalScroll.Value = 0;
        }

        private void ShiftToEndButton_Click(object sender, EventArgs e)
        {
            OnShift?.Invoke(-1);
            SplitContainer.Panel1.VerticalScroll.Value = 0;
        }

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            string hexValue = ShiftPostitionText.Text;
            if (!hexValue.All(ch => (ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'F')))
            {
                ShiftPostitionText.Text = ZERO_HEX_TEXT;
                return;
            }
            long value = Convert.ToInt64(hexValue, 16);
            SplitContainer.Panel1.VerticalScroll.Value = 0;
            OnShift?.Invoke(value);
        }

        private void UpdateFilePathText(string text)
        {
            FilePathTextBox.Text = text;
            FilePathTextBox.TextAlign = HorizontalAlignment.Left;
            UpdateReadButton(false);
        }

        private void UpdateDisplayText(string text, ScrollbarPosition scrollbarPosition)
        {
            
            HexStreamText.Text = text;
            SplitContainer.PerformLayout();
            int scrollbarValue = 0;
            VScrollProperties vScroll = SplitContainer.Panel1.VerticalScroll;
            switch (scrollbarPosition)
            {
                case ScrollbarPosition.AUTO:
                    scrollbarValue = vScroll.Value;
                    break;
                case ScrollbarPosition.TOP:
                    scrollbarValue = 0;
                    break;
                case ScrollbarPosition.MIDDLE:
                    scrollbarValue = (vScroll.Maximum - vScroll.Minimum) / 2;
                    break;
                case ScrollbarPosition.DOWN:
                    scrollbarValue = vScroll.Maximum;
                    break;
                default:
                    break;
            }
            SplitContainer.Panel1.VerticalScroll.Value = scrollbarValue;
        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            VScrollProperties vScroll = SplitContainer.Panel1.VerticalScroll;
            float scrollValue = (vScroll.Value * 1f / (vScroll.Maximum - vScroll.LargeChange));
            OnTextScroll?.Invoke(scrollValue);
            SplitContainer.PerformLayout();
        }

        private void UpdateReadButton(bool isReading)
        {
            ReadHexButton.Text = isReading ? READING_TEXT : READ_TEXT;
        }
    }
}
