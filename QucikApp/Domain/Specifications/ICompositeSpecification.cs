using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QucikApp.Domain.Specifications
{
    internal interface ICompositeSpecification<T>:ISpecification<T>
    {
        ISpecification<T> Left { get; }

        ISpecification<T> Right { get; }
    }
}
