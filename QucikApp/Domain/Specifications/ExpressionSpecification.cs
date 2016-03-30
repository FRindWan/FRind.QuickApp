using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QucikApp.Domain.Specifications
{
    internal sealed class ExpressionSpecification<T>:Specification<T>
    {
        private Expression<Func<T, bool>> expression = null;

        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            this.expression = expression;
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            return this.expression;
        }
    }
}
