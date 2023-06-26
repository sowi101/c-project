// See https://aka.ms/new-console-template for more information

using Quiz_A_Lot;

internal class Program
{
    private static void Main(string[] args)
    {
        // New instance of QuizApp
        QuizApp quizApp = new();
        // Iteration variable
        int i = 0;

        Console.WriteLine(Directory.GetCurrentDirectory());


        // While loop that runs as long the conditional is set to true
        while (true)
        {
            // Clearing of console
            Console.Clear();
            // Cursor non-visible
            Console.CursorVisible = false;
            // Printing of menu
            Console.WriteLine("VÄLKOMMEN TILL QUIZ-A-LOT\n\n");
            Console.WriteLine("Information om applikationen.\n\n");
            Console.WriteLine("MENYVAL");
            Console.WriteLine("1. Ta ett quiz");
            Console.WriteLine("2. Hantera quiz\n");
            Console.WriteLine("3. Stäng appen\n");

            // Setting the iteration variable to zero
            i = 0;

            // Utskrift med de tre senaste skapade quiz
            // Sort.Reverse()
            // Sort.Resize
            // Foreach
            var quizzes = quizApp.GetQuizzes();

            Console.WriteLine("DE TRE SENASTE SKAPADE QUIZEN");
            // Foreach loop that prints the last three created quizzes 
            if(quizzes != null) {

                quizzes.Reverse();

                var firstThreeQuizzes = quizzes.Take(3);

                foreach (Quiz quiz in firstThreeQuizzes)
                {
                    // Printing name of quiz and amount of questions
                    Console.WriteLine(quiz.Title + " (" + quiz.questions.Count + " frågor)");
                }
            }


            // Save option input for menu to a variable
            int option = (int)Console.ReadKey(true).Key;

            // Switch that runs different code based on value of option variable
            switch (option)
            {
                case '1': // Print all quizzes
                          // Cursor visible
                    Console.Clear();
                    Console.CursorVisible = true;
                    // Get all quizzes

                    // Setting the iteration variable to zero
                    i = 0;

                    var allQuizzes = quizApp.GetQuizzes();

                    foreach (Quiz quiz in allQuizzes)
                    {
                        // Printing name of quiz and amount of questions
                        Console.WriteLine("[" + i++ + "] " + quiz.Title + "(" + quiz.questions.Count() + " frågor");
                    }

                    Console.WriteLine("Ange siffra för det quiz du vill genomföra: ");
                    // Save option input for menu to a variable
                    int quizOption = Convert.ToInt32(Console.ReadLine());

                    var chosenQuiz = allQuizzes[quizOption];

                    Console.WriteLine(chosenQuiz.Title);

                    foreach (var question in chosenQuiz.questions)
                    {
                        var a = 0;
                        Console.WriteLine(question.Text);
                        foreach (var answer in question.answers)
                        {
                            Console.WriteLine("[" + a++ + "]" + answer.Text);
                        }
                    }

                    Console.Read();
                    break;
                case '2':

                    // Cursor visible
                    Console.Clear();
                    Console.CursorVisible = true;

                    Console.WriteLine("MENYVAL");
                    Console.WriteLine("1. Skapa quiz");
                    Console.WriteLine("2. Ändra quiz");
                    Console.WriteLine("3. Radera quiz");
                    Console.WriteLine("4. Tillbaka till huvudmenyn");

                    // Printing of text for input
                    Console.Write("Ange nummer för vad du vill göra: ");
                    // Saving input for menu variable
                    int quizManageOption = (int)Console.ReadKey(true).Key;

                    switch (quizManageOption)
                    {
                        case '1':
                            Console.Clear();
                            Console.CursorVisible = true;
                            // Skapa quiz

                            // New instance of Post
                            Quiz quiz = new();

                            // Printing of text for input
                            Console.WriteLine("Titel på quiz: ");
                            // Saving of input to variable
                            string title = Console.ReadLine();

                            // While loop that runs as long the string is empty
                            while (string.IsNullOrEmpty(title))
                            {
                                // Printing of error message
                                Console.WriteLine("Du har glömt att fylla i en titel för quizet.");
                                // Printing of text for input
                                Console.Write("Titel på quiz: ");
                                // Saving of input to variable
                                title = Console.ReadLine();
                            }

                            // Saves variable to object
                            quiz.Title = title;

                            // Printing of text for input
                            Console.WriteLine("Antal frågor i quizet: ");
                            // Savíng of input to variable
                            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            for (var q = 1; q <= numberOfQuestions; q++)
                            {
                                Question question = new();

                                // Printing of text for input
                                Console.WriteLine("Fråga " + q + ": ");

                                // Savíng of input to variable
                                string text = Console.ReadLine();

                                // While loop that runs as long the string is empty
                                while (string.IsNullOrEmpty(text))
                                {
                                    // Printing of error message
                                    Console.WriteLine("Du har glömt att skriva en fråga.");
                                    // Printing of text for input
                                    Console.WriteLine("Fråga " + q + ": ");
                                    // Savíng of input to variable
                                    text = Console.ReadLine();
                                }

                                // Saves variable to object
                                question.Text = text;

                                for (var a = 1; a < 4; a++)
                                {
                                    Answer answer = new();

                                    Console.WriteLine("Svar " + a + ": ");
                                    // Savíng of input to variable
                                    string atext = Console.ReadLine();

                                    // While loop that runs as long the string is empty
                                    while (string.IsNullOrEmpty(atext))
                                    {
                                        // Printing of error message
                                        Console.WriteLine("Du har glömt att skriva svar.");
                                        // Printing of text for input
                                        Console.WriteLine("Svar " + a + ": ");
                                        // Savíng of input to variable
                                        atext = Console.ReadLine();
                                    }

                                    answer.Text = atext;

                                    Console.WriteLine("Är detta det rätta svaret? Ange J för ja och N för nej.");
                                    char acorrect = (char)Console.ReadKey().KeyChar;
                                    Console.WriteLine();

                                    if (acorrect.Equals('j'))
                                    {
                                        answer.IsCorrect = true;
                                    }
                                    else
                                    {
                                        answer.IsCorrect = false;
                                    }

                                    question.AddAnswer(answer);
                                }

                                quiz.AddQuestion(question);

                            }

                            Console.WriteLine(quiz.Title);
                            
                            foreach (var question in quiz.questions) {
                                Console.WriteLine(question.Text);

                                foreach (var answer in question.answers)
                                {
                                    Console.WriteLine(answer.Text + ", " + answer.IsCorrect);
                                }
                            }

                            quizApp.AddQuiz(quiz);


                            Console.Read();
                            break;
                        case '2':
                            Console.Clear();
                            Console.CursorVisible = true;

                            // Printing of text for input
                            Console.Write("Ange nummer på quiz som ska ändras: ");
                            // Saving input to variable
                            int editQuizOption = (int)Console.ReadKey(true).Key;

                            break;
                        case '3':
                            Console.Clear();
                            Console.CursorVisible = true;

                            // Printing of text for input
                            Console.Write("Ange nummer på quiz som ska raderas: ");
                            // Saving input to variable
                            int removeQuizOption = (int)Console.ReadKey(true).Key;
                            // Converting variable to integer and call of method to delete post
                            quizApp.DeleteQuiz(Convert.ToInt32(removeQuizOption));

                            break;
                        case '4':
                            break;
                    }
                    break;

                case '3':
                    // Quit program
                    Environment.Exit(0);
                    break;
            }
        }
    }
}