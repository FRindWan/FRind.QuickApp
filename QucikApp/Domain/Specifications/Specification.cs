using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuickApp.Domain.Specifications
{
    public abstract class Specification<T>:ISpecification<T>
    {
        public static Specification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }

        public bool IsSatisfiedBy(T obj)
        {
            return this.GetExpression().Compile()(obj);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> AndNot(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Not(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public abstract Expression<Func<T, bool>> GetExpression();
    }
}
