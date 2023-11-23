# Projekt i Programmering i C#.NET (DT071G)
I detta respitory finns en konsolapplikation byggt med C# och .NET som skapats för projektarbetet i kursen Programmering i C#.NET på Mittuniversitetet. 
Konsolapplikationen är utformad som en quizapp i vilken det finns funktionalitet för skapa, ändra och radera quiz samt genomföra skapade quiz där resultat sparas i topplistor. 
Konsolapplikationen innehåller en programfil och sex klassfiler. JSON-fil med lagrad data finns under mappen Quiz-A-Lot/bin/Debug.

## Klasser

### QuizApp ###
#### Fält ####
- jsonFile: string
- quizzes: List<Quiz>
#### Metoder ####
- QuizApp är en konstruktor som har till uppgift att hämta alla lagrade quiz från JSON-filen när en ny instans av QuizApp skapas, konvertera dem och lägga till dem i listan för quiz.
- WriteToFile tar inga argument och returnerar inget. Metoden har till uppgift att konvertera listan för quiz till en JSON-string och skriva om JSON-filen.
- AddQuiz tar ett Quiz-objekt som argument och returnerar även objektet. Metoden har till uppgift att lägga till quiz i listan för quiz och köra metoden WriteToFile för att skriva quizen till JSON-filen. 
- ChangeQuiz tar inga argument och returnerar inget. Metoden har till uppgift att köra metoden WriteToFile för att skriva quizen till JSON-filen.
- DeleteQuiz tar en int som argument och returnerar en int. Metoden har till uppgift att ta bort specifikt objekt från listan för quiz.
- GetQuizzes tar inga argument men returnerar lista med Quiz-objekt. Metoden har till uppgift att hämta alla lagrade quiz.
- PrintQuizzes tar listan med Quiz-objekt som argument. Metoden har till uppgift att skriva ut titlarna för alla quiz.

### Quiz ###
#### Fält ####
- Title: string
- questions: List<Questions>
- topScores: List<TopScore>
#### Metoder ####
- AddQuestion tar ett Question-objekt som argument och returnerar även objektet. Metoden har till uppgift att lägga till fråga i listan för frågor.
- EditQuestion tar ett Question-objekt och en int som argument och returnerar en int. Metoden har till uppgift att byta ut det ändrade objektet i listan för frågor.
- DeleteQuestion tar en int som argument och returnerar en int. Metoden har till uppgift att ta bort specifikt objekt från listan för frågor.
- AddTopScore tar ett TopScore-objekt som argument och returnerar även objektet. Metoden har till uppgift att lägga till resultat i listan för topplistan. 
- DeleteTopScores tar inga argument och returnerar inget. Metoden har till uppgift att nollställa listan för topplistan.
- PrintTopScores tar ett Quiz-objekt som argument. Metoden har till uppgift att skriva ut alla titlar och topplistor för quizen.

### Question ###
#### Fält ####
- Text: string
- answers: List<Answers>
#### Metoder ####
- AddAnswer tar ett Answer-objekt som argument och returnerar även objektet. Metoden har till uppgift att lägga till svar i listan för svar.
- EditAnswer tar ett Answer-objekt och en int som argument och returnerar en int. Metoden har till uppgift att byta ut det ändrade objektet i listan för svar.
- DeleteAnswer tar en int som argument och returnerar en int. Metoden har till uppgift att ta bort specifikt objekt från listan för svar.

### Answer ###
#### Fält ####
- Text: string
- IsCorrect: boolean

### TopScore ###
#### Fält ####
- Score: int
- Name: string

### ErrorHandling ###
#### Metoder ####
- TextErrorCheck tar två string-argument och ett frivilligt int-argument och returnerar en string. Metoden har till uppgift att säkerställa att ingen inmatning för text lämnas tom.
- OptionErrorCheck tar ett string-argument och ett int-argument och returnerar en int. Metoden har till uppgift att säkerställa att inmatning för sifferval inte lämnas tom samt att inmatat värde existerar.
- YesOrNoErrorCheck tar två string-argument och returnerar en string. Metoden har till uppgift att säkerställa att inmatning vid bestämning av korrekt svar samt säkerhetsfråga vid radering inte lämnas tom samt att det enbart är giltiga tecken som matas in.

## Om repositoriet
Skapat av Sofia Widholm 2023

Programmering i C#.NET, Webbutvecklingsprogrammet, Mittuniversitetet
