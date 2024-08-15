namespace Pixeler.Net.Forms
{
    partial class CanvasSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasSetup));
            label1 = new Label();
            startButton = new Controls.CurvedButton();
            label2 = new Label();
            label4 = new Label();
            speedMultiplier = new NumericUpDown();
            confirmConfig = new Controls.CurvedButton();
            label3 = new Label();
            label5 = new Label();
            bottomRightLabel = new Label();
            topLeftLabel = new Label();
            label6 = new Label();
            screenSelection = new ComboBox();
            visualizeBounds = new Controls.CurvedButton();
            movePointDownButton = new Controls.CurvedButton();
            movePointUpButton = new Controls.CurvedButton();
            movePointLeftButton = new Controls.CurvedButton();
            movePointRightButton = new Controls.CurvedButton();
            topLeftPoint = new Controls.NewRadioButton();
            bottomRightPoint = new Controls.NewRadioButton();
            bothPoints = new Controls.NewRadioButton();
            panel1 = new Panel();
            stepCount = new NumericUpDown();
            paintMethodSelection = new ComboBox();
            label7 = new Label();
            helpLink = new LinkLabel();
            closeLocation = new Label();
            openLocation = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            setColorEnter = new Controls.CurvedButton();
            label13 = new Label();
            setColorExit = new Controls.CurvedButton();
            label14 = new Label();
            setHexInput = new Controls.CurvedButton();
            hexInputLocation = new Label();
            label16 = new Label();
            ((System.ComponentModel.ISupportInitialize)speedMultiplier).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stepCount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(194, 25);
            label1.TabIndex = 0;
            label1.Text = "Canvas Configuration";
            // 
            // startButton
            // 
            startButton.BackColor = Color.SteelBlue;
            startButton.BackgroundColor = Color.SteelBlue;
            startButton.BorderColor = Color.PaleVioletRed;
            startButton.BorderRadius = 10;
            startButton.BorderSize = 0;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(140, 50);
            startButton.Name = "startButton";
            startButton.Size = new Size(109, 23);
            startButton.TabIndex = 1;
            startButton.Text = "Set";
            startButton.TextColor = Color.White;
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += SetTopLeft_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 3;
            label2.Text = "Canvas Coordinates";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 198);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 6;
            label4.Text = "Speed Multiplier";
            // 
            // speedMultiplier
            // 
            speedMultiplier.DecimalPlaces = 1;
            speedMultiplier.Location = new Point(140, 196);
            speedMultiplier.Name = "speedMultiplier";
            speedMultiplier.Size = new Size(109, 23);
            speedMultiplier.TabIndex = 8;
            speedMultiplier.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            speedMultiplier.ValueChanged += SpeedMultiplier_ValueChanged;
            // 
            // confirmConfig
            // 
            confirmConfig.BackColor = Color.SteelBlue;
            confirmConfig.BackgroundColor = Color.SteelBlue;
            confirmConfig.BorderColor = Color.PaleVioletRed;
            confirmConfig.BorderRadius = 10;
            confirmConfig.BorderSize = 0;
            confirmConfig.FlatStyle = FlatStyle.Flat;
            confirmConfig.ForeColor = Color.White;
            confirmConfig.Location = new Point(15, 230);
            confirmConfig.Name = "confirmConfig";
            confirmConfig.Size = new Size(235, 25);
            confirmConfig.TabIndex = 9;
            confirmConfig.Text = "Confirm Configuration";
            confirmConfig.TextColor = Color.White;
            confirmConfig.UseVisualStyleBackColor = true;
            confirmConfig.Click += ConfirmConfig_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 80);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 10;
            label3.Text = "Top Left";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 99);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 11;
            label5.Text = "Bottom Right";
            // 
            // bottomRightLabel
            // 
            bottomRightLabel.AutoSize = true;
            bottomRightLabel.Location = new Point(142, 99);
            bottomRightLabel.Name = "bottomRightLabel";
            bottomRightLabel.Size = new Size(107, 15);
            bottomRightLabel.TabIndex = 13;
            bottomRightLabel.Text = "%PLACEHOLDER%";
            // 
            // topLeftLabel
            // 
            topLeftLabel.AutoSize = true;
            topLeftLabel.Location = new Point(142, 80);
            topLeftLabel.Name = "topLeftLabel";
            topLeftLabel.Size = new Size(107, 15);
            topLeftLabel.TabIndex = 12;
            topLeftLabel.Text = "%PLACEHOLDER%";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 164);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 14;
            label6.Text = "Screen";
            // 
            // screenSelection
            // 
            screenSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            screenSelection.FormattingEnabled = true;
            screenSelection.Location = new Point(97, 161);
            screenSelection.Name = "screenSelection";
            screenSelection.Size = new Size(152, 23);
            screenSelection.Sorted = true;
            screenSelection.TabIndex = 15;
            screenSelection.SelectedIndexChanged += ScreenSelection_SelectedIndexChanged;
            // 
            // visualizeBounds
            // 
            visualizeBounds.BackColor = Color.SteelBlue;
            visualizeBounds.BackgroundColor = Color.SteelBlue;
            visualizeBounds.BorderColor = Color.PaleVioletRed;
            visualizeBounds.BorderRadius = 10;
            visualizeBounds.BorderSize = 0;
            visualizeBounds.FlatStyle = FlatStyle.Flat;
            visualizeBounds.ForeColor = Color.White;
            visualizeBounds.Location = new Point(293, 230);
            visualizeBounds.Name = "visualizeBounds";
            visualizeBounds.Size = new Size(200, 25);
            visualizeBounds.TabIndex = 16;
            visualizeBounds.Text = "Visualize Bounds";
            visualizeBounds.TextColor = Color.White;
            visualizeBounds.UseVisualStyleBackColor = true;
            visualizeBounds.Click += VisualizeBounds_Click;
            // 
            // movePointDownButton
            // 
            movePointDownButton.BackColor = Color.SteelBlue;
            movePointDownButton.BackgroundColor = Color.SteelBlue;
            movePointDownButton.BorderColor = Color.PaleVioletRed;
            movePointDownButton.BorderRadius = 10;
            movePointDownButton.BorderSize = 0;
            movePointDownButton.Enabled = false;
            movePointDownButton.FlatStyle = FlatStyle.Flat;
            movePointDownButton.ForeColor = Color.White;
            movePointDownButton.Location = new Point(416, 152);
            movePointDownButton.Name = "movePointDownButton";
            movePointDownButton.Size = new Size(35, 35);
            movePointDownButton.TabIndex = 18;
            movePointDownButton.Text = "🡣";
            movePointDownButton.TextColor = Color.White;
            movePointDownButton.UseVisualStyleBackColor = true;
            movePointDownButton.Click += MovePointDownButton_Click;
            // 
            // movePointUpButton
            // 
            movePointUpButton.BackColor = Color.SteelBlue;
            movePointUpButton.BackgroundColor = Color.SteelBlue;
            movePointUpButton.BorderColor = Color.PaleVioletRed;
            movePointUpButton.BorderRadius = 10;
            movePointUpButton.BorderSize = 0;
            movePointUpButton.Enabled = false;
            movePointUpButton.FlatStyle = FlatStyle.Flat;
            movePointUpButton.ForeColor = Color.White;
            movePointUpButton.Location = new Point(416, 62);
            movePointUpButton.Name = "movePointUpButton";
            movePointUpButton.Size = new Size(35, 35);
            movePointUpButton.TabIndex = 19;
            movePointUpButton.Text = "🡡";
            movePointUpButton.TextColor = Color.White;
            movePointUpButton.UseVisualStyleBackColor = true;
            movePointUpButton.Click += MovePointUpButton_Click;
            // 
            // movePointLeftButton
            // 
            movePointLeftButton.BackColor = Color.SteelBlue;
            movePointLeftButton.BackgroundColor = Color.SteelBlue;
            movePointLeftButton.BorderColor = Color.PaleVioletRed;
            movePointLeftButton.BorderRadius = 10;
            movePointLeftButton.BorderSize = 0;
            movePointLeftButton.Enabled = false;
            movePointLeftButton.FlatStyle = FlatStyle.Flat;
            movePointLeftButton.ForeColor = Color.White;
            movePointLeftButton.Location = new Point(371, 107);
            movePointLeftButton.Name = "movePointLeftButton";
            movePointLeftButton.Size = new Size(35, 35);
            movePointLeftButton.TabIndex = 20;
            movePointLeftButton.Text = "🡠";
            movePointLeftButton.TextColor = Color.White;
            movePointLeftButton.UseVisualStyleBackColor = true;
            movePointLeftButton.Click += MovePointLeftButton_Click;
            // 
            // movePointRightButton
            // 
            movePointRightButton.BackColor = Color.SteelBlue;
            movePointRightButton.BackgroundColor = Color.SteelBlue;
            movePointRightButton.BorderColor = Color.PaleVioletRed;
            movePointRightButton.BorderRadius = 10;
            movePointRightButton.BorderSize = 0;
            movePointRightButton.Enabled = false;
            movePointRightButton.FlatStyle = FlatStyle.Flat;
            movePointRightButton.ForeColor = Color.White;
            movePointRightButton.Location = new Point(461, 107);
            movePointRightButton.Name = "movePointRightButton";
            movePointRightButton.Size = new Size(35, 35);
            movePointRightButton.TabIndex = 21;
            movePointRightButton.Text = "🡢";
            movePointRightButton.TextColor = Color.White;
            movePointRightButton.UseVisualStyleBackColor = true;
            movePointRightButton.Click += MovePointRightButton_Click;
            // 
            // topLeftPoint
            // 
            topLeftPoint.AutoSize = true;
            topLeftPoint.Checked = true;
            topLeftPoint.CheckedColor = Color.SteelBlue;
            topLeftPoint.Enabled = false;
            topLeftPoint.Location = new Point(6, 51);
            topLeftPoint.MinimumSize = new Size(0, 21);
            topLeftPoint.Name = "topLeftPoint";
            topLeftPoint.Padding = new Padding(10, 0, 0, 0);
            topLeftPoint.Size = new Size(77, 21);
            topLeftPoint.TabIndex = 22;
            topLeftPoint.TabStop = true;
            topLeftPoint.Text = "Top Left";
            topLeftPoint.UnCheckedColor = Color.Gray;
            topLeftPoint.UseVisualStyleBackColor = true;
            topLeftPoint.CheckedChanged += TopLeftPoint_CheckedChanged;
            // 
            // bottomRightPoint
            // 
            bottomRightPoint.AutoSize = true;
            bottomRightPoint.CheckedColor = Color.SteelBlue;
            bottomRightPoint.Enabled = false;
            bottomRightPoint.Location = new Point(6, 101);
            bottomRightPoint.MinimumSize = new Size(0, 21);
            bottomRightPoint.Name = "bottomRightPoint";
            bottomRightPoint.Padding = new Padding(10, 0, 0, 0);
            bottomRightPoint.Size = new Size(106, 21);
            bottomRightPoint.TabIndex = 23;
            bottomRightPoint.Text = "Bottom Right";
            bottomRightPoint.UnCheckedColor = Color.Gray;
            bottomRightPoint.UseVisualStyleBackColor = true;
            bottomRightPoint.CheckedChanged += BottomRightPoint_CheckedChanged;
            // 
            // bothPoints
            // 
            bothPoints.AutoSize = true;
            bothPoints.CheckedColor = Color.SteelBlue;
            bothPoints.Enabled = false;
            bothPoints.Location = new Point(6, 76);
            bothPoints.MinimumSize = new Size(0, 21);
            bothPoints.Name = "bothPoints";
            bothPoints.Padding = new Padding(10, 0, 0, 0);
            bothPoints.Size = new Size(60, 21);
            bothPoints.TabIndex = 24;
            bothPoints.Text = "Both";
            bothPoints.UnCheckedColor = Color.Gray;
            bothPoints.UseVisualStyleBackColor = true;
            bothPoints.CheckedChanged += BothPoints_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(topLeftPoint);
            panel1.Controls.Add(bothPoints);
            panel1.Controls.Add(stepCount);
            panel1.Controls.Add(bottomRightPoint);
            panel1.Location = new Point(287, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(105, 151);
            panel1.TabIndex = 25;
            // 
            // stepCount
            // 
            stepCount.Enabled = false;
            stepCount.Location = new Point(6, 19);
            stepCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            stepCount.Name = "stepCount";
            stepCount.Size = new Size(54, 23);
            stepCount.TabIndex = 26;
            stepCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // paintMethodSelection
            // 
            paintMethodSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            paintMethodSelection.FormattingEnabled = true;
            paintMethodSelection.Location = new Point(97, 122);
            paintMethodSelection.Name = "paintMethodSelection";
            paintMethodSelection.Size = new Size(152, 23);
            paintMethodSelection.Sorted = true;
            paintMethodSelection.TabIndex = 27;
            paintMethodSelection.SelectedIndexChanged += PaintMethodSelection_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 125);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 26;
            label7.Text = "Paint Method";
            // 
            // helpLink
            // 
            helpLink.AutoSize = true;
            helpLink.LinkColor = Color.FromArgb(128, 255, 255);
            helpLink.Location = new Point(203, 17);
            helpLink.Name = "helpLink";
            helpLink.Size = new Size(61, 15);
            helpLink.TabIndex = 28;
            helpLink.TabStop = true;
            helpLink.Text = "Help Page";
            // 
            // closeLocation
            // 
            closeLocation.AutoSize = true;
            closeLocation.Location = new Point(142, 366);
            closeLocation.Name = "closeLocation";
            closeLocation.Size = new Size(107, 15);
            closeLocation.TabIndex = 34;
            closeLocation.Text = "%PLACEHOLDER%";
            // 
            // openLocation
            // 
            openLocation.AutoSize = true;
            openLocation.Location = new Point(142, 309);
            openLocation.Name = "openLocation";
            openLocation.Size = new Size(107, 15);
            openLocation.TabIndex = 33;
            openLocation.Text = "%PLACEHOLDER%";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(35, 366);
            label10.Name = "label10";
            label10.Size = new Size(85, 15);
            label10.TabIndex = 32;
            label10.Text = "Close Location";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(35, 309);
            label11.Name = "label11";
            label11.Size = new Size(85, 15);
            label11.TabIndex = 31;
            label11.Text = "Open Location";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 285);
            label12.Name = "label12";
            label12.Size = new Size(114, 15);
            label12.TabIndex = 30;
            label12.Text = "Color Enter Override";
            // 
            // setColorEnter
            // 
            setColorEnter.BackColor = Color.SteelBlue;
            setColorEnter.BackgroundColor = Color.SteelBlue;
            setColorEnter.BorderColor = Color.PaleVioletRed;
            setColorEnter.BorderRadius = 10;
            setColorEnter.BorderSize = 0;
            setColorEnter.FlatStyle = FlatStyle.Flat;
            setColorEnter.ForeColor = Color.White;
            setColorEnter.Location = new Point(140, 281);
            setColorEnter.Name = "setColorEnter";
            setColorEnter.Size = new Size(109, 23);
            setColorEnter.TabIndex = 29;
            setColorEnter.Text = "Set";
            setColorEnter.TextColor = Color.White;
            setColorEnter.UseVisualStyleBackColor = true;
            setColorEnter.Click += setColorEnter_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 339);
            label13.Name = "label13";
            label13.Size = new Size(106, 15);
            label13.TabIndex = 36;
            label13.Text = "Color Exit Override";
            // 
            // setColorExit
            // 
            setColorExit.BackColor = Color.SteelBlue;
            setColorExit.BackgroundColor = Color.SteelBlue;
            setColorExit.BorderColor = Color.PaleVioletRed;
            setColorExit.BorderRadius = 10;
            setColorExit.BorderSize = 0;
            setColorExit.FlatStyle = FlatStyle.Flat;
            setColorExit.ForeColor = Color.White;
            setColorExit.Location = new Point(140, 335);
            setColorExit.Name = "setColorExit";
            setColorExit.Size = new Size(109, 23);
            setColorExit.TabIndex = 35;
            setColorExit.Text = "Set";
            setColorExit.TextColor = Color.White;
            setColorExit.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 398);
            label14.Name = "label14";
            label14.Size = new Size(107, 15);
            label14.TabIndex = 40;
            label14.Text = "Hex Input Override";
            // 
            // setHexInput
            // 
            setHexInput.BackColor = Color.SteelBlue;
            setHexInput.BackgroundColor = Color.SteelBlue;
            setHexInput.BorderColor = Color.PaleVioletRed;
            setHexInput.BorderRadius = 10;
            setHexInput.BorderSize = 0;
            setHexInput.FlatStyle = FlatStyle.Flat;
            setHexInput.ForeColor = Color.White;
            setHexInput.Location = new Point(142, 394);
            setHexInput.Name = "setHexInput";
            setHexInput.Size = new Size(109, 23);
            setHexInput.TabIndex = 39;
            setHexInput.Text = "Set";
            setHexInput.TextColor = Color.White;
            setHexInput.UseVisualStyleBackColor = true;
            // 
            // hexInputLocation
            // 
            hexInputLocation.AutoSize = true;
            hexInputLocation.Location = new Point(144, 425);
            hexInputLocation.Name = "hexInputLocation";
            hexInputLocation.Size = new Size(107, 15);
            hexInputLocation.TabIndex = 38;
            hexInputLocation.Text = "%PLACEHOLDER%";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(37, 425);
            label16.Name = "label16";
            label16.Size = new Size(84, 15);
            label16.TabIndex = 37;
            label16.Text = "Input Location";
            // 
            // CanvasSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(510, 459);
            Controls.Add(label14);
            Controls.Add(setHexInput);
            Controls.Add(hexInputLocation);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(setColorExit);
            Controls.Add(closeLocation);
            Controls.Add(openLocation);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(setColorEnter);
            Controls.Add(helpLink);
            Controls.Add(paintMethodSelection);
            Controls.Add(label7);
            Controls.Add(movePointRightButton);
            Controls.Add(movePointLeftButton);
            Controls.Add(movePointUpButton);
            Controls.Add(movePointDownButton);
            Controls.Add(visualizeBounds);
            Controls.Add(screenSelection);
            Controls.Add(label6);
            Controls.Add(bottomRightLabel);
            Controls.Add(topLeftLabel);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(confirmConfig);
            Controls.Add(speedMultiplier);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(startButton);
            Controls.Add(label1);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlLightLight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(280, 300);
            Name = "CanvasSetup";
            Text = "Canvas Setup";
            ((System.ComponentModel.ISupportInitialize)speedMultiplier).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stepCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Pixeler.Net.Controls.CurvedButton startButton;
        private Label label2;
        private Label label4;
        private NumericUpDown speedMultiplier;
        private Pixeler.Net.Controls.CurvedButton confirmConfig;
        private Label label3;
        private Label label5;
        private Label bottomRightLabel;
        private Label topLeftLabel;
        private Label label6;
        private ComboBox screenSelection;
        private Pixeler.Net.Controls.CurvedButton visualizeBounds;
        private Pixeler.Net.Controls.CurvedButton movePointDownButton;
        private Pixeler.Net.Controls.CurvedButton movePointUpButton;
        private Pixeler.Net.Controls.CurvedButton movePointLeftButton;
        private Pixeler.Net.Controls.CurvedButton movePointRightButton;
        private Pixeler.Net.Controls.NewRadioButton topLeftPoint;
        private Pixeler.Net.Controls.NewRadioButton bottomRightPoint;
        private Pixeler.Net.Controls.NewRadioButton bothPoints;
        private Panel panel1;
        private NumericUpDown stepCount;
        private ComboBox paintMethodSelection;
        private Label label7;
        private LinkLabel helpLink;
        private Label closeLocation;
        private Label openLocation;
        private Label label10;
        private Label label11;
        private Label label12;
        private Controls.CurvedButton setColorEnter;
        private Label label13;
        private Controls.CurvedButton setColorExit;
        private Label label14;
        private Controls.CurvedButton setHexInput;
        private Label hexInputLocation;
        private Label label16;
    }
}