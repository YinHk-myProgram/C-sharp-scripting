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
		int[] arr = new int[] { 99, 105, 100, 120, 97, 133, 109, 101 };

		//dictionary
		Dictionary<int, string> dict = new Dictionary<int, string>() {
			{ 1, "Japan"}, { 2, "Malaysia"}, { 3, "Singapore"}, { 4, "Thailand"}, { 5, "Taiwan"}, { 6, "New zealand" }  };

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

			s.list.Insert(1, "Izu");

			var newGroupItems = new List<string>() { "Miya", "Kaete" };
			s.list.InsertRange(2, newGroupItems);

			var readOnlyList = s.list.AsReadOnly();

			var checkItem = s.list.Contains("Erika");
			var biSearch = s.list.BinarySearch("Saya");
			var idx = s.list.IndexOf("Erika");
			var IdxLast = s.list.LastIndexOf("Erika");

			Predicate<int> match = s.FindNumber;
			var exist = list_2.Exists(match);
			var findNum = list_2.Find(match);
			var findLastNum = list_2.FindLast(match);
			var findAllNum = list_2.FindAll(match);
			var firstIdx = list_2.FindIndex(match);
			var lastIdx = list_2.FindLastIndex(match);

			Action<int> enumerate = s.Enumerator;
			//list_2.ForEach(enumerate);

			s.list.Remove("Moe");
			s.list.RemoveAt(0);
			s.list.RemoveRange(2, 2);

			s.list.Reverse();
			s.list.Reverse(2, 3);

			Comparison<int> compare = s.CompareNumber;
			list_2.Sort(compare);

			string[] name = s.list.ToArray();


			s.list.Clear();
			//Console.WriteLine(s.list.Count);


			//dictionary
			var countOfDict = s.dict.Count;
			s.dict.Add(7, "Australia");
			s.dict.Add(8, "Demark");

			var isExistKey = s.dict.ContainsKey(5);
			var isExistValue = s.dict.ContainsValue("Hong Kong");

			s.dict.Remove(4);

			foreach (var (i, j) in s.dict) Console.WriteLine(j);
			foreach (var (i, j) in s.dict) Console.WriteLine(i);

		}

		string GetListItem(int i, List<string> li) => li[i];

		bool FindNumber(int num) => num > 105;

		void Enumerator(int num) => Console.WriteLine(num);

		int CompareNumber(int x, int y)
		{
			if (x - y > 0) return 1;
			else if (x - y < 0) return -1;
			else return 0;
		}
	}
}