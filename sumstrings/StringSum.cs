using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumstrings
{
    public class StringSum
    {
        private static Tuple<char, char> SumDigits(char a, char b, char c, int numberBase)
        {
            if (Char.IsNumber(a) && Char.IsNumber(b) && Char.IsNumber(c))
            {
                int subRes = a - '0' + b - '0' + c - '0';
                return new Tuple<char, char>((char)('0' + (subRes / numberBase)), (char)('0' + (subRes % numberBase)));
            }
            throw new ArgumentOutOfRangeException();
        }

        public static string SumStringsAsString(string s1, string s2, AvailableBases numberBase = AvailableBases.Two)
        {
            StringBuilder result = new StringBuilder();
            int stringsLength = Math.Max(s1.Length, s2.Length);
            char rollover = '0';
            for (int i = 1; i <= stringsLength; ++i)
            {
                Tuple<char, char> sumResult = SumDigits((i <= s1.Length) ? s1[s1.Length - i] : '0', (i <= s2.Length) ? s2[s2.Length - i] : '0', rollover, (int)numberBase);
                rollover = sumResult.Item1;
                result.Append(sumResult.Item2);
            }
            if (rollover != '0')
            {
                result.Append(rollover);
            }
            return new string(result.ToString().Reverse().ToArray());
        }

        public static Int64 SumStrings(string s1, string s2, AvailableBases numberBase = AvailableBases.Two)
        {
            return Convert.ToInt64(SumStringsAsString(s1, s2, numberBase), (int)numberBase);
        }

        private static Tuple<int, int> SumDigits(char a, char b, int overflow)
        {
            if (Char.IsNumber(a) && Char.IsNumber(b))
            {
                int subRes = a - '0' + b - '0' + overflow;
                return new Tuple<int, int>(subRes / 2, subRes % 2);
            }
            throw new ArgumentOutOfRangeException();
        }

        public static Int64 SumStringBinary(string s1, string s2)
        {
            Int64 result = 0;
            int overflow = 0;
            int stringsLength = Math.Max(s1.Length, s2.Length);
            for (int i = 1; i <= stringsLength; ++i)
            {
                Tuple<int, int> sumResult = SumDigits((i <= s1.Length) ? s1[s1.Length - i] : '0', (i <= s2.Length) ? s2[s2.Length - i] : '0', overflow);
                overflow = sumResult.Item1;
                result += sumResult.Item2 << (i - 1);
            }
            if (overflow > 0)
            {
                result += overflow << stringsLength;
            }
            return result;
        }
    }
}
