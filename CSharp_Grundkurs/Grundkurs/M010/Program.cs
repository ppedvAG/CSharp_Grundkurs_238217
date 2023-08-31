using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Mensch m = new Mensch();
		m.Job = "Softwareentwickler";
		m.Gehalt = 10000;
		//m.Lohnauszahlung();
        Console.WriteLine(m.Jahresgehalt());
        Console.WriteLine(m.LohnProStunde(m.Gehalt));

		//Polymorphismus kann zusätzlich zu Klassen über Interfaces ermöglicht werden
		//Hier sind auch mehrere Interfaces möglich -> effektiv Mehrfachvererbung
		IArbeit arbeit = m;
		arbeit.Lohnauszahlung();

		Mensch2 m2 = new Mensch2();
		arbeit = m2;
		arbeit.Lohnauszahlung();

		ITeilzeitArbeit tzArbeit = m;
		tzArbeit.Lohnauszahlung(); //Selber Code wie beim ersten Interface

		//IEnumerable: Basis von allen Listen, gibt das Verhalten von Listen vor
		//IEnumerable enthält eine Komponente namens IEnumerator
		//IEnumerator:
		// - Stellt ein Grundgerüst von allen Listen dar
		// - "Zeiger" der immer auf ein Element zeigt (object Current)
		// - Kann mit MoveNext() ein Element weiter bewegt werden
		// - Wenn MoveNext() false zurück gibt, sind keine weiteren Elemente vorhanden. Danach kann mit Reset() der Zeiger an den Anfang zurück gesetzt werden.
		// - Die foreach Schleife greift auf den Enumerator zu um die Liste zu iterieren
		//IEnumerable wird verwendet um u.a. Linq Funktionen zu ermöglichen
		//Array, List, Dictionary, ... haben alle dieses Interface implementiert
		List<int> list = new();
		int[] a = new int[10];
		Dictionary<int, string> dict = new();

		Test(list); //Hier sind jetzt alle Listen möglich
		Test(a);
		Test(dict);
    }

	public static void Test<T>(IEnumerable<T> x) { }
}

/// <summary>
/// Interface: Eigener Typ der eine Struktur vorgibt (Properties, Methoden)</br>
/// Die Klassen die das Interface haben sollen, müssen alle Member des Interfaces implementieren (wie abstract)</br>
/// Nur Struktur (wie abstract)
/// </summary>
public interface IArbeit
{
	public static readonly int Wochenstunden = 40; //Sozusagen eine Konstante

	public string Job { get; set; }

	public int Gehalt { get; set; }

	void Lohnauszahlung(); //Bei Methoden gibt es keine Access Modifier

	int Jahresgehalt();

	double LohnProStunde(int lohn);

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit
{
	public static readonly int Wochenstunden = 20; //Sozusagen eine Konstante

	void Lohnauszahlung(); //Bei Methoden gibt es keine Access Modifier
}

public abstract class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit
{
	public string Job { get; set; }

	public int Gehalt { get; set; }

	public int Jahresgehalt()
	{
		return Gehalt * 12;
	}

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ pro Monat für den Job {Job} erhalten." +
		 $"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt / 2.0}€ pro Monat für den Job {Job} erhalten." +
			$"Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche.");
	}

	public double LohnProStunde(int lohn)
	{
		return Gehalt / (ITeilzeitArbeit.Wochenstunden * 4);
	}
}

public class Mensch2 : IArbeit
{
	public string Job { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public int Gehalt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public int Jahresgehalt()
	{
		throw new NotImplementedException();
	}

	public void Lohnauszahlung()
	{
		throw new NotImplementedException();
	}

	public double LohnProStunde(int lohn)
	{
		throw new NotImplementedException();
	}
}