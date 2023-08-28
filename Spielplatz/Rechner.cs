using System;
using System.Collections.Generic;
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
				Console.Write("Gib die 1. Zahl ein: ");
				double z1 = double.Parse(Console.ReadLine());

				Console.Write("Gib die 2. Zahl ein: ");
				double z2 = double.Parse(Console.ReadLine());

				Console.WriteLine("Gib die Rechenart ein: ");
				foreach (Rechenart a in Enum.GetValues<Rechenart>())
				{
					Console.WriteLine($"{(int) a}: {a}");
				}

				Rechenart art = Enum.Parse<Rechenart>(Console.ReadLine());

				switch (art)
				{
					case Rechenart.Addition:
						Console.WriteLine("Ergebnis: " + (z1 + z2));
						break;
					case Rechenart.Subtraktion:
						Console.WriteLine("Ergebnis: " + (z1 - z2));
						break;
					case Rechenart.Multiplikation:
						Console.WriteLine("Ergebnis: " + (z1 * z2));
						break;
					case Rechenart.Division:
						if (z2 != 0)
							Console.WriteLine("Ergebnis: " + (z1 / z2));
						else
							Console.WriteLine("Teilung durch 0 nicht möglich");
						break;
					default:
						Console.WriteLine("Keine valide Rechenart angegeben");
						break;
				}

                Console.WriteLine("Drücke J für eine Wiederholung");
				ConsoleKeyInfo info = Console.ReadKey();
				if (info.Key != ConsoleKey.J)
					break;
            }
		}
	}

	public enum Rechenart { Addition = 1, Subtraktion, Multiplikation, Division }
}
