namespace Graphing_Demo
{
    partial class GraphControlForm
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
            this.labelMinX = new System.Windows.Forms.Label();
            this.textBoxMinX = new System.Windows.Forms.TextBox();
            this.textBoxMaxX = new System.Windows.Forms.TextBox();
            this.labelMaxX = new System.Windows.Forms.Label();
            this.textBoxMaxY = new System.Windows.Forms.TextBox();
            this.labelMaxY = new System.Windows.Forms.Label();
            this.textBoxMinY = new System.Windows.Forms.TextBox();
            this.labelMinY = new System.Windows.Forms.Label();
            this.checkBoxGridLines = new System.Windows.Forms.CheckBox();
            this.checkBoxDrawAxes = new System.Windows.Forms.CheckBox();
            this.checkBoxKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.numericUpDownGraphPenWidth = new System.Windows.Forms.NumericUpDown();
            this.labelGraphPenWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphPenWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMinX
            // 
            this.labelMinX.AutoSize = true;
            this.labelMinX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinX.Location = new System.Drawing.Point(35, 163);
            this.labelMinX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMinX.Name = "labelMinX";
            this.labelMinX.Size = new System.Drawing.Size(75, 29);
            this.labelMinX.TabIndex = 1;
            this.labelMinX.Text = "Min X";
            // 
            // textBoxMinX
            // 
            this.textBoxMinX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinX.Location = new System.Drawing.Point(87, 159);
            this.textBoxMinX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMinX.Name = "textBoxMinX";
            this.textBoxMinX.Size = new System.Drawing.Size(76, 35);
            this.textBoxMinX.TabIndex = 2;
            this.textBoxMinX.Text = "-100.0";
            this.textBoxMinX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMaxX
            // 
            this.textBoxMaxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaxX.Location = new System.Drawing.Point(396, 159);
            this.textBoxMaxX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMaxX.Name = "textBoxMaxX";
            this.textBoxMaxX.Size = new System.Drawing.Size(76, 35);
            this.textBoxMaxX.TabIndex = 4;
            this.textBoxMaxX.Text = "350.0";
            this.textBoxMaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMaxX
            // 
            this.labelMaxX.AutoSize = true;
            this.labelMaxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxX.Location = new System.Drawing.Point(348, 163);
            this.labelMaxX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaxX.Name = "labelMaxX";
            this.labelMaxX.Size = new System.Drawing.Size(80, 29);
            this.labelMaxX.TabIndex = 3;
            this.labelMaxX.Text = "Max X";
            // 
            // textBoxMaxY
            // 
            this.textBoxMaxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaxY.Location = new System.Drawing.Point(239, 25);
            this.textBoxMaxY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMaxY.Name = "textBoxMaxY";
            this.textBoxMaxY.Size = new System.Drawing.Size(76, 35);
            this.textBoxMaxY.TabIndex = 6;
            this.textBoxMaxY.Text = "350.0";
            this.textBoxMaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMaxY
            // 
            this.labelMaxY.AutoSize = true;
            this.labelMaxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxY.Location = new System.Drawing.Point(191, 29);
            this.labelMaxY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaxY.Name = "labelMaxY";
            this.labelMaxY.Size = new System.Drawing.Size(79, 29);
            this.labelMaxY.TabIndex = 5;
            this.labelMaxY.Text = "Max Y";
            // 
            // textBoxMinY
            // 
            this.textBoxMinY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinY.Location = new System.Drawing.Point(239, 303);
            this.textBoxMinY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMinY.Name = "textBoxMinY";
            this.textBoxMinY.Size = new System.Drawing.Size(76, 35);
            this.textBoxMinY.TabIndex = 8;
            this.textBoxMinY.Text = "-100.0";
            this.textBoxMinY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMinY
            // 
            this.labelMinY.AutoSize = true;
            this.labelMinY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinY.Location = new System.Drawing.Point(196, 307);
            this.labelMinY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMinY.Name = "labelMinY";
            this.labelMinY.Size = new System.Drawing.Size(74, 29);
            this.labelMinY.TabIndex = 7;
            this.labelMinY.Text = "Min Y";
            // 
            // checkBoxGridLines
            // 
            this.checkBoxGridLines.AutoSize = true;
            this.checkBoxGridLines.Checked = true;
            this.checkBoxGridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGridLines.Location = new System.Drawing.Point(36, 269);
            this.checkBoxGridLines.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxGridLines.Name = "checkBoxGridLines";
            this.checkBoxGridLines.Size = new System.Drawing.Size(80, 21);
            this.checkBoxGridLines.TabIndex = 9;
            this.checkBoxGridLines.Text = "Grid Lines";
            this.checkBoxGridLines.UseVisualStyleBackColor = true;
            this.checkBoxGridLines.CheckedChanged += new System.EventHandler(this.invalidaateGraphForm);
            // 
            // checkBoxDrawAxes
            // 
            this.checkBoxDrawAxes.AutoSize = true;
            this.checkBoxDrawAxes.Checked = true;
            this.checkBoxDrawAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDrawAxes.Location = new System.Drawing.Point(36, 287);
            this.checkBoxDrawAxes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxDrawAxes.Name = "checkBoxDrawAxes";
            this.checkBoxDrawAxes.Size = new System.Drawing.Size(56, 21);
            this.checkBoxDrawAxes.TabIndex = 10;
            this.checkBoxDrawAxes.Text = "Axes";
            this.checkBoxDrawAxes.UseVisualStyleBackColor = true;
            this.checkBoxDrawAxes.CheckedChanged += new System.EventHandler(this.invalidaateGraphForm);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Checked = true;
            this.checkBoxKeepAspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(36, 305);
            this.checkBoxKeepAspectRatio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxKeepAspectRatio.Name = "checkBoxKeepAspectRatio";
            this.checkBoxKeepAspectRatio.Size = new System.Drawing.Size(94, 21);
            this.checkBoxKeepAspectRatio.TabIndex = 11;
            this.checkBoxKeepAspectRatio.Text = "Aspect Ratio";
            this.checkBoxKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxKeepAspectRatio.CheckedChanged += new System.EventHandler(this.invalidaateGraphForm);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(196, 155);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(119, 37);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.invalidaateGraphForm);
            // 
            // numericUpDownGraphPenWidth
            // 
            this.numericUpDownGraphPenWidth.DecimalPlaces = 1;
            this.numericUpDownGraphPenWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGraphPenWidth.Location = new System.Drawing.Point(373, 262);
            this.numericUpDownGraphPenWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownGraphPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGraphPenWidth.Name = "numericUpDownGraphPenWidth";
            this.numericUpDownGraphPenWidth.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownGraphPenWidth.TabIndex = 13;
            this.numericUpDownGraphPenWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownGraphPenWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelGraphPenWidth
            // 
            this.labelGraphPenWidth.AutoSize = true;
            this.labelGraphPenWidth.Location = new System.Drawing.Point(370, 245);
            this.labelGraphPenWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGraphPenWidth.Name = "labelGraphPenWidth";
            this.labelGraphPenWidth.Size = new System.Drawing.Size(89, 13);
            this.labelGraphPenWidth.TabIndex = 14;
            this.labelGraphPenWidth.Text = "Graph Pen Width";
            // 
            // GraphControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 340);
            this.Controls.Add(this.labelGraphPenWidth);
            this.Controls.Add(this.numericUpDownGraphPenWidth);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.checkBoxKeepAspectRatio);
            this.Controls.Add(this.checkBoxDrawAxes);
            this.Controls.Add(this.checkBoxGridLines);
            this.Controls.Add(this.textBoxMinY);
            this.Controls.Add(this.labelMinY);
            this.Controls.Add(this.textBoxMaxY);
            this.Controls.Add(this.labelMaxY);
            this.Controls.Add(this.textBoxMaxX);
            this.Controls.Add(this.labelMaxX);
            this.Controls.Add(this.textBoxMinX);
            this.Controls.Add(this.labelMinX);
            this.Location = new System.Drawing.Point(750, 0);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GraphControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GraphControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphControlForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphPenWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMinX;
        private System.Windows.Forms.TextBox textBoxMinX;
        private System.Windows.Forms.TextBox textBoxMaxX;
        private System.Windows.Forms.Label labelMaxX;
        private System.Windows.Forms.TextBox textBoxMaxY;
        private System.Windows.Forms.Label labelMaxY;
        private System.Windows.Forms.TextBox textBoxMinY;
        private System.Windows.Forms.Label labelMinY;
        private System.Windows.Forms.CheckBox checkBoxGridLines;
        private System.Windows.Forms.CheckBox checkBoxDrawAxes;
        private System.Windows.Forms.CheckBox checkBoxKeepAspectRatio;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.NumericUpDown numericUpDownGraphPenWidth;
        private System.Windows.Forms.Label labelGraphPenWidth;

    }
}