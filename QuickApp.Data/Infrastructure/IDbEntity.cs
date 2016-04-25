using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Infrastructure
{
    public interface IDbEntity
    {
        Object Entity { get;  }

        IEntry Entry { get; set; }

        OperationState OperationState { get; set; }

        TType Cast<TType>()where TType:class;
    }
}
