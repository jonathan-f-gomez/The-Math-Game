using System;

namespace The_Math_Game
{
    class Program
    {
        public static Random rnd = new Random();
        public static int correctAnswers = 0; //Counts the users Correct answers

        static void Main(string[] args)
        {
            bool tryAgain = true;
            while (tryAgain == true)
            {
                Welcome();

                Console.Write("Do you want to play again? \n[Yes]/No: ");
                string userAnswer = Console.ReadLine();
                if (userAnswer == "No" || userAnswer == "no" || userAnswer == "n" || userAnswer == "N")
                {
                    tryAgain = false;
                }
                Console.Clear();
            }



        }

        public static void Welcome()
        {
            string[] userChoices = { "Addition", "Subtraction", "Multiplication", "Division" };
            Menu menu = new Menu(MainTitle(),userChoices);
            try
            {
                int selectedIndex = menu.MainMenu();
                Console.Clear();
                
                Console.Write($"{Title()}\nHow many problems do you want to solve: ");
                int howManyProblems = int.Parse(Console.ReadLine());

                Console.WriteLine($"Press enter to start your {howManyProblems} {UserChoice(selectedIndex + 1)} problems.");
                Console.ReadLine();

                switch (selectedIndex)
                {
                    case 0:
                        Addition(howManyProblems);
                        break;
                    case 1:
                        Subtraction(howManyProblems);
                        break;
                    case 2:
                        Multiplication(howManyProblems);
                        break;
                    case 3:
                        Division(howManyProblems);
                        break;
                    default:
                        Welcome();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /*Returns 2 random Ints between 1-20
        ====================================*/
        public static Tuple<int,int> TwoRng()
        {
            int number1 = rnd.Next(0, 21);
            int number2 = rnd.Next(0, 21);

            return Tuple.Create(number1, number2);
        }

        /*Math Operators
         ===============*/
        public static void Addition(int howManyProblems)
        {
            try
            {
                for (int i = 0; i < howManyProblems; i++)
                {
                    var number = TwoRng();

                    Console.Write($"{i + 1}. {number.Item1} + {number.Item2} = ");
                    int userAnswer = int.Parse(Console.ReadLine());

                    int calcAnswer = number.Item1 + number.Item2;

                    if (userAnswer == calcAnswer)
                    {
                        Console.WriteLine("Correct.");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the correct answer is {calcAnswer}");
                    }
                }
                Report(correctAnswers, howManyProblems);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"{Title()}\nPlease try again.. Heres your {howManyProblems} problems");
                Addition(howManyProblems);
            }
            
        }
        public static void Subtraction(int howManyProblems)
        {
            try
            {
                for (int i = 0; i < howManyProblems; i++)
                {
                    var number = TwoRng();

                    Console.Write($"{i + 1}. {number.Item1} - {number.Item2} = ");
                    int userAnswer = int.Parse(Console.ReadLine());

                    int calcAnswer = number.Item1 - number.Item2;

                    if (userAnswer == calcAnswer)
                    {
                        Console.WriteLine("Correct.");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the correct answer is {calcAnswer}");
                    }
                }
                Report(correctAnswers, howManyProblems);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"{Title()}\nPlease try again.. Heres your {howManyProblems} problems");
                Subtraction(howManyProblems);
            }
            
        }
        public static void Multiplication(int howManyProblems)
        {
            try
            {
                for (int i = 0; i < howManyProblems; i++)
                {
                    var number = TwoRng();

                    Console.Write($"{i + 1}. {(float)number.Item1} * {(float)number.Item2} = ");

                    double userAnswer = double.Parse(Console.ReadLine());

                    int calcAnswer = number.Item1 * number.Item2;

                    if (userAnswer == calcAnswer)
                    {
                        Console.WriteLine("Correct.");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the correct answer is {calcAnswer}");
                    }
                }
                Report(correctAnswers, howManyProblems);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"{Title()}\nPlease try again.. Heres your {howManyProblems} problems");
                Multiplication(howManyProblems);
            }
        }
        public static void Division(int howManyProblems)
        {
            try
            {
                for (int i = 0; i < howManyProblems; i++)
                {
                    var number = TwoRng();

                    if (number.Item1 == 0 || number.Item2 == 0)
                    {
                        number = TwoRng();
                    }

                    Console.Write($"{i + 1}. {(float)number.Item1} / {(float)number.Item2} = ");
                    double userAnswer = double.Parse(Console.ReadLine());

                    float calcAnswer = (float)number.Item1 / number.Item2;
                    double roundAnswer = (double)Math.Round(calcAnswer, 2);

                    if (userAnswer == roundAnswer)
                    {
                        Console.WriteLine("Correct.");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the correct answer is {roundAnswer}");
                    }
                }
                Report(correctAnswers, howManyProblems);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"{Title()}\nPlease try again.. Heres your {howManyProblems} problems");
                Division(howManyProblems);
            }
        }

        /*User Interations
         =================*/
        public static void Report(int correct, int howMany)
        {
            float calcAnswer = (float)correct / howMany;
            double grade = ((double)Math.Round(calcAnswer, 2) * 100);

            Console.WriteLine($"\nYou got {correct} out of {howMany} correct. Your grade is {grade}%");
        }
        public static string UserChoice(int userChoice)
        {
            if (userChoice == 1)
            {
               return "Addition";
            }
            if (userChoice == 2)
            {
                return "Subtraction";
            }
            if (userChoice == 3)
            {
                return "Multiplication";
            }
            if (userChoice == 4)
            {
                return "Division";
            }

            return "Choice not found";
            
        }

        /*Titles
         =================*/
        public static string MainTitle()
        {
            return @"
 _____ _   _  _____   ___  ___  ___ _____ _   _    _____   ___  ___  ___ _____ 
|_   _| | | ||  ___|  |  \/  | / _ \_   _| | | |  |  __ \ / _ \ |  \/  ||  ___|
  | | | |_| || |__    | .  . |/ /_\ \| | | |_| |  | |  \// /_\ \| .  . || |__  
  | | |  _  ||  __|   | |\/| ||  _  || | |  _  |  | | __ |  _  || |\/| ||  __| 
  | | | | | || |___   | |  | || | | || | | | | |  | |_\ \| | | || |  | || |___ 
  \_/ \_| |_/\____/   \_|  |_/\_| |_/\_/ \_| |_/   \____/\_| |_/\_|  |_/\____/ 
    
   Please choose what type of problems you want to practice by highlighting the 
   choices using the arrow keys and pressing Enter to select.
";
        }

        public static string Title()
        {
            return @"
 _____ _   _  _____   ___  ___  ___ _____ _   _    _____   ___  ___  ___ _____ 
|_   _| | | ||  ___|  |  \/  | / _ \_   _| | | |  |  __ \ / _ \ |  \/  ||  ___|
  | | | |_| || |__    | .  . |/ /_\ \| | | |_| |  | |  \// /_\ \| .  . || |__  
  | | |  _  ||  __|   | |\/| ||  _  || | |  _  |  | | __ |  _  || |\/| ||  __| 
  | | | | | || |___   | |  | || | | || | | | | |  | |_\ \| | | || |  | || |___ 
  \_/ \_| |_/\____/   \_|  |_/\_| |_/\_/ \_| |_/   \____/\_| |_/\_|  |_/\____/ 

";
        }
    }
}
