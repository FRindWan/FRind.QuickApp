/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 11:24:06
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Domain.Repository;
using QuickApp.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.UnitOfWorks
{
    /// <summary>
    /// <see cref="QuickAppDataUnitOfWork"/>
    /// </summary>
    public class QuickAppDataUnitOfWork:UnitOfWork
    {
        private IList<IRepositoryContext> ContextList = new List<IRepositoryContext>();

        protected override void OnPreCommit()
        {
           
        }

        protected override void OnComplateCommit()
        {
            
        }

        protected override void OnCommit()
        {
            if (this.ContextList.Count <= 0)
            {
                return;
            }

            foreach (IRepositoryContext context in this.ContextList)
            {
               // context.con
            }
        }

        protected override void OnRollback()
        {
            
        }

        protected override void OnDispose()
        {
            
        }
    }
}
