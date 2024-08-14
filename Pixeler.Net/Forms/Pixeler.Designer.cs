namespace Pixeler.Net
{
    partial class PixelerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PixelerForm));
            SetupCoordinates = new Controls.CurvedButton();
            loggingBox = new RichTextBox();
            PaintStart = new Controls.CurvedButton();
            currentOperation = new Label();
            currentImageFilePath = new Label();
            loadImageButton = new Controls.CurvedButton();
            openFileDialog = new OpenFileDialog();
            ClearLogsButton = new Controls.CurvedButton();
            SuspendLayout();
            // 
            // SetupCoordinates
            // 
            SetupCoordinates.BackColor = Color.SteelBlue;
            SetupCoordinates.BackgroundColor = Color.SteelBlue;
            SetupCoordinates.BorderColor = Color.PaleVioletRed;
            SetupCoordinates.BorderRadius = 10;
            SetupCoordinates.BorderSize = 0;
            SetupCoordinates.FlatStyle = FlatStyle.Flat;
            SetupCoordinates.ForeColor = Color.White;
            SetupCoordinates.Location = new Point(12, 12);
            SetupCoordinates.Name = "SetupCoordinates";
            SetupCoordinates.Size = new Size(167, 23);
            SetupCoordinates.TabIndex = 0;
            SetupCoordinates.Text = "Edit Configuration";
            SetupCoordinates.TextColor = Color.White;
            SetupCoordinates.UseVisualStyleBackColor = true;
            SetupCoordinates.Click += SetupCoordinates_Click;
            // 
            // loggingBox
            // 
            loggingBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loggingBox.BackColor = SystemColors.ControlDark;
            loggingBox.BorderStyle = BorderStyle.None;
            loggingBox.Location = new Point(-5, 158);
            loggingBox.Margin = new Padding(0);
            loggingBox.Name = "loggingBox";
            loggingBox.ReadOnly = true;
            loggingBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            loggingBox.Size = new Size(575, 97);
            loggingBox.TabIndex = 1;
            loggingBox.Text = "";
            // 
            // PaintStart
            // 
            PaintStart.BackColor = Color.SteelBlue;
            PaintStart.BackgroundColor = Color.SteelBlue;
            PaintStart.BorderColor = Color.PaleVioletRed;
            PaintStart.BorderRadius = 10;
            PaintStart.BorderSize = 0;
            PaintStart.FlatStyle = FlatStyle.Flat;
            PaintStart.ForeColor = Color.White;
            PaintStart.Location = new Point(12, 82);
            PaintStart.Name = "PaintStart";
            PaintStart.Size = new Size(167, 23);
            PaintStart.TabIndex = 2;
            PaintStart.Text = "Start Painting";
            PaintStart.TextColor = Color.White;
            PaintStart.UseVisualStyleBackColor = true;
            PaintStart.Click += PaintStart_Click;
            // 
            // currentOperation
            // 
            currentOperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            currentOperation.AutoSize = true;
            currentOperation.Location = new Point(1, 255);
            currentOperation.Name = "currentOperation";
            currentOperation.Size = new Size(107, 15);
            currentOperation.TabIndex = 3;
            currentOperation.Text = "%PLACEHOLDER%";
            // 
            // currentImageFilePath
            // 
            currentImageFilePath.AutoSize = true;
            currentImageFilePath.Location = new Point(93, 52);
            currentImageFilePath.Name = "currentImageFilePath";
            currentImageFilePath.Size = new Size(59, 15);
            currentImageFilePath.TabIndex = 4;
            currentImageFilePath.Text = "No Image";
            // 
            // loadImageButton
            // 
            loadImageButton.BackColor = Color.SteelBlue;
            loadImageButton.BackgroundColor = Color.SteelBlue;
            loadImageButton.BorderColor = Color.PaleVioletRed;
            loadImageButton.BorderRadius = 10;
            loadImageButton.BorderSize = 0;
            loadImageButton.FlatStyle = FlatStyle.Flat;
            loadImageButton.ForeColor = Color.White;
            loadImageButton.Location = new Point(12, 48);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(75, 23);
            loadImageButton.TabIndex = 5;
            loadImageButton.Text = "Browse";
            loadImageButton.TextColor = Color.White;
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += LoadImageButton_Click;
            // 
            // ClearLogsButton
            // 
            ClearLogsButton.BackColor = Color.SteelBlue;
            ClearLogsButton.BackgroundColor = Color.SteelBlue;
            ClearLogsButton.BorderColor = Color.PaleVioletRed;
            ClearLogsButton.BorderRadius = 10;
            ClearLogsButton.BorderSize = 0;
            ClearLogsButton.FlatStyle = FlatStyle.Flat;
            ClearLogsButton.ForeColor = Color.White;
            ClearLogsButton.Location = new Point(12, 111);
            ClearLogsButton.Name = "ClearLogsButton";
            ClearLogsButton.Size = new Size(167, 23);
            ClearLogsButton.TabIndex = 6;
            ClearLogsButton.Text = "Clear Logs";
            ClearLogsButton.TextColor = Color.White;
            ClearLogsButton.UseVisualStyleBackColor = true;
            ClearLogsButton.Click += ClearLogsButton_Click;
            // 
            // PixelerForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(569, 271);
            Controls.Add(ClearLogsButton);
            Controls.Add(loadImageButton);
            Controls.Add(currentImageFilePath);
            Controls.Add(currentOperation);
            Controls.Add(PaintStart);
            Controls.Add(loggingBox);
            Controls.Add(SetupCoordinates);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(380, 310);
            Name = "PixelerForm";
            Text = "Pixeler.Net";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Pixeler.Net.Controls.CurvedButton SetupCoordinates;
        private RichTextBox loggingBox;
        private Pixeler.Net.Controls.CurvedButton PaintStart;
        private Label currentOperation;
        private Label currentImageFilePath;
        private Pixeler.Net.Controls.CurvedButton loadImageButton;
        private OpenFileDialog openFileDialog;
        private Pixeler.Net.Controls.CurvedButton ClearLogsButton;
    }
}
