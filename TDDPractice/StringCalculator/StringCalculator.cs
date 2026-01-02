using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDPractice.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            string numbersAfterDelimiterProcessing = numbers;
            var customDelimiterRegex = new Regex(@"^//(?<delimiter>.)\n");
            var hasCustomDelimiterMatch = customDelimiterRegex.Match(numbersAfterDelimiterProcessing);
            if (hasCustomDelimiterMatch.Success)
            {
                string expectedDelimiter = hasCustomDelimiterMatch.Groups["delimiter"].Value;
                var numbersWithoutDelimiterStart = numbersAfterDelimiterProcessing.Replace($"//{expectedDelimiter}\n", "");
                var removeExpectedCharactersRegex = new Regex($"[0-9{expectedDelimiter}]");
                var badDelimiters = removeExpectedCharactersRegex.Replace(numbersWithoutDelimiterStart, "");
                if (badDelimiters.Length > 0)
                {
                    char badDelimiter = badDelimiters[0];
                    int badDelimiterIndex = numbersWithoutDelimiterStart.IndexOf(badDelimiter);
                    // Need to find position of the number instead of index
                    string validNumbers = numbersWithoutDelimiterStart.Substring(0, badDelimiterIndex);
                    string[] validNumbersParts = validNumbers.Split(expectedDelimiter);
                    int badDelimiterPosition = validNumbersParts.Length + 1;

                    string message = $"'{expectedDelimiter}' expected but '{badDelimiter}' found at position {badDelimiterPosition}.";
                    throw new ArgumentException(message);
                }
            }


            string formattedNumbers = numbersAfterDelimiterProcessing.Replace("\n", ",");
            string[] numberParts = formattedNumbers.Split(',');
            bool containsAllInts = numberParts.All((n) => {
                return int.TryParse(n, out int outputtedInt);
            });

            if(!containsAllInts)
            {
                throw new ArgumentException("String must contain two CSV numbers");
            }

            int result = int.Parse(numberParts.Aggregate((a, b) => 
            (
                int.Parse(a) + int.Parse(b))
                .ToString()
            ));

            return result;
        }
    }
}
