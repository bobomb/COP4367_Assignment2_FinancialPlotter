using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    
         SymbolData stockSymbolData;
        
        public GraphForm(SymbolData data)
        {
            stockSymbolData = data;
            InitializeComponent();
            startDatePicker.MinDate = stockSymbolData.Data.Last().Date;
            startDatePicker.MaxDate = stockSymbolData.Data.First().Date;
            endDatePicker.MaxDate = stockSymbolData.Data.First().Date;
            this.Text = data.TickerName + " - " + data.CompanyName;
        }


        Pen lightGrayPen = new Pen(Color.LightGray, 0.5f);
        Pen blackPen = new Pen(Color.Black, 1f);
        Pen redPen = new Pen(Color.Red, 1f);
        Font arialFont = new Font("Arial", 10);
        Font tnrFont = new Font("Times New Roman", 10);
        Font tnrFont20 = new Font("Times New Roman", 20);
        Matrix identityMatrix = new Matrix();

        PointF origin = new PointF();

        public PointF randPointF(float minX, float maxX, float minY, float maxY)
        {
            return new PointF(randFloat(minX, maxX), randFloat(minY,maxY));
        }


        public float randFloat()
        {
            return (float)random.NextDouble();
        }

        public float randFloat(float max)
        {
            return randFloat() * max;
        }

        public float randFloat(float min,float max)
        {
            return randFloat(max-min) + min;
        }


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

        private void drawGrid(Graphics g)
        {

            if (graphControlForm.showGrid)
            {

                float xInc = (float)Math.Pow(10.0, Math.Floor(Math.Log10(tTransform.xRange)) -1);

                for (float x = 0f; x > tTransform.X1; x -= xInc)
                {
                    g.DrawLine(lightGrayPen, x, tTransform.Y1, x, tTransform.Y2);
                }

                for (float x = 0f; x < tTransform.X2; x += xInc)
                {
                    g.DrawLine(lightGrayPen, x, tTransform.Y1, x, tTransform.Y2);
                }
                float yInc = (float)Math.Pow(10.0, Math.Floor(Math.Log10(tTransform.yRange)) -1);

                for (float y = 0f; y < tTransform.Y1; y += yInc)
                {
                    g.DrawLine(lightGrayPen, tTransform.X1, y, tTransform.X2, y);
                }

                for (float y = 0f; y > tTransform.Y2; y -= yInc)
                {
                    g.DrawLine(lightGrayPen, tTransform.X1, y, tTransform.X2, y);
                }
            }
        }

        private void drawAxes(PaintEventArgs e)
        {
            if (graphControlForm.showAxes)
            {
                e.Graphics.DrawLine(blackPen, 0f, graphControlForm.maxY, 0f, graphControlForm.minY);
                e.Graphics.DrawLine(blackPen, graphControlForm.maxX, 0f, graphControlForm.minX, 0f);
            }
        }

        T_Transform tTransform = new T_Transform();
        
        private void SetGraphingTransform(PaintEventArgs e)
        {
            Rectangle winRect = this.ClientRectangle;
            Rectangle subWinRect = winRect;

            float u1 = subWinRect.X;
            float v1 = subWinRect.Y;
            float u2 = subWinRect.X + subWinRect.Width;
            float v2 = subWinRect.Y + subWinRect.Height;

            float x1 = graphControlForm.minX;
            float y1 = graphControlForm.maxY;
            float x2 = graphControlForm.maxX;
            float y2 = graphControlForm.minY;

            tTransform.setupBoundries(u1, v1, u2, v2, x1, y1, x2, y2);
            tTransform.setupMatrix(graphControlForm.aspectRatio);


            //Matrix matrix = new Matrix();

            //matrix.Scale(10f, -10f);

            //matrix.Translate(-200f, -200f);


            ////e.Graphics.Transform = matrix;
            e.Graphics.Transform = tTransform.matrix;
        }

        private void GraphForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public bool alreadyClosing = false;

        private void GraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            alreadyClosing = true;
            if (!graphControlForm.alreadyClosing)
            {
                graphControlForm.Close();
            }
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

            SetGraphingTransform(e);

            PointF pf = new PointF(-25f, -25f);

            pf = markPoint(e.Graphics, pf, 60f);


            drawGrid(e.Graphics);

            drawAxes(e);

            drawCircle(e.Graphics, blackPen, origin, 25f);
            //e.Graphics.DrawEllipse(blackPen, -25f, 25f, 50f, -50f);

            drawCircle(e.Graphics, redPen, origin, 10f);
            //e.Graphics.DrawEllipse(redPen, -10f, -10f, 20f, 20f);


            e.Graphics.DrawLine(blackPen, -5f, 0f, 5f, 0f);
            e.Graphics.DrawLine(blackPen, 0f, -5f, 0f, 5f);

            e.Graphics.DrawLine(redPen, -5f, 50f, 5f, 50f);
            e.Graphics.DrawLine(redPen, 0f, 45f, 0f, 55f);




            PointF p100100 = new PointF(100f, 100f);
            PointF p200200 = new PointF(200f, 200f);

            PointF p150150 = new PointF(150f, 150f);

            e.Graphics.DrawString("(150,150)", arialFont, Brushes.DarkRed, p150150);
            markPoint(e.Graphics, p150150);

            Pen graphPen = new Pen(Color.Black, graphControlForm.graphPenWidth);

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

            e.Graphics.DrawString("(100,100)", arialFont, Brushes.DarkBlue, tTransform.convertToUV(p100100));
            markPoint(e.Graphics, tTransform.convertToUV(p100100), 20f);
            e.Graphics.DrawString("(200,200)", tnrFont, Brushes.DarkBlue, tTransform.convertToUV(p200200));
            markPoint(e.Graphics, tTransform.convertToUV(p200200), 20f);

            List<PointF> polyPoints = new List<PointF>();

            for (int i = 0; i < 50; i++)
            {
                polyPoints.Add(randPointF(100, 200, 200, 300));
            }

            e.Graphics.Transform = tTransform.matrix;

            e.Graphics.DrawPolygon(blackPen, polyPoints.ToArray());

        }
    }
}
