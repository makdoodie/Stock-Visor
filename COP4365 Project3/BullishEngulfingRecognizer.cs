using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class BullishEngulfingRecognizer : recognizer
    {
        private const double EngulfingThreshold = 0.10; // 10% more engulfing

        public BullishEngulfingRecognizer() : base("Bullish Engulfing", 2) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick first = scsList[0];
            smartCandlestick second = scsList[1];

            bool isSignificantlyLarger = second.BodyRange > first.BodyRange * (1 + EngulfingThreshold);

            return first.IsBearish && second.IsBullish &&
                   second.Open < first.Close &&
                   second.Close > first.Open &&
                   isSignificantlyLarger;
        }
    }
}
