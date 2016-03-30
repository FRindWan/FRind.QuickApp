/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/3/30 星期三 15:29:11
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QucikApp.Domain.UnitOfWorks
{
    /// <summary>
    /// <see cref="CurrentUnitOfWorkProvider"/>
    /// </summary>
    public class CurrentUnitOfWorkProvider:ICurrentUnitOfWorkProvider
    {
        private String ContextKey = "QuickApp.UnitOfWork.Current";

        private static readonly ConcurrentDictionary<string, IUnitOfWork> UnitOfWorkDictionary = new ConcurrentDictionary<string, IUnitOfWork>();

        public IUnitOfWork GetCurrentUnitOfWork()
        {
            String unitOfWorkKey = CallContext.LogicalGetData(this.ContextKey) as string;
            if (String.IsNullOrWhiteSpace(unitOfWorkKey))
            {
                CallContext.FreeNamedDataSlot(this.ContextKey);
                return null;
            }

            IUnitOfWork unitOfWork;
            if (!UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out unitOfWork))
            {
                CallContext.FreeNamedDataSlot(this.ContextKey);
                return null;
            }

            if (unitOfWork.IsDisposed)
            {
                CallContext.FreeNamedDataSlot(this.ContextKey);
                UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);
                return null;
            }

            return unitOfWork;
        }

        public void SetCurrentUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null || unitOfWork.IsDisposed)
                return;

            if (!UnitOfWorkDictionary.TryAdd(unitOfWork.Id.ToString(), unitOfWork))
            {
                return;
            }

            CallContext.LogicalSetData(this.ContextKey, unitOfWork.Id.ToString());
        }

        public IUnitOfWork Current
        {
            get { return this.GetCurrentUnitOfWork(); }
            set { this.SetCurrentUnitOfWork(value); }
        }
    }
}
