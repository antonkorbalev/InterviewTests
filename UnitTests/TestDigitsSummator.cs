using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewClassesLib.SumDigits;

namespace UnitTests
{
    [TestClass]
    public class TestDigitsSummator
    {
        // Проверяет корректность нахождения пар чисел,
        // которые в сумме дают x
        [TestMethod]
        public void TestSums()
        {
            var values = new int[7] { 1, 3, 2, 7, 6, -1, -4 };
            var pairs = DigitsSummator.GetSumPairs(values, 3);
            Assert.IsTrue(pairs.Length == 2);
            values = new int[0];
            pairs = DigitsSummator.GetSumPairs(values, 0);
            Assert.IsTrue(pairs.Length == 0);
        }
    }
}
