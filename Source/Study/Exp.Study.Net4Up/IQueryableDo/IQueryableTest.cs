using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Exp.Study.Net4Up.IQueryableDo
{
    class IQueryableTest
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class QueryableImpl : IQueryable<T>
    {


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
    }
}
