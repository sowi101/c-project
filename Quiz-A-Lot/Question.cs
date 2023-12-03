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
    internal class Question
    {
        // Fields / Properties
        public string? Text { get; set; }
        public List<Answer> answers = new();

        // Methods
        
        // Method to add an answer
        public Answer AddAnswer(Answer answer) 
        {
            // Adds the object to the array of answers
            answers.Add(answer);
            return answer;
        }
    }
}
