using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4365_Project3
{
    public partial class Form_viewer : Form
    {
        private List<smartCandlestick> allCandlesticks;

        internal Form_viewer(List<smartCandlestick> candlesticks, DateTime start, DateTime end)
        {
            InitializeComponent();
            dateTimePicker_startDate.Value = start;
            dateTimePicker_endDate.Value = end;
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
            chart_stockView.DataSource = new BindingList<smartCandlestick>(filteredCandlesticks);
            chart_stockView.DataBind();
        }


        private void button_Refresh_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            LoadData(startDate, endDate);
        }

        private void comboBox_patterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear existing annotations.
            chart_stockView.Annotations.Clear();

            // Get the selected pattern.
            string selectedPattern = comboBox_patterns.SelectedItem.ToString();

            // Highlight the candlesticks based on the selected pattern.
            HighlightCandlesticks(selectedPattern);
        }

        private void HighlightCandlesticks(string pattern)
        {
            foreach (var candlestick in allCandlesticks)
            {
                if (CandlestickMatchesPattern(candlestick, pattern))
                {
                    ArrowAnnotation annotation = CreateAnnotationForCandlestick(candlestick);
                    chart_stockView.Annotations.Add(annotation);
                }
            }

            chart_stockView.Invalidate(); // Refresh the chart to show the annotations.
        }

        private bool CandlestickMatchesPattern(smartCandlestick candlestick, string pattern)
        {
            switch (pattern)
            {
                case "Bullish": return candlestick.IsBullish;
                case "Bearish": return candlestick.IsBearish;
                case "Neutral": return candlestick.IsNeutral;
                case "Doji": return candlestick.IsDoji;
                case "DragonFlyDoji": return candlestick.IsDragonflyDoji;
                case "GravestoneDoji": return candlestick.IsGravestoneDoji;
                case "Marubozu": return candlestick.IsMarubozu;
                case "Hammer": return candlestick.IsHammer;
                case "InvertedHammer": return candlestick.IsInvertedHammer;
                default: return false;
            }
        }

        private ArrowAnnotation CreateAnnotationForCandlestick(smartCandlestick cs)
        {
            // Adjust the position and size of the annotation as needed
            ArrowAnnotation annotation = new ArrowAnnotation
            {
                AnchorDataPoint = chart_stockView.Series[0].Points.FirstOrDefault(p => p.XValue == cs.Date.ToOADate()),
                AnchorX = cs.Date.ToOADate(),
                AnchorY = (double)cs.High,
                Height = (double)-cs.Range,
                Width = 0.8,
                LineColor = Color.Black
            };
            return annotation;
        }

        private void button_clearPatterns_Click(object sender, EventArgs e)
        {
            chart_stockView.Annotations.Clear();
        }
    }
}
