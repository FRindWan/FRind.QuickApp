using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QucikApp.Domain.Specifications
{
    public class NotSpecification<T>:Specification<T>
    {
        private ISpecification<T> spec;

        public NotSpecification(ISpecification<T> spec)
        {
            this.spec = spec;
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            var bodyNot = Expression.Not(spec.GetExpression().Body);
            return Expression.Lambda<Func<T, bool>>(bodyNot, spec.GetExpression().Parameters);
        }
    }
}
