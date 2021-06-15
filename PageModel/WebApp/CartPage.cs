using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageModel.WebApp
{
	public class CartPage : Base
	{
		List<double> amountList = new List<double>();
		private By itemRecord = By.XPath("//*[contains(@ng-repeat, 'cart.item')]");
		private string itemColumn = "//*[contains(@ng-repeat, 'cart.item')][{0}]//td[1]";
		private string quantityColumn = "//*[contains(@ng-repeat, 'cart.item')][{0}]/td[3]/input";
		private string priceColumn = "//*[contains(@ng-repeat, 'cart.item')][{0}]/td[2]";
		private string subTotalColumn = "//*[contains(@ng-repeat, 'cart.item')][{0}]/td[4]";
		private  By totalValue = By.XPath("//tfoot//tr[1]");
		List<String> itemDisplayed = new List<String>();
		List<String> countDisplayed = new List<String>();
		bool isFound = true;

		public CartPage()
		{ 
		}

		public bool VerifyItemsDisplayedCorrectly(string items, string itemCount)
		{
			Wait();
			bool isFound = true;
			int records = driver.FindElements(itemRecord).Count;


			for (int x = 1; x <= records; x++)
			{
				string itemNameSelector = string.Format(itemColumn, x);
				string itemCountSelector = string.Format(quantityColumn, x);
				string itemNameValue = driver.FindElement(By.XPath(itemNameSelector)).GetAttribute("textContent");
				string itemCountValue = driver.FindElement(By.XPath(itemCountSelector)).GetAttribute("value");

				itemDisplayed.Add(itemNameValue);
				countDisplayed.Add(itemCountValue);
			}

			string[] itemsAdded = items.Split(';');

			while(isFound)
			{
				foreach (string word in itemsAdded)
				{
					isFound = itemDisplayed.Contains(word);

					if (!isFound)
					{
						break;
					}
				}
				break;
			}
			
			string[] countAdded = itemCount.Split(';');
			while (isFound)
			{
				foreach (string num in countAdded)
				{
					isFound = countDisplayed.Contains(num);
					if (!isFound)
					{
						break;
					}
				}
				break;
			}
			
			return isFound;

		}

		public bool VerifyOrderIsCorrect(string item, string itemCount)
		{
			Wait();
			int records = driver.FindElements(itemRecord).Count;
			string[] itemOrdered = item.Split(';');
			string[] countPerItem = itemCount.Split(';');
			
			for (int x = 1; x <= records; x++)
			{
				string itemNameSelector = string.Format(itemColumn, x);
				string itemCountSelector = string.Format(quantityColumn, x);
				string itemPriceSelector = string.Format(priceColumn, x);
				string itemSubTotalSelector = string.Format(subTotalColumn, x);
				string itemNameValue = driver.FindElement(By.XPath(itemNameSelector)).GetAttribute("textContent");
				string itemCountValue = driver.FindElement(By.XPath(itemCountSelector)).GetAttribute("value");
				string itemPriceValue = driver.FindElement(By.XPath(itemPriceSelector)).GetAttribute("textContent");
				string itemSubTotalValue = driver.FindElement(By.XPath(itemSubTotalSelector)).GetAttribute("textContent");
				
				var price = from s in itemsRecord where s.ItemName.Equals(itemNameValue) select s.Price;
				var priceString = string.Join(",", price.ToArray());
				var priceInt = price.FirstOrDefault();
				var subTotal = Convert.ToInt32(itemCountValue) * priceInt;

				//this will verify if the item ordered is in the cart
				if (!(itemNameValue == itemOrdered[x - 1]))
				{
					isFound = false;
					break;
				}

				//this will verify if the item count ordered is correct in the cart
				if (!(itemCountValue == countPerItem[x - 1]))
				{
					isFound = false;
					break;
				}

				//this will verify if the price for each product is correct in the cart
				if (!(itemPriceValue.Contains(priceString)))
				{
					isFound = false;
					break;
				}

				//this will verify if the subtotal for each product is correct in the cart
				if (!(itemSubTotalValue.Contains(subTotal.ToString())))
				{
					isFound = false;
				}
				amountList.Add(subTotal);
			}
			return isFound;
		}

		public bool VerifyTotalAmountIsCorrect()
		{
			string itemTotalValue = driver.FindElement(totalValue).GetAttribute("outerText");
			double total = amountList.Sum();

			if (itemTotalValue.Contains(total.ToString()))
			{
				isFound = true;
			}
			else { return isFound = false; }
			return isFound;
		}
	}
}
