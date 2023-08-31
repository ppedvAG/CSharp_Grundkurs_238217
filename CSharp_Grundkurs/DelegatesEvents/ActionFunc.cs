using System.Threading.Channels;
using System.Timers;

namespace DelegatesEvents;

internal class ActionFunc
{
	static List<int> testList = new();

	static void Main(string[] args)
	{
		//Action, Func, Predicate: Vordefinierte Delegates die an verschiedenen Stellen in C# internem Code eingebaut sind
		//Essentiell für die Fortgeschrittene Programmierung
		//Können alles was in dem vorherigen Teil vorkommt

		//Action: Delegate mit Rückgabetyp void und bis zu 16 Parametern
		Action<int, int> action = Addiere; //Action<int, int> -> void Methode(int x, int y)
		action(4, 5);
		action?.Invoke(4, 9);

		DoAction(3, 4, Addiere);
		DoAction(3, 4, Subtrahiere);
		DoAction(5, 6, action);

		testList.ForEach(Quadriere); //Action<int> -> void Methode(int x)
		void Quadriere(int x) => Console.WriteLine(x * x);

		//Func: Methode mit Rückgabetyp (T) und bis zu 16 Parametern, Rückgabetyp ist das letzte Generische Typargument
		Func<int, int, double> func = Multipliziere; //Func<int, int, double> -> double Methode(int x, int y)
		double d = func(4, 7); //Ergebnis der Func in eine Variable schreiben

		DoFunc(4, 5, Multipliziere);
		DoFunc(3, 6, Dividiere);
		DoFunc(8, 2, func);

		//Anonyme Methoden: Funktionen für den einmaligen Gebrauch, ohne sie anlegen zu müssen
		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		//Anwenden von anonymen Funktionen
		DoAction(1, 6, (x, y) => Console.WriteLine(x % y)); //Durch Action wird hier ein Ausdruck benötigt, der void zurückgibt
		DoFunc(4, 7, (x, y) => x % y); //Func benötigt hier einen Ausdruck, der double zurück gibt und zwei ints nimmt
		testList.Find(e => e == 5);
		testList.Find(Number5);

		bool Number5(int e) => e == 5;

		//Action und Func finden sich an vielen Stellen in C# wieder
		//Sie benötigen jeweils eine anonyme Funktion als Parameter (e => ...), ((x, y) => ...)
	}

	#region Action
	static void Addiere(int x, int y) => Console.WriteLine(x + y);

	static void Subtrahiere(int x, int y) => Console.WriteLine(x - y);

	static void DoAction(int x, int y, Action<int, int> action) => action?.Invoke(x, y);
	#endregion

	#region Func
	static double Multipliziere(int x, int y) => x * y;

	static double Dividiere(int x, int y) => (double) x / y;

	static double DoFunc(int x, int y, Func<int, int, double> func) => func.Invoke(x, y);
	#endregion
}
