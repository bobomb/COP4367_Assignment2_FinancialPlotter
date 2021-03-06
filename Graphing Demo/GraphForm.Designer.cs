﻿namespace Graphing_Demo
{
    partial class GraphForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkDrawAxes = new System.Windows.Forms.CheckBox();
            this.radioCloseGraph = new System.Windows.Forms.RadioButton();
            this.radioQuadGraph = new System.Windows.Forms.RadioButton();
            this.radioCandleSticks = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.invalidateTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseMove);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.checkDrawAxes);
            this.splitContainer1.Panel2.Controls.Add(this.radioCloseGraph);
            this.splitContainer1.Panel2.Controls.Add(this.radioQuadGraph);
            this.splitContainer1.Panel2.Controls.Add(this.radioCandleSticks);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.endDatePicker);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.startDatePicker);
            this.splitContainer1.Size = new System.Drawing.Size(833, 501);
            this.splitContainer1.SplitterDistance = 531;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkDrawAxes
            // 
            this.checkDrawAxes.AutoSize = true;
            this.checkDrawAxes.Checked = true;
            this.checkDrawAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDrawAxes.Location = new System.Drawing.Point(18, 164);
            this.checkDrawAxes.Name = "checkDrawAxes";
            this.checkDrawAxes.Size = new System.Drawing.Size(77, 17);
            this.checkDrawAxes.TabIndex = 11;
            this.checkDrawAxes.Text = "Draw Axes";
            this.checkDrawAxes.UseVisualStyleBackColor = true;
            this.checkDrawAxes.CheckedChanged += new System.EventHandler(this.checkDrawAxes_CheckedChanged);
            // 
            // radioCloseGraph
            // 
            this.radioCloseGraph.AutoSize = true;
            this.radioCloseGraph.Checked = true;
            this.radioCloseGraph.Location = new System.Drawing.Point(18, 83);
            this.radioCloseGraph.Name = "radioCloseGraph";
            this.radioCloseGraph.Size = new System.Drawing.Size(75, 17);
            this.radioCloseGraph.TabIndex = 10;
            this.radioCloseGraph.TabStop = true;
            this.radioCloseGraph.Text = "Only Close";
            this.radioCloseGraph.UseVisualStyleBackColor = true;
            this.radioCloseGraph.CheckedChanged += new System.EventHandler(this.radioGraph_CheckedChanged);
            // 
            // radioQuadGraph
            // 
            this.radioQuadGraph.AutoSize = true;
            this.radioQuadGraph.Location = new System.Drawing.Point(18, 129);
            this.radioQuadGraph.Name = "radioQuadGraph";
            this.radioQuadGraph.Size = new System.Drawing.Size(122, 17);
            this.radioQuadGraph.TabIndex = 9;
            this.radioQuadGraph.Text = "Hi/Low/Open/Close";
            this.radioQuadGraph.UseVisualStyleBackColor = true;
            this.radioQuadGraph.CheckedChanged += new System.EventHandler(this.radioGraph_CheckedChanged);
            // 
            // radioCandleSticks
            // 
            this.radioCandleSticks.AutoSize = true;
            this.radioCandleSticks.Location = new System.Drawing.Point(18, 106);
            this.radioCandleSticks.Name = "radioCandleSticks";
            this.radioCandleSticks.Size = new System.Drawing.Size(88, 17);
            this.radioCandleSticks.TabIndex = 8;
            this.radioCandleSticks.Text = "Candle sticks";
            this.radioCandleSticks.UseVisualStyleBackColor = true;
            this.radioCandleSticks.CheckedChanged += new System.EventHandler(this.radioGraph_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "End Date";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(86, 48);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 6;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start date";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(86, 22);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);
            this.startDatePicker.TabIndex = 4;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // invalidateTimer
            // 
            this.invalidateTimer.Enabled = true;
            this.invalidateTimer.Interval = 1000;
            this.invalidateTimer.Tick += new System.EventHandler(this.invalidateTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(18, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "Low";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(137, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 35);
            this.button2.TabIndex = 13;
            this.button2.Text = "High";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(18, 307);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 35);
            this.button3.TabIndex = 14;
            this.button3.Text = "Open";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Enabled = false;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(137, 307);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 35);
            this.button4.TabIndex = 15;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Legend:";
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(833, 501);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphForm";
            this.Text = "GraphForm";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GraphForm_MouseClick);
            this.Resize += new System.EventHandler(this.GraphForm_Resize);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.RadioButton radioCloseGraph;
        private System.Windows.Forms.RadioButton radioQuadGraph;
        private System.Windows.Forms.RadioButton radioCandleSticks;
        private System.Windows.Forms.Timer invalidateTimer;
        private System.Windows.Forms.CheckBox checkDrawAxes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
    }
}