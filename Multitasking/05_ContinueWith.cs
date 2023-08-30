namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		//ContinueWith: Tasks verketten, wenn der erste Task fertig ist, können Folgetasks angekettet werden
		//Mittels Parameter auf den vorherigen Task zugreifen

		Task t = new Task(() => Thread.Sleep(1000));
		t.ContinueWith(vorherigerTask => Console.WriteLine("Folgetask 1")); //Hier wird ein Folgetask auf t konfiguriert
		t.ContinueWith(vorherigerTask => Console.WriteLine("Folgetask 2")); //Hier wird ein weiterer Folgetask auf t konfiguriert, beide Tasks werden gleichzeitig gestartet, wenn t fertig ist
		t.Start(); //Hier wird der fertig konfigurierte Task gestartet

		Task<double> berechne = new Task<double>(() =>
		{
			//throw new Exception();
			Thread.Sleep(1000);
			return Math.Pow(4, 23);
		});
		berechne.ContinueWith(vorherigerTask => Console.WriteLine(vorherigerTask.Result)); //Wird immer ausgeführt
		berechne.ContinueWith(vorherigerTask => Console.WriteLine("Fehler"), TaskContinuationOptions.OnlyOnFaulted); //Wird nur bei Fehlern ausgeführt
		berechne.ContinueWith(vorherigerTask => Console.WriteLine("Erfolg"), TaskContinuationOptions.OnlyOnRanToCompletion); //Wird nur bei Erfolg ausgeführt
		berechne.Start();

		for (int i = 0; i < 100; i++)
		{
            Console.WriteLine($"Main Thread: {i}");
            Thread.Sleep(50);
		}

		Console.ReadKey();
	}
}
