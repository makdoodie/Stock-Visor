using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class BullishHaramiRecognizer : recognizer
    {
        private const double HaramiThreshold = 0.80; // 80% of the first candlestick's body

        public BullishHaramiRecognizer() : base("Bullish Harami", 2) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick first = scsList[0];
            smartCandlestick second = scsList[1];

            bool isWithinRange = second.Open < first.Open &&
                                 second.Close > first.Close &&
                                 second.BodyRange <= first.BodyRange * HaramiThreshold;

            return first.IsBearish && second.IsBullish && isWithinRange;
        }
    }
}
