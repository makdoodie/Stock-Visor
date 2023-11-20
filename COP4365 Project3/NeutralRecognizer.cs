using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class NeutralRecognizer : recognizer
    {
        public NeutralRecognizer() : base("Neutral", 1) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick scs = scsList[0];
            return scs.IsNeutral;
        }
    }
}