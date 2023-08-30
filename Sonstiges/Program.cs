namespace Sonstiges;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon a = new Wagon();
		Wagon b = new Wagon();
		Console.WriteLine(a == b);

		Zug z = new Zug();
		z += a;
		z += b;

		Zug z2 = new Zug();
		z2++;
		z2++;
		z2++;
		z2++;
		z += z2;

		foreach (Wagon x in z)
		{

		}

		Console.WriteLine(z[3]);
		z[3] = new Wagon();

		Console.WriteLine(z[30, "Rot"]);

		var x = args.Select(e => new { e.Length, ErstesZeichen = e[0] });
		foreach (var obj in x)
		{
			Console.WriteLine(obj.Length);
			Console.WriteLine(obj.ErstesZeichen);
		}

		dynamic o = new Program();
		o.XYZ = 123;
		o.Func1(o.XYZ);

		string s1 = "123";
		string s2 = "456"; //2x string im RAM
		string s3 = s1 + s2; //4x string im RAM
		string s4 = s3 + s3; //8x string im RAM
	}
}



public class Zug : IEnumerable
{
	public List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator()
	{
		foreach (Wagon w in Wagons)
			yield return w; //Speichere die return Werte zwischen und gib sie am Ende der Funktion zurück

		//Selbiges wie oben nur ohne yield
		//List<Wagon> wagons = new();
		//foreach (Wagon w in Wagons)
		//	wagons.Add(w);
		//return wagons.GetEnumerator();

		//return Wagons.GetEnumerator();

	} //Hier finales return

	public Wagon this[int index]
	{
		get => Wagons[index];
		set => Wagons[index] = value;
	}

	public Wagon this[int anzSitze, string farbe]
	{
		get => Wagons.First(e => e.AnzSitze == anzSitze && e.Farbe == farbe);
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.Wagons.Add(w);
		return z;
	}

	public static Zug operator +(Zug z, Zug z2)
	{
		z.Wagons.AddRange(z2.Wagons);
		z2.Wagons.Clear();
		return z;
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new Wagon());
		return z;
	}
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}