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
        T_Transform tTransform = new T_Transform();
        Panel graphPanel;
        List<SymbolDataEntry> currentRangeData = new List<SymbolDataEntry>();


        Pen lightGrayPen = new Pen(Color.LightGray, 0.5f);
        Pen blackPen = new Pen(Color.Black, 1f);
        Pen redPen = new Pen(Color.Red, 1f);
        Font arialFont = new Font("Arial", 10f);
        Font tnrFont = new Font("Times New Roman", 10);
        Font tnrFont20 = new Font("Times New Roman", 20);
        Matrix identityMatrix = new Matrix();

        PointF origin = new PointF();
        
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

            graphPanel = splitContainer1.Panel1;
        }


        private void drawCircle(Graphics g, Pen pen, PointF center, float radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2f, radius * 2f);
        }

        

        private PointF markPoint(Graphics g, PointF pf, float size=1f)
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
            RecalculateGraphBounds();
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
            Debug.WriteLine("Start date picker change to : {0}", startDatePicker.Value);
            endDatePicker.MinDate = startDatePicker.Value;
            RecalculateGraphBounds();
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            RecalculateGraphBounds();
            Debug.WriteLine("end change");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Transform = tTransform.matrix;
            //drawGrid(e.Graphics);

            //drawAxes(e);

            //drawCircle(e.Graphics, blackPen, new PointF(tTransform.X1 +(tTransform.xRange/2), tTransform.Y1 + (tTransform.yRange/2)) , 50f);
            drawGraph(e.Graphics);
            //e.Graphics.DrawEllipse(blackPen, -25f, 25f, 50f, -50f);     

        }

        private void drawGraph(Graphics graphics)
        {
            if (radioCandleSticks.Checked)
            {
                DrawCandleSticks(graphics);
            }

            if (radioCloseGraph.Checked)
            {
                DrawClose(graphics);
            }

            if (radioQuadGraph.Checked)
            {
                DrawQuad(graphics);
            }
        }

        private void DrawQuad(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        private void DrawClose(Graphics graphics)
        {
            
            if (currentRangeData.Count > 0)
            {
                List<PointF> vertices = new List<PointF>();
                for(int i = 0; i < currentRangeData.Count; i++)
                {
                    
                    vertices.Add(new PointF(i, currentRangeData[i].Close));
                    markPoint(graphics, new PointF(i, currentRangeData[i].Close));
                    StringFormat strf = new StringFormat(StringFormatFlags.FitBlackBox | StringFormatFlags.DirectionVertical);
                    graphics.ResetTransform();
                    graphics.DrawString(currentRangeData[i].Date.ToShortDateString(), arialFont, redPen.Brush, new PointF(i* (graphPanel.ClientRectangle.Width / currentRangeData.Count), 0), strf);
                    graphics.DrawLine(blackPen, new PointF(i * (graphPanel.ClientRectangle.Width / currentRangeData.Count), 0), new PointF(i * (graphPanel.ClientRectangle.Width / currentRangeData.Count), 15f));
                    graphics.Transform = tTransform.matrix;
                    
                    
                }
                DumpDrawPoints(vertices);
                Pen p = new Pen(Color.Red, .05f);
                graphics.DrawLines(p, vertices.ToArray());
                
            }
        }

        private void DumpDrawPoints(List<PointF> vertices)
        {
            Debug.WriteLine("***********************************");
            foreach (var p in vertices)
            {
                Debug.WriteLine("{0}, {1}", p.X, p.Y);
            }
            Debug.WriteLine("***********************************");
        }

        private void DrawCandleSticks(Graphics graphics)
        {
            throw new NotImplementedException();
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

                //calculate max and min of graph
                currentRangeData = stockSymbolData.Data.Where(d => (d.Date <= endDatePicker.Value) && (d.Date >= startDatePicker.Value)).ToList();
                currentRangeData.Reverse();
                Debug.WriteLine("{0}, {1}", startDatePicker.Value, endDatePicker.Value);
                DumpSymbolData(currentRangeData);
                if (currentRangeData.Count > 0)
                {
                    float rangeCloseMax = currentRangeData.Max(entry => entry.Close);
                    float rangeCloseMin = currentRangeData.Min(entry => entry.Close);
                    Debug.WriteLine("Close max = {0}, close min = {1}", rangeCloseMax, rangeCloseMin);

                    float x1 = 0; // graphControlForm.minX;
                    float y1 = rangeCloseMin * .95f ; //graphControlForm.maxY;
                    float x2 = currentRangeData.Count; //graphControlForm.maxX;
                    float y2 = rangeCloseMax * 1.05f; //graphControlForm.minY;

                    tTransform.setupBoundries(u1, v1, u2, v2, x1, y1, x2, y2);
                    tTransform.setupMatrix(false);
                }

            }
        }

        private void DumpSymbolData(List<SymbolDataEntry> rangeSymbols)
        {
            Debug.WriteLine("==============================");
            foreach (var data in rangeSymbols)
            {
                Debug.WriteLine("Date = {0}, close= {1}", data.Date, data.Close);
            }
            Debug.WriteLine("==============================");
        }

        private void invalidateTimer_Tick(object sender, EventArgs e)
        {
           graphPanel.Invalidate();
        }

    }
}
