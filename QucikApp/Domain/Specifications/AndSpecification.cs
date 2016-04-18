using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickApp.Domain.Specifications
{
    public class AndSpecification<T>:CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { } 

        public override System.Linq.Expressions.Expression<Func<T, bool>> GetExpression()
        {
            return Left.GetExpression().And(Right.GetExpression());
        }
    }
}
