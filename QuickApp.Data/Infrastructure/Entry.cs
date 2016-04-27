using QuickApp.Common.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    public abstract class Entry:IEntry
    {
        protected string tableName;
        protected IList<String> keys;

        public string TableName { get { return this.tableName; } }

        public Type EntityType { get; private set; }

        public IList<String> Keys
        {
            get { return this.keys; }
        }

        public Entry(Type entityType)
        {
            this.EntityType = entityType;
            this.setTableName(entityType);
        }

        public bool Execute(object entity, OperationState operationState)
        {
            if (operationState == Infrastructure.OperationState.UnChanged)
                return true;

            switch (operationState)
            {
                case Infrastructure.OperationState.Add: return Add(entity);
                case Infrastructure.OperationState.Modify: return Update(entity);
                case Infrastructure.OperationState.Delete: return Delete(entity);
            }

            return false;
        }

        public abstract TEntity Find<TEntity>(params object[] ids) where TEntity : class;

        public abstract TEntity FindForSql<TEntity>(string strsql) where TEntity : class;

        public abstract IEnumerable<TEntity> FindAll<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null) where TEntity : class;

        public abstract IEnumerable<TEntity> FindAllForSql<TEntity>(string strsql) where TEntity : class;

        protected abstract bool Add(object entity);

        protected abstract bool Update(object entity);

        protected abstract bool Delete(object entity);

        private void setTableName(Type entityType)
        {
            if (String.IsNullOrWhiteSpace(this.tableName))
            {
                TableAttribute tableAttribute = ReflectionExtension.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TableAttribute>(entityType);
                if (tableAttribute == null)
                    this.tableName = entityType.Name;
                else
                    this.tableName = tableAttribute.Name;
            }
        }







    }
}
