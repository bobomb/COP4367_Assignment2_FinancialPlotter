using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphing_Demo
{
    public partial class GraphControlForm : Form
    {
        public bool showGrid
        {
            get { return checkBoxGridLines.Checked; }
        }
        public bool showAxes
        {
            get { return checkBoxDrawAxes.Checked; }
        }
        public bool aspectRatio
        {
            get { return checkBoxKeepAspectRatio.Checked; }
        }

        public float minX
        {
            get { return Convert.ToSingle(textBoxMinX.Text); }
        }
        public float maxX
        {
            get { return (float)Convert.ToDouble(textBoxMaxX.Text); }
        }
        public float minY
        {
            get { return (float)Convert.ToDouble(textBoxMinY.Text); }
        }
        public float maxY
        {
            get { return (float)Convert.ToDouble(textBoxMaxY.Text); }
        }

        public float graphPenWidth
        {
            get { return (float)numericUpDownGraphPenWidth.Value; }
        }

        public RectangleF worldRectF
        {
            
            get 
            {
                return new RectangleF(minX,minY,maxX-minX,maxY-minY); 
            }
        }




        public GraphForm graphForm
        {
            set { _graphForm = value; }
            get { return _graphForm; }
        }

        GraphForm _graphForm;

        public GraphControlForm()
        {
            InitializeComponent();
        }

        public bool alreadyClosing = false;

        private void GraphControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            alreadyClosing = true;
            if (!graphForm.alreadyClosing)
            {
                graphForm.Close();
            }
        }

        private void invalidaateGraphForm(object sender, EventArgs e)
        {
            graphForm.Invalidate();
        }

        private void textBoxMaxY_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
