using QuickApp.Logger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickApp.Data.Extensions;
using QuickApp.Exceptions;

namespace QuickApp.Data.Infrastructure.DataFilter
{
    internal class DataFilterManager
    {
        public static readonly DataFilterManager Instance = new DataFilterManager();

        private readonly ConcurrentDictionary<String, FilterInfo> filterDictionary = new ConcurrentDictionary<String, FilterInfo>();

        private DataFilterManager()
        { 
            
        }

        public void EnableFilter(String filterName)
        {
            FilterInfo filterInfo;
            if (!this.filterDictionary.TryGetValue(filterName, out filterInfo))
                return;

            filterInfo.EnableState = true;
            this.filterDictionary[filterName] = filterInfo;
        }

        public void DisableFilter(String filterName)
        {
            FilterInfo filterInfo;
            if (!this.filterDictionary.TryGetValue(filterName, out filterInfo))
                return;

            filterInfo.EnableState = false;
            this.filterDictionary[filterName] = filterInfo;
        }

        public void SetOrAddFilter(String filterName, String parameterName, Object parameterValue)
        { 
            FilterInfo filterInfo;
            if (this.filterDictionary.TryGetValue(filterName, out filterInfo))
            {
                filterInfo.SetOrAddParameterValue(parameterName, parameterValue);
                this.filterDictionary[filterName] = filterInfo;
            }
            else
            {
                filterInfo = new FilterInfo(filterName);
                filterInfo.SetOrAddParameterValue(parameterName, parameterValue);
                this.filterDictionary.TryAdd(filterName,filterInfo);
            }
        }

        public String CreateSqlWhere(Type entityType)
        {
            IDictionary<String, FilterInfo> filterInfoDictionary = GetLegalFilters(entityType);
            if (filterDictionary == null || filterDictionary.Count <= 0)
                return null;

            StringBuilder strsql = new StringBuilder();
            strsql.Append(" where 1=1 ");

            foreach (FilterInfo filterInfo in filterInfoDictionary.Values)
            {
                if (!filterInfo.EnableState)
                    continue;

                foreach (KeyValuePair<String, Object> param in filterInfo.GetDictionaryValue())
                {
                    strsql.AppendFormat(" and {0} ={1} ", param.Key, param.Value.ConvertSelectSqlValue());
                }
            }

            return strsql.ToString();
        }

        public IDictionary<string, FilterInfo> GetLegalFilters(Type entityType)
        {
            if (entityType == null)
            {
                Logger.Logger.GetLogger(this.GetType()).Error("请传入有效的实体类型！");
                throw new QuickAppException("请传入有效的实体类型！");
            }

            IDictionary<String, FilterInfo> filterInfoDictionary = new Dictionary<String, FilterInfo>();
            foreach (Type interfaceType in entityType.GetInterfaces())
            {
                FilterInfo filterInfo;
                if (this.filterDictionary.TryGetValue(interfaceType.Name, out filterInfo))
                    filterInfoDictionary.Add(filterInfo.FilterName, filterInfo);
            }
            return filterInfoDictionary;
        }

    }
}
