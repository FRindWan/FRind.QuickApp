﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using QuickApp.Data.Infrastructure.MSSqlerver;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using QuickApp.Query;
using QuickApp.Infrastructure;
using QuickApp.Config;

namespace QuickApp.Data.Infrastructure
{
    public abstract class SqlDbContext:IDisposable
    {
        private IDbFactory dbFactory;

        private readonly ConcurrentQueue<IDbEntity> queue = new ConcurrentQueue<IDbEntity>();

        private readonly ConcurrentDictionary<Type, IEntry> entityDictionary = new ConcurrentDictionary<Type, IEntry>();

        public SqlDbContext(String nameOfConnectString)
        {
            this.dbFactory = DbFactory.Create(nameOfConnectString, ConfigSource.Instance.RepositoryConfigSource.DbType);
            this.Initialize();
        }

        public IEntry GetEntry(Type entityType)
        {
            IEntry entry = null;
            if (!this.entityDictionary.TryGetValue(entityType, out entry))
            {
                entry = EntryFactory.CreateEntry(this.dbFactory, entityType);
                this.entityDictionary.TryAdd(entityType, entry);
            }
            return entry;
        }

        public virtual void Initialize()
        { }

        public void Add<TEntity>(TEntity entity)where TEntity:class
        {
            IDbEntity dbEntity = this.GetEntity<TEntity>(entity);
            dbEntity.OperationState = OperationState.Add;
            this.queue.Enqueue(dbEntity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            IDbEntity dbEntity = this.GetEntity<TEntity>(entity);
            dbEntity.OperationState = OperationState.Modify;
            this.queue.Enqueue(dbEntity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            IDbEntity dbEntity = this.GetEntity<TEntity>(entity);
            dbEntity.OperationState = OperationState.Delete;
            this.queue.Enqueue(dbEntity);
        }

        public void SaveChanges()
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                while (this.queue.Count > 0)
                {
                    IDbEntity dbEntity;
                    if (!this.queue.TryDequeue(out dbEntity))
                        continue;

                    this.SaveEntity(dbEntity);
                }

                transactionScope.Complete();
            }
        }

        public async Task SaveChangesAsync()
        {
            this.SaveChanges();
        }

        public object Query(String sql,params object[] parameters)
        {
            return this.dbFactory.ExecuteResult(sql, parameters);
        }

        protected virtual void SaveEntity(IDbEntity dbEntity)
        {
            dbEntity.Entry.Execute(dbEntity.Entity, dbEntity.OperationState);
        }

        private IDbEntity GetEntity<TEntity>(TEntity entity)where TEntity:class
        {
            IEntry entry = GetEntry(entity.GetType());

            DbEntity<TEntity> dbEntity = new DbEntity<TEntity>();
            dbEntity.Entity = entity;
            dbEntity.Entry = entry;

            return dbEntity;
        }

        public void Dispose()
        {
            this.dbFactory.Dispose();
        }
    }
}
