using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public static class Tools
    {

        /// <summary>
        /// Generates a random number between min and max inclusive.
        /// </summary>
        /// <param name="min">Minimum number to pick from.</param>
        /// <param name="max">Maximum number to pick from<./param>
        /// <returns></returns>
        public static int RandGen(int min, int max)
        {
            max += 1;
            Random rnd = new Random();
            int output = rnd.Next(min, max);
            return output;
        }

        /// <summary>
        /// Generates a random number between min and max inclusive, putting weight on the target.
        /// </summary>
        /// <param name="min">The minimum number to pick.</param>
        /// <param name="max">The maximum number to pick.</param>
        /// <param name="weight">The chance that target will be pulled,
        /// 1 = roughly 14% chance.
        /// 1.7 would be 25%???.
        /// 2.2 = roughly 50% chance.
        /// 3.2/3.3 would be 75%? untested!
        /// 4 = roughly 85% chance.</param>
        /// <param name="target">The number to put the weight on.</param>
        /// <returns></returns>
        public static int RandGen(int min, int max, double weight, int target)
        {
            max += 1;
            var rng = new Random();
            int dflt = 0;
            while (true)
            {
                var result = rng.Next(min, max);
                if (RandChecker(result, weight, target, rng)) return result;
                dflt++;
                if (dflt == 1000) return target;
            }
        }

        /// <summary>
        /// Required for RandGen
        /// </summary>
        /// <param name="input"></param>
        /// <param name="weight"></param>
        /// <param name="target"></param>
        /// <param name="rng"></param>
        /// <returns></returns>
        private static bool RandChecker(int input, double weight, int target, Random rng)
        {
            int diff = Math.Abs(input - target);
            int power = (int)Math.Pow(diff + 1, weight);
            if (rng.Next(0, power) == 0) return true;
            return false;
        }

        public static List<ILootables> MySort(List<ILootables> listToSort)
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