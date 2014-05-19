using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exp.Study.Net4Up.DynamicDo
{
    class DynamicXmlTest
    {
        static void Main(string[] args)
        {
            var xmlStr = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DynamicDo", "DynamicXm.xml"));
            dynamic xml=new DynamicXml (xmlStr);
            

        }
    }
}
