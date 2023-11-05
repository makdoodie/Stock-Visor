using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project2
{
    internal class aCandlestick
    {
        public string Ticker { get; set; }
        public string Period { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }

        public aCandlestick(string csvLine)
        {
            string[] values = SplitCsv(csvLine);

            this.Ticker = values[0];
            this.Period = values[1];
            this.Date = DateTime.ParseExact(values[2], "MMM d, yyyy", CultureInfo.InvariantCulture);
            this.Open = decimal.TryParse(values[3], out decimal openVal) ? openVal : 0;
            this.High = decimal.TryParse(values[4], out decimal highVal) ? highVal : 0;
            this.Low = decimal.TryParse(values[5], out decimal lowVal) ? lowVal : 0;
            this.Close = decimal.TryParse(values[6], out decimal closeVal) ? closeVal : 0;
            this.Volume = long.TryParse(values[7], out long volumeVal) ? volumeVal : 0;
        }

        private static string[] SplitCsv(string input)
        {
            List<string> values = new List<string>();

            bool inQuotes = false;
            char[] chars = input.ToCharArray();
            string current = "";

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (c == '"')
                {
                    inQuotes = !inQuotes; // Toggle inQuotes state
                    continue; // Move to next character
                }

                if (c == ',' && !inQuotes)
                {
                    values.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }

            // Add the last value
            values.Add(current);

            return values.ToArray();
        }
    }
}