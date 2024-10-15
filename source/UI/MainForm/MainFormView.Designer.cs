namespace HexReader.UI.MainForm
{
    partial class MainFormView
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
            SplitContainer = new SplitContainer();
            HexStreamText = new Label();
            ShiftPostitionText = new TextBox();
            ShiftButton = new Button();
            ResetPositionButton = new Button();
            FunctionLabel = new Label();
            ReadHexButton = new Button();
            FilePathTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
            SplitContainer.Panel1.SuspendLayout();
            SplitContainer.Panel2.SuspendLayout();
            SplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // SplitContainer
            // 
            SplitContainer.BorderStyle = BorderStyle.FixedSingle;
            SplitContainer.Dock = DockStyle.Fill;
            SplitContainer.FixedPanel = FixedPanel.Panel1;
            SplitContainer.IsSplitterFixed = true;
            SplitContainer.Location = new Point(0, 0);
            SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            SplitContainer.Panel1.AutoScroll = true;
            SplitContainer.Panel1.BackColor = SystemColors.ControlLightLight;
            SplitContainer.Panel1.Controls.Add(HexStreamText);
            SplitContainer.Panel1.Scroll += HandleScroll;
            // 
            // SplitContainer.Panel2
            // 
            SplitContainer.Panel2.Controls.Add(ShiftPostitionText);
            SplitContainer.Panel2.Controls.Add(ShiftButton);
            SplitContainer.Panel2.Controls.Add(ResetPositionButton);
            SplitContainer.Panel2.Controls.Add(FunctionLabel);
            SplitContainer.Panel2.Controls.Add(ReadHexButton);
            SplitContainer.Panel2.Controls.Add(FilePathTextBox);
            SplitContainer.Size = new Size(852, 461);
            SplitContainer.SplitterDistance = 609;
            SplitContainer.TabIndex = 0;
            // 
            // HexStreamText
            // 
            HexStreamText.AutoSize = true;
            HexStreamText.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            HexStreamText.Location = new Point(11, 8);
            HexStreamText.Name = "HexStreamText";
            HexStreamText.Size = new Size(217, 14);
            HexStreamText.TabIndex = 0;
            HexStreamText.Text = "The text will be printed here.";
            // 
            // ShiftPostitionText
            // 
            ShiftPostitionText.CharacterCasing = CharacterCasing.Upper;
            ShiftPostitionText.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ShiftPostitionText.Location = new Point(161, 147);
            ShiftPostitionText.MaxLength = 8;
            ShiftPostitionText.Name = "ShiftPostitionText";
            ShiftPostitionText.Size = new Size(65, 23);
            ShiftPostitionText.TabIndex = 9;
            ShiftPostitionText.Text = "00000000";
            ShiftPostitionText.TextAlign = HorizontalAlignment.Center;
            // 
            // ShiftButton
            // 
            ShiftButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ShiftButton.Location = new Point(12, 144);
            ShiftButton.Name = "ShiftButton";
            ShiftButton.Size = new Size(143, 30);
            ShiftButton.TabIndex = 8;
            ShiftButton.Text = "Shift to:";
            ShiftButton.UseVisualStyleBackColor = true;
            ShiftButton.Click += ShiftButton_Click;
            // 
            // ResetPositionButton
            // 
            ResetPositionButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ResetPositionButton.Location = new Point(12, 108);
            ResetPositionButton.Name = "ResetPositionButton";
            ResetPositionButton.Size = new Size(214, 30);
            ResetPositionButton.TabIndex = 7;
            ResetPositionButton.Text = "Reset";
            ResetPositionButton.UseVisualStyleBackColor = true;
            ResetPositionButton.Click += ResetPositionButton_Click;
            // 
            // FunctionLabel
            // 
            FunctionLabel.AutoSize = true;
            FunctionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FunctionLabel.Location = new Point(86, 86);
            FunctionLabel.Name = "FunctionLabel";
            FunctionLabel.Size = new Size(68, 19);
            FunctionLabel.TabIndex = 6;
            FunctionLabel.Text = "Functions";
            // 
            // ReadHexButton
            // 
            ReadHexButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ReadHexButton.Location = new Point(12, 43);
            ReadHexButton.Name = "ReadHexButton";
            ReadHexButton.Size = new Size(215, 40);
            ReadHexButton.TabIndex = 5;
            ReadHexButton.Text = "Read";
            ReadHexButton.UseVisualStyleBackColor = true;
            ReadHexButton.Click += ReadHexButton_Click;
            // 
            // FilePathTextBox
            // 
            FilePathTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FilePathTextBox.Location = new Point(12, 12);
            FilePathTextBox.Name = "FilePathTextBox";
            FilePathTextBox.ReadOnly = true;
            FilePathTextBox.Size = new Size(215, 25);
            FilePathTextBox.TabIndex = 0;
            FilePathTextBox.Text = "Double click to find file";
            FilePathTextBox.TextAlign = HorizontalAlignment.Center;
            FilePathTextBox.DoubleClick += PathTextBox_DoubleClick;
            // 
            // MainFormView
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(852, 461);
            Controls.Add(SplitContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainFormView";
            Text = "HexReader";
            SplitContainer.Panel1.ResumeLayout(false);
            SplitContainer.Panel1.PerformLayout();
            SplitContainer.Panel2.ResumeLayout(false);
            SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
            SplitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer SplitContainer;
        private TextBox FilePathTextBox;
        private Button ReadHexButton;
        private Label HexStreamText;
        private Label FunctionLabel;
        private TextBox ShiftPostitionText;
        private Button ShiftButton;
        private Button ResetPositionButton;
    }
}