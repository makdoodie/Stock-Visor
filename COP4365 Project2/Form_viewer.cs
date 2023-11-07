using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_Project2
{
    public partial class Form_viewer : Form
    {
        private List<aCandlestick> allCandlesticks;

        internal Form_viewer(List<aCandlestick> candlesticks, DateTime start, DateTime end)
        {
            InitializeComponent();
            allCandlesticks = candlesticks;
            LoadData(start, end); // Initially load the data with the provided date range
        }


        private void Form_viewer_Load(object sender, EventArgs e)
        {

        }

        //Binds a passed in list to the chart
        internal void LoadData(DateTime startDate, DateTime endDate)
        {
            var filteredCandlesticks = allCandlesticks.Where(c => c.Date >= startDate && c.Date <= endDate).ToList();
            chart_stockView.DataSource = new BindingList<aCandlestick>(filteredCandlesticks);
            chart_stockView.DataBind();
        }


        private void button_Refresh_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            LoadData(startDate, endDate);
        }


    }
}
