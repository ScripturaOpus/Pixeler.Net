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
            label4.Location = new Point(12, 132);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 6;
            label4.Text = "Speed Multiplier";
            // 
            // speedMultiplier
            // 
            speedMultiplier.DecimalPlaces = 1;
            speedMultiplier.Location = new Point(142, 130);
            speedMultiplier.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            speedMultiplier.Name = "speedMultiplier";
            speedMultiplier.Size = new Size(75, 23);
            speedMultiplier.TabIndex = 8;
            speedMultiplier.Value = new decimal(new int[] { 1, 0, 0, 131072 });
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
            // CanvasSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 286);
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
    }
}