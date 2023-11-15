// See https://aka.ms/new-console-template for more information

/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-11-15
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
            Console.Write("ANGE DITT VAL: ");
            string? option = Console.ReadLine();

            int validOption = errorHandling.OptionErrorCheck(option, 4);

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

                    Console.WriteLine("VILKET QUIZ VILL DU GENOMFÖRA?\n");

                    quizApp.PrintQuizzes(allQuizzes);

                    Console.Write("\nANGE DITT VAL: ");

                    // Save option input for menu to a variable
                    string? quizOption = Console.ReadLine();

                    int validQuizOption = errorHandling.OptionErrorCheck(quizOption, allQuizzes.Count);

                    var chosenQuiz = allQuizzes[validQuizOption - 1];

                    Console.Clear();
                    Console.WriteLine("══════════════════════════════");
                    Console.WriteLine(chosenQuiz.Title.ToUpper());
                    Console.WriteLine("══════════════════════════════\n");

                    Console.WriteLine("QUIZET INNEHÅLLER " + chosenQuiz.questions.Count() + " FRÅGOR.\n");

                    int score = 0;
                    int q = 1;
                    

                    foreach (var question in chosenQuiz.questions)
                    {
                        Console.WriteLine("══════════════════════════════");
                        Console.WriteLine("FRÅGA " + q + ": " + question.Text.ToUpper());
                        Console.WriteLine();

                        int a = 1;

                        foreach (var answer in question.answers)
                        {
                            Console.WriteLine("[" + a++ + "] " + answer.Text);
                        }

                        Console.WriteLine();
                        Console.Write("ANGE DITT VAL: ");

                        string userAnswer = Console.ReadLine();
                        int validUserAnswer = errorHandling.OptionErrorCheck(userAnswer, 3);

                        if (question.answers[validUserAnswer - 1].IsCorrect)
                        {
                            score++;
                        }
                        Console.WriteLine();
                        q++;
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

                    Console.WriteLine("VAD VILL DU GÖRA?\n");

                    Console.WriteLine("╔═════════════════╗");
                    Console.WriteLine("║ [1] SKAPA QUIZ  ║");
                    Console.WriteLine("║ [2] ÄNDRA QUIZ  ║");
                    Console.WriteLine("║ [3] RADERA QUIZ ║");
                    Console.WriteLine("║ [4] HUVUDMENY   ║");
                    Console.WriteLine("╚═════════════════╝\n");

                    // Printing of text for input
                    Console.Write("ANGE DITT VAL: ");
                    // Saving input for menu variable
                    string? quizManageOption = Console.ReadLine();

                    int validQuizManageOption = errorHandling.OptionErrorCheck(quizManageOption, 4);

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
                            int numberOfQuestionsInt = 0;
                            string numberOfQuestionsStr = Console.ReadLine();
                            int.TryParse(numberOfQuestionsStr, out numberOfQuestionsInt);

                            while (numberOfQuestionsInt < 1 || string.IsNullOrEmpty(numberOfQuestionsStr))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                if (string.IsNullOrEmpty(numberOfQuestionsStr))
                                {
                                    Console.WriteLine("DU HAR INTE ANGETT ANTAL FRÅGOR.\n");
                                }
                                else if (!int.TryParse(numberOfQuestionsStr, out numberOfQuestionsInt))
                                {
                                    Console.WriteLine("DU HAR ANGETT INKORREKTA TECKEN.\n");
                                }
                                else if (numberOfQuestionsInt < 1)
                                {
                                    Console.WriteLine("QUIZET MÅSTE INNEHÅLLA MINST 1 FRÅGA.\n");
                                    
                                } 
                                
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("ANTAL FRÅGOR I QUIZET: ");
                                numberOfQuestionsStr = Console.ReadLine();
                                int.TryParse(numberOfQuestionsStr, out numberOfQuestionsInt);
                            }


                            for (q = 1; q <= numberOfQuestionsInt; q++)
                            {
                                Question question = new();

                                // Printing of text for input
                                Console.WriteLine("\n══════════════════════════════");
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

                                    Console.Write("\nÄR SVARET RÄTT? ANGE J FÖR JA OCH N FÖR NEJ. ");
                                    string correctAnswer = Console.ReadLine();
                                    string validCorrectAnswer = errorHandling.YesOrNoErrorCheck(correctAnswer, "correctAnswer");

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
                                        
                                        Console.WriteLine($"[{a1}] {answer1.Text}");
                                        a1++;
                                    }

                                    Console.Write("ANGE DITT VAL:");

                                    string correctAnswerOption = Console.ReadLine();
                                    int validCorrectAnswerOption = errorHandling.OptionErrorCheck(correctAnswerOption, 3);

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

                            // Printing of text for input
                            Console.WriteLine("VILKET QUIZ SKA ÄNDRAS?\n");

                            // Print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            Console.Write("\nANGE DITT VAL: ");

                            // Saving input to variable
                            string? editQuizOption = Console.ReadLine();

                            int validEditQuizOption = errorHandling.OptionErrorCheck(editQuizOption, allQuizzes.Count) - 1;

                            var chosenQuizToEdit = allQuizzes[validEditQuizOption];

                            Console.Clear();
                            Console.WriteLine("══════════════════════════════");
                            Console.WriteLine("ÄNDRA " + chosenQuizToEdit.Title.ToUpper());
                            Console.WriteLine("══════════════════════════════\n");

                            Console.WriteLine("VAD VILL DU GÖRA?\n");

                            Console.WriteLine("╔══════════════════════════╗");
                            Console.WriteLine("║ [1] ÄNDRA TITEL          ║");
                            Console.WriteLine("║ [2] ÄNDRA / RADERA FRÅGA ║");
                            Console.WriteLine("║ [3] RADERA TOPPLISTA     ║");
                            Console.WriteLine("║ [4] HUVUDMENY            ║");
                            Console.WriteLine("╚══════════════════════════╝");

                            Console.Write("\nANGE DITT VAL: ");
                            string editOption = Console.ReadLine();

                            int validEditOption = errorHandling.OptionErrorCheck(editOption, 4);

                            // Switch for editing of quiz
                            switch (validEditOption)
                            {
                                case 1: // Edit quiz title
                                    Console.WriteLine("\n╔═════════════╗");
                                    Console.WriteLine("║ ÄNDRA TITEL ║");
                                    Console.WriteLine("╚═════════════╝\n");

                                    // Ändra titel
                                    Console.Write("TITEL PÅ QUIZ: ");
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
                                    Console.WriteLine("\n╔══════════════════════╗");
                                    Console.WriteLine("║ ÄNDRA / RADERA FRÅGA ║");
                                    Console.WriteLine("╚══════════════════════╝\n");

                                    Console.WriteLine("VILKEN FRÅGA VILL DU ÄNDRA / RADERA?\n");
                                    q = 1;
                                    foreach (var question in chosenQuizToEdit.questions)
                                    {
                                        Console.WriteLine("[" + q++ + "] " + question.Text.ToUpper());
                                    }

                                    Console.Write("\nANGE DITT VAL: ");
                                    string questionToEdit = Console.ReadLine();
                                    int validQuestionToEdit = errorHandling.OptionErrorCheck(questionToEdit, chosenQuizToEdit.questions.Count);

                                    Console.WriteLine("\n╔══════════════════╗");
                                    Console.WriteLine("║ [1] ÄNDRA TEXT   ║");
                                    Console.WriteLine("║ [2] ÄNDRA SVAR   ║");
                                    Console.WriteLine("║ [3] RADERA FRÅGA ║");
                                    Console.WriteLine("╚══════════════════╝\n");

                                    Console.Write("ANGE DITT VAL: "); 
                                    string manageEditOfQuestion = Console.ReadLine();
                                    int validManageEditOfQuestion = errorHandling.OptionErrorCheck(manageEditOfQuestion, 3);

                                    // Switch for editing of question
                                    switch (validManageEditOfQuestion)
                                    {
                                        case 1: // Edit text for question
                                            Console.WriteLine("\n╔════════════╗");
                                            Console.WriteLine("║ ÄNDRA TEXT ║");
                                            Console.WriteLine("╚════════════╝\n");

                                            Console.WriteLine("FRÅGA " + validQuestionToEdit + ": ");
                                            string newQuestion = Console.ReadLine();
                                            string validNewQuestion = errorHandling.TextErrorCheck(newQuestion, "question", validQuestionToEdit);

                                            chosenQuizToEdit.questions[validQuestionToEdit-1].Text = validNewQuestion;
                                            quizApp.ChangeQuiz();

                                            Console.WriteLine("\n══════════════════════════════");
                                            Console.WriteLine("TEXT PÅ FRÅGA " + validQuestionToEdit + " ÄNDRAD!\n");
                                            Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                            Console.ReadKey();

                                            // Code to clear buffer before returning to main menu
                                            while (Console.KeyAvailable)
                                            {
                                                Console.ReadKey(intercept: true);
                                            }
                                            break;
                                        case 2: // Edit answers for question
                                            Console.WriteLine("\n╔════════════╗");
                                            Console.WriteLine("║ ÄNDRA SVAR ║");
                                            Console.WriteLine("╚════════════╝\n");

                                            Console.WriteLine("VILKET SVAR VILL DU ÄNDRA?\n");
                                            int a = 1;
                                            foreach (var answer in chosenQuizToEdit.questions[validQuestionToEdit-1].answers)
                                            {
                                                Console.WriteLine("[" + a++ + "] " + answer.Text.ToUpper());
                                            }

                                            Console.Write("\nANGE DITT VAL: ");
                                            string answerToEdit = Console.ReadLine();
                                            int validAnswerToEdit = errorHandling.OptionErrorCheck(answerToEdit, 3);

                                            Console.WriteLine("\nVAD VILL DU ÄNDRA PÅ SVARET?\n");
                                            Console.WriteLine("╔════════════════════╗");
                                            Console.WriteLine("║ [1] ÄNDRA TEXT     ║");
                                            Console.WriteLine("║ [2] ÄNDRA RÄTT/FEL ║");
                                            Console.WriteLine("╚════════════════════╝");

                                            Console.Write("\nANGE DITT VAL: ");
                                            string manageAnswerEdit = Console.ReadLine();

                                            int validMangageAnswerEdit = errorHandling.OptionErrorCheck(manageAnswerEdit, 2);

                                            if (validMangageAnswerEdit == 1)
                                            {
                                                
                                                Console.WriteLine("\n╔═════════════════════╗");
                                                Console.WriteLine("║ ÄNDRA TEXT FÖR SVAR ║");
                                                Console.WriteLine("╚═════════════════════╝\n");

                                                Console.Write("SVAR " + validAnswerToEdit + ": ");
                                                string newAnswer = Console.ReadLine();
                                                string validNewAnswer = errorHandling.TextErrorCheck(newAnswer, "answer", validAnswerToEdit);
                                                chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].Text = validNewAnswer;
                                                quizApp.ChangeQuiz();

                                                Console.WriteLine("\n══════════════════════════════");
                                                Console.WriteLine("SVAR " + validAnswerToEdit + " PÅ FRÅGA " + validQuestionToEdit + " ÄNDRAD!\n");
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
                                                
                                                Console.WriteLine("\n╔════════════════╗");
                                                Console.WriteLine("║ ÄNDRA RÄTT/FEL ║");
                                                Console.WriteLine("╚════════════════╝\n");

                                                Console.Write("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ.");

                                                string newAnswerCorrect = Console.ReadLine();
                                                string validNewAnswerCorrect = errorHandling.YesOrNoErrorCheck(newAnswerCorrect, "correctAnswer");

                                                if (validNewAnswerCorrect.Equals("J", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = true;

                                                    quizApp.ChangeQuiz();
                                                    Console.WriteLine("\n══════════════════════════════");
                                                    Console.WriteLine("SVAR " + validAnswerToEdit + "PÅ FRÅGA " + validQuestionToEdit + " ÄNDRAD!\n");
                                                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                    Console.ReadKey();

                                                    // Code to clear buffer before returning to main menu
                                                    while (Console.KeyAvailable)
                                                    {
                                                        Console.ReadKey(intercept: true);
                                                    }
                                                }
                                                else if (validNewAnswerCorrect.Equals("N", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = false;

                                                    bool correctAnswerAfterEditExists = chosenQuizToEdit.questions[validQuestionToEdit - 1].answers.Any(a => a.IsCorrect == true);

                                                    if (!correctAnswerAfterEditExists)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("FRÅGAN SAKNAR ETT KORREKT SVAR.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine("\nVILKEN AV SVAREN ÄR KORREKT?");
                                                        int anum = 1;
                                                        foreach (Answer answer1 in chosenQuizToEdit.questions[validQuestionToEdit - 1].answers)
                                                        {
                                                            
                                                            Console.WriteLine($"{anum}. {answer1.Text.ToUpper()}");
                                                            anum++;
                                                        }

                                                        Console.Write("\nANGE DITT VAL: ");

                                                        string correctAnswerOption = Console.ReadLine();
                                                        int validCorrectAnswerOption = errorHandling.OptionErrorCheck(correctAnswerOption, 3);

                                                        chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validCorrectAnswerOption - 1].IsCorrect = true;
                                                    }

                                                    quizApp.ChangeQuiz();
                                                    Console.WriteLine("\n══════════════════════════════");
                                                    Console.WriteLine("SVAR PÅ FRÅGA " + validQuestionToEdit + " ÄNDRAD!\n");
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
                                            
                                            Console.WriteLine("\n╔══════════════╗");
                                            Console.WriteLine("║ RADERA FRÅGA ║");
                                            Console.WriteLine("╚══════════════╝\n");

                                            Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA FRÅGA " + validQuestionToEdit + "? TRYCK J FÖR JA OCH N FÖR NEJ.");
                                            string controlAnswerDeleteQuestion = Console.ReadLine();

                                            string validControlAnswerQuestion = errorHandling.YesOrNoErrorCheck(controlAnswerDeleteQuestion, "controlAnswer");

                                            if (validControlAnswerQuestion.Equals("J", StringComparison.OrdinalIgnoreCase))
                                            {
                                                chosenQuizToEdit.DeleteQuestion(validQuestionToEdit - 1);
                                                quizApp.ChangeQuiz();
                                                Console.WriteLine("\n══════════════════════════════");
                                                Console.WriteLine("FRÅGA " + validQuestionToEdit + " ÄR RADERAD!\n");
                                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                                Console.ReadKey();

                                                // Code to clear buffer before returning to main menu
                                                while (Console.KeyAvailable)
                                                {
                                                    Console.ReadKey(intercept: true);
                                                }
                                            }
                                            else if (validControlAnswerQuestion.Equals("N", StringComparison.OrdinalIgnoreCase))
                                            {
                                                Console.WriteLine("\n══════════════════════════════");
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

                                    Console.WriteLine("\n╔══════════════════╗");
                                    Console.WriteLine("║ RADERA TOPPLISTA ║");
                                    Console.WriteLine("╚══════════════════╝\n");

                                    // Control question
                                    Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA TOPPLISTAN FÖR " + chosenQuizToEdit.Title.ToUpper() + "? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                                    string controlAnswerDeleteTopScore = Console.ReadLine();

                                    string validControlAnswerTopScore = errorHandling.YesOrNoErrorCheck(controlAnswerDeleteTopScore, "controlAnswer");

                                    if (validControlAnswerTopScore.Equals("J", StringComparison.OrdinalIgnoreCase))
                                    {
                                        chosenQuizToEdit.DeleteTopScores();
                                        quizApp.ChangeQuiz();
                                        Console.WriteLine("\n══════════════════════════════");
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
                                        Console.WriteLine("\n══════════════════════════════");
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

                            // Printing of text for input
                            Console.WriteLine("VILKET QUIZ SKA RADERAS?\n");

                            // Print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            // Printing of text for input
                            Console.Write("\nANGE DITT VAL: ");
                            // Saving input to variable
                            string removeQuizOption = Console.ReadLine();

                            int validRemoveQuizOption = errorHandling.OptionErrorCheck(removeQuizOption, allQuizzes.Count);

                            // Control question
                            Console.Write("\nÄR DU SÄKER PÅ ATT DU VILL RADERA " + allQuizzes[validRemoveQuizOption - 1].Title.ToUpper() + "? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                            string controlAnswerDeleteQuiz = Console.ReadLine();

                            string validControlAnswerQuiz = errorHandling.YesOrNoErrorCheck(controlAnswerDeleteQuiz, "controlAnswer");

                            if (validControlAnswerQuiz.Equals("J", StringComparison.OrdinalIgnoreCase))
                            {
                                quizApp.DeleteQuiz(validRemoveQuizOption-1);
                                Console.WriteLine("\n══════════════════════════════");
                                Console.WriteLine("QUIZET ÄR RADERAD!\n");
                                Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                                Console.ReadKey();

                                // Code to clear buffer before returning to main menu
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(intercept: true);
                                }
                            }
                            else if (validControlAnswerQuiz.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("\n══════════════════════════════");
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
                case 3: // Topscores
                    Console.Clear();
                    Console.WriteLine("╔════════════╗");
                    Console.WriteLine("║ TOPPLISTOR ║");
                    Console.WriteLine("╚════════════╝\n");

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