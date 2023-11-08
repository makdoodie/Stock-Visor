using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace COP4365_Project2
{
    public partial class Form_Loader : Form
    {
        private Dictionary<string, List<smartCandlestick>> _fileCandlesticks = new Dictionary<string, List<smartCandlestick>>();

        private string _referenceHeader = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

        public Form_Loader()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker_startDate.Value = new DateTime(2023, 1, 1, 0, 0, 0);
        }
        
        //Function for reading candlesticks given a filename
        private List <smartCandlestick> LoadCandlesticks(string filename)
        {
            var tempList = new List<smartCandlestick>(1024);
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                string header = sr.ReadLine();
                if (header == _referenceHeader)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        smartCandlestick newCandlestick = new smartCandlestick(line);
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


        //For each file, loads candlesticks into templist, filters them, and makes a new form
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            foreach (var fileName in openFileDialog_stockLoader.FileNames)
            {
                var candlesticks = LoadCandlesticks(fileName);
                _fileCandlesticks[fileName] = candlesticks;     // Store candlesticks with the filename as the key
                newForm(fileName, startDate, endDate);          // Pass the filename and date range to the new form
            }
        }


        //Shows the file dialog box when the load stocks button is clicked
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog_stockLoader.ShowDialog();
        }

        //This function creates a new form, passes in data, and displays it
        private void newForm(string fileName, DateTime startDate, DateTime endDate)
        {
            Form_viewer newForm = new Form_viewer(_fileCandlesticks[fileName], startDate, endDate);
            newForm.Show();
        }


    }
}
