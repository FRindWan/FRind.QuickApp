/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 12:05:03
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickApp.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test.Query
{
    /// <summary>
    /// <see cref="QueryBuilderTest"/>
    /// </summary>
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public void TestQueryBuilder()
        {
            new QueryBuilder().FromTable("PersonInfoes").AddSelectColumn("*").AddWhere("UserName='FRind'").ToString();
        }
    }
}
