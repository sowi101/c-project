// See https://aka.ms/new-console-template for more information

/* 
 * The program is made by Sofia Widholm
 * Projekt, Programmering i C#.NET
 * Webbutvecklingsprogrammet, Mittuniversitetet
 * Last update: 2023-12-03
*/

using Quiz_A_Lot;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // New instance of QuizApp and ErrorHandling
        QuizApp quizApp = new();

        // Call of method to get all quiz objects
        var allQuizzes = quizApp.GetQuizzes();

        // While loop that runs as long the conditional is set to true
        while (true)
        {
            // Clearing of console
            Console.Clear();
            Console.WriteLine("\x1b[3J");

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

            // Saves option input for main menu
            Console.Write("ANGE DITT VAL: ");
            string? option = Console.ReadLine();

            // Call of method to check for input errors
            int validOption = ErrorHandling.OptionErrorCheck(option, 4);

            // Switch for main menu
            switch (validOption)
            {
                case 1:
                    // Clearing of console
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");

                    Console.WriteLine("╔═════════════╗");
                    Console.WriteLine("║ TA ETT QUIZ ║");
                    Console.WriteLine("╚═════════════╝\n");
                    
                    // If statement to check if there are no quizzes
                    if (allQuizzes.Count < 1)
                    {
                        // Prints error message
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
                    // Call of method to print information about quizzes
                    quizApp.PrintQuizzes(allQuizzes);

                    Console.Write("\nANGE DITT VAL: ");
                    // Saves option input for quiz
                    string? quizOption = Console.ReadLine();
                    // Call of method to check for input errors
                    int validQuizOption = ErrorHandling.OptionErrorCheck(quizOption, allQuizzes.Count);
                    // Saves the object at the index to a variable
                    var chosenQuiz = allQuizzes[validQuizOption - 1];

                    // Clearing of console
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    // Prints title of quiz and amount of questions
                    Console.WriteLine("══════════════════════════════");
                    Console.WriteLine(chosenQuiz.Title.ToUpper());
                    Console.WriteLine("══════════════════════════════\n");
                    Console.WriteLine("QUIZET INNEHÅLLER " + chosenQuiz.questions.Count() + " FRÅGOR.\n");

                    int score = 0;
                    int q = 1;
                    
                    // Loops through all questions in the quiz
                    foreach (var question in chosenQuiz.questions)
                    {
                        // Prints number and text for question
                        Console.WriteLine("══════════════════════════════");
                        Console.WriteLine("FRÅGA " + q + ": " + question.Text.ToUpper());
                        Console.WriteLine();

                        int a = 1;
                        // Loops through all answers for question
                        foreach (var answer in question.answers)
                        {
                            // Prints number and text for answer
                            Console.WriteLine("[" + a++ + "] " + answer.Text);
                        }

                        Console.WriteLine();
                        Console.Write("ANGE DITT VAL: ");
                        // Saves option input for answer
                        string userAnswer = Console.ReadLine();
                        // Call of method to check for input errors
                        int validUserAnswer = ErrorHandling.OptionErrorCheck(userAnswer, 3);

                        // If statement that check if chosen answer is correct
                        if (question.answers[validUserAnswer - 1].IsCorrect)
                        {
                            // Increses the score
                            score++;
                        }
                        Console.WriteLine();
                        q++;
                    }

                    // Prints result
                    Console.WriteLine("══════════════════════════════");
                    Console.WriteLine("DU FICK " + score + " POÄNG!\n");

                    Console.Write("ANGE NAMN FÖR TOPPLISTAN: ");
                    // Saves input for name on topscore
                    string userName = Console.ReadLine();
                    // Call of method to check for input errors
                    string validUserName = ErrorHandling.TextErrorCheck(userName, "name");
                    // New instance of TopScore
                    TopScore topScore = new TopScore();
                    // Save name and score to object
                    topScore.Score = score;
                    topScore.Name = validUserName;
                    // Call of method to add topscore to quiz
                    allQuizzes[validQuizOption-1].AddTopScore(topScore);
                    // Call of method to save changes
                    quizApp.ChangeQuiz();

                    Console.WriteLine("\n══════════════════════════════");
                    Console.WriteLine("DITT RESULTAT ÄR SPARAT!\n");
                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENYN.");
                    Console.ReadKey();

                    // Code to clear buffer before returning to main menu
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(intercept: true);
                    }

                    break;
                case 2:
                    // Clearing of console
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");

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

                    Console.Write("ANGE DITT VAL: ");
                    // Saves option input for quiz management
                    string? quizManageOption = Console.ReadLine();
                    // Call of method to check for input errors
                    int validQuizManageOption = ErrorHandling.OptionErrorCheck(quizManageOption, 4);

                    // Switch for quiz management
                    switch (validQuizManageOption)
                    {
                        case 1: // Create quiz
                            //Clearing of console
                            Console.Clear();
                            Console.WriteLine("\x1b[3J");
                            // New instance of Quiz
                            Quiz quiz = new();

                            Console.WriteLine("╔════════════╗");
                            Console.WriteLine("║ SKAPA QUIZ ║");
                            Console.WriteLine("╚════════════╝\n");
                            Console.WriteLine("══════════════════════════════");
                            Console.Write("TITEL PÅ QUIZ: ");
                            // Saves input for quiz title
                            string titleInput = Console.ReadLine();
                            // Call of method to check for input errors
                            string validTitle = ErrorHandling.TextErrorCheck(titleInput, "title");
                            // Save title to object
                            quiz.Title = validTitle;

                            Console.WriteLine("══════════════════════════════");
                            Console.Write("ANTAL FRÅGOR I QUIZET: ");
                            // Saves input for amount of questions
                            string numberOfQuestionsStr = Console.ReadLine();
                            int numberOfQuestionsInt = 0;
                            // Converts amount from string to int
                            int.TryParse(numberOfQuestionsStr, out numberOfQuestionsInt);

                            // While loop that runs as long as input is smaller than 0 or empty
                            while (numberOfQuestionsInt < 1 || string.IsNullOrEmpty(numberOfQuestionsStr))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                // If statement to check what type of error it is
                                if (string.IsNullOrEmpty(numberOfQuestionsStr))
                                {
                                    // Prints error message
                                    Console.WriteLine("DU HAR INTE ANGETT ANTAL FRÅGOR.\n");
                                }
                                else if (!int.TryParse(numberOfQuestionsStr, out numberOfQuestionsInt))
                                {
                                    // Prints error message
                                    Console.WriteLine("DU HAR ANGETT INKORREKTA TECKEN.\n");
                                }
                                else if (numberOfQuestionsInt < 1)
                                {
                                    // Prints error message
                                    Console.WriteLine("QUIZET MÅSTE INNEHÅLLA MINST 1 FRÅGA.\n");
                                    
                                } 
                                
                                // Asking for new input
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("ANTAL FRÅGOR I QUIZET: ");
                                numberOfQuestionsStr = Console.ReadLine();
                                // Converts amount from string to int
                                int.TryParse(numberOfQuestionsStr, out numberOfQuestionsInt);
                            }

                            // Loop that runs as many times as the amount of questions
                            for (q = 1; q <= numberOfQuestionsInt; q++)
                            {
                                // New instance of question
                                Question question = new();
                                Console.WriteLine("\n══════════════════════════════");
                                Console.Write("FRÅGA " + q + ": ");

                                // Saves input for question
                                string questionText = Console.ReadLine();
                                // Call of method to check for input errors
                                string validQuestionText = ErrorHandling.TextErrorCheck(questionText, "question", q);
                                // Saves text to object
                                question.Text = validQuestionText;

                                // Loop that runs three times
                                for (int a = 1; a < 4; a++)
                                {
                                    // New instance of Answer
                                    Answer answer = new();
                                    Console.WriteLine("══════════════════════════════");
                                    Console.Write("SVAR " + a + ": ");

                                    // Saves input for answer
                                    string answertext = Console.ReadLine();
                                    // Call of method to check for input errors
                                    string validAnswerText = ErrorHandling.TextErrorCheck(answertext, "answer", a);
                                    // Saves text to object
                                    answer.Text = validAnswerText;

                                    Console.Write("\nÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                                    // Saves input if answer is correct or not
                                    string correctAnswer = Console.ReadLine();
                                    // Call of method to check for input errors
                                    string validCorrectAnswer = ErrorHandling.YesOrNoErrorCheck(correctAnswer, "correctAnswer");

                                    // If statement that checks the letter in the input
                                    if (validCorrectAnswer.Equals("J", StringComparison.OrdinalIgnoreCase))
                                    {
                                        // Sets answer to true
                                        answer.IsCorrect = true;
                                    }
                                    else if (validCorrectAnswer.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        // Sets answer to false
                                        answer.IsCorrect = false;
                                    }

                                    // Call of metod to add answer to question
                                    question.AddAnswer(answer);
                                }

                                // Check that there are at least one true answer
                                bool correctAnswerExists = question.answers.Any(a => a.IsCorrect == true);

                                // If statement that runs if no correct answers exists
                                if (!correctAnswerExists)
                                {
                                    Console.WriteLine("══════════════════════════════");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("FRÅGAN SAKNAR ETT KORREKT SVAR!\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("VILKET SVAR ÄR KORREKT?");

                                    int a1 = 1;

                                    // Loops through all answers for the question
                                    foreach (Answer answer1 in question.answers)
                                    {
                                        // Prints number and text for answer
                                        Console.WriteLine($"[{a1}] {answer1.Text}");
                                        a1++;
                                    }

                                    Console.Write("\nANGE DITT VAL: ");

                                    // Saves input for correct answer
                                    string correctAnswerOption = Console.ReadLine();
                                    // Call of method to check for input errors
                                    int validCorrectAnswerOption = ErrorHandling.OptionErrorCheck(correctAnswerOption, 3);
                                    // Change answer to true
                                    question.answers[validCorrectAnswerOption-1].IsCorrect = true;
                                }

                                // Call of metod to add question to quiz
                                quiz.AddQuestion(question);

                            }

                            // Call of method to add quiz to application
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
                            // Clearing of console
                            Console.Clear();
                            Console.WriteLine("\x1b[3J");
                            Console.WriteLine("╔════════════╗");
                            Console.WriteLine("║ ÄNDRA QUIZ ║");
                            Console.WriteLine("╚════════════╝\n");

                            // If statement that checks if there are no quizzes
                            if (allQuizzes.Count < 1)
                            {
                                // Prints error message
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

                            Console.WriteLine("VILKET QUIZ SKA ÄNDRAS?\n");
                            // Call of method to print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            Console.Write("\nANGE DITT VAL: ");
                            // Saves option input for quiz to edit
                            string? editQuizOption = Console.ReadLine();
                            // Call of method to check for input errors
                            int validEditQuizOption = ErrorHandling.OptionErrorCheck(editQuizOption, allQuizzes.Count) - 1;
                            // Save quiz object to new variable
                            var chosenQuizToEdit = allQuizzes[validEditQuizOption];

                            // Clearing of console
                            Console.Clear();
                            Console.WriteLine("\x1b[3J");
                            // Prints title of quiz
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
                            // Saves option input for type of editing in quiz
                            string editOption = Console.ReadLine();
                            // Call of method to check for input errors
                            int validEditOption = ErrorHandling.OptionErrorCheck(editOption, 4);

                            // Switch for editing of quiz
                            switch (validEditOption)
                            {
                                case 1: // Edit quiz title
                                    Console.WriteLine("\n╔═════════════╗");
                                    Console.WriteLine("║ ÄNDRA TITEL ║");
                                    Console.WriteLine("╚═════════════╝\n");

                                    Console.Write("TITEL PÅ QUIZ: ");
                                    // Saves input for new title
                                    string newTitle = Console.ReadLine();
                                    // Call of method to check for input errors
                                    string validNewTitle = ErrorHandling.TextErrorCheck(newTitle, "title");
                                    // Saves new title to object
                                    chosenQuizToEdit.Title = validNewTitle;
                                    // Call of method to save changes
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
                                    // Loops through all questions in quiz
                                    foreach (var question in chosenQuizToEdit.questions)
                                    {
                                        Console.WriteLine("══════════════════════════════");
                                        Console.WriteLine("[" + q++ + "] " + question.Text.ToUpper());
                                        Console.WriteLine("══════════════════════════════");
                                    }

                                    Console.Write("\nANGE DITT VAL: ");
                                    // Saves option input for what question to edit in quiz
                                    string questionToEdit = Console.ReadLine();
                                    // Call of method to check for input errors
                                    int validQuestionToEdit = ErrorHandling.OptionErrorCheck(questionToEdit, chosenQuizToEdit.questions.Count);

                                    Console.WriteLine("\n╔══════════════════╗");
                                    Console.WriteLine("║ [1] ÄNDRA TEXT   ║");
                                    Console.WriteLine("║ [2] ÄNDRA SVAR   ║");
                                    Console.WriteLine("║ [3] RADERA FRÅGA ║");
                                    Console.WriteLine("╚══════════════════╝\n");

                                    Console.Write("ANGE DITT VAL: ");
                                    // Saves option input for what to edit in question
                                    string manageEditOfQuestion = Console.ReadLine();
                                    // Call of method to check for input errors
                                    int validManageEditOfQuestion = ErrorHandling.OptionErrorCheck(manageEditOfQuestion, 3);

                                    // Switch for editing of question
                                    switch (validManageEditOfQuestion)
                                    {
                                        case 1: // Edit text for question
                                            Console.WriteLine("\n╔════════════╗");
                                            Console.WriteLine("║ ÄNDRA TEXT ║");
                                            Console.WriteLine("╚════════════╝\n");

                                            Console.WriteLine("FRÅGA " + validQuestionToEdit + ": ");
                                            // Saves input for new text for question
                                            string newQuestion = Console.ReadLine();
                                            // Call of method to check for input errors
                                            string validNewQuestion = ErrorHandling.TextErrorCheck(newQuestion, "question", validQuestionToEdit);
                                            // Add new text to object
                                            chosenQuizToEdit.questions[validQuestionToEdit-1].Text = validNewQuestion;
                                            // Call of method to save changes
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
                                            // Loops through all answers
                                            foreach (var answer in chosenQuizToEdit.questions[validQuestionToEdit-1].answers)
                                            {
                                                // Prints number and text for answers
                                                Console.WriteLine("[" + a++ + "] " + answer.Text.ToUpper());
                                            }

                                            Console.Write("\nANGE DITT VAL: ");
                                            // Saves option input for which answer to edit
                                            string answerToEdit = Console.ReadLine();
                                            // Call of method to check for input errors
                                            int validAnswerToEdit = ErrorHandling.OptionErrorCheck(answerToEdit, 3);

                                            Console.WriteLine("\nVAD VILL DU ÄNDRA PÅ SVARET?\n");
                                            Console.WriteLine("╔════════════════════╗");
                                            Console.WriteLine("║ [1] ÄNDRA TEXT     ║");
                                            Console.WriteLine("║ [2] ÄNDRA RÄTT/FEL ║");
                                            Console.WriteLine("╚════════════════════╝");

                                            Console.Write("\nANGE DITT VAL: ");
                                            // Saves option input for what to edit in answer
                                            string manageAnswerEdit = Console.ReadLine();
                                            // Call of method to check for input errors
                                            int validMangageAnswerEdit = ErrorHandling.OptionErrorCheck(manageAnswerEdit, 2);

                                            // If statement that check input of what to edit in answer
                                            if (validMangageAnswerEdit == 1)
                                            {
                                                Console.WriteLine("\n╔═════════════════════╗");
                                                Console.WriteLine("║ ÄNDRA TEXT FÖR SVAR ║");
                                                Console.WriteLine("╚═════════════════════╝\n");

                                                Console.Write("SVAR " + validAnswerToEdit + ": ");
                                                // Saves input for new answer
                                                string newAnswer = Console.ReadLine();
                                                // Call of method to check for input errors
                                                string validNewAnswer = ErrorHandling.TextErrorCheck(newAnswer, "answer", validAnswerToEdit);
                                                // Saves input to object
                                                chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].Text = validNewAnswer;
                                                // Call of method to save changes
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

                                                Console.Write("ÄR SVARET RÄTT? TRYCK J FÖR JA OCH N FÖR NEJ. ");

                                                // Saves input for correction of answer
                                                string newAnswerCorrect = Console.ReadLine();
                                                // Call of method to check for input errors
                                                string validNewAnswerCorrect = ErrorHandling.YesOrNoErrorCheck(newAnswerCorrect, "correctAnswer");

                                                // If statement that check if input contains the letter J or N
                                                if (validNewAnswerCorrect.Equals("J", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    // Set answer to true
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = true;
                                                    // Call of method to save changes
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
                                                    // Set answer to false
                                                    chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validAnswerToEdit - 1].IsCorrect = false;

                                                    // Check if there is at least one correct answer
                                                    bool correctAnswerAfterEditExists = chosenQuizToEdit.questions[validQuestionToEdit - 1].answers.Any(a => a.IsCorrect == true);

                                                    // If statement that runs if no correct answers exists
                                                    if (!correctAnswerAfterEditExists)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("FRÅGAN SAKNAR ETT KORREKT SVAR.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine("\nVILKEN AV SVAREN ÄR KORREKT?");
                                                        int anum = 1;
                                                        // Loops through all answers
                                                        foreach (Answer answer1 in chosenQuizToEdit.questions[validQuestionToEdit - 1].answers)
                                                        {
                                                            // Prints number and text for answer
                                                            Console.WriteLine($"{anum}. {answer1.Text.ToUpper()}");
                                                            anum++;
                                                        }

                                                        Console.Write("\nANGE DITT VAL: ");
                                                        // Saves input for correct answer
                                                        string correctAnswerOption = Console.ReadLine();
                                                        // Call of method to check for input errors
                                                        int validCorrectAnswerOption = ErrorHandling.OptionErrorCheck(correctAnswerOption, 3);
                                                        // Set answer to true
                                                        chosenQuizToEdit.questions[validQuestionToEdit - 1].answers[validCorrectAnswerOption - 1].IsCorrect = true;
                                                    }

                                                    // Call of method to save changes
                                                    quizApp.ChangeQuiz();

                                                    Console.WriteLine("══════════════════════════════");
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
                                        case 3: // Delete question
                                            Console.WriteLine("\n╔══════════════╗");
                                            Console.WriteLine("║ RADERA FRÅGA ║");
                                            Console.WriteLine("╚══════════════╝\n");

                                            Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA FRÅGA " + validQuestionToEdit + "? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                                            // Saves input for control question to delete question
                                            string controlAnswerDeleteQuestion = Console.ReadLine();
                                            // Call of method to check for input errors
                                            string validControlAnswerQuestion = ErrorHandling.YesOrNoErrorCheck(controlAnswerDeleteQuestion, "controlAnswer");

                                            // If statement that check if input contains the letter J or N
                                            if (validControlAnswerQuestion.Equals("J", StringComparison.OrdinalIgnoreCase))
                                            {
                                                // Call of method to delete question
                                                chosenQuizToEdit.DeleteQuestion(validQuestionToEdit - 1);
                                                // Call of method to save changes
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

                                    Console.Write("ÄR DU SÄKER PÅ ATT DU VILL RADERA TOPPLISTAN FÖR " + chosenQuizToEdit.Title.ToUpper() + "? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                                    // Saves input for control question to delete topscores
                                    string controlAnswerDeleteTopScore = Console.ReadLine();
                                    // Call of method to check for input errors
                                    string validControlAnswerTopScore = ErrorHandling.YesOrNoErrorCheck(controlAnswerDeleteTopScore, "controlAnswer");

                                    // If statement that check if input contains the letter J or N
                                    if (validControlAnswerTopScore.Equals("J", StringComparison.OrdinalIgnoreCase))
                                    {
                                        // Call of method to delete topscores
                                        chosenQuizToEdit.DeleteTopScores();
                                        // Call of method to save changes
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
                        case 3: // Delete quiz
                            // Clearing of console
                            Console.Clear();
                            Console.WriteLine("\x1b[3J");
                            Console.WriteLine("╔═════════════╗");
                            Console.WriteLine("║ RADERA QUIZ ║");
                            Console.WriteLine("╚═════════════╝\n");

                            Console.WriteLine("VILKET QUIZ SKA RADERAS?\n");

                            // Call of method to print information about quizzes
                            quizApp.PrintQuizzes(allQuizzes);

                            Console.Write("\nANGE DITT VAL: ");
                            // Saves option for what quiz to delete
                            string removeQuizOption = Console.ReadLine();
                            // Call of method to check for input errors
                            int validRemoveQuizOption = ErrorHandling.OptionErrorCheck(removeQuizOption, allQuizzes.Count);

                            
                            Console.Write("\nÄR DU SÄKER PÅ ATT DU VILL RADERA " + allQuizzes[validRemoveQuizOption - 1].Title.ToUpper() + "? TRYCK J FÖR JA OCH N FÖR NEJ. ");
                            // Saves input for control question to delete quiz
                            string controlAnswerDeleteQuiz = Console.ReadLine();
                            // Call of method to check for input errors
                            string validControlAnswerQuiz = ErrorHandling.YesOrNoErrorCheck(controlAnswerDeleteQuiz, "controlAnswer");

                            // If statement that check if input contains the letter J or N
                            if (validControlAnswerQuiz.Equals("J", StringComparison.OrdinalIgnoreCase))
                            {
                                // Call of method to delete quiz
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
                    // Clearing of console
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    Console.WriteLine("╔════════════╗");
                    Console.WriteLine("║ TOPPLISTOR ║");
                    Console.WriteLine("╚════════════╝\n");

                    // If statement that check if there are no quizzes
                    if (allQuizzes.Count < 1)
                    {
                        Console.WriteLine("DET FINNS INGA SPARADE QUIZ.\n");
                    }

                    Console.WriteLine("TRYCK PÅ VALFRI TANGENT FÖR ATT ÅTERVÄNDA TILL HUVUDMENY.\n");

                    // Loops through all quizzes
                    foreach (Quiz quiz in allQuizzes)
                    {
                        // Prints topscores for quiz
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