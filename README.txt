TankstellenApp – Funktionsübersicht

Mit diesem Programm können aktuelle Kraftstoffpreise von Tankstellen in Deutschland abgerufen und angezeigt werden.

Vor der ersten Nutzung:
- Die App wurde als portable Anwendung veröffentlicht. Das heißt, sie benötigt keine Installation. Die ZIP-Datei einfach entpacken und die EXE-Datei öffnen.
- Für die Nutzung des Programms werden zwei gültige API-Keys benötigt:
  - Geo-API-Key (für die Umwandlung von Ort/PLZ in Koordinaten)
  - Tankerkönig-API-Key (für das Abrufen der Kraftstoffpreise)
- Die API-Keys erhältst du kostenfrei nach Registrierung auf folgenden Seiten:
  - https://geocode.maps.co/join/ (Geo-API)
  - https://creativecommons.tankerkoenig.de/ (Tankerkönig-API)
- Nach Erhalt der Keys öffne das Konfigurationsmenü (Zahnrad-Button) und trage die Keys in die entsprechenden Felder ein. Mit Klick auf "Speichern" werden die Keys als Umgebungsvariablen für den aktuellen Benutzer hinterlegt.

Hauptfunktionen:
- Suche nach Tankstellen anhand von Postleitzahl oder Ort.
- Auswahl des Suchradius (in Kilometern) über einen Schieberegler.
- Auswahl der Kraftstoffsorte (Benzin, Diesel, E10) per Radiobutton.
- Anzeige der gefundenen Tankstellen mit Name, Preis, Adresse und Ort in einer übersichtlichen Tabelle.
- Speichern der Suchergebnisse als CSV-Datei.
- Laden von gespeicherten CSV-Dateien zur späteren Ansicht.
- Verwaltung der benötigten API-Keys (Geo-API und Tankerkönig-API) im Konfigurationsfenster.

Hinweise:
- Das Programm benötigt eine Internetverbindung, um aktuelle Preisdaten abzurufen.

Erläuterung der Funktionen:
- Textfeld zur Eingabe von Postleitzahl oder Ort.
- Schieberegler zur Bestimmung des Suchradius um den gewählten Ort.
- Drei Radiobuttons zur Auswahl der Kraftstoffsorte.
- Button "Eingabe": Startet die Suche nach Tankstellen im definierten Bereich.
- Button "Speichern": Speichert die aktuelle Suchabfrage als CSV-Datei.
- Button "Laden": Öffnet gespeicherte Suchabfragen.
- Runder Button (Zahnrad): Öffnet das Konfigurationsmenü zur Verwaltung der API-Keys. Nach Eingabe und Speichern der Keys können diese sofort verwendet werden. Das Fenster kann danach einfach geschlossen werden.

Erstellt mit .NET 8 und WPF.
