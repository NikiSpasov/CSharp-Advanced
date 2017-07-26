using System;

namespace Utilities
{
    public class StartupHelper
    {
        public StartupHelper(Window window)
        {
            this.Window = window;
        }
        public Window Window { get; set; }

        public void SetProperties()
        {
            Console.WindowWidth = Window.Width;
            Console.CursorVisible = false;
            Console.SetBufferSize(Window.Width, Window.Height);
            Console.WindowHeight = Window.Height;
            Console.WindowWidth = Window.Width + 2;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
