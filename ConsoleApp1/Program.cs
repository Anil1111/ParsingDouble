using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileLines = {
            "33 0.573140941467E-01 0.112914262390E-03 0.255553577735E-02 0.497192659486E-04 0.141869181079E-01-0.147813598922E-03",
            "34 0.570076593453E-01 0.100112550891E-03 0.256427138318E-02-0.868691490164E-05 0.142821920093E-01-0.346011975369E-03",
            "35 0.715507714946E-01 0.316132133031E-03-0.106581466521E-01-0.920513736900E-04 0.138018668842E-01-0.212219497066E-03"
        };

            var rex = new Regex(@"\b([-+]?\d+(?:\.\d+(?:E[+-]\d+)?)?)\b", RegexOptions.Compiled);
            foreach (var line in fileLines)
            {

                var dblValues = new List<double>();
                foreach (Match match in rex.Matches(line))
                {
                    string strVal = match.Groups[1].Value;
                    double number = Double.Parse(strVal, NumberFormatInfo.InvariantInfo);
                    dblValues.Add(number);
                }

                Console.WriteLine(string.Join("; ", dblValues));
            }

            Console.ReadLine();
        }
    }
}
