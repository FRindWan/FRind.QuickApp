using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    public interface IEntry
    {
        string TableName { get; }

        Type EntityType { get;  }

        IList<String> Keys { get;  }

        bool Execute(object entity,OperationState operationState);

        TEntity Find<TEntity>(params object[] ids) where TEntity : class;

        TEntity FindForSql<TEntity>(String strsql) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity,bool>> predicate=null) where TEntity : class;

        IEnumerable<TEntity> FindAllForSql<TEntity>(String strsql) where TEntity : class;
    }
}
