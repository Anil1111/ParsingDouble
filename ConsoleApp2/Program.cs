using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = @"h.txt";
            Func<string, string[]> split = (s) =>
            {
                string[] res = new string[7];
                res[0] = s.Substring(0, 2);
                for (int i = 0; i < 6; i++)
                {
                    res[i + 1] = s.Substring(2 + (i * 19), 19);
                }
                return res;
            };
            var result = from l in File.ReadAllLines(filename)
                         let la = split(l)
                         select new
                         {
                             i = int.Parse(la[0]),
                             d1 = double.Parse(la[1]),
                             d2 = double.Parse(la[2]),
                             d3 = double.Parse(la[3]),
                             d4 = double.Parse(la[4]),
                             d5 = double.Parse(la[5]),
                             d6 = double.Parse(la[6])

                         };
            foreach (var e in result)
            {
                Console.WriteLine($"{e.i}, {e.d1}, {e.d2}, {e.d3}, {e.d4}, {e.d5}, {e.d6}");
            }
        }
    }
}
