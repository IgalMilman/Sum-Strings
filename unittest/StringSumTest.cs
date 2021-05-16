using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using sumstrings;

namespace unittest
{
    [TestClass]
    public class StringSumTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestSumStringsShortZeroEqual()
        {
            Assert.AreEqual("000", StringSum.SumStringsAsString("000", "000"));
        }

        [TestMethod]
        public void TestSumStringsShortOnesEqual()
        {
            Assert.AreEqual("1110", StringSum.SumStringsAsString("111", "111"));
        }

        [TestMethod]
        public void TestSumStringsShortZeroAndOnesEqual()
        {
            Assert.AreEqual("111", StringSum.SumStringsAsString("101", "010"));
        }

        [TestMethod]
        public void TestSumStringsLongZeroEqual()
        {
            Assert.AreEqual("000000000000000000000000000000000000", StringSum.SumStringsAsString("000000000000000000000000000000000000", "000000000000000000000000000000000000"));
        }

        [TestMethod]
        public void TestSumStringsLongOnesEqual()
        {
            Assert.AreEqual("1111111111111111111111111111111110", StringSum.SumStringsAsString("111111111111111111111111111111111", "111111111111111111111111111111111"));
        }

        [TestMethod]
        public void TestSumStringsLongZeroAndOnesEqual()
        {
            Assert.AreEqual("1111111111111111111111111111", StringSum.SumStringsAsString("1010101010101010101010101010", "0101010101010101010101010101"));
        }

        [TestMethod]
        public void TestSumStringsLongZeroAndOnesNotEqual()
        {
            Assert.AreEqual("1111111111111", StringSum.SumStringsAsString("11111", "1111111100000"));
        }

        public string generateString(Random random, int length, AvailableBases numberBase = AvailableBases.Two)
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<length; ++i)
            {
                int intNum = random.Next(0, (int)numberBase);
                sb.Append((char)('0' + intNum));
            }
            return sb.ToString();
        }

        [TestMethod]
        public void TestSumStringsRandom()
        {
            Random random = new Random();
            for (int i = 0; i < 25; ++i)
            {
                string s1 = generateString(random, random.Next(2, 7));
                string s2 = generateString(random, random.Next(2, 7));
                Int64 n1 = Convert.ToInt64(s1, 2);
                Int64 n2 = Convert.ToInt64(s2, 2);
                this.TestContext.WriteLine(String.Format("Test {4}, Trying to sum {0} and {1}. Integer values {2} and {3}", s1, s2, n1, n2, i));
                Int64 res = StringSum.SumStrings(s1, s2);
                Assert.AreEqual(n1 + n2, res);
                Assert.AreEqual(n1 + n2, StringSum.SumStringBinary(s1, s2));
            }
        }

        [TestMethod]
        public void TestSumStringsRandomBaseEight()
        {
            Random random = new Random();
            for (int i = 0; i < 25; ++i)
            {
                AvailableBases numberBase = AvailableBases.Eight;
                string s1 = generateString(random, random.Next(2, 7), numberBase);
                string s2 = generateString(random, random.Next(2, 7), numberBase);
                Int64 n1 = Convert.ToInt64(s1, (int)numberBase);
                Int64 n2 = Convert.ToInt64(s2, (int)numberBase);
                this.TestContext.WriteLine(String.Format("Test {4}, Trying to sum {0} and {1} with base {5}. Integer values {2} and {3}", s1, s2, n1, n2, i, numberBase));
                Int64 res = StringSum.SumStrings(s1, s2, numberBase);
                Assert.AreEqual(n1 + n2, res);
            }
        }
    }
}
