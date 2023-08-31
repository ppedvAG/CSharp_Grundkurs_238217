using System.Diagnostics;

namespace DelegatesEvents;

public class Component
{
	//Komponente, die Daten von einer Schnittstelle (DB, Web, File, ...) lädt und den User über den Fortschritt benachrichtigt
	//Entwicklerseite
	//3 Events: Start, Ende, Fortschritt

	public event Action ProcessStarted;

	public event Action<long> ProcessEnded;

	public event Action<int> Progress;

	public void StartProcess()
	{
		ProcessStarted?.Invoke(); //Programm würde abstürzen, wenn der User hier keine Funktion anhängt
		Stopwatch sw = Stopwatch.StartNew();
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(Random.Shared.Next(20, 70)); //Simuliert eine Arbeit die ausgeführt wird
			Progress?.Invoke(i); //Fortschritt dem User mitteilen
		}
		ProcessEnded?.Invoke(sw.ElapsedMilliseconds); //Hier am Ende wird dem User mitgeteilt wie lange die Arbeit gedauert hat (Stopwatch)
	}
}
