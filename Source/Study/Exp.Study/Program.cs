using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Exp.Study
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] formats = new string[] { "N", "C", "E", "F", "G", "G28" };
            var number = 123.44m;
            var number2 = 123m;
            System.Threading.Thread.CurrentThread.CurrentCulture= new CultureInfo("Zh-cn");
            
            foreach (var format in formats)
            {


                Console.WriteLine(string.Format(" {0} is {1}    {2}", format, number.ToString(format), number2.ToString(format)));

            }
            int[] data = new int[] { 1,2,3,4,5,6,7,89};
            var result = string.Join(",", data);
            
            Console.WriteLine(result);

            Console.Read();
        }


    }

    public class NumberFormatHelper
    {


    }


}
