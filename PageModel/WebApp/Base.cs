using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace PageModel.WebApp
{
	public abstract class Base
	{
		public static List<ItemList> itemsRecord;

		public double[] priceList = { 9.99, 10.99, 12.99, 14.99 };

		public static IWebDriver driver;

		public void Wait()
		{
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
		}

		public void InventoryItems()
		{
			itemsRecord = new List<ItemList>();
			
			itemsRecord.Add(new ItemList { ItemName = " Teddy Bear", Price = 12.99 });
			itemsRecord.Add(new ItemList { ItemName = " Stuffed Frog", Price = 10.99 });
			itemsRecord.Add(new ItemList { ItemName = " Handmade Doll", Price = 10.99 });
			itemsRecord.Add(new ItemList { ItemName = " Fluffy Bunny", Price = 9.99 });
			itemsRecord.Add(new ItemList { ItemName = " Smiley Bear", Price = 14.99 });
			itemsRecord.Add(new ItemList { ItemName = " Funny Cow", Price = 10.99 });
			itemsRecord.Add(new ItemList { ItemName = " Valentine Bear", Price = 14.99 });
			itemsRecord.Add(new ItemList { ItemName = " Smiley Face", Price = 9.99 });
		}
	}
}
