using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphing_Demo
{
    public partial class GraphForm : Form
    {
        Random random = new Random();
        bool IsInitialized = false;
        SymbolData stockSymbolData;
        Pen lightGrayPen = new Pen(Color.LightGray, 0.5f);
        Pen blackPen = new Pen(Color.Black, 1f);
        Pen redPen = new Pen(Color.Red, 1f);
        Font arialFont = new Font("Arial", 10);
        Font tnrFont = new Font("Times New Roman", 10);
        Font tnrFont20 = new Font("Times New Roman", 20);
        T_Transform tTransform = new T_Transform();
        
        public GraphForm(SymbolData data)
        {
            stockSymbolData = data;
            InitializeComponent();
            
            startDatePicker.MinDate = stockSymbolData.Data.Last().Date;
            startDatePicker.MaxDate = stockSymbolData.Data.First().Date;
            endDatePicker.MinDate = startDatePicker.MinDate.AddDays(1);
            endDatePicker.MaxDate = stockSymbolData.Data.First().Date;
            //set start day to 30 days before the end, and the end to the end
            startDatePicker.Value = startDatePicker.MaxDate.Subtract(new TimeSpan(30, 0, 0, 0));
            
            //change name
            this.Text = data.TickerName + " - " + data.CompanyName;
            IsInitialized = true;
            RecalculateGraphBounds();
        }
        Matrix identityMatrix = new Matrix();

        PointF origin = new PointF();

        private void drawCircle(Graphics g, Pen pen, PointF center, float radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2f, radius * 2f);
        }

        private PointF markPoint(Graphics g, PointF pf, float size=10f)
        {
            g.DrawLine(blackPen, pf.X - (size / 2f), pf.Y, pf.X + (size / 2f), pf.Y);
            g.DrawLine(blackPen, pf.X, pf.Y - (size / 2f), pf.X, pf.Y + (size / 2f));
            g.DrawEllipse(blackPen, pf.X - (size / 4f), pf.Y - (size / 4f), (size / 2f), (size / 2f));
            return pf;
        }


        //private void drawAxes(PaintEventArgs e)
        //{
        //    if (graphControlForm.showAxes)
        //    {
        //        e.Graphics.DrawLine(blackPen, 0f, graphControlForm.maxY, 0f, graphControlForm.minY);
        //        e.Graphics.DrawLine(blackPen, graphControlForm.maxX, 0f, graphControlForm.minX, 0f);
        //    }
        //}

        private void GraphForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public bool alreadyClosing = false;

        private void GraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void GraphForm_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
        }


        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDatePicker.MinDate = startDatePicker.Value;
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Transform = tTransform.matrix;
            PointF pf = new PointF(-25f, -25f);

            pf = markPoint(e.Graphics, pf, 60f);


            //drawGrid(e.Graphics);

            //drawAxes(e);

            drawCircle(e.Graphics, blackPen, origin, 25f);
            //e.Graphics.DrawEllipse(blackPen, -25f, 25f, 50f, -50f);

            drawCircle(e.Graphics, redPen, origin, 10f);

            PointF p100100 = new PointF(100f, 100f);
            PointF p500500 = new PointF(500f, 500f);

            e.Graphics.DrawString("(100,100)", arialFont, Brushes.DarkRed, p100100);
            markPoint(e.Graphics, p100100);

            e.Graphics.DrawString("(100,100)", arialFont, Brushes.DarkRed, p500500);
            markPoint(e.Graphics, p500500);

            /*
            Pen graphPen = new Pen(Color.Black, 3);

            List<PointF> pointFL = new List<PointF>();

            for (float x = tTransform.X1; x < tTransform.X2; x += 0.01f)
            {
                float y = (float)Math.Sin(x * 0.02) * x * 0.5f;
                pointFL.Add(new PointF(x, y));
            }

            e.Graphics.DrawLines(graphPen, pointFL.ToArray());

            e.Graphics.Transform = identityMatrix;

            e.Graphics.DrawString("y = sin(x*0.02)*x*0.5", tnrFont20, Brushes.RoyalBlue, tTransform.convertToUV(-90f, -40f));

            e.Graphics.DrawString("(100,100)", arialFont, Brushes.DarkRed, p100100);
            e.Graphics.DrawString("(200,200)", tnrFont, Brushes.DarkRed, p200200);
            /*
            e.Graphics.DrawString("(100,100)", arialFont, Brushes.DarkBlue, tTransform.convertToUV(p100100));
            markPoint(e.Graphics, tTransform.convertToUV(p100100), 20f);
            e.Graphics.DrawString("(200,200)", tnrFont, Brushes.DarkBlue, tTransform.convertToUV(p200200));
            markPoint(e.Graphics, tTransform.convertToUV(p200200), 20f);
            */
            

        }

        private void startDatePicker_ValueChanged_1(object sender, EventArgs e)
        {
            Debug.WriteLine("start change");
           // RecalculateGraphBounds();
        }

        private void RecalculateGraphBounds()
        {
            if (IsInitialized)
            {
                Rectangle subWinRect = splitContainer1.Panel1.ClientRectangle;

                float u1 = subWinRect.X;
                float v1 = subWinRect.Y;
                float u2 = subWinRect.X + subWinRect.Width;
                float v2 = subWinRect.Y + subWinRect.Height;

                float x1 = startDatePicker.Value.DayOfYear; // graphControlForm.minX;
                float y1 = 0; //graphControlForm.maxY;
                float x2 = endDatePicker.Value.DayOfYear; //graphControlForm.maxX;
                float y2 = 1000; //graphControlForm.minY;

                tTransform.setupBoundries(u1, v1, u2, v2, x1, y1, x2, y2);
                tTransform.setupMatrix(false);
            }
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
           // RecalculateGraphBounds();
            Debug.WriteLine("end change");
        }
    }
}
