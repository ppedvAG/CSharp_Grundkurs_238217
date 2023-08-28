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

			ConsoleKeyInfo info = Console.ReadKey();
            Console.WriteLine(info.Key);
            Console.WriteLine(info.Modifiers);

			int x = 3489;
			x.ToString();

			Math.Round(235879.2359789324, 2);

			string s = x > 50 ? "x größer 50" : "x kleiner gleich 50"; //Links und rechts müssen Ergebnisse heraus kommen

			//x > 50 ? Console.WriteLine(s) : Console.WriteLine(); //Nicht möglich
        }
	}
}