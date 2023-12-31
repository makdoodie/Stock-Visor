﻿using System;

namespace COP4365_Project3
{
    internal class smartCandlestick : aCandlestick
    {
        // High level properties
        public float Range { get; private set; }
        public float BodyRange { get; private set; }
        public float TopPrice { get; private set; }
        public float BottomPrice { get; private set; }
        public float UpperTail { get; private set; }
        public float LowerTail { get; private set; }

        // Pattern properties
        public bool IsBullish { get; private set; }
        public bool IsBearish { get; private set; }
        public bool IsNeutral { get; private set; }
        public bool IsMarubozu { get; private set; }
        public bool IsDoji { get; private set; }
        public bool IsDragonflyDoji { get; private set; }
        public bool IsGravestoneDoji { get; private set; }
        public bool IsHammer { get; private set; }
        public bool IsInvertedHammer { get; private set; }

        public smartCandlestick(string csvLine) : base(csvLine)
        {
            CalculateProperties();
            DeterminePatterns();
        }

        private void CalculateProperties()
        {
            Range = (float)(High - Low);
            BodyRange = (float)Math.Abs(Close - Open);
            TopPrice = Math.Max((float)Close, (float)Open);
            BottomPrice = Math.Min((float)Close, (float)Open);
            UpperTail = (float)High - (float)TopPrice;
            LowerTail = (float)BottomPrice - (float)Low;
        }

        private void DeterminePatterns()
        {
            // Define the threshold for considering a candlestick as a Doji
            float dojiThreshold = Range * 0.1f;

            decimal threshold = Open * 0.01m; // 1% of the opening price

            if (Close > Open + threshold)
            {
                IsBullish = true;
                IsBearish = false;
                IsNeutral = false;
            }
            else if (Close < Open - threshold)
            {
                IsBullish = false;
                IsBearish = true;
                IsNeutral = false;
            }
            else
            {
                IsBullish = false;
                IsBearish = false;
                IsNeutral = true;
            }

            // Marubozu - no or very small tails
            IsMarubozu = UpperTail < dojiThreshold && LowerTail < dojiThreshold && BodyRange > dojiThreshold;

            // Doji - very small body
            IsDoji = BodyRange < dojiThreshold;

            // Special Doji types
            IsDragonflyDoji = IsDoji && LowerTail < dojiThreshold;
            IsGravestoneDoji = IsDoji && UpperTail < dojiThreshold;

            // Hammer type patterns have a small body and a long lower tail
            IsHammer = BodyRange < Range * 0.3f && LowerTail > Range * 0.7f && UpperTail < Range * 0.3f;
            IsInvertedHammer = BodyRange < Range * 0.3f && UpperTail > Range * 0.7f && LowerTail < Range * 0.3f;
        }
    }
}
