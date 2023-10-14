// See https://aka.ms/new-console-template for more information

/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-09-24
*/

using Quiz_A_Lot;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // New instance of QuizApp
        QuizApp quizApp = new();
        ErrorHandling errorHandling = new ErrorHandling();

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
            Console.WriteLine("HUVUDMENY");
            Console.WriteLine("[1] Ta ett quiz");
            Console.WriteLine("[2] Hantera quiz");
            Console.WriteLine("[3] Se topplistor");
            Console.WriteLine("[4] Stäng appen");
            Console.WriteLine();

            // Printing info about the last three added quizzes
            var allQuizzes = quizApp.GetQuizzes();

            //Console.WriteLine("DE TRE SENASTE SKAPADE QUIZEN");

            //if(allQuizzes != null) {
            //allQuizzes.Reverse();
            //var firstThreeQuizzes = allQuizzes.Take(3);

            //foreach (Quiz quiz in firstThreeQuizzes)
            //{
            // Printing name of quiz and amount of questions
            //Console.WriteLine(quiz.Title + " (" + quiz.questions.Count + " frågor)");
            //}
            //}

            Console.Write("Ange menyval: ");
            // Save option input for menu to a variable
            string? option = Console.ReadLine();

            int validOption = errorHandling.MenuOptionErrorCheck(option, 4);

            // Switch for main menu
            switch (validOption)
            {
                case 1: // Main menu
                    Console.Clear();
                    Console.WriteLine("TA ETT QUIZ\n\n");
                    Console.CursorVisible = true;

                    // Print information about quizzes
                    if (allQuizzes.Count < 1)
                    {
                        Console.WriteLine("Det finns inga sparade quiz.");
                        Console.Read();
                        break;
                    }

                    quizApp.PrintQuizzes(allQuizzes);
                    Console.WriteLine();

                    // Save option input for menu to a variable
                    string? quizOption = Console.ReadLine();

                    int validQuizOption = errorHandling.MenuOptionErrorCheck(quizOption, allQuizzes.Count);

                    var chosenQuiz = allQuizzes[validQuizOption - 1];

                    Console.WriteLine(chosenQuiz.Title);

                    int score = 0;

                    foreach (var question in chosenQuiz.questions)
                    {
                        int a = 1;
                        Console.WriteLine(question.Text);
                        foreach (var answer in question.answers)
                        {
                            Console.WriteLine("[" + a++ + "]" + answer.Text);
                        }

                        // Ange svar
                        string userAnswer = Console.ReadLine();

                        int validUserAnswer = errorHandling.MenuOptionErrorCheck(userAnswer, 3);

                        if (question.answers[validUserAnswer - 1].IsCorrect)
                        {
                            score++;
                        }
                    }

                    Console.WriteLine("Du fick " + score + " poäng!");

                    Console.WriteLine("Ange namn för topplistan: ");
                    string userName = Console.ReadLine();
                    string validUserName = errorHandling.TextErrorCheck(userName, "name");

                    TopScore topScore = new TopScore();
                    topScore.Score = score;
                    topScore.Name = validUserName;

                    allQuizzes[validQuizOption].AddTopScore(topScore);
                    quizApp.ChangeQuiz();

                    Console.Read();
                    break;
                case 2: // Main menu

                    // Cursor visible
                    Console.Clear();
                    Console.CursorVisible = true;

                    Console.WriteLine("MENYVAL");
                    Console.WriteLine("1. Skapa quiz");
                    Console.WriteLine("2. Ändra quiz");
                    Console.WriteLine("3. Radera quiz");
                    Console.WriteLine("4. Tillbaka till huvudmenyn");

                    // Printing of text for input
                    Console.Write("Ange menyval: ");
                    // Saving input for menu variable
                    string? quizManageOption = Console.ReadLine();

                    int validQuizManageOption = errorHandling.MenuOptionErrorCheck(quizManageOption, 4);

                    // Switch for quiz management
                    switch (validQuizManageOption)
                    {
                        // Create quiz
                        case 1: // Quiz manage
                            Console.Clear();
                            Console.CursorVisible = true;

                            // New instance of Quiz
                            Quiz quiz = new();

                            // Printing of text for input
                            Console.WriteLine("Titel på quiz: ");
                            // Saving of input to variable
                            string titleInput = Console.ReadLine();

                            string validTitle = errorHandling.TextErrorCheck(titleInput, "title");

                            // Saves variable to object
                            quiz.Title = validTitle;

                            // Printing of text for input
                            Console.Write("Antal frågor i quizet: ");
                            // Saving of input to variable
                            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());

                            while (numberOfQuestions < 1)
                            {
                                Console.WriteLine("Quizet måste innehålla minst 1 fråga.");
                                numberOfQuestions = Convert.ToInt32(Console.ReadLine());
                            }

                            for (var q = 1; q <= numberOfQuestions; q++)
                            {
                                Question question = new();

                                // Printing of text for input
                                Console.WriteLine("Fråga " + q + ": ");

                                // Savíng of input to variable
                                string questionText = Console.ReadLine();

                                string validQuestionText = errorHandling.TextErrorCheck(questionText, "question", q);

                                // Saves variable to object
                                question.Text = validQuestionText;

                                for (var a = 1; a < 4; a++)
                                {
                                    Answer answer = new();

                                    Console.WriteLine("Svar " + a + ": ");

                                    string answertext = Console.ReadLine();

                                    string validAnswerText = errorHandling.TextErrorCheck(answertext, "answer", a);

                                    answer.Text = validAnswerText;

                                    Console.WriteLine("Är detta det rätta svaret? Ange J för ja och N för nej.");
                                    string correctAnswer = Console.ReadLine();
                                    string validCorrectAnswer = errorHandling.YesOrNoOptionErrorCheck(correctAnswer);

                                    if (validCorrectAnswer.Equals('j'))
                                    {
                                        answer.IsCorrect = true;
                                    }
                                    else if (validCorrectAnswer.Equals('n'))
                                    {
                                        answer.IsCorrect = false;
                                    }

                                    question.AddAnswer(answer);

                                }
                                quiz.AddQuestion(question);
                            }
                            quizApp.AddQuiz(quiz);

                            Console.Read();
                            break;
                        // Change quiz
                        case 2: // Quiz manage
                            Console.Clear();
                            Console.CursorVisible = true;

                            Console.WriteLine("ÄNDRA QUIZ");

                            if (allQuizzes.Count < 1)
                            {
                                Console.WriteLine("Det finns inga sparade quiz.");
                                Console.WriteLine("Tryck Enter för att återgå till föregående meny.");
                                Console.Read();
                                break;
                            }

                            // Print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            // Printing of text for input
                            Console.Write("Ange nummer på quiz som ska ändras: ");
                            // Saving input to variable
                            string? editQuizOption = Console.ReadLine();

                            int validEditQuizOption = errorHandling.MenuOptionErrorCheck(editQuizOption, allQuizzes.Count) - 1;

                            var chosenQuizToEdit = allQuizzes[validEditQuizOption];
                            Console.WriteLine("Vad vill du göra?");

                            Console.WriteLine("[1] Ändra titel");
                            Console.WriteLine("[2] Ändra eller ta bort frågor");
                            Console.WriteLine("[3] Radera topplistan");
                            Console.WriteLine("[4] Tillbaka till huvudmeny");

                            string editOption = Console.ReadLine();

                            int validEditOption = errorHandling.MenuOptionErrorCheck(editOption, 4);

                            // Switch for editing of quiz
                            switch (validEditOption)
                            {
                                case 1: // Edit manage

                                    // Ändra titel
                                    Console.WriteLine("Ange ändring på titel: ");
                                    string newTitle = Console.ReadLine();

                                    string validNewTitle = errorHandling.TextErrorCheck(newTitle, "title");

                                    chosenQuizToEdit.Title = validNewTitle;
                                    quizApp.ChangeQuiz();

                                    Console.WriteLine("Titel ändrad!");
                                    Console.Read();

                                    break;
                                case 2: // Edit manage
                                    Console.WriteLine("Vilken fråga vill du ändra eller ta bort?");
                                    int q = 1;
                                    foreach (var question in chosenQuizToEdit.questions)
                                    {
                                        Console.WriteLine("[" + q++ + "]" + question.Text);
                                    }

                                    string questionToEdit = Console.ReadLine();
                                    int validQuestionToEdit = errorHandling.MenuOptionErrorCheck(questionToEdit, chosenQuizToEdit.questions.Count);

                                    Console.WriteLine("[1] Ändra text på frågan");
                                    Console.WriteLine("[2] Ändra svar på fråga");


                                    string manageEditOfQuestion = Console.ReadLine();
                                    int validManageEditOfQuestion = errorHandling.MenuOptionErrorCheck(manageEditOfQuestion, 2);

                                    // Switch for editing of question
                                    switch (validManageEditOfQuestion)
                                    {
                                        case 1: // Manage question
                                            Console.WriteLine("Ange ändring på fråga: ");
                                            string newQuestion = Console.ReadLine();

                                            chosenQuizToEdit.questions[validQuestionToEdit].Text = newQuestion;
                                            break;
                                        case 2: // Manage question
                                            Console.WriteLine("Vilket svar vill du ändra?");
                                            int a = 1;
                                            foreach (var answer in chosenQuizToEdit.questions[validQuestionToEdit].answers)
                                            {
                                                Console.WriteLine("[" + a++ + "]" + answer.Text);
                                            }

                                            string answerToEdit = Console.ReadLine();
                                            int validAnswerToEdit = errorHandling.MenuOptionErrorCheck(answerToEdit, 3);

                                            Console.WriteLine("Vad vill du ändra på svaret?");
                                            Console.WriteLine("[1] Ändra text på svaret");
                                            Console.WriteLine("[2] Ändra rätt eller fel");

                                            string manageAnswerEdit = Console.ReadLine();

                                            int validMangageAnswerEdit = errorHandling.MenuOptionErrorCheck(manageAnswerEdit, 2);

                                            if (validMangageAnswerEdit == 1)
                                            {
                                                Console.WriteLine("Ange ändring på svar: ");
                                                string newAnswer = Console.ReadLine();
                                                string validNewAnswer = errorHandling.TextErrorCheck(newAnswer, "answer", validAnswerToEdit);
                                                chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].Text = validNewAnswer;
                                                quizApp.ChangeQuiz();
                                            }
                                            else if (validMangageAnswerEdit == 2)
                                            {
                                                Console.WriteLine("Är svaret rätt (J) eller fel (N)?");

                                                char newAnswerCorrect = (char)Console.ReadKey().KeyChar;
                                                Console.WriteLine();

                                                if (newAnswerCorrect.Equals('j'))
                                                {
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = true;
                                                    quizApp.ChangeQuiz();
                                                    Console.Write("Svar " + validAnswerToEdit + " på fråga " + validQuestionToEdit + " ändrad!");
                                                    Console.Read();
                                                }
                                                else if (newAnswerCorrect.Equals('n'))
                                                {
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = false;
                                                    quizApp.ChangeQuiz();
                                                    Console.Write("Svar " + validAnswerToEdit + " på fråga " + validQuestionToEdit + " ändrad!");
                                                    Console.Read();
                                                }
                                            }

                                            break;
                                    }

                                    break;
                                case 3: // Edit manage
                                    // Control question
                                    Console.WriteLine("Är du säker att du vill radera topplistan för " + chosenQuizToEdit.Title + "?");
                                    string controlAnswerTopScore = Console.ReadLine();

                                    string validControlAnswerTopScore = errorHandling.YesOrNoOptionErrorCheck(controlAnswerTopScore);

                                    if (validControlAnswerTopScore == "J")
                                    {
                                        chosenQuizToEdit.DeleteTopScores();
                                        Console.WriteLine("TOPPLISTA RADERAD!");
                                        Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn.");
                                        Console.Read();
                                    }
                                    else if (validControlAnswerTopScore == "N")
                                    {
                                        Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn.");
                                        Console.Read();
                                    }
                                    chosenQuizToEdit.DeleteTopScores();
                                    break;
                                case 4:
                                    break;
                            }
                            break;

                        // Delete quiz
                        case 3: // Manage quiz
                            Console.Clear();
                            Console.WriteLine("RADERA QUIZ");

                            // Print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            // Printing of text for input
                            Console.Write("Ange nummer på quiz som ska raderas: ");
                            // Saving input to variable
                            string removeQuizOption = Console.ReadLine();

                            int validRemoveQuizOption = errorHandling.MenuOptionErrorCheck(removeQuizOption, allQuizzes.Count);

                            // Control question
                            Console.WriteLine("Är du säker att du vill radera " + allQuizzes[validRemoveQuizOption - 1].Title + "?");
                            string controlAnswer = Console.ReadLine();

                            string validControlAnswer = errorHandling.YesOrNoOptionErrorCheck(controlAnswer);

                            if (validControlAnswer == "J")
                            {
                                quizApp.DeleteQuiz(validRemoveQuizOption);
                                Console.WriteLine("QUIZ RADERAT!");
                                Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn.");
                                Console.Read();
                            }
                            else if (validControlAnswer == "N")
                            {
                                Console.WriteLine("Tryck på valfri tangent för att återvända till huvudmenyn.");
                                Console.Read();
                            }
                            break;
                        case 4: // Manage quiz
                            break;
                    }
                    break;
                case 3: // Main menu
                        // Print topScores for all quizzes
                    Console.Clear();
                    Console.WriteLine("TOPPLISTOR\n\n");

                    Console.WriteLine("Tryck Enter för att återvända till huvudmenyn");

                    foreach (Quiz quiz in allQuizzes)
                    {
                        quiz.PrintTopScores(quiz);
                    }

                    Console.Read();
                    break;
                case 4: // Main menu
                        // Quit program
                    Environment.Exit(0);
                    break;
                
                
            }
        }
    }
}