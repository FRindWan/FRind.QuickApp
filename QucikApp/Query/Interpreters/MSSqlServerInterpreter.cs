using QuickApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Query.Interpreters
{
    public class MSSqlServerInterpreter:Interpreter
    {
        public MSSqlServerInterpreter()
        { 
        
        }

        protected override string DoInterpreter(QueryBuilder queryBuilder)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            //{0}  需要插入的Top信息   
            //{1}  需要插入的查询列信息
            //{2}  需要插入的表信息
            //{3}  需要插入的表连接信息
            //{4}  需要插入的条件信息
            //{5}  需要插入的排序信息
            sqlBuilder.Append("select {0} {1} from {2} {3} where {4} {5}");

        }

        protected string GetTopInfo(QueryBuilder queryBuilder)
        { 
            
        }
    }
}
