using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class DegreeConverter
    {
        public double ToFahrenheit(double c)
        {
            return (c * 9 / 5) + 32;
        }

        public double ToCelsius(double f)
        {
            return (f - 32) * 5 / 9;
        }
    }
}
