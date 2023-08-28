using System.Net;
using M008;

namespace Spielplatz;

internal class Program
{
	/// <summary>
	/// Die Main Methode
	/// </summary>
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!"); //Ein Kommentar

		//string eingabe = Console.ReadLine();
		//Console.WriteLine($"Deine Eingabe ist: {eingabe}");

		//ConsoleKeyInfo info = Console.ReadKey();
		//Console.WriteLine(info.Key);
		//Console.WriteLine(info.Modifiers);

		int zahl = 3489;
		zahl.ToString();

		Math.Round(235879.2359789324, 2);

		string s = zahl > 50 ? "x größer 50" : "x kleiner gleich 50"; //Links und rechts müssen Ergebnisse heraus kommen

		//x > 50 ? Console.WriteLine(s) : Console.WriteLine(); //Nicht möglich

		for (int i = 0, j = 1; i < 31; i++, j *= 2)
		{
			Console.WriteLine($"2^{i}={j}");
		}

		Rechner r = new Rechner();
		r.Rechne();

		(int, int) x = (1, 2);
		Console.WriteLine(x.Item1);
		Console.WriteLine(x.Item2);


		//int.Parse("x");
		//int result;
		bool b = int.TryParse("12", out int result); //Verbindung zu result herstellen über out
		if (b)
		{
			Console.WriteLine("Parsen funktioniert");
		}
		else
		{
			Console.WriteLine("Parsen hat nicht funktioniert");
		}

        Console.WriteLine(43268.4236879.ToString("N2"));
	}
}

//public class Test : AccessModifier
//{
//    public Test()
//    {

//    }
//}