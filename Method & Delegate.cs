using System;
using System.Collections;
using System.Collections.Generic;


namespace Method_and_delegate
{
	class Script
	{
		//declare a delegate 
		delegate void MessageDelegate(string message);

		//main method 
		static void Main(string[] args)
		{
			Console.WriteLine("Hi there! Happy scripting");

			//create an obect of this class
			Script script = new Script();

			//get access to the object's method
			int num;
			int result = script.GetNumber(out num);
			Console.WriteLine(result);

			//delegate
			MessageDelegate del = MyDelegate.Message;
			del.Invoke("This is a simple example of delegate");

			//Multicast delegate
			del += MyDelegate.AnotherMessage;
			del.Invoke("delegate");

			//Anonymous method in delegate
			MessageDelegate del2 = delegate (string message)
			{
				Console.WriteLine($"{message}");
			};
			del2.Invoke("This anonymous");

			//Action delegate - without care about declaration of delegate
			Action<string> del3 = MyDelegate.Message;
			del3.Invoke("This is from Action delegate");

			//Function delegate - without care about declaration of delegate
			Func<int, string> del4 = MyDelegate.NumberToString;
			string number = del4.Invoke(100);
			Console.WriteLine(number);

			//Predicate delegate
			Predicate<int> predicate = MyDelegate.FindMultiples;
			//find multiple of 3
			List<int> list = new List<int>() { 1, 3, 5, 7, 9, 11, 13, 15 };
			int multiple = list.Find(predicate);
			Console.WriteLine(multiple);
			List<int> multiples = list.FindAll(predicate);

			foreach (var i in multiples)
			{
				Console.WriteLine(i);
			}

			//Compariosn delegate
			Comparison<int> compare = MyDelegate.CompareNumbers;
			var numbers = new List<int> { -1, 20, 3, 9, 11, -3, 99, 150, 2, 0, 21, 1 };
			numbers.Sort(compare);

			foreach (var i in numbers)
			{
				Console.WriteLine(i);
			}

			//event
			Publisher pub = new Publisher();
			Subscriber sub = new Subscriber(1, pub);
			pub.OnAlert();

			//EventHandler 
			Subscriber sub2 = new Subscriber(2, pub);
			pub.InvokeEvent();

			//EventHabdler<TEventArgs> 
			Subscriber sub3 = new Subscriber(3, pub);
			MyEventArgs eventArgs = new MyEventArgs() { Number = 1, Text = "hello world" };
			pub.InvokeEventWithdata(eventArgs);

			//Extension method
			script.ExtensionMethod("This is an extension method for the Script class");
		}

		public int GetNumber(out int num)
		{
			num = 99;
			return num + 1;
		}

	}

	class MyDelegate
	{
		//a delegate method
		public static void Message(string message)
		{
			Console.WriteLine($"{message}");
		}

		public static void AnotherMessage(string message)
		{
			Console.WriteLine($"Another {message}");
		}

		public static string NumberToString(int num)
		{
			string str = num.ToString();
			return "The number is:" + str;
		}
		//Check whether the integer is multiple of 3 
		public static bool FindMultiples(int element)
		{
			return element % 3 == 0;
		}

		public static int CompareNumbers(int x, int y)
		{
			if (x - y > 0) return 1;
			else if (x - y < 0) return -1;
			else return 0;
		}

	}

	class Publisher
	{
		//C# event
		public delegate void Alert();
		public event Alert alert;

		//EventHandler 
		public event EventHandler messageLog;

		//EventHandler<TEventArgs>
		public event EventHandler<MyEventArgs> eventDataLog;

		//raising an event here
		public void OnAlert()
		{
			alert?.Invoke(); //invoke delegate
		}

		//EvenHandler delegate
		public void InvokeEvent() => OnCall();
		protected virtual void OnCall() => messageLog?.Invoke(this, EventArgs.Empty);


		//EventHandler<TEventArgs> delegate
		public void InvokeEventWithdata(MyEventArgs args) => OnMessage(args);
		protected virtual void OnMessage(MyEventArgs args) => eventDataLog?.Invoke(this, args);

	}

	class Subscriber
	{
		public Subscriber(int id, Publisher p)
		{

			if (id == 1) p.alert += AlertHandler;
			else if (id == 2) p.messageLog += MessageHandler;
			else if (id == 3) p.eventDataLog += EventDataHandler;
		}

		public void AlertHandler()
		{
			Console.Beep(3000, 1000);
			Console.WriteLine("This is an alert!");
		}

		public void MessageHandler(object sender, EventArgs e)
		{
			Console.Beep(8000, 1000);
			Console.WriteLine("This is a message");
		}

		public void EventDataHandler(object sender, MyEventArgs e)
		{
			Console.Beep(1000, 1000);
			Console.WriteLine($"There is {e.Number} text from sender." + " " + $"Text: {e.Text}");
		}

	}

	class MyEventArgs : EventArgs
	{
		public int Number { get; set; }
		public string Text { get; set; }
	}

	//Extension method for class Script
	static class Extension
	{
		public static void ExtensionMethod(this Script s, string str)
		{
			Console.Beep(2000, 1000);
			Console.WriteLine($"{str}");
		}
	}
}







