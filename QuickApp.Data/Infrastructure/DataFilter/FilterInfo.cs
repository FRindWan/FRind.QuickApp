using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure.DataFilter
{
    public class FilterInfo
    {
        private IDictionary<String, Object> parameterValues = new Dictionary<String, Object>();

        public FilterInfo(String filterName)
        {
            this.FilterName = filterName;
            this.EnableState = true;
        }

        public FilterInfo(String filterName,String parameterName, Object parameterValue)
        {
            this.FilterName = filterName;
            this.parameterValues.Add(parameterName, parameterValue);
            this.EnableState = true;
        }

        public String FilterName { get; private set; }

        public bool EnableState { get; set; }

        public void SetOrAddParameterValue(String parameterName, Object parameterValue)
        { 
            Object oldParameterValue;
            if (this.parameterValues.TryGetValue(parameterName, out oldParameterValue))
            {
                this.parameterValues[parameterName] = parameterValue;
            }
            else
            {
                this.parameterValues.Add(parameterName, parameterValue);
            }
        }

        public IDictionary<String, Object> GetDictionaryValue()
        {
            return parameterValues;
        }
    }
}
