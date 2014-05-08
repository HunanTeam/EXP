using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Study
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] formats = new string[] { "N", "C", "E", "F", };
            var number = 123.44m;
            foreach (var format in formats)
            {

               
               Console.WriteLine(string.Format(" {0} is {1}", format, number.ToString(format)));

            }
            Console.Read();
        }

       
    }

    public class NumberFormatHelper
    {
       
        
    }

    
}
