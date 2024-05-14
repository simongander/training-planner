# Trainingsplanung API
Dieses Projekt stellt eine REST-API zur Verfügung, um persönliche Trainings und Trainings von Teams zu verwalten. Die API ist zur Verwendung mit einer App vorgesehen, die aktuell noch Entwickelt wird. Deshalb bietet die API nur Methoden an, die für Benutzende der App zugänglich sein sollen und es können nicht alle Daten bearbeitet werden.

## Deployment
Die Applikation steht auf Azure zum Testen zur Verfügung, Daten werden nicht permanent persistiert.
https://swat-baa-app.azurewebsites.net/api/

## Installation
### Voraussetzungen
- .Net 8
- IDE die .Net unterstützt (Visual Studio, VSCode, Rider)
- MySql/MariaDb

### Lokale Installation
- [Datenbankfile](/Database/training.sql) importieren
- User erstellen
- Connection String in den Appsettings setzen z.b
  `"ConnectionStrings": {
    "TrainingDb": "Server=localhost Database=trainingDb;Uid=testuser;Pwd=1234"
    }`
- Projekt starten

## API-Dokumentation
https://swat-baa-app.azurewebsites.net/swagger/index.html

## Aufbau
Die Applikation ist in drei Schichten aufgeteilt:
Der Service Layer enthält die Controller und die Logik zum starten der API.
Im Business Layer sind die Aufrufe an den Data Access Layer implementiert mit dem Repository Pattern.
Der Data Access Layer verwendet das Entity Framework für die Datenbankaufrufe.
![Klassendiagramm der API](/Docs/TrainingApp.png)