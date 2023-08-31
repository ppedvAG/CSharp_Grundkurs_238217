namespace DelegatesEvents;

internal class Events
{
	//Event: Statischer Punkt (muss nicht static sein), an den Methoden angehängt werden können
	//Zweigeteilte Entwicklung
	//Entwickler der Komponente, dieser stellt das Event bereit und ruft es auf
	//Benutzer der Komponente, dieser hängt Funktionen an das Event an und kann dadurch die Funktionsweise der Komponente anpassen
	//Kann nicht instanziert werden

	static event EventHandler TestEvent; //Entwickler

	static event EventHandler<TestEventArgs> ArgsEvent;

	static event EventHandler<int> IntEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Benutzer
		TestEvent(null, EventArgs.Empty); //Entwickler

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent(null, new TestEventArgs() { Data = "Event aufgerufen" });

		IntEvent += Events_IntEvent;
	}

	private static void Events_TestEvent(object? sender, EventArgs e)
	{
        Console.WriteLine("Event aufgerufen");
	}

	private static void Events_ArgsEvent(object? sender, TestEventArgs e)
	{
		Console.WriteLine(e.Data);
	}

	private static void Events_IntEvent(object? sender, int e)
	{
		Console.WriteLine(e);
	}
}

public class TestEventArgs : EventArgs
{
	public string Data { get; set; }
}