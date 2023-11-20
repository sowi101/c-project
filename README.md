# Projekt i Programmering i C#.NET (DT071G)
I detta respitory finns en konsolapplikation byggt med C# och .NET som skapats för projektarbetet i kursen Programmering i C#.NET på Mittuniversitetet. 
Konsolapplikationen är utformad som en quizapp i vilken det finns funktionalitet för skapa, ändra och radera quiz samt genomföra skapade quiz där resultat sparas i topplistor. 
Konsolapplikationen innehåller en programfil och sex klassfiler. JSON-fil med lagrad data finns under mappen 
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
#### Fält ####
#### Metoder ####



### Projekt
| Metod | Ändpunkt | Beskrivning |
| ----------- | ----------- | ----------- |
| GET | /projects | Hämtar alla projekt. |
| GET | /projects/{id} | Hämtar projekt med angivet ID. |
| POST | /projects | Lagrar nytt projekt, ett projektobjekt måste skickas med. |
| PUT | /projects/{id} | Uppdaterar existerande projekt med angivet ID, ett projektobjekt måste skickas med. |
| DELETE | /projects/{id} | Raderar projekt med angivet ID. |

Ett projektobjekt skickas eller returneras på följande sätt:

### Verktyg
| Metod | Ändpunkt | Beskrivning |
| ----------- | ----------- | ----------- |
| GET | /tools | Hämtar alla verktyg. |
| GET | /tools/{id} | Hämtar verktyg med angivet ID. |
| POST | /tools | Lagrar nytt verktyg, ett verktygsobjekt måste skickas med. |
| PUT | /tools/{id} | Uppdaterar existerande verktyg med angivet ID, ett verktygsobjekt måste skickas med. |
| DELETE | /tools/{id} | Raderar verktyg med angivet ID. |

### Garn
| Metod | Ändpunkt | Beskrivning |
| ----------- | ----------- | ----------- |
| GET | /yarns | Hämtar alla garn. |
| GET | /yarns/{id} | Hämtar garn med angivet ID. |
| POST | /yarns | Lagrar nytt garn, ett garnobjekt måste skickas med. |
| PUT | /yarns/{id} | Uppdaterar existerande garn med angivet ID, ett garnobjekt måste skickas med. |
| DELETE | /yarns/{id} | Raderar garn med angivet ID. |


## Om repositoriet
Skapat av Sofia Widholm 2023

Programmering i C#.NET, Webbutvecklingsprogrammet, Mittuniversitetet
