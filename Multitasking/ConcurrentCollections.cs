using System.Collections.Concurrent;

namespace Multitasking;

internal class ConcurrentCollections
{
	static void Main(string[] args)
	{
		ConcurrentBag<int> list = new ConcurrentBag<int>();
		list.Add(1);

		ConcurrentDictionary<string, int> dict = new();
		dict.TryAdd("a", 1);
	}
}
