/******************************************************************************/
/*                                                                            */
/*   Program: MySimpleConsoleApp                                              */
/*   Just a smal example for a C# console application with nice colorers      */
/*                                                                            */
/*   25.8.2013 0.0.0.0 uhwgmxorg Start                                        */
/*                                                                            */
/******************************************************************************/
using System;
using System.Linq;

namespace MySimpleConsoleApp
{
    class Program
    {
        /// <summary>
        /// PrintMenu
        /// </summary>
        static void PrintMenu()
        {
            string Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ScreenOutput(0, 0, "Program MySimpleConsoleApp Version " + Version, ConsoleColor.Cyan);

            int X = 30, Y = 3;
            ScreenOutput(X, Y + 0, "a For PrintAllForegroundColor");
            ScreenOutput(X, Y + 1, "b For PrintAllBackgroundColor");
            ScreenOutput(X, Y + 2, "c For Beep");
            ScreenOutput(X, Y + 3, "x For Exit");
            ScreenOutput(X, Y + 5, "press a key for choice",ConsoleColor.Green);
        }

        /// <summary>
        /// MenuDispatcher
        /// </summary>
        /// <param name="key"></param>
        private static void MenuDispatcher(char key)
        {
            switch (key)
            {
                case 'a':
                    ClearScreen();
                    PrintAllForegroundColor();
                    ClearScreen();
                    break;
                case 'b':
                    ClearScreen();
                    PrintAllBackgroundColor();
                    ClearScreen();
                    break;
                case 'c':
                    Console.Beep();
                    ClearScreen();
                    break;
                case 'x':
                    break;
                default:
                    ClearScreen();
                    Console.Beep();
                    Console.Beep();
                    ScreenOutput(28, 5, "You pressed a wrong key !!", ConsoleColor.Red, ConsoleColor.White);
                    Console.ReadKey();
                    ClearScreen();
                    break;
            }
        }

        /// <summary>
        /// PrintAllForegroundColor
        /// Example is from msdn http://msdn.microsoft.com/de-de/library/vstudio/system.console.resetcolor(v=vs.110).aspx
        /// </summary>
        static void PrintAllForegroundColor()
        {
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            foreach (string colorName in colorNames)
            {
                // Convert the string representing the enum name to the enum value.
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                if (color == ConsoleColor.Black) continue;

                Console.Write("{0,11}: ", colorName);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = color;
                Console.WriteLine("This is foreground color {0}.", colorName);
                // Restore the original foreground and background colors.
                Console.ResetColor();
            }
            Console.WriteLine();
            ScreenOutput("press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// PrintAllBackgroundColor
        /// Example is from msdn http://msdn.microsoft.com/de-de/library/vstudio/system.console.resetcolor(v=vs.110).aspx
        /// </summary>
        static void PrintAllBackgroundColor()
        {
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            foreach (string colorName in colorNames)
            {
                // Convert the string representing the enum name to the enum value.
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                if (color == ConsoleColor.White) continue;

                Console.Write("{0,11}: ", colorName);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
                Console.WriteLine("This is background color {0}.", colorName);
                Console.ResetColor();
            }
            ScreenOutput("press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// ScreenOutput
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        static void ScreenOutput(int x, int y, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }
        static void ScreenOutput(int x, int y, string text, ConsoleColor foregroundColor)
        {
            ScreenOutput(x, y, text, foregroundColor, ConsoleColor.Black);
        }
        static void ScreenOutput(int x, int y, string text)
        {
            ScreenOutput(x, y, text, ConsoleColor.Gray);
        }
        static void ScreenOutput(string text)
        {
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// ClearScreen
        /// </summary>
        static void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConsoleKeyInfo KeyInfo;
            char Key;

            ClearScreen();
            do
            {
                PrintMenu();

                KeyInfo = Console.ReadKey();
                Key = KeyInfo.KeyChar;

                MenuDispatcher(Key);
            }
            while (Key != 'x');

            ScreenOutput("\nEnd.");
        }
      }
}
