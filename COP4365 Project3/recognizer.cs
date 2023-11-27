using System.Collections.Generic;

namespace COP4365_Project3
{
    abstract class recognizer
    {
        public int patternSize { get; private set; }
        public string patternName { get; private set; }

        public recognizer(string pn, int ps)
        {
            patternName = pn;
            patternSize = ps;
        }

        public List<int> recognize(List<smartCandlestick> scsList)
        {

            List<int> result = new List<int>(scsList.Count);
            for (int i = patternSize - 1; i < scsList.Count; ++i)
            {
                List<smartCandlestick> subList = scsList.GetRange(i - patternSize + 1, patternSize);
                if (RecognizePattern(subList)) result.Add(i);
            }
            return result;

        }

        protected abstract bool RecognizePattern(List<smartCandlestick> scsList);
    }
}
