using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    public class Wardrobe
    {
        public IList<WardrobeElement> _elements;

        public Wardrobe()
        {
            _elements = GenerateAllAvailableWardrobeElementToFillSpace();
        }

        internal IList<IList<WardrobeElement>> GetDistinctCombinations(IList<IList<WardrobeElement>> combinations)
        {
            var list = new List<IList<WardrobeElement>>();

            for (int i = 0; i < combinations.Count; i++)
            {
                if (!list.Any(a => a.AreEqual(combinations[i])))
                    list.Add(combinations[i]);
            }

            return list;
        }

        private IList<WardrobeElement> GenerateAllAvailableWardrobeElementToFillSpace()
        {
            var list = new List<WardrobeElement>();

            Console.WriteLine($"Longitud armario: {Configurations.MAX_LENGTH}");

            Console.WriteLine($"Elementos encontrados para llenar espacio:");

            foreach (var model in Configurations.PossibleModels)
            {
                var sum = 0;

                while (sum <= Configurations.MAX_LENGTH)
                {
                    if (sum + (int)model.Item1 <= Configurations.MAX_LENGTH)
                        list.Add(WardrobeElementFactory.CreateInstance(model.Item1));

                    sum += (int)model.Item1;
                }
            }

            list.WriteList();

            return list;
        }

        private IList<WardrobeElement> GetGroup(IList<WardrobeElement> elements, int indexCurrentItem, int sumatoria)
        {
            var combination = new List<WardrobeElement>();

            var suma = 0;

            for (int j = 0; j < elements.Count; j++)
            {
                if (indexCurrentItem == j)
                    continue;

                var currentElement = elements[j];

                var currentElementLength = currentElement._size;

                var sumaParcial = suma + (int)currentElementLength;

                if (sumaParcial > sumatoria)
                    continue;

                combination.Add(currentElement);

                suma += (int)currentElementLength;

                if (suma == sumatoria)
                {
                    return combination;
                }
            }

            return combination;
        }

        public IList<IList<WardrobeElement>> GetAllPossibleCombination()
        {
            var combinations = new List<IList<WardrobeElement>>();

            for (int i = 0; i < _elements.Count; i++)
            {
                var suma = (int)_elements[i]._size;

                var combination = new List<WardrobeElement>
                {
                    _elements[i]
                };

                for (int j = 0; j < _elements.Count; j++)
                {
                    if (i == j)
                        continue;

                    var currentElement = _elements[j];

                    var currentElementLength = currentElement._size;

                    var sumaParcial = suma + (int)currentElementLength;

                    if (sumaParcial > Configurations.MAX_LENGTH)
                        continue;

                    combination.Add(currentElement);

                    suma += (int)currentElementLength;

                    if (suma == Configurations.MAX_LENGTH)
                    {
                        combinations.Add(combination);
                    }
                }
            }

            return combinations;
        }
    }
}