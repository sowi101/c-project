using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_A_Lot
{
    internal class Quiz
    {
        //Fields
        public string? Title { get; set; }
        public List<Question> questions = new();
        public List<TopScore> topScores = new();


        // Method to add a question
        public Question AddQuestion(Question question)
        {
            // Adds the object to the array of questions
            questions.Add(question);
            return question;
        }

        // Method that delete a specific question
        public int DeleteQuestion(int index)
        {
            // Deletes the question with the specific index
            questions.RemoveAt(index);
            return index;
        }

        public int EditQuestion(Question editedQuestion, int index)
        {
            questions[index] = editedQuestion;

            return index;
        }

        // Method that return an array of all questions
        public List<Question> GetQuestions()
        {
            return questions;
        }

        // Method to add a top score
        public TopScore AddTopScore(TopScore topscore)
        {
            // Adds the object to the array of topscores
            topScores.Add(topscore);
            return topscore;
        }

        // Method that delete the topscores for a quiz
        public void DeleteTopScores()
        {
            // Deletes the topscore with the specific index
            topScores.Clear();
            Console.WriteLine("Alla resultat för quizet har raderats");
        }

        // Method that return an array of all topscores
        public List<TopScore> GetTopScores()
        {
            return topScores;
        }

        public void PrintTopScores(Quiz quiz)
        {
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine(quiz.Title?.ToUpper());
            Console.WriteLine("══════════════════════════════");

            quiz.topScores.Sort((ts1, ts2) => ts2.Score.CompareTo(ts1.Score));

            // Print information about quizzes
            if (quiz.topScores.Count < 1)
            {
                Console.WriteLine("INGA SPARADE RESULTAT.");
            }

            foreach (TopScore topScore in quiz.topScores)
            {

                // Printing name of quiz and amount of questions
                Console.WriteLine(topScore.Name + " " + topScore.Score);
            }
            Console.WriteLine("══════════════════════════════\n");
        }
    }
}
