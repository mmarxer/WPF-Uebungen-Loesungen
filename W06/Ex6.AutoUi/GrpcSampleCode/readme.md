# Anbindung des AutoUi via gRPC

Um das AutoUi-WPF-Projekt mit dem gRPC-Client zu verbinden, sind folgende Dinge zu beachten:

* Das WPF-Projekt muss auf .NET Core (>=3.0) umgestellt werden, damit gRPC genutzt werden kann.
* Am besten deshalb in der Autoreservations-Solution ein neues WPF-Projekt (.NET Core) hinzufügen und alle .xaml und .cs-Dateien aus dem bisherigen WPF-Projekt ins neue Projekt copy/pasten.
* Das X-Plattform-Projekt mit den ViewModels kann direkt wiederverwendet werden (copy/paste und Hinzufügen des bestehenden Projekts zur Autoreservations-Solution).

Für die Anpassung des WPF-Projekts zudem noch folgende Hinweise:

* Es wird eine Service-Implementation des Interfaces IModelDataService benötigt.
  * Dazu im Verzeichnis "Services" im WPF-Projekt "AutoUi" eine neue Klasse hinzufügen:  `GrpcModelDataService`
  * In der Klasse werden Instanzen der gRPC-Clients benötigt, welche im Autoreservations-Projekt autogeneriert wurden. Daher muss im AutoUi-Projekt eine Referenz auf das Projekt `AutoReservation.Service.Client` gesetzt werden.
  * Die Clients benötigen einen `GrpcChannel` (vgl. Testprojekt unter Common\ServiceTestFixture.cs im Konstruktor). Dabei ist die verwendete Url und der verwendete Port speziell zu beachten.
  * Das Öffnen des Channels und die Instanziierung der Clients kann im Konstruktor des `GrpcModelDataService` erledigt werden.
  * Ein Beispiel dazu ist im File [`GrpcModelDataService`](GrpcModelDataService.cs) zu finden.
  * Die von den Clients zurückgegebenen Dto-Objekte müssen dann noch in unsere ViewModels konvertiert werden.
  * Die Service-Implementation muss anstelle des `MockModelDataService` im Code in `App.xaml.cs` instanziiert werden.
* Um das Ganze auszuprobieren, muss zudem folgendes beachtet werden:
  * Es wird ein laufender gRPC-Server benötigt.
  * Ein solcher steht im Projekt `AutoReservation.Service.Grpc` in der MsTe-Projektvorlage als Konsolenapplikation zur Verfügung.
  * Um die Konsolen-App (also den gRPC-Server) zu starten, muss das Projekt zuerst kompiliert werden. Danach kann das erzeugte .exe-File (`AutoReservation.Service.Grpc.exe`) direkt aus dem  Untervzeichnis `bin\Debug\netcoreapp3.0\` des entsprechenden Projekts heraus gestartet werden.
  * Wichtig ist, dass der gRPC-Server auf dem gleichen Port läuft, über welchen die Clients zugreifen möchten. Achtung: standardmässig läuft der Server auf Port 5001.

