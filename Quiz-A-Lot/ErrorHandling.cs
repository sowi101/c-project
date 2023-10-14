using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Quiz_A_Lot
{
    internal class ErrorHandling
    {
        public string TextErrorCheck(string textInput, string typeOfText, [Optional] int num) 
        {
            // While loop that runs as long the format of the variable is incorrect
            while (string.IsNullOrWhiteSpace(textInput))
            {
                // Printing of error message and asking for new input
                if (typeOfText == "title")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har inte angett någon titel.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Titel på quiz: ");
                    textInput = Console.ReadLine();
                }
                else if (typeOfText == "question")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har inte angett någon fråga.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Fråga " + num + ": ");
                    textInput = Console.ReadLine();
                }
                else if (typeOfText == "answer")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har inte angett något svar.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Svar " + num + ": ");
                    textInput = Console.ReadLine();
                } 
                else if(typeOfText == "name")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har inte angett något namn.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Namn: ");
                    textInput = Console.ReadLine();
                }      
            }

            return textInput;
        }

        public int MenuOptionErrorCheck(string option, int amount)
        {
            Regex quizOptionRegex = new Regex(@"^1$");

            if (amount > 1)
            {
                quizOptionRegex = new Regex(@"^[1-amount]$");
            }

            // While loop that runs as long the format of the variable is incorrect
            while (!quizOptionRegex.IsMatch(option))
            {
                // If statement that checks if string is empty
                if (string.IsNullOrWhiteSpace(option))
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har gjort inte angett något val!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ange ditt val: ");
                    option = Console.ReadLine();
                }
                else
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har angett ett val som inte finns!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ange ditt val: ");
                    option = Console.ReadLine();
                }
            }

            return Convert.ToInt32(option);
        }

        public string YesOrNoOptionErrorCheck(string inputCharacter)
        {
            Regex YesOrNoOptionRegex = new Regex(@"^(J | j | N | n)$");

            // While loop that runs as long the format of the variable is incorrect
            while (!YesOrNoOptionRegex.IsMatch(inputCharacter))
            {
                // If statement that checks if string is empty
                if (string.IsNullOrWhiteSpace(inputCharacter))
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har gjort inte angett något val!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ange ditt val: ");
                    inputCharacter = Console.ReadLine();
                }
                else
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du har angett ett inkorrekt val!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ange ditt val: ");
                    inputCharacter = Console.ReadLine();
                }
            }

            return inputCharacter;
        }

    }
}
