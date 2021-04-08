using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Math_Game
{
    class Menu
    {
        public string Title { get; set; }
        public string[] Options { get; set; }
        public int SelectedIndex { get; set; }

        public Menu(string title, string[] options)
        {
            this.Title = title;
            this.Options = options;
            this.SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.WriteLine(Title);

            for (int i = 0; i < Options.Length; i++)
            {
                string prefix;
                string currentOption = Options[i];

                if (i == SelectedIndex)
                {
                    prefix = ">>";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} {currentOption}");
            }
            Console.ResetColor();
        }

        public int MainMenu()
        {
            ConsoleKey consoleKey;

            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                consoleKey = consoleKeyInfo.Key;

                if (consoleKey == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                    
                }
                else if(consoleKey == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (consoleKey != ConsoleKey.Enter);
            return SelectedIndex;
        }



    }
}
