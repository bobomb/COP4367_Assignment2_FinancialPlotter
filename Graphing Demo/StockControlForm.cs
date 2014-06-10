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
    public partial class StockControlForm : Form
    {
        SymbolData stockSymbolData;
        public StockControlForm(SymbolData data)
        {
            stockSymbolData = data;
            InitializeComponent();
            startDatePicker.MinDate = stockSymbolData.Data.Last().Date;
            startDatePicker.MaxDate = stockSymbolData.Data.First().Date;
            endDatePicker.MaxDate = stockSymbolData.Data.First().Date;
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDatePicker.MinDate = startDatePicker.Value;
        }
    }
}
