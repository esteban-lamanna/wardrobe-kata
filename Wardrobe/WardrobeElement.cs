using System.Diagnostics;

namespace Wardrobe
{
    [DebuggerDisplay("Size = {_size}")]
    public class WardrobeElement
    {
        public readonly AvailableSize _size;

        public WardrobeElement(AvailableSize size)
        {
            _size = size;
        }
    }
}