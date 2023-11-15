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
                    Console.WriteLine("DU HAR INTE ANGETT NÅGON TITEL.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("TITEL PÅ QUIZ: ");
                    textInput = Console.ReadLine();
                }
                else if (typeOfText == "question")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du HAR INTE ANGETT NÅGON FRÅGA.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("FRÅGA " + num + ": ");
                    textInput = Console.ReadLine();
                }
                else if (typeOfText == "answer")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du HAR INTE ANGETT NÅGOT SVAR.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("SVAR " + num + ": ");
                    textInput = Console.ReadLine();
                } 
                else if(typeOfText == "name")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR INTE ANGETT NÅGOT NAMN.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("NAMN: ");
                    textInput = Console.ReadLine();
                }      
            }

            return textInput;
        }

        public int OptionErrorCheck(string option, int amount)
        {
            Regex quizOptionRegex = new Regex(@"^1$");

            if (amount > 1)
            {
                quizOptionRegex = new Regex(@"^[1-" + amount + "]$");
            }

            // While loop that runs as long the format of the variable is incorrect
            while (!quizOptionRegex.IsMatch(option))
            {
                // If statement that checks if string is empty
                if (string.IsNullOrWhiteSpace(option))
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR INTE ANGETT NÅGOT ALTERNATIV.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("ANGE DITT VAL: ");
                    option = Console.ReadLine();
                }
                else
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR ANGETT ETT ALTERNATIV SOM INTE FINNS.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("ANGE DITT VAL: ");
                    option = Console.ReadLine();
                }
            }

            return Convert.ToInt32(option);
        }

        public string YesOrNoErrorCheck(string inputCharacter, string typeOfUse)
        {
            Regex YesOrNoOptionRegex = new(@"^[JjNn]{1}$");

            // While loop that runs as long the format of the variable is incorrect
            while (!YesOrNoOptionRegex.IsMatch(inputCharacter))
            {
                // If statement that checks if string is empty
                if (string.IsNullOrWhiteSpace(inputCharacter))
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR INTE ANGETT NÅGOT ALTERNATIV.\n ");
                    Console.ForegroundColor = ConsoleColor.White;
                    if(typeOfUse == "correctAnswer")
                    {
                        Console.Write("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ.");
                    } else if (typeOfUse == "controlAnswer")
                    {
                        Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA? TRYCK J FÖR JA OCH N FÖR NEJ.");
                    }
                    
                    inputCharacter = Console.ReadLine();
                }
                else
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR ANGETT ETT ALTERNATIV SOM INTE FINNS.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (typeOfUse == "correctAnswer")
                    {
                        Console.Write("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ.");
                    }
                    else if (typeOfUse == "controlAnswer")
                    {
                        Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA? TRYCK J FÖR JA OCH N FÖR NEJ.");
                    }
                    inputCharacter = Console.ReadLine();
                }
            }

            return inputCharacter;
        }

    }
}
