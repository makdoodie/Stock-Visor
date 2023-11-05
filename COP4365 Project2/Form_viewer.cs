using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_Project2
{
    public partial class Form_viewer : Form
    {
        public Form_viewer()
        {
            InitializeComponent();
        }

        private void Form_viewer_Load(object sender, EventArgs e)
        {

        }

        //Binds a passed in list to the chart
        internal void LoadData(BindingList<aCandlestick> candlesticks)
        {
            chart_stockView.DataSource = candlesticks;
            chart_stockView.DataBind();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {

        }

    }
}
