using System;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
            {
                action(obj);
            }
        }

        public static int IndexOfMaxBy<TSource, TProjected>
    (this IEnumerable<TSource> source,
     Func<TSource, TProjected> selector,
     IComparer<TProjected> comparer = null
    )
        {

            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                    throw new InvalidOperationException("Sequence is empty.");

                if (comparer == null)
                    comparer = Comparer<TProjected>.Default;

                int index = 0, maxIndex = 0;
                var maxProjection = selector(iterator.Current);

                while (iterator.MoveNext())
                {
                    index++;
                    var projectedItem = selector(iterator.Current);

                    if (comparer.Compare(projectedItem, maxProjection) > 0)
                    {
                        maxIndex = index;
                        maxProjection = projectedItem;
                    }
                }
                return maxIndex;
            }
        }
    }
}