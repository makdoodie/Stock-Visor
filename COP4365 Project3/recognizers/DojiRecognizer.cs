using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class DojiRecognizer : recognizer
    {
        public DojiRecognizer() : base("Doji", 1) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            smartCandlestick scs = scsList[0];
            return scs.IsDoji;
        }
    }
}