using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class BearishHaramiRecognizer : recognizer
    {
        private const double HaramiThreshold = 0.80; // 25% of the first candlestick's body

        public BearishHaramiRecognizer() : base("Bearish Harami", 2) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick first = scsList[0];
            smartCandlestick second = scsList[1];

            bool isWithinRange = second.Open > first.Open &&
                                 second.Close < first.Close &&
                                 second.BodyRange <= first.BodyRange * HaramiThreshold;

            return first.IsBullish && second.IsBearish && isWithinRange;
        }
    }
}
