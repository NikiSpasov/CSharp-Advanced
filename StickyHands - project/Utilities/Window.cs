namespace Utilities
{
    public class Window
    {
        public readonly int Width = 0;
        public readonly int Height = 0;
        internal readonly int FrameWidth = 0;
        internal readonly int FrameHeight = 0;
        internal const char VerticalBorder = '║';
        internal const char HorizontalBorder = '═';
        internal const char TopLeftCornerBorder = '╔';
        internal const char TopRightCornerBorder = '╗';
        internal const char BottomLeftCornerBorder = '╚';
        internal const char BottomRightCornerBorder = '╝';
        internal const char EmptySpace = ' ';

        public Window(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public Window()
            : this(160, 40)
        {
            this.FrameWidth = this.Width - 4;
            this.FrameHeight = this.Height - 4;
        }
    }
}
