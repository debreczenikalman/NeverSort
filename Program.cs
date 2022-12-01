using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace NeverSort
{
	class Program
	{
		static int MinNumber = 0; // floor for the random generator
		static int MaxNumber = 10; // roof for the random generator
								   // static Random r = new Random(); // if this is enabled, there will be no repeating sequence of numbers in the NeverSort() function, making it significantly faster
		static void Main(string[] args)
		{
			byte[] arrayToSort = { 3, 1, 2, 5, 4 };
			bool isSorted;
			byte[] tmpArr;
			List<string> summary = new List<string>();

			Console.WriteLine("Begin testing:");
			summary.Add("Begin testing:");

			Console.WriteLine();
			summary.Add("");

			Console.WriteLine("Parameters:");
			summary.Add("Parameters:");

			Console.WriteLine("MinNumber: " + MinNumber);
			summary.Add("MinNumber: " + MinNumber);

			Console.WriteLine("MaxNumber: " + MaxNumber);
			summary.Add("MaxNumber: " + MaxNumber);

			Console.WriteLine("Length of the array: " + arrayToSort.Length);
			summary.Add("Length of the array: " + arrayToSort.Length);

			Console.WriteLine();
			summary.Add("");

			Stopwatch st = new Stopwatch();

			Console.Write("Array to sort: ");
			summary.Add("Array to sort: ");

			foreach (var item in arrayToSort)
			{
				Console.Write(item + "; ");
				summary[summary.Count - 1] += item + "; ";
			}

			Console.WriteLine();
			summary.Add("");

			Console.WriteLine("Begin sorting using NeverSort...");
			summary.Add("Begin sorting using NeverSort...");


			st.Start();
			do
			{
				tmpArr = NeverSort(arrayToSort.Length);
				isSorted = IsSorted(arrayToSort, tmpArr);

			} while (!isSorted);

			st.Stop();

			Console.WriteLine();
			summary.Add("");

			Console.WriteLine("Array sorted");
			summary.Add("Array sorted");

			Console.WriteLine();
			summary.Add("");

			Console.WriteLine("It took {0} milliseconds. ({1} seconds)", st.ElapsedMilliseconds, (st.ElapsedMilliseconds - st.ElapsedMilliseconds % 1000) / 1000);
			summary.Add($"It took {st.ElapsedMilliseconds} milliseconds. ({st.ElapsedMilliseconds / 1000} seconds)");

			arrayToSort = tmpArr;

			Console.Write("Output: ");
			summary.Add("Output: ");

			foreach (var item in arrayToSort)
			{
				Console.Write(item + "; ");
				summary[summary.Count - 1] += item + "; ";
			}

			Console.WriteLine();
			summary.Add("");

			Console.WriteLine("End...");
			summary.Add("End...");

			System.IO.File.WriteAllLines("testSummary.txt", summary.ToArray());

			Console.ReadKey();
			Console.ReadLine();
		}
		static bool IsSorted(byte[] original, byte[] newArray)
		{
			if (original.Length != newArray.Length)
			{
				return false;
			}
			else
			{
				for (int i = 0; i < original.Length - 1; i++)
				{
					if (!original.Contains(newArray[i]) || newArray[i] >= newArray[i + 1])
					{
						return false;
					}
				}
				if (!original.Contains(newArray[newArray.Length - 1]))
				{
					return false;
				}
				return true;
			}
		}

		static byte[] NeverSort(int length)
		{
			Random r = new Random(); // if this is enabled, there might be repeating sequences of numbers, making the sorting slow
			byte[] ret = new byte[length];
			for (int i = 0; i < length; i++)
			{
				byte number;
				do
				{
					number = (byte)r.Next(MinNumber, MaxNumber);
				} while (ret.Contains(number));
				ret[i] = number;
			}
			return ret;
		}

	}
}
