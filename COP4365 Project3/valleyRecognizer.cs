using System.Collections.Generic;

namespace COP4365_Project3
{
    internal class ValleyRecognizer : recognizer
    {
        public ValleyRecognizer() : base("Valley", 3) { }

        protected override bool RecognizePattern(List<smartCandlestick> scsList)
        {
            // A valley is where the middle candlestick has a lower low than its neighbors
            return scsList[1].Low < scsList[0].Low && scsList[1].Low < scsList[2].Low;
        }
    }
}