/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 11:56:28
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="DefaultUnitOfWorkRepositoryContextProvider"/>
    /// </summary>
    public class DefaultUnitOfWorkRepositoryContextProvider<TContext>:IUnitOfWorkRepositoryContextProvider<TContext> where TContext:IRepositoryContextCommit
    {
        private ICurrentUnitOfWorkProvider unitOfWorkProvider;

        public DefaultUnitOfWorkRepositoryContextProvider(ICurrentUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }
        
        public TContext Context
        {
            get { return ((DefaultUnitOfWork)this.unitOfWorkProvider.Current).CreateContext<TContext>(); }
        }
    }
}
