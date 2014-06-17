namespace Graphing_Demo
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
            this.radioCloseGraph = new System.Windows.Forms.RadioButton();
            this.radioQuadGraph = new System.Windows.Forms.RadioButton();
            this.radioCandleSticks = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.invalidateTimer = new System.Windows.Forms.Timer(this.components);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radioCloseGraph);
            this.splitContainer1.Panel2.Controls.Add(this.radioQuadGraph);
            this.splitContainer1.Panel2.Controls.Add(this.radioCandleSticks);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.endDatePicker);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.startDatePicker);
            this.splitContainer1.Size = new System.Drawing.Size(776, 464);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 0;
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
            this.invalidateTimer.Interval = 10;
            this.invalidateTimer.Tick += new System.EventHandler(this.invalidateTimer_Tick);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 464);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphForm";
            this.Text = "GraphForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphForm_FormClosing);
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
    }
}