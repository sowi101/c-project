# Projekt i Programmering i C#.NET (DT071G)
I detta respitory finns en konsolapplikation byggt med C# och .NET som skapats för projektarbetet i kursen Programmering i C#.NET på Mittuniversitetet. 
Konsolapplikationen är utformad som en quizapp i vilken det finns funktionalitet för skapa, ändra och radera quiz samt genomföra skapade quiz där resultat sparas i topplistor. 
Konsolapplikationen innehåller en programfil och sex klassfiler. 
## Klasser

| QuizApp |
| ----------- | 
| **_id** (ObjectId), **name** (String), **link** (String), **status** (String), **tool** (String), **yarn** (String)|

| Quiz |
| ----------- | ----------- |
| **_id** (ObjectId), **name** (String), **link** (String), **status** (String), **tool** (String), **yarn** (String)|

| Question |
| ----------- | ----------- |
| **_id** (ObjectId), **name** (String), **link** (String), **status** (String), **tool** (String), **yarn** (String)|

| TopScore |
| ----------- | ----------- |
| **_id** (ObjectId), **name** (String), **link** (String), **status** (String), **tool** (String), **yarn** (String)|

| Answer |
| ----------- | ----------- |
| **_id** (ObjectId), **name** (String), **link** (String), **status** (String), **tool** (String), **yarn** (String)|

| ErrorHandling |
| ----------- | ----------- |
| **_id** (ObjectId), **name** (String), **link** (String), **status** (String), **tool** (String), **yarn** (String)|


## Scheman och routes med metoder

### Projekt
#### Schema: Project
- **name**: String, namn på projekt
- **link**: String, länk till publicerat mönster
- **status**: String, status på produkt
- **tool**: String, vilket verktyg som rekommenderas/använts.
- **yarn**: String, vilket garn som rekommenderas/använts.
- **information**: String, övrig information om projekt

#### Route: Project
- **GET-metod**: metod som hämtar alla dokument i samlingen.
- **GETbyid-metod**: metod hämtar ett angivet dokument i samlingen.
- **POST-metod**: metod som lägger till ett dokument i samlingen.
- **PUT-metod**: metod som uppdaterar ett angivet dokument i samlingen.
- **DELETE-metod**: metod som tar bort ett angivet dokument i samlingen.


### Verktyg
#### Schema: Tool
- **category**: String, kategori för verktyget
- **brand**: String,  märke på verktyget
- **size**: String, storlek på verktyget

#### Route: Tool
- **GET-metod**: metod som hämtar alla dokument i samlingen.
- **GETbyid-metod**: metod hämtar ett angivet dokument i samlingen.
- **POST-metod**: metod som lägger till ett dokument i samlingen.
- **PUT-metod**: metod som uppdaterar ett angivet dokument i samlingen.
- **DELETE-metod**: metod som tar bort ett angivet dokument i samlingen.

### Garn
#### Schema: Yarn
- **category**: String, kategori för garnet
- **brand**: String,  märke på garnet
- **name**: String, namn på garnet

#### Route: Yarn
- **GET-metod**: metod som hämtar alla dokument i samlingen.
- **GETbyid-metod**: metod hämtar ett angivet dokument i samlingen.
- **POST-metod**: metod som lägger till ett dokument i samlingen.
- **PUT-metod**: metod som uppdaterar ett angivet dokument i samlingen.
- **DELETE-metod**: metod som tar bort ett angivet dokument i samlingen.

## Användning

### Projekt
| Metod | Ändpunkt | Beskrivning |
| ----------- | ----------- | ----------- |
| GET | /projects | Hämtar alla projekt. |
| GET | /projects/{id} | Hämtar projekt med angivet ID. |
| POST | /projects | Lagrar nytt projekt, ett projektobjekt måste skickas med. |
| PUT | /projects/{id} | Uppdaterar existerande projekt med angivet ID, ett projektobjekt måste skickas med. |
| DELETE | /projects/{id} | Raderar projekt med angivet ID. |

Ett projektobjekt skickas eller returneras på följande sätt:

```json
{
  "namn": "Love och Lovenina",
  "länk": "https://bautawitch.se/2019/03/01/diy-stor-virkad-kramgo-nalle-och-kanin/",
  "status": "Påbörjad",
  "verktyg": "Virknål Hobbii 5 mm",
  "garn": "Sammetsgarn DMC Velvet",
  "information": "Färger: Beige, grå och ljusrosa",
}
```
### Verktyg
| Metod | Ändpunkt | Beskrivning |
| ----------- | ----------- | ----------- |
| GET | /tools | Hämtar alla verktyg. |
| GET | /tools/{id} | Hämtar verktyg med angivet ID. |
| POST | /tools | Lagrar nytt verktyg, ett verktygsobjekt måste skickas med. |
| PUT | /tools/{id} | Uppdaterar existerande verktyg med angivet ID, ett verktygsobjekt måste skickas med. |
| DELETE | /tools/{id} | Raderar verktyg med angivet ID. |

Ett verktygsobjekt skickas eller returneras på följande sätt:

```json
{
  "category": "Virknål",
  "brand": "Hobbii",
  "size": "5 mm"
}
```

### Garn
| Metod | Ändpunkt | Beskrivning |
| ----------- | ----------- | ----------- |
| GET | /yarns | Hämtar alla garn. |
| GET | /yarns/{id} | Hämtar garn med angivet ID. |
| POST | /yarns | Lagrar nytt garn, ett garnobjekt måste skickas med. |
| PUT | /yarns/{id} | Uppdaterar existerande garn med angivet ID, ett garnobjekt måste skickas med. |
| DELETE | /yarns/{id} | Raderar garn med angivet ID. |

Ett garnobjekt skickas eller returneras på följande sätt:

```json
{
  "category": "Sammetsgarn",
  "brand": "DMC",
  "name": "Velvet"
}
```

## Om repositoriet
Skapat av Sofia Widholm 2022-2023

JavaScriptbaserad webbutveckling, Webbutvecklingsprogrammet, Mittuniversitetet
