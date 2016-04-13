/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/13 星期三 16:52:32
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp;
using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using QuickApp.Common.Test.Domain.Reposities;
using QuickApp.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Test
{
    /// <summary>
    /// <see cref="Gobal"/>
    /// </summary>
    public class TestBase
    {
        protected IQuickApp app;

        public TestBase()
        {
            this.app = new DefaultQuickApp();
            this.app.Initialize();
            this.app.DependencyContainer.Register<DbContext,EFDbContext>();
            this.app.DependencyContainer.Register<IRepositoryContext, EFRepositoryContext>();
            this.app.DependencyContainer.Register(Assembly.Load("QuickApp.Common.Test"));
        }
    }
}
