/*-------------------------------------------------------------------------
 * 作者：FRind
 * 创建时间： 2016/4/26 星期二 18:26:39
 * 版本号：v1.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/

using QuickApp.Exceptions;
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
        private readonly DataBaseType interpreterDbType;

        public Interpreter(DataBaseType interpreterDbType)
        {
            this.interpreterDbType = interpreterDbType;
        }

        protected DataBaseType InterpreterDbType { get { return this.interpreterDbType; } }

        public string InterpreterQueryBuilder(QueryBuilder queryBuilder, DataBaseType dbType)
        {
            if(this.interpreterDbType!=dbType)
            {
                return null;
            }

            if (queryBuilder.TableName == null || queryBuilder.TableName.Count <= 0)
            {
                throw new QueryInterpreterException("请至少添加一项FromTable！");
            }

            if (queryBuilder.TableName.Count > 1 && (queryBuilder.SelectColumns == null || queryBuilder.SelectColumns.Count <= 0))
            {
                throw new QueryInterpreterException("当Table达到两个及两个以上，必须显式指定查询的列！");
            }

            return this.DoInterpreter(queryBuilder);
        }

        protected abstract string DoInterpreter(QueryBuilder queryBuilder);

    }
}
