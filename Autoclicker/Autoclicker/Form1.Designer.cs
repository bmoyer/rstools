namespace Autoclicker
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.fuzzingCheckbox = new System.Windows.Forms.CheckBox();
            this.clickerIntervalField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fuzzStrengthLabel = new System.Windows.Forms.Label();
            this.fuzzStrengthBox = new System.Windows.Forms.NumericUpDown();
            this.timeDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fuzzStrengthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(161, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fuzzingCheckbox
            // 
            this.fuzzingCheckbox.AutoSize = true;
            this.fuzzingCheckbox.Location = new System.Drawing.Point(72, 12);
            this.fuzzingCheckbox.Name = "fuzzingCheckbox";
            this.fuzzingCheckbox.Size = new System.Drawing.Size(62, 17);
            this.fuzzingCheckbox.TabIndex = 1;
            this.fuzzingCheckbox.Text = "Fuzzing";
            this.fuzzingCheckbox.UseVisualStyleBackColor = true;
            this.fuzzingCheckbox.CheckedChanged += new System.EventHandler(this.fuzzingCheckbox_CheckedChanged);
            // 
            // clickerIntervalField
            // 
            this.clickerIntervalField.Location = new System.Drawing.Point(12, 12);
            this.clickerIntervalField.Name = "clickerIntervalField";
            this.clickerIntervalField.Size = new System.Drawing.Size(42, 20);
            this.clickerIntervalField.TabIndex = 2;
            this.clickerIntervalField.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Interval";
            // 
            // fuzzStrengthLabel
            // 
            this.fuzzStrengthLabel.AutoSize = true;
            this.fuzzStrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fuzzStrengthLabel.Location = new System.Drawing.Point(62, 61);
            this.fuzzStrengthLabel.Name = "fuzzStrengthLabel";
            this.fuzzStrengthLabel.Size = new System.Drawing.Size(72, 13);
            this.fuzzStrengthLabel.TabIndex = 5;
            this.fuzzStrengthLabel.Text = "Fuzz Strength";
            this.fuzzStrengthLabel.Visible = false;
            // 
            // fuzzStrengthBox
            // 
            this.fuzzStrengthBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fuzzStrengthBox.Location = new System.Drawing.Point(72, 38);
            this.fuzzStrengthBox.Name = "fuzzStrengthBox";
            this.fuzzStrengthBox.Size = new System.Drawing.Size(37, 20);
            this.fuzzStrengthBox.TabIndex = 6;
            this.fuzzStrengthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fuzzStrengthBox.Visible = false;
            // 
            // timeDisplay
            // 
            this.timeDisplay.AutoSize = true;
            this.timeDisplay.Location = new System.Drawing.Point(194, 59);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.Size = new System.Drawing.Size(0, 13);
            this.timeDisplay.TabIndex = 7;
            this.timeDisplay.Click += new System.EventHandler(this.timeDisplay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Interval:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 79);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeDisplay);
            this.Controls.Add(this.fuzzStrengthBox);
            this.Controls.Add(this.fuzzStrengthLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clickerIntervalField);
            this.Controls.Add(this.fuzzingCheckbox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "pre-Alpha";
            ((System.ComponentModel.ISupportInitialize)(this.fuzzStrengthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox fuzzingCheckbox;
        private System.Windows.Forms.TextBox clickerIntervalField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fuzzStrengthLabel;
        private System.Windows.Forms.NumericUpDown fuzzStrengthBox;
        private System.Windows.Forms.Label timeDisplay;
        private System.Windows.Forms.Label label2;
    }
}

