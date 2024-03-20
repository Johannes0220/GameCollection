# Game Collection

## Übersicht der Eigenschaften

- Games Anzeigen
- Games starten
  - TIK TAK TOE
  - ...
- Games beenden
- Games pausieren
- Bestenliste
  - Players[]
  - Points (#Winns)
- Archivements
  - X Games Played
  - X Games Won
  - X Games Lost
- Players

## Technische Umsetzung

- GameRepository
- PlayerRepository
- Game(Interface)
  - Start
  - Stop
  - Pause
  - LeaderBoard
    - Player
    - Points/Time
    - Rank
- Player
  - Name
  - Archivements
  - Game-Score-Map
  
- Archivement
  - Name
  - Condition
- ArchivementRepository

- Testing
  - DIY Mocks
  - Test Runner? VS Intern?
