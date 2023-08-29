using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spielplatz
{
	internal static class ExtensionMethods
	{
		public static char NextChar(this Random r)
		{
			return r.Next() % 2 == 0 ? (char) Random.Shared.Next(65, 91) : (char) Random.Shared.Next(97, 123);
		}

		public static string NextString(this Random r, int length)
		{
			string str = "";
			for (int i = 0; i < length; i++)
				str += r.NextChar();
			return str;
		}
	}
}
