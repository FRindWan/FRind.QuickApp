/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 18:26:39
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query.Interpreters
{
    /// <summary>
    /// <see cref="Interpreter"/>
    /// </summary>
    public abstract class Interpreter : IInterpreter
    {
        private readonly DbType interpreterDbType;

        public Interpreter(DbType interpreterDbType)
        {
            this.interpreterDbType = interpreterDbType;
        }

        protected DbType InterpreterDbType { get { return this.interpreterDbType; } }

        public string InterpreterQueryBuilder(QueryBuilder queryBuilder, DbType dbType)
        {
            if(this.interpreterDbType!=dbType)
            {
                return null;
            }

            return this.DoInterpreter(queryBuilder);
        }

        protected abstract string DoInterpreter(QueryBuilder queryBuilder);

    }
}
