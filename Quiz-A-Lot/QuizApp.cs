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
            if (File.Exists(Directory.GetCurrentDirectory().ToString() + "quizzes.json") == true)
            {
                // Read data from JSON file
                var jsonString = File.ReadAllText(jsonFile);
                // Convert data from JSON
                quizzes = JsonConvert.DeserializeObject<List<Quiz>>(jsonString);
            }
        }

        // Method to add a quiz
        public void AddQuiz(Quiz quiz)
        {
            // Adds the object to the array of quizzes
            quizzes?.Add(quiz);
            // Write all quizzes to JSON file
            WriteToFile();
        }

        public void ChangeQuiz() { 
            WriteToFile();
        }

        // Method that delete a specific quiz
        public int DeleteQuiz(int index)
        {
            // Deletes the quiz with the specific index
            quizzes?.RemoveAt(index);
            // Write all remaining quizzes to JSON file
            WriteToFile();

            return index;
        }

        // Method that return an array of all quizzes
        public List<Quiz> GetQuizzes()
        {
            return quizzes;
        }

        // Method that writes quizzes to JSON file
        private void WriteToFile()
        {
            // Converts array of objects to JSON
            var jsonString = JsonConvert.SerializeObject(quizzes, Newtonsoft.Json.Formatting.Indented);
            // Write data to JSON file
            File.WriteAllText(jsonFile, jsonString);
        }

        public void PrintQuizzes(List<Quiz> allQuizzes)
        {
            var q = 1;

            foreach (Quiz quiz in allQuizzes)
            {
                // Printing name of quiz and amount of questions
                Console.WriteLine("[" + q++ + "] " + quiz.Title + " (" + quiz.questions.Count() + " frågor)");
            }
        }
    }
}

