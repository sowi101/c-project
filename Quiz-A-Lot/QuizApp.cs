/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#.NET
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-12-03
*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Quiz_A_Lot
{
    internal class QuizApp
    {
        // Fields
        private string jsonFile = Directory.GetCurrentDirectory().ToString() + "quizzes.json";
        private List<Quiz>? quizzes = new();

        // Constructor
        public QuizApp()
        {
            // Checks if JSON file exists
            if (File.Exists(Directory.GetCurrentDirectory().ToString() + "quizzes.json") == true)
            {
                // Reads data from JSON file
                var jsonString = File.ReadAllText(jsonFile);
                // Converts data from JSON string to objects
                quizzes = JsonConvert.DeserializeObject<List<Quiz>>(jsonString);
            }
        }

        // Methods

        // Method that writes data to JSON file
        private void WriteToFile()
        {
            // Converts list of objects to JSON string
            var jsonString = JsonConvert.SerializeObject(quizzes, Newtonsoft.Json.Formatting.Indented);
            // Writes data to JSON file
            File.WriteAllText(jsonFile, jsonString);
        }

        // Method to add a quiz
        public Quiz AddQuiz(Quiz quiz)
        {
            // Adds the object to the array of quizzes
            quizzes?.Add(quiz);
            // Write all quizzes to JSON file
            WriteToFile();
            return quiz;
        }

        // Method to saves changes
        public void ChangeQuiz() { 
            // Call of method to rewrite JSON file
            WriteToFile();
        }

        // Method to delete a quiz
        public int DeleteQuiz(int index)
        {
            // Deletes the object at the specific index in the list of quizzes
            quizzes?.RemoveAt(index);
            // Call of method to rewrite JSON file
            WriteToFile();
            return index;
        }

        // Method to get the list of all quizzes
        public List<Quiz> GetQuizzes()
        {
            return quizzes;
        }

        // Method to print quizzes
        public void PrintQuizzes(List<Quiz> allQuizzes)
        {
            var q = 1;
            Console.WriteLine("══════════════════════════════");
            // Loops through all quizzes and prints title of the quiz and amount of questions
            foreach (Quiz quiz in allQuizzes)
            {
                Console.WriteLine(" [" + q++ + "] " + quiz.Title.ToUpper() + " (" + quiz.questions.Count() + " FRÅGOR)");  
            }
            Console.WriteLine("══════════════════════════════");
        }
    }
}

