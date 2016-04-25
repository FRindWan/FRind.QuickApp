﻿using QuickApp.Data.Infrastructure.MSSqlerver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    public static class EntryFactory
    {
        public static IEntry CreateEntry(IDbFactory dbFactory,Type entityType)
        {
            switch (dbFactory.DbType)
            {
                case DbFactoryType.MSSQLSERVER: return new MSEntry(dbFactory, entityType);
            }

            return null;
        }
    }
}
