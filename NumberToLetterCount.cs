using System;
using System.Collections.Generic;

namespace NumberToLetterCount
{
    public class NumberToLetterCount
    {
        private static Dictionary<int, string> numberInWords = null;
        private const int HundredLength = 7; //fixed for  100(HUNDRED)
        private const int OneThousandLength = 11; //Fixed for 1000 (One Thousand)

        static void Main(string[] args)
        {
            if (numberInWords == null)
            {
                InitializeNumberInWords();
            }
            long letterCount = GetLetterCount();
            Console.WriteLine("Letter Count: " + letterCount);
            Console.ReadKey();
        }

        private static int GetLetterCount()
        {
            int letterCount = 0;
            for (int number = 1; number < 1000; number++)
            {
                if (number >= 1 && number < 100)
                {
                    letterCount += GetWordsCountforTens(number);
                }
                if (number >= 100 && number < 1000)
                {
                    letterCount += GetWordsCountforHundreds(number);
                }
            }
            return letterCount + OneThousandLength;
        }

        private static int GetWordsCountforTens(int number)
        {
            if (number >= 1 && number < 20)
            {
                return numberInWords[number].Length;
            }

            int tensLength = 0;
            int tens = (number / 10) * 10;
            var units = number % 10;
            if (tens > 0)
            {
                tensLength = numberInWords[tens].Length;
            }
            if (units > 0)
            {
                tensLength += numberInWords[units].Length;

            }
            return tensLength;
        }
        private static int GetWordsCountforHundreds(int number)
        {
            var hundreds = number / 100;
            var remainder = number % 100;
            int hundredsLength = numberInWords[hundreds].Length + HundredLength;
            if (remainder > 0)
            {
                hundredsLength += 3; // for and
                hundredsLength += GetWordsCountforTens(remainder);
            }

            return hundredsLength;
        }

        private static void InitializeNumberInWords()
        {
            numberInWords = new Dictionary<int, string>()
            {
                    {1, "one"},
                    {2, "two"},
                    {3, "three"},
                    {4, "four"},
                    {5, "five"},
                    {6, "six"},
                    {7, "seven"},
                    {8, "eight"},
                    {9, "nine"},
                    {10, "ten"},
                    {11, "eleven"},
                    {12, "twelve"},
                    {13, "thirteen"},
                    {14, "fourteen"},
                    {15, "fifteen"},
                    {16, "sixteen"},
                    {17, "seventeen"},
                    {18, "eighteen"},
                    {19, "nineteen"},
                    {20, "twenty"},
                    {30, "thirty"},
                    {40, "forty"},
                    {50, "fifty"},
                    {60, "sixty"},
                    {70, "seventy"},
                    {80, "eighty"},
                    {90, "ninety"}
                 };
        }
    }
}
