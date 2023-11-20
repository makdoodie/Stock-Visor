using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class MarubozuRecognizer : recognizer
    {
        public MarubozuRecognizer() : base("Marubozu", 1) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick scs = scsList[0];
            return scs.IsMarubozu;
        }
    }
}