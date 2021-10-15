using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    public static class Configurations
    {
        public const int MAX_LENGTH = 150;

        private static readonly IList<(AvailableSize, int)> _possibleModels = new List<(AvailableSize, int)>
                {
                    (AvailableSize.HundredAndTwenty, 111),
                    (AvailableSize.Hundred, 90),
                    (AvailableSize.SeventyFive, 62),
                    (AvailableSize.Fifty, 59),
                };

        public static IList<(AvailableSize, int)> PossibleModels
        {
            get
            {
                return _possibleModels;
            }
        }

        public static (AvailableSize, int) GetSmallerSize()
        {
            return _possibleModels.ToList()
                                  .OrderBy(a => a.Item1)
                                  .First();
        }

        public static int CalcularCantidadMaximaDeCajonMenorTamanio()
        {
            var cajonMasChico = GetSmallerSize();

            return MAX_LENGTH / (int)cajonMasChico.Item1;
        }
    }
}