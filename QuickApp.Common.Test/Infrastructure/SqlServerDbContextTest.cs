using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Common.Test.Domain.SqlReposities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Common.Test.Infrastructure
{
    [TestClass]
    public class SqlServerDbContextTest
    {
        [TestMethod]
        public void TestSqlServerDbContext()
        {
            SqlServerDbContext context = new SqlServerDbContext();
            context.Initialize();
        }
    }
}
