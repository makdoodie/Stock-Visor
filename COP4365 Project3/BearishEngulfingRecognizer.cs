using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class BearishEngulfingRecognizer : recognizer
    {
        private const double EngulfingThreshold = 0.10; // 10% more engulfing

        public BearishEngulfingRecognizer() : base("Bearish Engulfing", 2) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick first = scsList[0];
            smartCandlestick second = scsList[1];

            bool isSignificantlyLarger = second.BodyRange > first.BodyRange * (1 + EngulfingThreshold);

            return first.IsBullish && second.IsBearish &&
                   second.Open > first.Close &&
                   second.Close < first.Open &&
                   isSignificantlyLarger;
        }
    }
}
