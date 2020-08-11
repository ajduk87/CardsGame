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
    }
}