using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spielplatz
{
	internal class Rechner
	{
		public void Rechne()
		{
			while (true)
			{
				double z1;
				bool parsenFunktioniert;
				do
				{
					Console.Write("Gib die 1. Zahl ein: ");
					parsenFunktioniert = double.TryParse(Console.ReadLine(), out z1);
				}
				while (!parsenFunktioniert);

				Console.Write("Gib die 2. Zahl ein: ");
				double z2;
				while (!double.TryParse(Console.ReadLine(), out z2))
					Console.Write("Gib die 2. Zahl ein: ");


				Console.WriteLine("Gib die Rechenart ein: ");
				foreach (Rechenart a in Enum.GetValues<Rechenart>())
				{
					Console.WriteLine($"{(int) a}: {a}");
				}

				Rechenart art;
				Enum.TryParse(Console.ReadLine(), out art);

				double ergebnis = Berechne(z1, z2, art, out	string symbol);
				if (symbol != string.Empty)
					Console.WriteLine($"{z1} {symbol} {z2} = {ergebnis}");

                Console.WriteLine("Drücke J für eine Wiederholung");
				ConsoleKeyInfo info = Console.ReadKey();
				if (info.Key != ConsoleKey.J)
					break;
            }
		}

		private double Berechne(double z1, double z2, Rechenart art, out string symbol)
		{
			symbol = art switch { Rechenart.Addition => "+", Rechenart.Subtraktion => "-", Rechenart.Multiplikation => "*", Rechenart.Division => "/", _ => string.Empty };
			switch (art)
			{
				case Rechenart.Addition: return z1 + z2;
				case Rechenart.Subtraktion: return z1 - z2;
				case Rechenart.Multiplikation: return z1 * z2;
				case Rechenart.Division: return z2 != 0 ? z1 / z2 : double.NaN;
				default:
					Console.WriteLine("Keine valide Rechenart angegeben");
					return double.NaN;
			}
		}
	}

	public enum Rechenart { Addition = 1, Subtraktion, Multiplikation, Division }
}
