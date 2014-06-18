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
        ToolTip graphToolTip = new ToolTip();             
        Matrix identityMatrix = new Matrix();
        Pen lightGrayPen = new Pen(Color.LightGray, 0.5f);
        Pen blackPen = new Pen(Color.Black, 1f);
        Pen redPen = new Pen(Color.Red, 1f);
        Font arialFont = new Font("Arial", 10f);
        Font tnrFont = new Font("Times New Roman", 10);
        Font tnrFont20 = new Font("Times New Roman", 20);

        public GraphForm(SymbolData data)
        {
            stockSymbolData = data;
            InitializeComponent();
            graphPanel = splitContainer1.Panel1;

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
            graphToolTip.ShowAlways = true;
            
        }


        private void drawCircle(Graphics g, Pen pen, PointF center, float radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2f, radius * 2f);
        }

        private void GraphForm_Resize(object sender, EventArgs e)
        {
            RecalculateGraphBounds();
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
            Pen HighPen = new Pen(Color.Green, .05f);
            Pen LowPen = new Pen(Color.Red, .05f);
            Pen OpenPen = new Pen(Color.Blue, .05f);
            Pen ClosePen = new Pen(Color.Black, .05f);

            if (currentRangeData.Count > 0)
            {
                savedVertices.Clear();
                List<PointF> vertices = new List<PointF>();
                DrawXAxis(graphics);
                DrawYAxis(graphics);
                //high
                for (int i = 0; i < currentRangeData.Count; i++)
                    vertices.Add(new PointF(i, currentRangeData[i].High));
                DrawLineGraph(graphics, vertices.ToArray(), HighPen);
                savedVertices.AddRange(vertices);
                vertices.Clear();
                //low
                for (int i = 0; i < currentRangeData.Count; i++)
                    vertices.Add(new PointF(i, currentRangeData[i].Low));
                DrawLineGraph(graphics, vertices.ToArray(), LowPen);
                savedVertices.AddRange(vertices);
                vertices.Clear();
                //open
                for (int i = 0; i < currentRangeData.Count; i++)
                    vertices.Add(new PointF(i, currentRangeData[i].Open));
                DrawLineGraph(graphics, vertices.ToArray(), OpenPen);
                savedVertices.AddRange(vertices);
                vertices.Clear();
                //close
                for (int i = 0; i < currentRangeData.Count; i++)
                    vertices.Add(new PointF(i, currentRangeData[i].Close));
                DrawLineGraph(graphics, vertices.ToArray(), ClosePen);
                savedVertices.AddRange(vertices);
                vertices.Clear();                
            }
        }

        private void DrawLineGraph(Graphics graphics, PointF[] points, Pen drawPen)
        {
            graphics.Transform = tTransform.matrix;
            graphics.DrawLines(drawPen, points.ToArray());
            graphics.ResetTransform();
            foreach (PointF pf in points)
            {
                drawCircle(graphics, drawPen, GraphToScreen(pf), 5);
            }
            graphics.Transform = tTransform.matrix;
        }
        List<PointF> savedVertices = new List<PointF>();
        private void DrawCandleSticks(Graphics graphics)
        {
            Pen WhiskerPenHigh = new Pen(Color.Green, .05f);
            Pen WhiskerPenLow = new Pen(Color.Red, .05f);
            Pen BearPen = new Pen(Color.Red, .05f);
            Pen ConnectionPen = new Pen(Color.Black, .05f);
            Pen BullPen = new Pen(Color.Green, .05f);
            if (currentRangeData.Count > 0)
            {
                List<PointF> vertices = new List<PointF>();
                DrawXAxis(graphics);
                DrawYAxis(graphics);
                for (int i = 0; i < currentRangeData.Count; i++)
                {
                    //vertices.Add(new PointF(i, currentRangeData[i].Close));
                    //first draw the whisker at the top (high)
                    graphics.DrawLine(WhiskerPenHigh, (float)i - .15f, currentRangeData[i].High, (float)i + .15f, currentRangeData[i].High);
                    //then whisker at the bottom (low)
                    graphics.DrawLine(WhiskerPenLow, (float)i - .15f, currentRangeData[i].Low, (float)i + .15f, currentRangeData[i].Low);
                    
                    //next the box and connecting lines
                    if (currentRangeData[i].Open > currentRangeData[i].Close)
                    {
                        graphics.DrawRectangle(BearPen, (float)i - .25f, currentRangeData[i].Close, .5f, currentRangeData[i].Open - currentRangeData[i].Close);
                        graphics.DrawLine(ConnectionPen, i, currentRangeData[i].High, i, currentRangeData[i].Open);
                        graphics.DrawLine(ConnectionPen, i, currentRangeData[i].Low, i, currentRangeData[i].Close);
                    }
                    else
                    {
                        graphics.DrawRectangle(BullPen, (float)i - .25f, currentRangeData[i].Open, .5f, currentRangeData[i].Close - currentRangeData[i].Open);
                        graphics.DrawLine(ConnectionPen, i, currentRangeData[i].High, i, currentRangeData[i].Close);
                        graphics.DrawLine(ConnectionPen, i, currentRangeData[i].Low, i, currentRangeData[i].Open);
                    }

                    vertices.Add(new PointF(i, (currentRangeData[i].Open + currentRangeData[i].Close) / 2f));                   
                    

                }

                savedVertices = vertices;
                //DumpDrawPoints(vertices);
                graphics.Transform = tTransform.matrix;
            }
        }
        private void DrawClose(Graphics graphics)
        {
            
            if (currentRangeData.Count > 0)
            {
                List<PointF> vertices = new List<PointF>();
                DrawXAxis(graphics);
                DrawYAxis(graphics);
                for(int i = 0; i < currentRangeData.Count; i++)
                {
                    vertices.Add(new PointF(i, currentRangeData[i].Close));         
                }
                savedVertices = vertices;
                //DumpDrawPoints(vertices);
                Pen p = new Pen(Color.Black, .05f);
                graphics.DrawLines(p, vertices.ToArray());
                graphics.ResetTransform();

                foreach (PointF pf in vertices)
                {
                    
                    drawCircle(graphics, Pens.Black, GraphToScreen(pf), 5);
                }
                graphics.Transform = tTransform.matrix;
            }
            
        }

        private void DrawYAxis(Graphics graphics)
        {
            if (checkDrawAxes.Checked)
            {
                graphics.ResetTransform();
                for (int j = 0; j < 11; j++)
                {
                    float val = (graphPanel.ClientRectangle.Height / tTransform.yRange);
                    float div = graphPanel.ClientRectangle.Height / 12;
                    float graphVal = j * (tTransform.yRange / 12) + tTransform.Y2; //the value of the graph at this markpoint
                    float axesDrawVal = div * j;

                    //Debug.WriteLine("draw value {0} at point {1} , {2}", graphVal, 0, graphPanel.ClientRectangle.Height - axesDrawVal);
                    graphics.DrawString(graphVal.ToString(), arialFont, redPen.Brush, new PointF(0f, graphPanel.ClientRectangle.Height - axesDrawVal));
                }
                graphics.Transform = tTransform.matrix;
            }
        }

        private void DrawXAxis(Graphics graphics)
        {
            if (checkDrawAxes.Checked)
            {
                graphics.ResetTransform();
                for (int i = 0; i < currentRangeData.Count; i++)
                {
                    StringFormat strf = new StringFormat(StringFormatFlags.FitBlackBox | StringFormatFlags.DirectionVertical);

                    //draw X axis
                    graphics.DrawString(currentRangeData[i].Date.ToShortDateString(), arialFont, redPen.Brush, new PointF(i * (graphPanel.ClientRectangle.Width / currentRangeData.Count), 0), strf);
                    graphics.DrawLine(blackPen, new PointF(i * (graphPanel.ClientRectangle.Width / currentRangeData.Count), 0), new PointF(i * (graphPanel.ClientRectangle.Width / currentRangeData.Count), 15f));
                    //draw Y axis
                }
                graphics.Transform = tTransform.matrix;
            }

        }

        private PointF GraphToScreen(PointF graph)
        {
            //number of pixels per 1 unit of the graph
            float xVal = (graphPanel.ClientRectangle.Width/ tTransform.xRange);
            float xScreen = xVal * graph.X;
            //Debug.WriteLine("graph x of {0} corresponds to screen x of {1}", graph.X, xScreen);
            float yVal = graphPanel.ClientRectangle.Height / tTransform.yRange;
            float yScreen = graphPanel.ClientRectangle.Height - (yVal * (graph.Y - tTransform.Y2));
           // Debug.WriteLine("graph y of {0} corresponds to screen y of {1}", graph.Y, yScreen);
            return new PointF(xScreen, yScreen);
            
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
                    float y2 = rangeCloseMin *.95f; //graphControlForm.maxY;
                    float x2 = currentRangeData.Count; //graphControlForm.maxX;
                    float y1 = rangeCloseMax *1.1f; //graphControlForm.minY;

                    tTransform.setupBoundries(u1, v1, u2, v2, x1, y1, x2, y2);
                    tTransform.setupMatrix(false);
                }

            }
            graphPanel.Invalidate();
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
           //graphPanel.Invalidate();
        }

        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            bool show = false;
            if (savedVertices.Count > 0)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                PointF mousepos = new PointF(x,y);
                int THRESHHOLD = 5;
                foreach (PointF p in savedVertices)
                {
                    //Debug.WriteLine("checking collision for {0},{1} mouse vs pt {2},{3}", x, y, p.X, p.Y);
                    if (isInCircle(GraphToScreen(p), mousepos, THRESHHOLD))
                    {
                        
                        graphToolTip.Show(currentRangeData[(int)p.X].Date.ToShortDateString() + " " + p.Y, this, e.Location.X, e.Location.Y);
                        show = true;
                        break;
                    }
                }
            }
            if(!show)
                graphToolTip.Hide(this);
            
        }

        private bool isInCircle(PointF circle, PointF p, int radius)
        {
            return (p.X <= (circle.X + radius) &&
                p.X >= (circle.X - radius) &&
                p.Y <= (circle.Y + radius) &&
                p.Y >= (circle.Y - radius));
        }

        private void checkDrawAxes_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateGraphBounds();
        }

        private void radioGraph_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateGraphBounds();
        }
    }
}
