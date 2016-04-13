/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/11 星期一 10:39:30
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QucikApp.Dependency;
using QucikApp.Domain.UnitOfWorks;
using QucikApp.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using QucikApp.Exceptions;

namespace QuickApp.EntityFramework.UnitOfWorks
{
    /// <summary>
    /// <see cref="EFUnitOfWork"/>
    /// </summary>
    public class EFUnitOfWork:UnitOfWork
    {
        private readonly IDependencyResolver resolver;
        private readonly ILogger<EFUnitOfWork> logger;

        private readonly IDictionary<Type, DbContext> dbContexts;

        public EFUnitOfWork(IDependencyResolver resolver,ILogger<EFUnitOfWork> logger)
        {
            this.resolver = resolver;
            this.logger = logger;

            this.dbContexts = new Dictionary<Type, DbContext>();
        }

        public TDbContext CreateContext<TDbContext>()where TDbContext:DbContext
        {
            DbContext context ;
            if (this.dbContexts.TryGetValue(typeof(TDbContext), out context))
            {
                return (TDbContext)context;
            }
            else
            {
                context = this.resolver.Resolver<TDbContext>();
                this.dbContexts.Add(typeof(TDbContext),context);
                return (TDbContext)context;
            }
        }

        protected override void OnPreCommit()
        {
            
        }

        protected override void OnComplateCommit()
        {
            
        }

        protected override void OnCommit()
        {
            TransactionScope transaction = new TransactionScope();
            bool commitStatus = true;
            foreach (DbContext context in this.dbContexts.Values)
            {
                try
                {
                    if (context.SaveChanges() < 0)
                    {
                        commitStatus = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    commitStatus = true;
                    this.logger.Error("提交项目出错!" + ex.ToDetailMessage());
                    break;
                }
            }

            if (!commitStatus)
            {
                transaction.Dispose();
                this.logger.Error("在提交的时候出现错误，本次提交失败！");
                throw new UnitOfWorkException("提交到数据库过程中，出现提交失败，有关细节请查阅日志文件！");
            }

            transaction.Complete();
        }

        protected override void OnRollback()
        {
            
        }

        protected override void OnDispose()
        {
            foreach (DbContext dbContext in this.dbContexts.Values)
            {
                dbContext.Dispose();
            }
            this.dbContexts.Clear();
        }
    }
}
