namespace PICROSSCommon
{
    public abstract class PanelButtonBase : Button
    {
        public Color Color { get; protected set; }

        public int Index { get; set; }

        public int Size { get; set; }

        public int Row => Index / Size;

        public int Column => Index % Size;

        public PanelButtonBase(int index, int size) 
        {
            if (index < 0) {  throw new ArgumentOutOfRangeException(nameof(index)); }
            if (size < 1) { throw new ArgumentOutOfRangeException(nameof(size)); }
            Index = index;
            Size = size;
        }
    }
}
