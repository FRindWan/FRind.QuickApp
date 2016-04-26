using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Exceptions
{
    public class QueryInterpreterException : QuickAppException
    {
        public QueryInterpreterException(String errorMessage)
            : base(errorMessage)
        { 
        }
    }
}
