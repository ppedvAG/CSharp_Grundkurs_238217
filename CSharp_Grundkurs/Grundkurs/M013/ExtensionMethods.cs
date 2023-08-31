using System.Text.Json;

namespace M013;

public static class ExtensionMethods
{
	public static int Quersumme(this int x)
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next());
	}

	public static JsonElement GetPropertyChain(this JsonElement x, params string[] properties)
	{
		foreach (string property in properties)
			x = x.GetProperty(property);
		return x;
	}
}
