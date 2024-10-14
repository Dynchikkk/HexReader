namespace HexReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            PrevPageButton = new Button();
            NextPageButton = new Button();
            HexStreamTextBox = new RichTextBox();
            ReadHexButton = new Button();
            ChunkSizeLabel = new Label();
            ChunkSizeComboBox = new ComboBox();
            BytesPerLineLabel = new Label();
            BytesPerLineComboBox = new ComboBox();
            FilePathTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(PrevPageButton);
            splitContainer1.Panel1.Controls.Add(NextPageButton);
            splitContainer1.Panel1.Controls.Add(HexStreamTextBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ReadHexButton);
            splitContainer1.Panel2.Controls.Add(ChunkSizeLabel);
            splitContainer1.Panel2.Controls.Add(ChunkSizeComboBox);
            splitContainer1.Panel2.Controls.Add(BytesPerLineLabel);
            splitContainer1.Panel2.Controls.Add(BytesPerLineComboBox);
            splitContainer1.Panel2.Controls.Add(FilePathTextBox);
            splitContainer1.Size = new Size(852, 461);
            splitContainer1.SplitterDistance = 609;
            splitContainer1.TabIndex = 0;
            // 
            // PrevPageButton
            // 
            PrevPageButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            PrevPageButton.Location = new Point(12, 418);
            PrevPageButton.Name = "PrevPageButton";
            PrevPageButton.Size = new Size(74, 40);
            PrevPageButton.TabIndex = 2;
            PrevPageButton.Text = "Prev";
            PrevPageButton.UseVisualStyleBackColor = true;
            PrevPageButton.Click += PrevPageButton_Click;
            // 
            // NextPageButton
            // 
            NextPageButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            NextPageButton.Location = new Point(532, 418);
            NextPageButton.Name = "NextPageButton";
            NextPageButton.Size = new Size(74, 40);
            NextPageButton.TabIndex = 1;
            NextPageButton.Text = "Next";
            NextPageButton.UseVisualStyleBackColor = true;
            NextPageButton.Click += NextPageButton_Click;
            // 
            // HexStreamTextBox
            // 
            HexStreamTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HexStreamTextBox.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            HexStreamTextBox.Location = new Point(12, 12);
            HexStreamTextBox.Name = "HexStreamTextBox";
            HexStreamTextBox.ReadOnly = true;
            HexStreamTextBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            HexStreamTextBox.Size = new Size(594, 404);
            HexStreamTextBox.TabIndex = 0;
            HexStreamTextBox.Text = "There will be a text here";
            // 
            // ReadHexButton
            // 
            ReadHexButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ReadHexButton.Location = new Point(10, 418);
            ReadHexButton.Name = "ReadHexButton";
            ReadHexButton.Size = new Size(217, 40);
            ReadHexButton.TabIndex = 5;
            ReadHexButton.Text = "Read";
            ReadHexButton.UseVisualStyleBackColor = true;
            ReadHexButton.Click += ReadHexButton_Click;
            // 
            // ChunkSizeLabel
            // 
            ChunkSizeLabel.AutoSize = true;
            ChunkSizeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ChunkSizeLabel.Location = new Point(12, 72);
            ChunkSizeLabel.Name = "ChunkSizeLabel";
            ChunkSizeLabel.Size = new Size(75, 19);
            ChunkSizeLabel.TabIndex = 4;
            ChunkSizeLabel.Text = "Chunk size";
            // 
            // ChunkSizeComboBox
            // 
            ChunkSizeComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ChunkSizeComboBox.FormattingEnabled = true;
            ChunkSizeComboBox.Items.AddRange(new object[] { "64", "128", "256", "512", "1024", "2048" });
            ChunkSizeComboBox.Location = new Point(106, 69);
            ChunkSizeComboBox.Name = "ChunkSizeComboBox";
            ChunkSizeComboBox.Size = new Size(121, 25);
            ChunkSizeComboBox.TabIndex = 3;
            ChunkSizeComboBox.Text = "1024";
            // 
            // BytesPerLineLabel
            // 
            BytesPerLineLabel.AutoSize = true;
            BytesPerLineLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BytesPerLineLabel.Location = new Point(12, 42);
            BytesPerLineLabel.Name = "BytesPerLineLabel";
            BytesPerLineLabel.Size = new Size(91, 19);
            BytesPerLineLabel.TabIndex = 2;
            BytesPerLineLabel.Text = "Bytes per line";
            // 
            // BytesPerLineComboBox
            // 
            BytesPerLineComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BytesPerLineComboBox.FormattingEnabled = true;
            BytesPerLineComboBox.Items.AddRange(new object[] { "8", "16" });
            BytesPerLineComboBox.Location = new Point(106, 39);
            BytesPerLineComboBox.Name = "BytesPerLineComboBox";
            BytesPerLineComboBox.Size = new Size(121, 25);
            BytesPerLineComboBox.TabIndex = 1;
            BytesPerLineComboBox.Text = "16";
            // 
            // FilePathTextBox
            // 
            FilePathTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FilePathTextBox.Location = new Point(12, 10);
            FilePathTextBox.Name = "FilePathTextBox";
            FilePathTextBox.ReadOnly = true;
            FilePathTextBox.Size = new Size(215, 25);
            FilePathTextBox.TabIndex = 0;
            FilePathTextBox.Text = "Double click to find file";
            FilePathTextBox.TextAlign = HorizontalAlignment.Center;
            FilePathTextBox.DoubleClick += PathTextBox_DoubleClick;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(852, 461);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private RichTextBox HexStreamTextBox;
        private Button PrevPageButton;
        private Button NextPageButton;
        private TextBox FilePathTextBox;
        private ComboBox BytesPerLineComboBox;
        private Label BytesPerLineLabel;
        private Label ChunkSizeLabel;
        private ComboBox ChunkSizeComboBox;
        private Button ReadHexButton;
    }
}