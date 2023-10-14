using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_A_Lot
{
    internal class Question
    {
        public string? Text { get; set; }
        public List<Answer> answers = new();

        // Method to add an answer
        public Answer AddAnswer(Answer answer)
        {
            // Adds the object to the array of questions
            answers.Add(answer);
            return answer;
        }

        // Method that delete a specific question
        public int DeleteAnswer(int index)
        {
            // Deletes the question with the specific index
            answers.RemoveAt(index);
            return index;
        }

        public int EditAnswer(Answer editedAnswer, int index)
        {
            answers[index] = editedAnswer;

            return index;
        }

        // Method that return an array of all questions
        public List<Answer> GetAnswers()
        {
            return answers;
        }
    }
}
