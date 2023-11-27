using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace COP4365_Project3
{
    public partial class Form_Loader : Form
    {
        // Stores candlestick data with filenames as keys
        private Dictionary<string, List<smartCandlestick>> _fileCandlesticks;

        // Reference header for validating file format
        private const string ReferenceHeader = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

        public Form_Loader()
        {
            InitializeComponent();
            _fileCandlesticks = new Dictionary<string, List<smartCandlestick>>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize start date to January 1, 2023
            dateTimePicker_startDate.Value = new DateTime(2023, 1, 1);
        }

        //Function for reading candlesticks given a filename
        private List<smartCandlestick> LoadCandlesticks(string filename)
        {
            var tempList = new List<smartCandlestick>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                string header = sr.ReadLine();
                if (header == ReferenceHeader)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var newCandlestick = new smartCandlestick(line);
                        tempList.Add(newCandlestick);
                    }
                    tempList.Reverse(); // Reverse for chronological order
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
                _fileCandlesticks[fileName] = candlesticks;
                NewForm(fileName, startDate, endDate);
            }
        }

        //Shows the file dialog box when the load stocks button is clicked
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            openFileDialog_stockLoader.ShowDialog();
        }

        // Creates and displays a new form for visualizing data
        private void NewForm(string fileName, DateTime startDate, DateTime endDate)
        {
            var newForm = new Form_viewer(Path.GetFileNameWithoutExtension(fileName), _fileCandlesticks[fileName], startDate, endDate);
            newForm.Show();
        }
    }
}
