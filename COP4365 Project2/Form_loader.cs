using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_Project2
{
    public partial class Form_Loader : Form
    {
        private List<aCandlestick> tempList = new List<aCandlestick>(1024);
        private BindingList<aCandlestick> candlesticks { get; set; }
        private string referenceHeader = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

        public Form_Loader()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        //Function for reading candlesticks given a filename
        private List <aCandlestick> LoadCandlesticks(string filename)
        {
            tempList.Clear();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                string header = sr.ReadLine();
                if (header == referenceHeader)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        aCandlestick newCandlestick = new aCandlestick(line);
                        tempList.Add(newCandlestick);
                    }
                    tempList.Reverse(); //reverseing so the list is oldest to newest
                }
                else
                {
                    MessageBox.Show("The file format is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            return tempList;
        }

        //Filters candlesticks based on given dates
        private void filterCandlesticks()
        {
            candlesticks = new BindingList<aCandlestick>();
            //MAKE SURE CANDLESTICKS ARE IN RANGE
            foreach (var candlestick in tempList)
            {
                if (candlestick.Date > dateTimePicker_endDate.Value)
                {
                    break;
                }
                if (candlestick.Date >= dateTimePicker_startDate.Value)
                {
                    candlesticks.Add(candlestick);
                }
            }
        }

        //For each file, loads candlesticks into templist, filters them, and makes a new form
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            foreach (var fileName in openFileDialog_stockLoader.FileNames)
            {
                tempList.Clear();
                tempList = LoadCandlesticks(fileName);
                filterCandlesticks();
                newForm(candlesticks);
            }
        }

        //Shows the file dialog box when the load stocks button is clicked
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog_stockLoader.ShowDialog();
        }

        //This function creates a new form, passes in data, and displays it
        private void newForm(BindingList<aCandlestick> candlesticks)
        {
            Form_viewer newForm = new Form_viewer();
            newForm.LoadData(candlesticks);
            newForm.Show();
        }
    }
}
