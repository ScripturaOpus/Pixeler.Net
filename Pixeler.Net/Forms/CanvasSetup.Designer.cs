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
            ((System.ComponentModel.ISupportInitialize)speedMultiplier).BeginInit();
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
            startButton.Location = new Point(142, 50);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
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
            label4.Location = new Point(12, 161);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 6;
            label4.Text = "Speed Multiplier";
            // 
            // speedMultiplier
            // 
            speedMultiplier.DecimalPlaces = 1;
            speedMultiplier.Location = new Point(142, 159);
            speedMultiplier.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            speedMultiplier.Name = "speedMultiplier";
            speedMultiplier.Size = new Size(75, 23);
            speedMultiplier.TabIndex = 8;
            speedMultiplier.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            speedMultiplier.ValueChanged += speedMultiplier_ValueChanged;
            // 
            // confirmConfig
            // 
            confirmConfig.Location = new Point(15, 195);
            confirmConfig.Name = "confirmConfig";
            confirmConfig.Size = new Size(202, 23);
            confirmConfig.TabIndex = 9;
            confirmConfig.Text = "Confirm Configuration";
            confirmConfig.UseVisualStyleBackColor = true;
            confirmConfig.Click += ConfirmConfig_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 85);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 10;
            label3.Text = "Top Left";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 111);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 11;
            label5.Text = "Bottom Right";
            // 
            // bottomRightLabel
            // 
            bottomRightLabel.AutoSize = true;
            bottomRightLabel.Location = new Point(142, 111);
            bottomRightLabel.Name = "bottomRightLabel";
            bottomRightLabel.Size = new Size(107, 15);
            bottomRightLabel.TabIndex = 13;
            bottomRightLabel.Text = "%PLACEHOLDER%";
            // 
            // topLeftLabel
            // 
            topLeftLabel.AutoSize = true;
            topLeftLabel.Location = new Point(142, 85);
            topLeftLabel.Name = "topLeftLabel";
            topLeftLabel.Size = new Size(107, 15);
            topLeftLabel.TabIndex = 12;
            topLeftLabel.Text = "%PLACEHOLDER%";
            // 
            // CanvasSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 246);
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
            MinimumSize = new Size(250, 285);
            Name = "CanvasSetup";
            Text = "Canvas Setup";
            ((System.ComponentModel.ISupportInitialize)speedMultiplier).EndInit();
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
    }
}