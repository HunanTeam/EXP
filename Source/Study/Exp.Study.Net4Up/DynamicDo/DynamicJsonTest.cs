using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;
namespace Exp.Study.Net4Up.DynamicDo
{
    class DynamicJsonTest
    {
        static void Main(string[] args)
        {
            var d = new DynamicJsonObj() { 
               Age=12,
               Ids = new int[] { 1,2,3,4,5,6,7,8},
               Name="12312312"

            };
            var str= DynamicJson.Serialize(d);
            var d2 = DynamicJson.Parse(str);
            Console.Read();
        }
    }

    public class DynamicJsonObj
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int[] Ids { get; set; }

    }

}
