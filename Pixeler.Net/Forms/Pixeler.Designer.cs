namespace Pixeler.Net
{
    partial class Pixeler
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
            SetupCoordinates = new Button();
            loggingBox = new RichTextBox();
            PaintStart = new Button();
            currentOperation = new Label();
            currentImageFilePath = new Label();
            loadImageButton = new Button();
            openFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // SetupCoordinates
            // 
            SetupCoordinates.Location = new Point(12, 12);
            SetupCoordinates.Name = "SetupCoordinates";
            SetupCoordinates.Size = new Size(167, 23);
            SetupCoordinates.TabIndex = 0;
            SetupCoordinates.Text = "Setup Coordinates";
            SetupCoordinates.UseVisualStyleBackColor = true;
            SetupCoordinates.Click += SetupCoordinates_Click;
            // 
            // loggingBox
            // 
            loggingBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loggingBox.Location = new Point(0, 137);
            loggingBox.Name = "loggingBox";
            loggingBox.Size = new Size(569, 118);
            loggingBox.TabIndex = 1;
            loggingBox.Text = "";
            // 
            // PaintStart
            // 
            PaintStart.Location = new Point(12, 82);
            PaintStart.Name = "PaintStart";
            PaintStart.Size = new Size(167, 23);
            PaintStart.TabIndex = 2;
            PaintStart.Text = "Start Painting";
            PaintStart.UseVisualStyleBackColor = true;
            PaintStart.Click += PaintStart_Click;
            // 
            // currentOperation
            // 
            currentOperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            currentOperation.AutoSize = true;
            currentOperation.Location = new Point(0, 255);
            currentOperation.Name = "currentOperation";
            currentOperation.Size = new Size(107, 15);
            currentOperation.TabIndex = 3;
            currentOperation.Text = "%PLACEHOLDER%";
            // 
            // currentImageFilePath
            // 
            currentImageFilePath.AutoSize = true;
            currentImageFilePath.Location = new Point(12, 52);
            currentImageFilePath.Name = "currentImageFilePath";
            currentImageFilePath.Size = new Size(59, 15);
            currentImageFilePath.TabIndex = 4;
            currentImageFilePath.Text = "No Image";
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(104, 48);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(75, 23);
            loadImageButton.TabIndex = 5;
            loadImageButton.Text = "Browse";
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += LoadImageButton_Click;
            // 
            // Pixeler
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 271);
            Controls.Add(loadImageButton);
            Controls.Add(currentImageFilePath);
            Controls.Add(currentOperation);
            Controls.Add(PaintStart);
            Controls.Add(loggingBox);
            Controls.Add(SetupCoordinates);
            MinimumSize = new Size(380, 310);
            Name = "Pixeler";
            Text = "Pixeler.Net";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SetupCoordinates;
        private RichTextBox loggingBox;
        private Button PaintStart;
        private Label currentOperation;
        private Label currentImageFilePath;
        private Button loadImageButton;
        private OpenFileDialog openFileDialog;
    }
}
