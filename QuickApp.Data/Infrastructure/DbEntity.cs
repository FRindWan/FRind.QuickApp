using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    public class DbEntity<TEntity>:IDbEntity where TEntity:class
    {
        public TEntity Entity { get; set; }

        public IEntry Entry { get; set; }

        public OperationState OperationState { get; set; }
        
        public TType Cast<TType>()where TType:class
        {
            return Entity as TType;
        }

        object IDbEntity.Entity { get { return this.Entity; }  }
    }
}
