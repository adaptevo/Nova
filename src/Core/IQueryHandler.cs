using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nova.Core
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
