using QuickApp.Data.Infrastructure;
using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Domain.SqlReposities
{
    public class SqlServerDbContext:SqlDbContext
    {
        public SqlServerDbContext()
            : base("Server=(local);DataBase=QuickAppTest1;uid=sa;pwd=aaaa1111!")
        { 
        
        }
    }
}
