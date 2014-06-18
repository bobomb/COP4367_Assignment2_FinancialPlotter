namespace Graphing_Demo
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtTickerSymbol = new System.Windows.Forms.ToolStripTextBox();
            this.btnGraphTickerSymbol = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtTickerSymbol,
            this.btnGraphTickerSymbol,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(929, 41);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(161, 38);
            this.toolStripLabel1.Text = "Enter Ticker Symbol to Graph";
            // 
            // txtTickerSymbol
            // 
            this.txtTickerSymbol.Name = "txtTickerSymbol";
            this.txtTickerSymbol.Size = new System.Drawing.Size(100, 41);
            // 
            // btnGraphTickerSymbol
            // 
            this.btnGraphTickerSymbol.AutoSize = false;
            this.btnGraphTickerSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGraphTickerSymbol.Image = global::Graphing_Demo.Properties.Resources.GraphButton;
            this.btnGraphTickerSymbol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGraphTickerSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGraphTickerSymbol.Name = "btnGraphTickerSymbol";
            this.btnGraphTickerSymbol.Size = new System.Drawing.Size(47, 47);
            this.btnGraphTickerSymbol.Text = "toolStripButton1";
            this.btnGraphTickerSymbol.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(198, 38);
            this.toolStripLabel2.Text = "<- Press after entering ticker symbol";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 651);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Graphing Demo";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGraphTickerSymbol;
        private System.Windows.Forms.ToolStripTextBox txtTickerSymbol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}

