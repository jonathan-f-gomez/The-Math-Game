using System;

namespace The_Math_Game
{
    class Program
    {
        public static Random rnd = new Random();
        public static int correctAnswers = 0; //Counts the users Correct answers

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
                Console.WriteLine($"Please try again.. Heres your {howManyProblems} problems");
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
                Console.WriteLine($"Please try again.. Heres your {howManyProblems} problems");
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
                Console.WriteLine($"Please try again.. Heres your {howManyProblems} problems");
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
                Console.WriteLine($"Please try again.. Heres your {howManyProblems} problems");
                Division(howManyProblems);
            }
        }

        /*User Interations
         =================*/
        public static  void Report(int correct, int howMany)
        {
            float calcAnswer = (float)correct / howMany;
            double grade = ((double)Math.Round(calcAnswer, 2) * 100);

            Console.WriteLine($"You got {correct} out of {howMany} correct. Your grade is {grade}%");
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
        public static void Welcome()
        {

            try
            {
                Console.WriteLine("\tWelcome to the Math Games");

                Console.WriteLine($"Please choose what type of problems you want to practice" +
                    $"\n1. Addition" +
                    $"\n2. Subtraction" +
                    $"\n3. Multiplication" +
                    $"\n4. Division");

                int userChoice = int.Parse(Console.ReadLine());
                string userChoiceString = UserChoice(userChoice);

                Console.WriteLine($"How many problems?");
                int howManyProblems = int.Parse(Console.ReadLine());

                Console.WriteLine($"Press enter to start your {howManyProblems} {userChoiceString} problems.");
                Console.ReadLine();

                switch (userChoice)
                {
                    case 1:
                        Addition(howManyProblems);
                        break;
                    case 2:
                        Subtraction(howManyProblems);
                        break;
                    case 3:
                        Multiplication(howManyProblems);
                        break;
                    case 4:
                        Subtraction(howManyProblems);
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
    }
}
