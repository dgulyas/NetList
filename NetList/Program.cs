using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;

namespace NetList
{
	static class Program
	{
		static void Main()
		{
			Dictionary<string, List<object>> Lists = new Dictionary<string, List<object>>();
			using (var host = new NancyHost(new Uri("http://localhost:1234")))
			{
				host.Start();
				Console.WriteLine("Running on http://localhost:1234");
				Console.ReadKey(); //letting cats shutdown systems since 1999.
			}
		}
	}
}
