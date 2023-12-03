/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#.NET
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-12-03
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_A_Lot
{
    internal class Quiz
    {
        //Fields / Properties
        public string? Title { get; set; }
        public List<Question> questions = new();
        public List<TopScore> topScores = new();

        // Methods

        // Method to add a question
        public Question AddQuestion(Question question)
        {
            // Adds the object to the list of questions
            questions.Add(question);
            return question;
        }

        // Method to delete a question
        public int DeleteQuestion(int index)
        {
            // Deletes the object at the specific index in the list of questions
            questions.RemoveAt(index);
            return index;
        }

        // Method to add a top score
        public TopScore AddTopScore(TopScore topscore)
        {
            // Adds the object to the list of topscores
            topScores.Add(topscore);
            return topscore;
        }

        // Method that delete the topscores
        public void DeleteTopScores()
        {
            // Clears all topscore in the list
            topScores.Clear();
        }

        // Method to print topscores
        public void PrintTopScores(Quiz quiz)
        {
            // Prints title of quiz
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine(quiz.Title?.ToUpper());
            Console.WriteLine("══════════════════════════════");

            // Prints error message if there is no topscore for the quiz
            if (quiz.topScores.Count < 1)
            {
                Console.WriteLine("Inga sparade resultat.");
            }

            // Sorting of topscore objects, highest to lowest score
            quiz.topScores.Sort((ts1, ts2) => ts2.Score.CompareTo(ts1.Score));

            // Loops through list of topscores and print name and score
            foreach (TopScore topScore in quiz.topScores)
            {
                Console.WriteLine(topScore.Name + " " + topScore.Score + " poäng");
            }
            Console.WriteLine("══════════════════════════════\n");
        }
    }
}
