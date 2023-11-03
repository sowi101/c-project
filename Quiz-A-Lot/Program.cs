// See https://aka.ms/new-console-template for more information

/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-10-26
*/

using Quiz_A_Lot;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // New instance of QuizApp and ErrorHandling
        QuizApp quizApp = new();
        ErrorHandling errorHandling = new();

        // While loop that runs as long the conditional is set to true
        while (true)
        {
            Console.Clear();

            // Printing of information and menu
            Console.WriteLine("╔═══════════════════════════╗");
            Console.WriteLine("║ VÄLKOMMEN TILL QUIZ-A-LOT ║");
            Console.WriteLine("╚═══════════════════════════╝\n");

            Console.WriteLine("SYFTET MED DETTA PROGRAM ÄR ATT KUNNA SKAPA OCH GENOMGÖRA QUIZ.");
            Console.WriteLine("VID GENOMFÖRANDE AV ETT QUIZ SPARAS DITT RESULTAT I QUIZETS TOPPLISTA.");
            Console.WriteLine("QUIZEN KAN ÄNDRAS OCH RADERAS VID BEHOV OCH TOPPLISTAN KAN NOLLSTÄLLAS. \n");

            Console.WriteLine("╔══════════════════╗");
            Console.WriteLine("║ [1] TA ETT QUIZ  ║");
            Console.WriteLine("║ [2] HANTERA QUIZ ║");
            Console.WriteLine("║ [3] TOPPLISTOR   ║");
            Console.WriteLine("║ [4] STÄNG APPEN  ║");
            Console.WriteLine("╚══════════════════╝\n");

            // Printing info about the last three added quizzes
            var allQuizzes = quizApp.GetQuizzes();

            // Save option input for menu to a variable
            Console.Write("ANGE MENYVAL: ");
            string? option = Console.ReadLine();

            int validOption = errorHandling.MenuOptionErrorCheck(option, 4);

            // Switch for main menu
            switch (validOption)
            {
                case 1: // Main menu
                    Console.Clear();

                    Console.WriteLine("╔═════════════╗");
                    Console.WriteLine("║ TA ETT QUIZ ║");
                    Console.WriteLine("╚═════════════╝\n");
                    

                    // Print information about quizzes
                    if (allQuizzes.Count < 1)
                    {
                        Console.WriteLine("══════════════════════════════");
                        Console.WriteLine("DET FINNS INGA SPARADE QUIZ.\n");
                        Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");

                        Console.ReadKey();

                        // Code to clear buffer before returning to main menu
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(intercept: true);
                        }
                        break;
                    }

                    quizApp.PrintQuizzes(allQuizzes);
                    Console.WriteLine();

                    Console.Write("ANGE VILKET QUIZ DU VILL GENOMFÖRA: ");

                    // Save option input for menu to a variable
                    string? quizOption = Console.ReadLine();

                    int validQuizOption = errorHandling.MenuOptionErrorCheck(quizOption, allQuizzes.Count);

                    var chosenQuiz = allQuizzes[validQuizOption - 1];

                    Console.Clear();
                    Console.WriteLine("══════════════════════════════");
                    Console.WriteLine(chosenQuiz.Title);
                    Console.WriteLine("══════════════════════════════\n");

                    int score = 0;
                    int q = 1;
                    

                    foreach (var question in chosenQuiz.questions)
                    {
                        Console.WriteLine("══════════════════════════════");
                        Console.WriteLine("FRÅGA " + q + ": " + question.Text.ToUpper());
                        Console.WriteLine("══════════════════════════════");

                        int a = 1;

                        foreach (var answer in question.answers)
                        {
                            Console.WriteLine("[" + a++ + "] " + answer.Text);
                        }

                        Console.WriteLine();
                        Console.Write("DITT SVAR: ");

                        string userAnswer = Console.ReadLine();
                        int validUserAnswer = errorHandling.MenuOptionErrorCheck(userAnswer, 3);

                        if (question.answers[validUserAnswer - 1].IsCorrect)
                        {
                            score++;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("══════════════════════════════");
                    Console.WriteLine("DU FICK " + score + " POÄNG!\n");

                    Console.Write("ANGE NAMN FÖR TOPPLISTAN: ");

                    string userName = Console.ReadLine();
                    string validUserName = errorHandling.TextErrorCheck(userName, "name");

                    Console.WriteLine();

                    TopScore topScore = new TopScore();
                    topScore.Score = score;
                    topScore.Name = validUserName;

                    allQuizzes[validQuizOption-1].AddTopScore(topScore);
                    quizApp.ChangeQuiz();

                    Console.WriteLine("══════════════════════════════");
                    Console.WriteLine("DITT RESULTAT ÄR SPARAT!\n");

                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");

                    Console.ReadKey();

                    // Code to clear buffer before returning to main menu
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(intercept: true);
                    }

                    break;
                case 2: // Main menu
                    Console.Clear();
                    Console.CursorVisible = true;

                    Console.WriteLine("╔══════════════╗");
                    Console.WriteLine("║ HANTERA QUIZ ║");
                    Console.WriteLine("╚══════════════╝\n");

                    Console.WriteLine("╔══════════════════╗");
                    Console.WriteLine("║ [1] SKAPA QUIZ   ║");
                    Console.WriteLine("║ [2] ÄNDRA QUIZ   ║");
                    Console.WriteLine("║ [3] RADERA QUIZ  ║");
                    Console.WriteLine("║ [4] HUVUDMENY    ║");
                    Console.WriteLine("╚══════════════════╝\n");

                    // Printing of text for input
                    Console.Write("ANGE MENYVAL: ");
                    // Saving input for menu variable
                    string? quizManageOption = Console.ReadLine();

                    int validQuizManageOption = errorHandling.MenuOptionErrorCheck(quizManageOption, 4);

                    // Switch for quiz management
                    switch (validQuizManageOption)
                    {
                        case 1: // Create quiz
                            Console.Clear();
                            Console.CursorVisible = true;

                            // New instance of Quiz
                            Quiz quiz = new();

                            Console.WriteLine("╔════════════╗");
                            Console.WriteLine("║ SKAPA QUIZ ║");
                            Console.WriteLine("╚════════════╝\n");


                            // Printing of text for input
                            Console.WriteLine("══════════════════════════════");
                            Console.Write("TITEL PÅ QUIZ: ");
                            // Saving of input to variable
                            string titleInput = Console.ReadLine();
                            string validTitle = errorHandling.TextErrorCheck(titleInput, "title");
                            quiz.Title = validTitle;


                            // Printing of text for input
                            Console.WriteLine("══════════════════════════════");
                            Console.Write("ANTAL FRÅGOR I QUIZET: ");
                            // Saving of input to variable
                            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());

                            while (numberOfQuestions < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("QUIZET MÅSTE INNEHÅLLA MINST 1 FRÅGA.");
                                numberOfQuestions = Convert.ToInt32(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            for (q = 1; q <= numberOfQuestions; q++)
                            {
                                Question question = new();

                                // Printing of text for input
                                Console.WriteLine("══════════════════════════════");
                                Console.Write("FRÅGA " + q + ": ");

                                // Savíng of input to variable
                                string questionText = Console.ReadLine();
                                string validQuestionText = errorHandling.TextErrorCheck(questionText, "question", q);
                                question.Text = validQuestionText;

                                for (int a = 1; a < 4; a++)
                                {
                                    Answer answer = new();
                                    Console.WriteLine("══════════════════════════════");
                                    Console.Write("SVAR " + a + ": ");

                                    string answertext = Console.ReadLine();
                                    string validAnswerText = errorHandling.TextErrorCheck(answertext, "answer", a);
                                     answer.Text = validAnswerText;

                                    Console.WriteLine("ÄR SVARET KORREKT? ANGE J FÖR JA OCH N FÖR NEJ.");
                                    string correctAnswer = Console.ReadLine();
                                    string validCorrectAnswer = errorHandling.YesOrNoOptionErrorCheck(correctAnswer);

                                    if (validCorrectAnswer.Equals("J", StringComparison.OrdinalIgnoreCase))
                                    {
                                        answer.IsCorrect = true;
                                    }
                                    else if (validCorrectAnswer.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        answer.IsCorrect = false;
                                    }

                                    question.AddAnswer(answer);

                                }

                                bool correctAnswerExists = question.answers.Any(a => a.IsCorrect == true);

                                if (!correctAnswerExists)
                                {
                                    Console.WriteLine("══════════════════════════════");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("FRÅGAN SAKNAR ETT KORREKT SVAR!\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("VILKET SVAR ÄR KORREKT?");

                                    int a1 = 1;
                                    foreach (Answer answer1 in question.answers)
                                    {
                                        
                                        Console.WriteLine($"{a1}. {answer1.Text}");
                                        a1++;
                                    }

                                    string correctAnswerOption = Console.ReadLine();
                                    int validCorrectAnswerOption = errorHandling.MenuOptionErrorCheck(correctAnswerOption, 3);

                                    question.answers[validCorrectAnswerOption-1].IsCorrect = true;
                                }

                                quiz.AddQuestion(question);

                            }
                            quizApp.AddQuiz(quiz);

                            Console.WriteLine("══════════════════════════════");
                            Console.WriteLine("QUIZET ÄR SPARAT!\n");

                            Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");

                            Console.ReadKey();

                            // Code to clear buffer before returning to main menu
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(intercept: true);
                            }
                            break;
                        case 2: // Edit quiz
                            Console.Clear();

                            Console.WriteLine("╔════════════╗");
                            Console.WriteLine("║ ÄNDRA QUIZ ║");
                            Console.WriteLine("╚════════════╝\n");

                            if (allQuizzes.Count < 1)
                            {
                                Console.WriteLine("DET FINNS INGA SPARADE QUIZ.");
                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                Console.ReadKey();

                                // Code to clear buffer before returning to main menu
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(intercept: true);
                                }
                                break;
                            }

                            // Print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            // Printing of text for input
                            Console.Write("ANGE QUIZ SOM SKA ÄNDRAS: ");
                            // Saving input to variable
                            string? editQuizOption = Console.ReadLine();

                            int validEditQuizOption = errorHandling.MenuOptionErrorCheck(editQuizOption, allQuizzes.Count) - 1;

                            var chosenQuizToEdit = allQuizzes[validEditQuizOption];
                            Console.WriteLine("VAD VILL DU GÖRA?");

                            Console.WriteLine("╔═══════════════════════════════╗");
                            Console.WriteLine("║ [1] ÄNDRA TITEL               ║");
                            Console.WriteLine("║ [2] ÄNDRA ELLER RADERA FRÅGOR ║");
                            Console.WriteLine("║ [3] RADERA TOPPLISTA          ║");
                            Console.WriteLine("║ [4] HUVUDMENY                 ║"); // Kommer jag till huvudmeny
                            Console.WriteLine("╚═══════════════════════════════╝\n");

                            string editOption = Console.ReadLine();

                            int validEditOption = errorHandling.MenuOptionErrorCheck(editOption, 4);

                            // Switch for editing of quiz
                            switch (validEditOption)
                            {
                                case 1: // Edit quiz title
                                    Console.Clear();

                                    Console.WriteLine("╔═════════════╗");
                                    Console.WriteLine("║ ÄNDRA TITEL ║");
                                    Console.WriteLine("╚═════════════╝\n");

                                    // Ändra titel
                                    Console.Write("ANGE ÄNDRING: ");
                                    string newTitle = Console.ReadLine();

                                    string validNewTitle = errorHandling.TextErrorCheck(newTitle, "title");

                                    chosenQuizToEdit.Title = validNewTitle;
                                    quizApp.ChangeQuiz();

                                    Console.WriteLine("\n══════════════════════════════");
                                    Console.WriteLine("TITEL ÄNDRAD!\n");
                                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                    Console.ReadKey();

                                    // Code to clear buffer before returning to main menu
                                    while (Console.KeyAvailable)
                                    {
                                        Console.ReadKey(intercept: true);
                                    }
                                    break;
                                case 2: // Edit or delete question
                                    Console.Clear();
                                    Console.WriteLine("╔═══════════════════════════╗");
                                    Console.WriteLine("║ ÄNDRA ELLER TA BORT FRÅGA ║");
                                    Console.WriteLine("╚═══════════════════════════╝\n");

                                    Console.WriteLine("VILKEN FRÅGA VILL DU ÄNDRA ELLER TA BORT?");
                                    q = 1;
                                    foreach (var question in chosenQuizToEdit.questions)
                                    {
                                        Console.WriteLine("[" + q++ + "]" + question.Text);
                                    }

                                    string questionToEdit = Console.ReadLine();
                                    int validQuestionToEdit = errorHandling.MenuOptionErrorCheck(questionToEdit, chosenQuizToEdit.questions.Count);

                                    Console.WriteLine("╔══════════════════╗");
                                    Console.WriteLine("║ [1] ÄNDRA TEXT   ║");
                                    Console.WriteLine("║ [2] ÄNDRA SVAR   ║");
                                    Console.WriteLine("║ [3] RADERA FRÅGA ║");
                                    Console.WriteLine("╚══════════════════╝\n");

                                    string manageEditOfQuestion = Console.ReadLine();
                                    int validManageEditOfQuestion = errorHandling.MenuOptionErrorCheck(manageEditOfQuestion, 3);

                                    // Switch for editing of question
                                    switch (validManageEditOfQuestion)
                                    {
                                        case 1: // Edit text for question
                                            Console.Clear();
                                            Console.WriteLine("╔══════════════════════╗");
                                            Console.WriteLine("║ ÄNDRA TEXT FÖR FRÅGA ║");
                                            Console.WriteLine("╚══════════════════════╝\n");

                                            Console.WriteLine("ANGE ÄNDRING: ");
                                            string newQuestion = Console.ReadLine();

                                            chosenQuizToEdit.questions[validQuestionToEdit-1].Text = newQuestion;
                                            quizApp.ChangeQuiz();

                                            Console.WriteLine("\n══════════════════════════════");
                                            Console.WriteLine("FRÅGA ÄNDRAD!\n");
                                            Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                            Console.ReadKey();

                                            // Code to clear buffer before returning to main menu
                                            while (Console.KeyAvailable)
                                            {
                                                Console.ReadKey(intercept: true);
                                            }
                                            break;
                                        case 2: // Edit answers for question
                                            Console.Clear();
                                            Console.WriteLine("╔══════════════════════╗");
                                            Console.WriteLine("║ ÄNDRA SVAR FÖR FRÅGA ║");
                                            Console.WriteLine("╚══════════════════════╝\n");

                                            Console.WriteLine("VILKET SVAR VILL DU ÄNDRA?\n");
                                            int a = 1;
                                            foreach (var answer in chosenQuizToEdit.questions[validQuestionToEdit-1].answers)
                                            {
                                                Console.WriteLine("[" + a++ + "]" + answer.Text);
                                            }

                                            string answerToEdit = Console.ReadLine();
                                            int validAnswerToEdit = errorHandling.MenuOptionErrorCheck(answerToEdit, 3);

                                            Console.WriteLine("VAD VILL DU ÄNDRA PÅ SVARET?\n");
                                            Console.WriteLine("╔══════════════════════╗");
                                            Console.WriteLine("║ [1] ÄNDRA TEXT       ║");
                                            Console.WriteLine("║ [2] ÄNDRA RÄTT/FEL   ║");
                                            Console.WriteLine("╚══════════════════════╝\n");

                                            string manageAnswerEdit = Console.ReadLine();

                                            int validMangageAnswerEdit = errorHandling.MenuOptionErrorCheck(manageAnswerEdit, 2);

                                            if (validMangageAnswerEdit == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("╔═════════════════════╗");
                                                Console.WriteLine("║ ÄNDRA TEXT FÖR SVAR ║");
                                                Console.WriteLine("╚═════════════════════╝\n");

                                                Console.WriteLine("ANGE ÄNDRING: ");
                                                string newAnswer = Console.ReadLine();
                                                string validNewAnswer = errorHandling.TextErrorCheck(newAnswer, "answer", validAnswerToEdit);
                                                chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].Text = validNewAnswer;
                                                quizApp.ChangeQuiz();

                                                Console.WriteLine("\n══════════════════════════════");
                                                Console.WriteLine("SVAR ÄNDRAT!\n");
                                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                Console.ReadKey();

                                                // Code to clear buffer before returning to main menu
                                                while (Console.KeyAvailable)
                                                {
                                                    Console.ReadKey(intercept: true);
                                                }
                                            }
                                            else if (validMangageAnswerEdit == 2)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("╔════════════════╗");
                                                Console.WriteLine("║ ÄNDRA RÄTT/FEL ║");
                                                Console.WriteLine("╚════════════════╝\n");

                                                Console.WriteLine("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ.");

                                                string newAnswerCorrect = Console.ReadLine();
                                                string validNewAnswerCorrect = errorHandling.YesOrNoOptionErrorCheck(newAnswerCorrect);

                                                if (validNewAnswerCorrect.Equals("J", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = true;

                                                    quizApp.ChangeQuiz();
                                                    Console.Write("SVAR PÅ FRÅGA " + validQuestionToEdit + " ÄNDRAD!");
                                                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                    Console.ReadKey();

                                                    // Code to clear buffer before returning to main menu
                                                    while (Console.KeyAvailable)
                                                    {
                                                        Console.ReadKey(intercept: true);
                                                    }
                                                }
                                                else if (newAnswerCorrect.Equals("N", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = false;

                                                    bool correctAnswerAfterEditExists = chosenQuizToEdit.questions[validQuestionToEdit - 1].answers.Any(a => a.IsCorrect == true);

                                                    if (!correctAnswerAfterEditExists)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("FRÅGAN SAKNAR ETT KORREKT SVAR.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine("VILKEN AV SVAREN ÄR KORREKT?");
                                                        int anum = 1;
                                                        foreach (Answer answer1 in chosenQuizToEdit.questions[validQuestionToEdit - 1].answers)
                                                        {
                                                            
                                                            Console.WriteLine($"{anum}. {answer1.Text}");
                                                            anum++;
                                                        }

                                                        string correctAnswerOption = Console.ReadLine();
                                                        int validCorrectAnswerOption = errorHandling.MenuOptionErrorCheck(correctAnswerOption, 3);

                                                        chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validCorrectAnswerOption - 1].IsCorrect = true;
                                                    }

                                                    quizApp.ChangeQuiz();
                                                    Console.Write("SVAR " + validAnswerToEdit + " PÅ FRÅGA " + validQuestionToEdit + " ÄNDRAD!");
                                                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                    Console.ReadKey();

                                                    // Code to clear buffer before returning to main menu
                                                    while (Console.KeyAvailable)
                                                    {
                                                        Console.ReadKey(intercept: true);
                                                    }
                                                }
                                            }

                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine("╔══════════════╗");
                                            Console.WriteLine("║ RADERA FRÅGA ║");
                                            Console.WriteLine("╚══════════════╝\n");

                                            Console.WriteLine("ÄR DU SÄKER PÅ ATT DU VILL RADERA FRÅGAN?");
                                            string controlAnswerDeleteQuestion = Console.ReadLine();

                                            string validControlAnswerDeleteQuestion = errorHandling.YesOrNoOptionErrorCheck(controlAnswerDeleteQuestion);

                                            if (validControlAnswerDeleteQuestion.Equals("J", StringComparison.OrdinalIgnoreCase))
                                            {
                                                chosenQuizToEdit.DeleteQuestion(validQuestionToEdit - 1);
                                                Console.WriteLine("FRÅGA RADERAD!\n");
                                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                Console.ReadKey();

                                                // Code to clear buffer before returning to main menu
                                                while (Console.KeyAvailable)
                                                {
                                                    Console.ReadKey(intercept: true);
                                                }
                                            }
                                            else if (validControlAnswerDeleteQuestion.Equals("N", StringComparison.OrdinalIgnoreCase))
                                            {
                                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                Console.ReadKey();

                                                // Code to clear buffer before returning to main menu
                                                while (Console.KeyAvailable)
                                                {
                                                    Console.ReadKey(intercept: true);
                                                }
                                            }
                                            
                                            break;
                                    }

                                    break;
                                case 3: // Delete topscore

                                    Console.WriteLine("╔══════════════════╗");
                                    Console.WriteLine("║ RADERA TOPPLISTA ║");
                                    Console.WriteLine("╚══════════════════╝\n");

                                    // Control question
                                    Console.WriteLine("ÄR DU SÄKER PÅ ATT DU VILL RADERA TOPPLISTAN FÖR " + chosenQuizToEdit.Title + "?");
                                    string controlAnswerTopScore = Console.ReadLine();

                                    string validControlAnswerTopScore = errorHandling.YesOrNoOptionErrorCheck(controlAnswerTopScore);

                                    if (validControlAnswerTopScore.Equals("J", StringComparison.OrdinalIgnoreCase))
                                    {
                                        chosenQuizToEdit.DeleteTopScores();
                                        quizApp.ChangeQuiz();
                                        Console.WriteLine("TOPPLISTA RADERAD!\n");
                                        Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                        Console.ReadKey();

                                        // Code to clear buffer before returning to main menu
                                        while (Console.KeyAvailable)
                                        {
                                            Console.ReadKey(intercept: true);
                                        }
                                    }
                                    else if (validControlAnswerTopScore.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                        Console.ReadKey();

                                        // Code to clear buffer before returning to main menu
                                        while (Console.KeyAvailable)
                                        {
                                            Console.ReadKey(intercept: true);
                                        }
                                    }
                                    break;
                                case 4:
                                    // Return to main menu
                                    break;
                            }
                            break;

                        // Delete quiz
                        case 3: // Manage quiz
                            Console.Clear();
                            Console.WriteLine("╔═════════════╗");
                            Console.WriteLine("║ RADERA QUIZ ║");
                            Console.WriteLine("╚═════════════╝\n");

                            // Print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            // Printing of text for input
                            Console.Write("ANGE QUIZ SOM SKA RADERAS: ");
                            // Saving input to variable
                            string removeQuizOption = Console.ReadLine();

                            int validRemoveQuizOption = errorHandling.MenuOptionErrorCheck(removeQuizOption, allQuizzes.Count);

                            // Control question
                            Console.WriteLine("ÄR DU SÄKER PÅ ATT DU VILL RADERA " + allQuizzes[validRemoveQuizOption - 1].Title + "?");
                            string controlAnswer = Console.ReadLine();

                            string validControlAnswer = errorHandling.YesOrNoOptionErrorCheck(controlAnswer);

                            if (validControlAnswer.Equals("J", StringComparison.OrdinalIgnoreCase))
                            {
                                quizApp.DeleteQuiz(validRemoveQuizOption);
                                Console.WriteLine("QUIZ RADERAT!");
                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                Console.ReadKey();

                                // Code to clear buffer before returning to main menu
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(intercept: true);
                                }
                            }
                            else if (validControlAnswer.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                Console.ReadKey();

                                // Code to clear buffer before returning to main menu
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(intercept: true);
                                }
                            }
                            break;
                        case 4:
                            // Return to main menu
                            break;
                    }
                    break;
                case 3: // Main menu
                        // Print topScores for all quizzes
                    Console.Clear();
                    Console.WriteLine("╔════════════╗");
                    Console.WriteLine("║ TOPPLISTOR ║");
                    Console.WriteLine("╚════════════╝\n");

                    // Print information about quizzes
                    if (allQuizzes.Count < 1)
                    {
                        Console.WriteLine("DET FINNS INGA SPARADE QUIZ.\n");
                    }

                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENY.\n");

                    foreach (Quiz quiz in allQuizzes)
                    {
                        quiz.PrintTopScores(quiz);
                    }

                    Console.ReadKey();
                    
                    // Code to clear buffer before returning to main menu
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(intercept: true);
                    }

                    break;
                case 4:
                    // Quit program
                    Environment.Exit(0);
                    break; 
            }
        }
    }
}