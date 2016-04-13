/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/31 星期四 11:58:48
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="DefaultUnitOfWork"/>
    /// </summary>
    public class DefaultUnitOfWork : UnitOfWork
    {
        public DefaultUnitOfWork(IDependencyResolver dependencyResolver)
        { 
        
        }

        protected override void OnPreCommit()
        {
            
        }

        protected override void OnComplateCommit()
        {
            
        }

        protected override void OnRollback()
        {
            
        }

        protected override void OnDispose()
        {
            
        }

        protected override void OnCommit()
        {
            
        }
    }
}
