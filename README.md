# Projekt i Programmering i C#.NET (DT071G)
I detta respitory finns en konsolapplikation byggt med C# och .NET som skapats för projektarbetet i kursen Programmering i C#.NET på Mittuniversitetet. 
Konsolapplikationen är utformad som en quizapp i vilken det finns funktionalitet för skapa, ändra och radera quiz samt genomföra skapade quiz där resultat sparas i topplistor. 
Konsolapplikationen innehåller en programfil och sex klassfiler. JSON-fil med lagrad data finns under mappen Quiz-A-Lot/bin/Debug.

## Klasser

### QuizApp ###
#### Fält ####
#### Metoder ####

### Quiz ###
#### Fält ####
#### Metoder ####

### Question ###
#### Fält ####
#### Metoder ####

### Answer ###
#### Fält ####
#### Metoder ####

### TopScore ###
#### Fält ####
#### Metoder ####

### ErrorHandling ###
#### Metoder ####
- TextErrorCheck tar två string-argument och ett frivilligt int-argument och returnerar en string. Metoden har till uppgift att säkerställa att ingen inmatning för text lämnas tom.
- OptionErrorCheck tar ett string-argument och ett int-argument och returnerar en int. Metoden har till uppgift att säkerställa att inmatning för sifferval inte lämnas tom samt att inmatat värde existerar.
- YesOrNoErrorCheck tar två string-argument och returnerar en string. Metoden har till uppgift att säkerställa att inmatning vid bestämning av korrekt svar samt säkerhetsfråga vid radering inte lämnas tom samt att det enbart är giltiga tecken som matas in.


## Om repositoriet
Skapat av Sofia Widholm 2023

Programmering i C#.NET, Webbutvecklingsprogrammet, Mittuniversitetet
