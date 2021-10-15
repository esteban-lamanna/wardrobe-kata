using System;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Wardrobe();
            var combinations = wardrobe.GetAllPossibleCombination();

            var uniques = wardrobe.GetDistinctCombinations(combinations);

            uniques.ToList().ForEach(internalList =>
            {
                Console.WriteLine($"Combination found:");

                internalList.WriteList();
            });
        }
    }
}