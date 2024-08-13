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
            label1 = new Label();
            startButton = new Button();
            label2 = new Label();
            label4 = new Label();
            speedMultiplier = new NumericUpDown();
            confirmConfig = new Button();
            label3 = new Label();
            label5 = new Label();
            bottomRightLabel = new Label();
            topLeftLabel = new Label();
            label6 = new Label();
            screenSelection = new ComboBox();
            visualizeBounds = new Button();
            movePointDownButton = new Button();
            movePointUpButton = new Button();
            movePointLeftButton = new Button();
            movePointRightButton = new Button();
            topLeftPoint = new RadioButton();
            bottomRightPoint = new RadioButton();
            bothPoints = new RadioButton();
            panel1 = new Panel();
            stepCount = new NumericUpDown();
            paintMethodSelection = new ComboBox();
            label7 = new Label();
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
            startButton.Location = new Point(140, 50);
            startButton.Name = "startButton";
            startButton.Size = new Size(109, 23);
            startButton.TabIndex = 1;
            startButton.Text = "Set";
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
            speedMultiplier.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            speedMultiplier.Name = "speedMultiplier";
            speedMultiplier.Size = new Size(109, 23);
            speedMultiplier.TabIndex = 8;
            speedMultiplier.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            speedMultiplier.ValueChanged += SpeedMultiplier_ValueChanged;
            // 
            // confirmConfig
            // 
            confirmConfig.Location = new Point(15, 232);
            confirmConfig.Name = "confirmConfig";
            confirmConfig.Size = new Size(234, 21);
            confirmConfig.TabIndex = 9;
            confirmConfig.Text = "Confirm Configuration";
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
            visualizeBounds.Location = new Point(293, 230);
            visualizeBounds.Name = "visualizeBounds";
            visualizeBounds.Size = new Size(200, 23);
            visualizeBounds.TabIndex = 16;
            visualizeBounds.Text = "Visualize Bounds";
            visualizeBounds.UseVisualStyleBackColor = true;
            visualizeBounds.Click += VisualizeBounds_Click;
            // 
            // movePointDownButton
            // 
            movePointDownButton.Enabled = false;
            movePointDownButton.Location = new Point(416, 152);
            movePointDownButton.Name = "movePointDownButton";
            movePointDownButton.Size = new Size(35, 35);
            movePointDownButton.TabIndex = 18;
            movePointDownButton.Text = "🡣";
            movePointDownButton.UseVisualStyleBackColor = true;
            movePointDownButton.Click += MovePointDownButton_Click;
            // 
            // movePointUpButton
            // 
            movePointUpButton.Enabled = false;
            movePointUpButton.Location = new Point(416, 62);
            movePointUpButton.Name = "movePointUpButton";
            movePointUpButton.Size = new Size(35, 35);
            movePointUpButton.TabIndex = 19;
            movePointUpButton.Text = "🡡";
            movePointUpButton.UseVisualStyleBackColor = true;
            movePointUpButton.Click += MovePointUpButton_Click;
            // 
            // movePointLeftButton
            // 
            movePointLeftButton.Enabled = false;
            movePointLeftButton.Location = new Point(371, 107);
            movePointLeftButton.Name = "movePointLeftButton";
            movePointLeftButton.Size = new Size(35, 35);
            movePointLeftButton.TabIndex = 20;
            movePointLeftButton.Text = "🡠";
            movePointLeftButton.UseVisualStyleBackColor = true;
            movePointLeftButton.Click += MovePointLeftButton_Click;
            // 
            // movePointRightButton
            // 
            movePointRightButton.Enabled = false;
            movePointRightButton.Location = new Point(461, 107);
            movePointRightButton.Name = "movePointRightButton";
            movePointRightButton.Size = new Size(35, 35);
            movePointRightButton.TabIndex = 21;
            movePointRightButton.Text = "🡢";
            movePointRightButton.UseVisualStyleBackColor = true;
            movePointRightButton.Click += MovePointRightButton_Click;
            // 
            // topLeftPoint
            // 
            topLeftPoint.AutoSize = true;
            topLeftPoint.Checked = true;
            topLeftPoint.Enabled = false;
            topLeftPoint.Location = new Point(6, 51);
            topLeftPoint.Name = "topLeftPoint";
            topLeftPoint.Size = new Size(67, 19);
            topLeftPoint.TabIndex = 22;
            topLeftPoint.TabStop = true;
            topLeftPoint.Text = "Top Left";
            topLeftPoint.UseVisualStyleBackColor = true;
            topLeftPoint.CheckedChanged += TopLeftPoint_CheckedChanged;
            // 
            // bottomRightPoint
            // 
            bottomRightPoint.AutoSize = true;
            bottomRightPoint.Enabled = false;
            bottomRightPoint.Location = new Point(6, 104);
            bottomRightPoint.Name = "bottomRightPoint";
            bottomRightPoint.Size = new Size(96, 19);
            bottomRightPoint.TabIndex = 23;
            bottomRightPoint.Text = "Bottom Right";
            bottomRightPoint.UseVisualStyleBackColor = true;
            bottomRightPoint.CheckedChanged += BottomRightPoint_CheckedChanged;
            // 
            // bothPoints
            // 
            bothPoints.AutoSize = true;
            bothPoints.Enabled = false;
            bothPoints.Location = new Point(6, 79);
            bothPoints.Name = "bothPoints";
            bothPoints.Size = new Size(50, 19);
            bothPoints.TabIndex = 24;
            bothPoints.Text = "Both";
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
            // CanvasSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 261);
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
        private Button startButton;
        private Label label2;
        private Label label4;
        private NumericUpDown speedMultiplier;
        private Button confirmConfig;
        private Label label3;
        private Label label5;
        private Label bottomRightLabel;
        private Label topLeftLabel;
        private Label label6;
        private ComboBox screenSelection;
        private Button visualizeBounds;
        private Button movePointDownButton;
        private Button movePointUpButton;
        private Button movePointLeftButton;
        private Button movePointRightButton;
        private RadioButton topLeftPoint;
        private RadioButton bottomRightPoint;
        private RadioButton bothPoints;
        private Panel panel1;
        private NumericUpDown stepCount;
        private ComboBox paintMethodSelection;
        private Label label7;
    }
}