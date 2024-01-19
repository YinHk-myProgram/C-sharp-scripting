using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_and_collections
{
	class Script
	{
		//generic collection - List
		List<string> list = new List<string>() { "Erika", "Rinka", "Momoko", "Jun", "Saya", "Hikari", "Ai" };


		static void Main(string[] args)
		{
			Script s = new Script();

			//List<T> properties
			int count = s.list.Count;
			Console.WriteLine(count);

			int cap = s.list.Capacity;
			Console.WriteLine(cap);





		}
	}
}