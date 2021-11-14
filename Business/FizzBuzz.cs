using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class FizzBuzz
    {
        public static string Ask(int number)
        {
            if (number % 3 == 00 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            if (number % 3 == 0)
            {
                return "Fizz";
            }
            if (number % 5 == 0)
            {
                return "Buzz";
            }
            return string.Empty;
        }
    }
}
