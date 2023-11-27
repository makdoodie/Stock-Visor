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
        private List<smartCandlestick> allCandlesticks;                                             // Stores all candlesticks data
        private List<smartCandlestick> filteredCandlesticks = new List<smartCandlestick>();         // Stores candlesticks filtered based on the date range
        private List<recognizer> recognizers = new List<recognizer>();                              // Stores instances of different pattern recognizers

        // Constructor for the form, initializes the component and loads initial data
        internal Form_viewer(string filename, List<smartCandlestick> candlesticks, DateTime start, DateTime end)
        {
            InitializeComponent();
            label_ticker.Text = filename + "                        ";
            dateTimePicker_startDate.Value = start;
            dateTimePicker_endDate.Value = end;
            allCandlesticks = candlesticks;
            LoadData(start, end);
        }


        private void Form_viewer_Load(object sender, EventArgs e)
        {
            fillRecognizersList();  // Fills the recognizer list
            
            // Populate the pattern combo box with available patterns
            foreach (var rec in recognizers)
            {
                comboBox_patterns.Items.Add(rec.patternName);
            }
        }

        // Loads data into the chart based on the specified date range
        internal void LoadData(DateTime startDate, DateTime endDate)
        {
            filteredCandlesticks = allCandlesticks.Where(c => c.Date >= startDate && c.Date <= endDate).ToList();
            chart_stockView.DataSource = new BindingList<smartCandlestick>(filteredCandlesticks);
            chart_stockView.DataBind();
        }


        private void button_Refresh_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            LoadData(startDate, endDate);   // Refresh data based on new date range
        }

        private void comboBox_patterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_stockView.Annotations.Clear();                        // Clear existing annotations.
            int selectedPattern = comboBox_patterns.SelectedIndex;      // Get the selected pattern's index
            HighlightCandlesticks(selectedPattern);                     // Highlight the candlesticks based on the selected pattern.
        }

        // Highlight the candlesticks based on the selected pattern.
        private void HighlightCandlesticks(int pattern)
        {
            recognizer currRecognizer = recognizers[pattern];
            var toBeHighlighted = currRecognizer.recognize(filteredCandlesticks);

            foreach (var index in toBeHighlighted)
            {
                var patternCandlesticks = filteredCandlesticks.GetRange(index - currRecognizer.patternSize + 1, currRecognizer.patternSize);
                ArrowAnnotation annotation = CreateAnnotationForPattern(patternCandlesticks);
                chart_stockView.Annotations.Add(annotation);
            }

            chart_stockView.Invalidate(); // Refresh the chart to show the annotations.
        }


        /*        // Highlight the candlesticks based on the selected pattern.
                private void HighlightCandlesticks(int pattern)
                {
                    recognizer currRecognizer = recognizers[pattern];
                    var toBeHighlighted = currRecognizer.recognize(filteredCandlesticks);

                    foreach (var index in toBeHighlighted)
                    {
                        var candlestick = filteredCandlesticks[index];
                        ArrowAnnotation annotation = CreateAnnotationForCandlestick(candlestick);
                        chart_stockView.Annotations.Add(annotation);
                    }

                    chart_stockView.Invalidate(); // Refresh the chart to show the annotations.
                }*/

        // Create an annotation for a given pattern
        private ArrowAnnotation CreateAnnotationForPattern(List<smartCandlestick> patternCandlesticks)
        {
            double anchorX;
            switch (patternCandlesticks.Count)
            {
                case 1:
                    // For single candlestick patterns like Doji
                    anchorX = patternCandlesticks[0].Date.ToOADate();
                    break;
                case 3:
                    // For patterns like Peak or Valley
                    anchorX = patternCandlesticks[1].Date.ToOADate();
                    break;
                default:
                    // For other multi-candlestick patterns
                    anchorX = (patternCandlesticks.First().Date.ToOADate() + patternCandlesticks.Last().Date.ToOADate()) / 2.0;
                    break;
            }

            double highestHigh = (double)patternCandlesticks.Max(cs => cs.High);
            double lowestLow = (double)patternCandlesticks.Min(cs => cs.Low);

            return new ArrowAnnotation
            {
                AnchorDataPoint = chart_stockView.Series[0].Points.FirstOrDefault(p => p.XValue == patternCandlesticks.Last().Date.ToOADate()),
                AnchorX = anchorX,
                AnchorY = highestHigh,
                Height = - (highestHigh - lowestLow),
                Width = 0.8, // Adjust width as needed
                LineColor = Color.Black
            };
        }




        /*// Highlight the candlesticks based on the selected pattern.
        private ArrowAnnotation CreateAnnotationForCandlestick(smartCandlestick cs)
        {
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
        }*/

        private void button_clearPatterns_Click(object sender, EventArgs e)
        {
            chart_stockView.Annotations.Clear();
        }

        // Highlight the candlesticks based on the selected pattern.
        private void fillRecognizersList()
        {
            recognizers.Add(new BullishRecognizer());
            recognizers.Add(new BearishRecognizer());
            recognizers.Add(new NeutralRecognizer());
            recognizers.Add(new DojiRecognizer());
            recognizers.Add(new DragonFlyDojiRecognizer());
            recognizers.Add(new GravestoneDojiRecognizer());
            recognizers.Add(new MarubozuRecognizer());
            recognizers.Add(new HammerRecognizer());
            recognizers.Add(new InvertedHammerRecognizer());
            recognizers.Add(new BullishEngulfingRecognizer());
            recognizers.Add(new BearishEngulfingRecognizer());
            recognizers.Add(new BearishHaramiRecognizer());
            recognizers.Add(new BullishHaramiRecognizer());
            recognizers.Add(new PeakRecognizer());
            recognizers.Add(new ValleyRecognizer());
        }
    }
}
