using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    public static class IListExtensions
    {
        public static int GetQuantityOfModel(this IList<WardrobeElement> list, AvailableSize size)
        {
            return list.Count(a => a._size == size);
        }

        public static void WriteList(this IList<WardrobeElement> elementsList)
        {
            foreach (var item in elementsList)
                Console.WriteLine($" - {item._size}");

            Console.WriteLine("\n");
        }

        public static bool AreEqual(this IList<WardrobeElement> list, IList<WardrobeElement> anotherlist)
        {
            var equal = true;

            if (list.Count != anotherlist.Count)
                return false;

            var sizes = list.Select(a => a._size).Distinct();

            foreach (var size in sizes.Distinct())
            {
                var quantitySecondList = anotherlist.Count(a => a._size == size);
                var quantityFirstList = list.Count(a => a._size == size);

                if (quantitySecondList != quantityFirstList)
                    return false;
            }

            return equal;
        }
    }
}