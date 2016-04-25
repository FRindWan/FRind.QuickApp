using QuickApp.Data.Infrastructure;
using QuickApp.Data.Infrastructure.DataFilter;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4c.Extensions
{
    public static class DataFilterExtension
    {
        public static void EnableFilter(this SqlDbContext dbContext, string filterName)
        {
            DataFilterManager.Instance.EnableFilter(filterName);
        }

        public static void DisableFilter(this SqlDbContext dbContext, string filterName)
        {
            DataFilterManager.Instance.DisableFilter(filterName);
        }

        public static void SetFilterScopedParameterValue(this SqlDbContext context, string filterName, string parameterName, Object parameterValue)
        {
            DataFilterManager.Instance.SetOrAddFilter(filterName, parameterName, parameterValue);
        }

        //public static void SetFilterScopedParameterValue(this SqlDbContext context, string filterName, string parameterName, object value)
        //{
        //    DataFilterManager.Instance.SetOrAddFilter(filterName, parameterName, value);
        //}

        public static void CreateSqlWhereForDataFilter(this DbCommand command,Type entityType)
        {
            if (String.IsNullOrWhiteSpace(command.CommandText) || command.CommandText.ToLower().Trim().IndexOf("select") > 0)
                return;

            String strWhereSql= DataFilterManager.Instance.CreateSqlWhere(entityType);
            if (String.IsNullOrWhiteSpace(strWhereSql))
                return;

            if (command.CommandText.ToLower().Contains("where"))
            {
                command.CommandText += strWhereSql.Replace("where", "and");
            }
            else
            {
                command.CommandText += strWhereSql;
            }
        }

        public static string CreateSqlWhereForDataFilter(this String strsql,Type entityType)
        {
            if (String.IsNullOrWhiteSpace(strsql) || strsql.ToLower().Trim().IndexOf("select") > 0)
                return strsql;

            String strWhereSql = DataFilterManager.Instance.CreateSqlWhere(entityType);
            if (String.IsNullOrWhiteSpace(strWhereSql))
                return strsql ;

            if (strsql.ToLower().Contains("where"))
            {
                strsql += strWhereSql.Replace("where", "and");
            }
            else
            {
                strsql += strWhereSql;
            }
            return strsql;
        }
    }
}
