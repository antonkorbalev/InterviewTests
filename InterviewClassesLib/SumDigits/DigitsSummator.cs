using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewClassesLib.SumDigits
{
    public static class DigitsSummator
    {
        public static ValuePair[] GetSumPairs(int[] values, int x)
        {
            var sortedValues = values.OrderBy(o => o).ToArray();
            var pairs = new List<ValuePair>();

            int j = sortedValues.Length - 1;
            for (var i = 0; i < j; i++)
                while (j > i)
                {
                    if (sortedValues[i] + sortedValues[j] == x)
                        pairs.Add(new ValuePair(sortedValues[i], sortedValues[j]));
                    if (sortedValues[i] + sortedValues[j] < x)
                        break;
                    j--;
                }

            return pairs.ToArray();
        }
    }
}
