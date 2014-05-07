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

            List<string> sysTypeNameList = new List<string>();
            sysTypeNameList.Add(typeof(int).Name);
            sysTypeNameList.Add(typeof(decimal).Name);
            sysTypeNameList.Add(typeof(double).Name);
            sysTypeNameList.Add(typeof(DateTime).Name);
            sysTypeNameList.Add(typeof(string).Name);
            sysTypeNameList.Add(typeof(bool).Name);
            sysTypeNameList.Add(typeof(int?).Name);
            sysTypeNameList.Add(typeof(decimal?).Name);
            sysTypeNameList.Add(typeof(double?).Name);
            sysTypeNameList.Add(typeof(DateTime?).Name);
            sysTypeNameList.Add(typeof(string).Name);
            sysTypeNameList.Add(typeof(bool?).Name);

            sysTypeNameList.Add(typeof(Nullable<int>).Name);
         
        }

       
    }
}
