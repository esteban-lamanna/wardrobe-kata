namespace Wardrobe
{
    public static class WardrobeElementFactory
    {
        public static WardrobeElement CreateInstance(AvailableSize size)
        {
            return new WardrobeElement(size);
        }
    }
}