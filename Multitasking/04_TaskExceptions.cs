namespace Multitasking;

internal class _04_TaskExceptions
{
	static void Main(string[] args)
	{
		try
		{
			Task.Run(() => throw new Exception("Task wurde abgebrochen")).Wait();
		}
		catch (AggregateException e)
		{
			foreach (Exception t in e.InnerExceptions)
			{
                Console.WriteLine(t.Message);
            }
        }
	}
}
