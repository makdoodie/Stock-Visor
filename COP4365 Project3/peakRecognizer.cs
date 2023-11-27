using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class PeakRecognizer : recognizer
    {
        public PeakRecognizer() : base("Peak", 3) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            // A peak is where the middle candlestick has a higher high than its neighbors
            return scsList[1].High > scsList[0].High && scsList[1].High > scsList[2].High;
        }
    }
}
