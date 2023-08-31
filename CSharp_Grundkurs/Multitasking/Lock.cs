namespace Multitasking;

internal class Lock
{
	static int Zahl;
	static object LockObj = new();

	static void Main(string[] args)
	{
		List<Task> tasks = new List<Task>();
		for (int i = 0; i < 1000; i++)
		{
			tasks.Add(Task.Run(() =>
			{
				for (int j = 0; j < 100; j++)
				{
					lock (LockObj)
					{
						Zahl++;
					}
				}
			}));
		}
		Task.WaitAll(tasks.ToArray());
		Console.WriteLine(Zahl);
	}
}
