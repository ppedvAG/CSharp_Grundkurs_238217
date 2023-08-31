using System.Net.Http.Headers;

namespace DelegatesEvents;

internal class ComponentUser
{
	static void Main(string[] args)
	{
		Component comp = new Component(); //Benutzerseite, hier werden die Events angehängt
		comp.ProcessStarted += Comp_ProcessStarted;
		comp.ProcessEnded += Comp_ProcessEnded;
		comp.Progress += Comp_Progress;
		comp.StartProcess();
	}

	private static void Comp_ProcessStarted()
	{
        Console.WriteLine("Prozess wurde gestartet"); //Hier kann der Benutzer selbst festlegen, wohin der Output geht (Konsole, UI, Log, ...)
	}

	private static void Comp_ProcessEnded(long obj)
	{
		Console.WriteLine($"Prozess ist abgeschlossen. Dauer: {obj / 1000.0}s");
	}

	private static void Comp_Progress(int obj)
	{
		Console.WriteLine($"Fortschritt: {obj}");
	}
}
