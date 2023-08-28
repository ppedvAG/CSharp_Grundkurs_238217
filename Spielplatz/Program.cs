using Spielplatz;
using System.Net;
using System.Threading.Channels;

namespace M001
{
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
		}
	}
}