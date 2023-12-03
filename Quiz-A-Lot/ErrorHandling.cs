/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#.NET
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-12-03
*/

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Quiz_A_Lot
{
    internal class ErrorHandling
    {
        // Methods

        // Method to ensure the input is not empty
        public static string TextErrorCheck(string textInput, string typeOfText, [Optional] int num) 
        {
            // While loop that runs as long as the input is empty
            while (string.IsNullOrWhiteSpace(textInput))
            {
                // If statements to check type of text of the input
                
                if (typeOfText == "title")
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR INTE ANGETT NÅGON TITEL.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("TITEL PÅ QUIZ: ");
                    textInput = Console.ReadLine();
                }
                else if (typeOfText == "question")
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du HAR INTE ANGETT NÅGON FRÅGA.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("FRÅGA " + num + ": ");
                    textInput = Console.ReadLine();
                }
                else if (typeOfText == "answer")
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du HAR INTE ANGETT NÅGOT SVAR.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("SVAR " + num + ": ");
                    textInput = Console.ReadLine();
                } 
                else if(typeOfText == "name")
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR INTE ANGETT NÅGOT NAMN.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("NAMN: ");
                    textInput = Console.ReadLine();
                }      
            }

            return textInput;
        }

        // Method to ensure that input is not empty and option in input exists
        public static int OptionErrorCheck(string option, int amount)
        {
            // Defines format for input
            Regex quizOptionRegex = new Regex(@"^1$");

            // If statement to check if there are more than one possible option
            if (amount > 1)
            {
                // Redefines format for input
                quizOptionRegex = new Regex(@"^[1-" + amount + "]$");
            }

            // While loop that runs as long the format of the input is incorrect
            while (!quizOptionRegex.IsMatch(option))
            {
                // If statement to check if string is empty
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

            // Converts input from string to int
            return Convert.ToInt32(option);
        }

        // Method to ensure that input is not empty and input contain one of two specific characters
        public static string YesOrNoErrorCheck(string inputCharacter, string typeOfUse)
        {
            // Defines format for input
            Regex YesOrNoOptionRegex = new(@"^[JjNn]{1}$");

            // While loop that runs as long the format of the input is incorrect
            while (!YesOrNoOptionRegex.IsMatch(inputCharacter))
            {
                // If statement to check if string is empty
                if (string.IsNullOrWhiteSpace(inputCharacter))
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR INTE ANGETT NÅGOT ALTERNATIV.\n ");
                    Console.ForegroundColor = ConsoleColor.White;
                    // If statements to check type of use for the input
                    if (typeOfUse == "correctAnswer")
                    {
                        Console.Write("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                    } else if (typeOfUse == "controlAnswer")
                    {
                        Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                    }   
                    inputCharacter = Console.ReadLine();
                }
                else
                {
                    // Printing of error message and asking for new input
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DU HAR ANGETT ETT ALTERNATIV SOM INTE FINNS.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    // If statements to check type of use for the input
                    if (typeOfUse == "correctAnswer")
                    {
                        Console.Write("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                    }
                    else if (typeOfUse == "controlAnswer")
                    {
                        Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                    }
                    inputCharacter = Console.ReadLine();
                }
            }
            return inputCharacter;
        }
    }
}
