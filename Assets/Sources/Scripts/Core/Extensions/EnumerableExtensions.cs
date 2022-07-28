using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (T item in items)
        {
            action(item);
        }
    }
}
