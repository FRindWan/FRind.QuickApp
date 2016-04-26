using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Common.Test.Domain.SqlReposities;
using QuickApp.Common.Test.Domain.Model;

namespace QuickApp.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDbContext()
        {
            PersonInfo personInfo=new PersonInfo();
            personInfo.ID=Guid.NewGuid();

            SqlServerDbContext context = new SqlServerDbContext();
            context.Add(personInfo);
            context.SaveChanges();
        }
    }
}
