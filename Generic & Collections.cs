using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_and_collections
{
	class Script
	{
		//generic collection - List
		List<string> list = new List<string>() { "Erika", "Rinka", "Momoko", "Jun", "Saya", "Hikari", "Ai" };

		//array
		int[] arr = new int[] { 99, 100, 105, 120, 111, 133 };

		static void Main(string[] args)
		{
			Script s = new Script();

			//create list from array
			var list_2 = new List<int>(s.arr);
			//foreach (var i in list_2) Console.WriteLine(i);

			//List<T> properties
			var count = s.list.Count;
			var cap = s.list.Capacity;
			var item = s.GetListItem(2, s.list);

			//List<T> Methods
			s.list.Add("Neon");

			var newItems = new List<string>() { "Maru", "Moe" };
			s.list.AddRange(newItems);

			var readOnlyList = s.list.AsReadOnly();

			var checkItem = s.list.Contains("Erika");
			var biSearch = s.list.BinarySearch("Saya");

			Predicate<int> match = s.FindNumber;
			var exist = list_2.Exists(match);
			var findNum = list_2.Find(match);
			var findLastNum = list_2.FindLast(match);
			var findAllNum = list_2.FindAll(match);
			var firstIdx = list_2.FindIndex(match);
			var lastIdx = list_2.FindLastIndex(match);

			Action<int> enumerate = s.Enumerator;
			list_2.ForEach(enumerate);

			Console.WriteLine();


			//foreach (var i in s.list) Console.WriteLine(i);

			s.list.Clear();
			//Console.WriteLine(s.list.Count);


		}

		string GetListItem(int i, List<string> li) => li[i];

		bool FindNumber(int num) => num > 105;

		void Enumerator(int num) => Console.WriteLine(num);
	}
}