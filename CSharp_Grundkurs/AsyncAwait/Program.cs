using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		Stopwatch sw = Stopwatch.StartNew();
		//Toast();
		//Tasse();
		//Kaffee();
		//Console.WriteLine(sw.ElapsedMilliseconds);

		//Task t1 = Task.Run(Toast);
		//Task t2 = Task.Run(Tasse).ContinueWith(v => Kaffee());
		//Task.WaitAll(t1, t2);
		//Console.WriteLine(sw.ElapsedMilliseconds);

		//async Methoden
		//Wenn eine Async Methode gestartet wird, wird diese als Task gestartet
		//Nur innerhalb von async Methoden kann await verwendet werden
		//async void: Kann await verwenden, kann aber selbst nicht awaited werden
		//async Task: Kann await verwenden, und kann aber selbst awaited werden
		//async Task<T>: Kann await verwenden, kann selbst awaited werden und es kommt hier noch ein Ergebnis heraus

		//Hier können die Methoden nicht awaited werden, weil sie void sind
		//ToastAsync();
		//TasseAsync();
		//KaffeeAsync();
		//Console.WriteLine(sw.ElapsedMilliseconds);

		//Task t1 = ToastAsync(); //Hier wird der Toast Task gestartet (hier wird kein Run oder Start benötigt)
		//Task t2 = TasseAsync();
		//await t2;
		//Task t3 = KaffeeAsync();
		//await t3;
		//await t1; //Hier schätzen welcher Task am längsten benötigt, und die Tasks so ordnen das der längste Task der letzte Task ist
		//Console.WriteLine(sw.ElapsedMilliseconds);

		//Task<Toast> t1 = ToastObjectAsync(); //Hier wird der Toast Task gestartet (hier wird kein Run oder Start benötigt)
		//Task<Tasse> t2 = TasseObjectAsync();
		//Tasse t = await t2; //Wenn der Task einen Rückgabewert hat, kommt das Ergebnis über await als fertiges Objekt heraus
		//Task<Kaffee> t3 = KaffeeObjectAsync(t);
		//Kaffee k = await t3;
		//Toast toast = await t1;
		//Console.WriteLine(sw.ElapsedMilliseconds);

		Task<Toast> t1 = ToastObjectAsync(); //Hier wird der Toast Task gestartet (hier wird kein Run oder Start benötigt)
		Task<Kaffee> t3 = KaffeeObjectAsync(await TasseObjectAsync());
		Kaffee k = await t3;
		Toast toast = await t1;
		Console.WriteLine(sw.ElapsedMilliseconds);

		//WhenAll, WhenAny: Warte auf mehrere Tasks mit await
		await Task.WhenAll(t1, t3); //Warte auf mehrere Tasks (keine Schätzung des längsten Tasks notwendig) -> await t1, t3;
	}

	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Tasse()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Tasse fertig");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee fertig");
	}

	static async Task ToastAsync()  //Methoden mit Rückgabewert Task die async sind können keinen return Wert haben
	{
		await Task.Delay(4000); //Warte hier, bis dieser Task fertig ist
		Console.WriteLine("Toast fertig");
	}

	static async Task TasseAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse fertig");
	}

	static async Task KaffeeAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
	}

	static async Task<Toast> ToastObjectAsync()  //Methoden mit Rückgabewert Task<T> die async sind müssen einen return Wert haben
	{
		await Task.Delay(4000); //Warte hier, bis dieser Task fertig ist
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> TasseObjectAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse fertig");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeObjectAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
		return new Kaffee();
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }