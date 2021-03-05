using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public static class Tools
    {
        public static int GetRandRange(int min, int max, Random rng)
        {
            Random rnd = rng;
            int output = rnd.Next(min, max);
            return output;
        }

        public static List<ILootables> MySort(List<ILootables> listToSort) // CHANGE TO PRIVATE AFTER TESTING
        {
            List<ILootables> output = new List<ILootables>();
            var distinct = listToSort.DistinctBy(i => i.Name).ToList();
            var notDistinct = new List<ILootables>();
            foreach (var item in listToSort)
            {
                if (!(distinct.Contains(item))) notDistinct.Add(item);
            }
            foreach (var entry in notDistinct)
            {
                distinct.Find(i => i.Name == entry.Name).Amount += entry.Amount;
            }
            return distinct.OrderBy(i => i.Name).ToList(); ;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}