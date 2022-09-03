using System.Collections;
using System.Collections.Generic;

namespace CORE.Common.Intefaces
{
    public interface IModelMapper<TSource,TResult>
    {
        TResult Map(TSource source);
        IEnumerable<TResult> Map(IEnumerable<TSource> source);
        TSource ReverseMap(TResult dto);
        IEnumerable<TSource> ReverseMap(IEnumerable<TResult> dto);
    }
}
