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
            HexStreamText.Location = new Point(0, 0);
            HexStreamText.Name = "HexStreamText";
            HexStreamText.Size = new Size(49, 14);
            HexStreamText.TabIndex = 0;
            HexStreamText.Text = "label1";
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
    }
}