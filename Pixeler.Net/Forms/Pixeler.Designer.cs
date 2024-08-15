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
            openSavedImages = new Controls.CurvedButton();
            viewImage = new Controls.CurvedButton();
            appearOnTop = new Controls.ToggleButton();
            label1 = new Label();
            validateColors = new Controls.CurvedButton();
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
            SetupCoordinates.Size = new Size(167, 25);
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
            loggingBox.Location = new Point(1, 190);
            loggingBox.Margin = new Padding(0);
            loggingBox.Name = "loggingBox";
            loggingBox.ReadOnly = true;
            loggingBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            loggingBox.Size = new Size(569, 145);
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
            PaintStart.Size = new Size(167, 25);
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
            currentOperation.Location = new Point(1, 335);
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
            loadImageButton.Size = new Size(75, 25);
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
            ClearLogsButton.Location = new Point(12, 113);
            ClearLogsButton.Name = "ClearLogsButton";
            ClearLogsButton.Size = new Size(167, 25);
            ClearLogsButton.TabIndex = 6;
            ClearLogsButton.Text = "Clear Logs";
            ClearLogsButton.TextColor = Color.White;
            ClearLogsButton.UseVisualStyleBackColor = true;
            ClearLogsButton.Click += ClearLogsButton_Click;
            // 
            // openSavedImages
            // 
            openSavedImages.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openSavedImages.BackColor = Color.SteelBlue;
            openSavedImages.BackgroundColor = Color.SteelBlue;
            openSavedImages.BorderColor = Color.PaleVioletRed;
            openSavedImages.BorderRadius = 10;
            openSavedImages.BorderSize = 0;
            openSavedImages.FlatStyle = FlatStyle.Flat;
            openSavedImages.ForeColor = Color.White;
            openSavedImages.Location = new Point(390, 80);
            openSavedImages.Name = "openSavedImages";
            openSavedImages.Size = new Size(167, 25);
            openSavedImages.TabIndex = 7;
            openSavedImages.Text = "Open Downloaded Images";
            openSavedImages.TextColor = Color.White;
            openSavedImages.UseVisualStyleBackColor = true;
            openSavedImages.Click += openSavedImages_Click;
            // 
            // viewImage
            // 
            viewImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            viewImage.BackColor = Color.SteelBlue;
            viewImage.BackgroundColor = Color.SteelBlue;
            viewImage.BorderColor = Color.PaleVioletRed;
            viewImage.BorderRadius = 10;
            viewImage.BorderSize = 0;
            viewImage.FlatStyle = FlatStyle.Flat;
            viewImage.ForeColor = Color.White;
            viewImage.Location = new Point(390, 111);
            viewImage.Name = "viewImage";
            viewImage.Size = new Size(167, 25);
            viewImage.TabIndex = 8;
            viewImage.Text = "View Image";
            viewImage.TextColor = Color.White;
            viewImage.UseVisualStyleBackColor = true;
            viewImage.Click += viewImage_Click;
            // 
            // appearOnTop
            // 
            appearOnTop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            appearOnTop.AutoSize = true;
            appearOnTop.Location = new Point(512, 12);
            appearOnTop.MinimumSize = new Size(45, 22);
            appearOnTop.Name = "appearOnTop";
            appearOnTop.OffBackColor = Color.Gray;
            appearOnTop.OffToggleColor = Color.Gainsboro;
            appearOnTop.OnBackColor = Color.SteelBlue;
            appearOnTop.OnToggleColor = Color.WhiteSmoke;
            appearOnTop.Size = new Size(45, 22);
            appearOnTop.TabIndex = 11;
            appearOnTop.UseVisualStyleBackColor = true;
            appearOnTop.CheckedChanged += appearOnTop_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(420, 15);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 12;
            label1.Text = "Appear On Top";
            // 
            // validateColors
            // 
            validateColors.BackColor = Color.SteelBlue;
            validateColors.BackgroundColor = Color.SteelBlue;
            validateColors.BorderColor = Color.PaleVioletRed;
            validateColors.BorderRadius = 10;
            validateColors.BorderSize = 0;
            validateColors.FlatStyle = FlatStyle.Flat;
            validateColors.ForeColor = Color.White;
            validateColors.Location = new Point(12, 144);
            validateColors.Name = "validateColors";
            validateColors.Size = new Size(167, 25);
            validateColors.TabIndex = 13;
            validateColors.Text = "Validate Colors";
            validateColors.TextColor = Color.White;
            validateColors.UseVisualStyleBackColor = true;
            validateColors.Click += validateColors_Click;
            // 
            // PixelerForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(569, 351);
            Controls.Add(validateColors);
            Controls.Add(label1);
            Controls.Add(appearOnTop);
            Controls.Add(viewImage);
            Controls.Add(openSavedImages);
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
        private Controls.CurvedButton openSavedImages;
        private Controls.CurvedButton viewImage;
        private Controls.ToggleButton appearOnTop;
        private Label label1;
        private Controls.CurvedButton validateColors;
    }
}
