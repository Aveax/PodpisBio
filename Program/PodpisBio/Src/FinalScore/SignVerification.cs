﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodpisBio.Src.FinalScore
{
    class SignVerification
    {
        public List<double> init(Signature sign, List<Signature> signList, Weight weights)
        {
            List<double> ver = new List<double>();
            foreach(Signature first in signList)
            {
                ver.Add(check(first, sign));
            }

            return ver;
        }

        private double check(Signature first, Signature second/*, Wagi*/)
        {
            double temp = 0;
            double lengthM = checkLengthM(first, second);
            if (lengthM < 0.5)
            {
                return 0;
            }
            double strokesCount = checkStrokesCount(first, second);
            double timeSizeRatio = checkTimeSizeRatio(first, second);
            double timeSizeRatioForEachStroke = checkTimeSizeRatioForEachStroke(first, second);
            double preciseComparison = checkPreciseComparison(first, second);
            /*
             * Inne
             */

            temp = (lengthM + strokesCount + timeSizeRatio + timeSizeRatioForEachStroke + preciseComparison) / 5;
            //temp = lengthM * waga + strokesCount * waga + timeSizeRatio * waga + timeSizeRatioForEachStroke * waga + preciseComparison * waga;

            return temp;
        }

        private double checkLengthM(Signature first, Signature second)
        {
            double temp = 1-(Math.Abs(first.getLengthM()-second.getLengthM()) / first.getLengthM());
            if (temp < 0) { return 0; }

            return temp;
        }

        private double checkStrokesCount(Signature original, Signature testSubject/*, Wagi*/)
        {
            double temp = 1;
            
            

            return temp;
        }

        private double checkTimeSizeRatio(Signature first, Signature second/*, Wagi*/)
        {
            double temp = 1;


            return temp;
        }

        private double checkTimeSizeRatioForEachStroke(Signature first, Signature second/*, Wagi*/)
        {
            double temp = 1;

            return temp;
        }

        private double checkPreciseComparison(Signature first, Signature second/*, Wagi*/)
        {
            DynamicTimeWrapping dtw = new DynamicTimeWrapping();
            if (dtw.calcSimilarity(first, second) < 1100)
                return 0.95;
            if (dtw.calcSimilarity(first, second) < 1200)
                return 0.8;
            if (dtw.calcSimilarity(first, second) < 1500)
                return 0.7;
            if (dtw.calcSimilarity(first, second) < 1450)
                return 0.6;
            if (dtw.calcSimilarity(first, second) < 1500)
                return 0.2;
            return 0;
        }
    }
}
