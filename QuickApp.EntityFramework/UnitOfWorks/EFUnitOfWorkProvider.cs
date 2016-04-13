/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 11:56:28
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using QucikApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.EntityFramework.UnitOfWorks
{
    /// <summary>
    /// <see cref="EFUnitOfWorkProvider"/>
    /// </summary>
    public class EFUnitOfWorkProvider<TContext>:IUnitOfWorkContextProvider<TContext> where TContext:DbContext
    {
        private ICurrentUnitOfWorkProvider unitOfWorkProvider;

        public EFUnitOfWorkProvider(ICurrentUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }
        
        public TContext Context
        {
            get { return ((EFUnitOfWork)this.unitOfWorkProvider.Current).CreateContext<TContext>(); }
        }
    }
}
