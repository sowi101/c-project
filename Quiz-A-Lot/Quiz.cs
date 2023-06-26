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

        // Method that delete a specific topscore
        public int DeleteTopScore(int index)
        {
            // Deletes the topscore with the specific index
            topScores.RemoveAt(index);
            return index;
        }

        // Method that return an array of all topscores
        public List<TopScore> GetTopScores()
        {
            return topScores;
        }
    }
}
