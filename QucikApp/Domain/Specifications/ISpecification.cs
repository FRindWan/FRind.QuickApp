using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuickApp.Domain.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T obj);

        ISpecification<T> Or(ISpecification<T> other);

        ISpecification<T> And(ISpecification<T> other);

        ISpecification<T> AndNot(ISpecification<T> other);

        ISpecification<T> Not(ISpecification<T> other);

        Expression<Func<T, bool>> GetExpression();
    }
}
