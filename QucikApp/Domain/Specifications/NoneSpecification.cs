using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QucikApp.Domain.Specifications
{
    public class NoneSpecification<T>:Specification<T>
    {
        public override System.Linq.Expressions.Expression<Func<T, bool>> GetExpression()
        {
            return o => false;
        }
    }
}
