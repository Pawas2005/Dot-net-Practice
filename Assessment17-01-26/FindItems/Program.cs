using System;
using System.Collections.Generic;
using System.Linq;

namespace FindItems
{
	public class Program
	{
		public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();
		
		public static SortedDictionary<string, long> FindItemDetails(long soldCount)
		{
			SortedDictionary<string, long> result = new SortedDictionary<string, long>();
			
			foreach(var item in itemDetails)
			{
				if(item.Value == soldCount)
				{
					result.Add(item.Key, item.Value);
				}
			}	
			return result;
		}
		
		public static List<string> FindMinAndMaxSoldItem(){
			List<string> result = new List<string>();
			
			long mini = long.MaxValue;
			long maxi = long.MinValue;
			
			string minItem = "";
			string maxItem = "";
			
			foreach(var item in itemDetails){
				if(item.Value < mini){
					mini = item.Value;
					minItem = item.Key;
				}
				
				if(item.Value > maxi) {
					maxi = item.Value;
					maxItem = item.Key;
				}
			}
			
			result.Add(minItem);
			result.Add(maxItem);	
				
			return result;
		}
		
		public static Dictionary<string, long> SortByCount(){
			Dictionary<string, long> result = new Dictionary<string, long>();
			
			foreach(var item in itemDetails.OrderBy(x => x.Value)) {
				result.Add(item.Key, item.Value);
			}
			return result;
		}
		
		public static void Main()
		{
			Console.Write("Enter the number of items u want to add : ");
			int n = int.Parse(Console.ReadLine());
			
			for(int i = 0; i < n; i++)
			{
				Console.Write("Enter item name : ");
				string name = Console.ReadLine();
				
				Console.Write("Enter the sold count : ");
				long soldCount = long.Parse(Console.ReadLine());
				
				itemDetails.Add(name, soldCount);
			}
			
			//1.
			Console.Write("\nEnter the sold count to search : ");
			long searchCnt = long.Parse(Console.ReadLine());
			
			var items = FindItemDetails(searchCnt);
			if(items.Count == 0)
			{
				Console.WriteLine("Invalid sold count");
			}
			else
			{
				foreach(var item in items)
				{
					Console.WriteLine(item.Key + "----" + item.Value);
				}
			}
			
			//2.
			var MinAndMax = FindMinAndMaxSoldItem();
			if(MinAndMax.Count == 2)
			{
				Console.WriteLine("\nMinimum Sold Item : " + MinAndMax[0]);
				Console.WriteLine("Maximum Sold Item : " + MinAndMax[1]);
			}
			
			//3.
			var sorted = SortByCount();
			Console.WriteLine("\nItems sorted by sold Count : ");
			foreach(var item in sorted)
			{
				Console.WriteLine(item.Key + " --> " + item.Value);
			}
		}
	}
}
	