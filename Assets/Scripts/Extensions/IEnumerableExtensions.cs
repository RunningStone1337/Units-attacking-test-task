using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class IEnumerableExtensions
{
    public static Queue<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        var cast = collection.ToList();
        var l = cast.Count;
        var shuffled = new Queue<T>();
        for (int i = 0; i < l; i++)
        {
            var index = Random.Range(0, cast.Count);
            shuffled.Enqueue(cast[index]);
            cast.RemoveAt(index);
        }
        return shuffled;
    }
}