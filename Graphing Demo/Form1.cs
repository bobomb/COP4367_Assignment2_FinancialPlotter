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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //btnGraphTickerSymbol
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtTickerSymbol.Text.Length > 0)
            {
                //grab the ticker symbol data
                Cursor.Current = Cursors.WaitCursor;
                SymbolData data = SymbolDataGrabber.GetSymbolData(txtTickerSymbol.Text);
                Cursor.Current = Cursors.Default;
                if (data != null)
                {
                    GraphForm gForm = new GraphForm(data);
                    //GraphForm gForm = new GraphForm(SymbolDataGrabber.GetTestData());
                    gForm.MdiParent = this;
                    gForm.Show();

                }    
            }   
        }
    }
}
