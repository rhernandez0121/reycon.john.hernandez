using OpenQA.Selenium;

namespace PageModel.WebApp
{
	public class ShopPage : Base
	{
		
		private By teddyBuyBtn = By.XPath("//*[@id='product-1']//a[contains(@class, 'btn-success')]");
		private By frogBuyBtn = By.XPath("//*[@id='product-2']//a[contains(@class, 'btn-success')]");
		private By dollBuyBtn = By.XPath("//*[@id='product-3']//a[contains(@class, 'btn-success')]");
		private By bunnyBuyBtn = By.XPath("//*[@id='product-4']//a[contains(@class, 'btn-success')]");
		private By bearBuyBtn = By.XPath("//*[@id='product-5']//a[contains(@class, 'btn-success')]");
		private By cowBuyBtn = By.XPath("//*[@id='product-6']//a[contains(@class, 'btn-success')]");
		private By valentineyBuyBtn = By.XPath("//*[@id='product-7']//a[contains(@class, 'btn-success')]");
		private By smileyBuyBtn = By.XPath("//*[@id='product-8']//a[contains(@class, 'btn-success')]");

		public ShopPage()
		{ 
		}

		public void ClickBuyTeddyBear(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(teddyBuyBtn).Click();
			}
		}

		public void ClickBuyStuffedFrog(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(frogBuyBtn).Click();
			}	
		}

		public void ClickBuyHandMadeDoll(int count)
		{
			driver.FindElement(dollBuyBtn).Click();
		}

		public void ClickBuyFluffyBunny(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(bunnyBuyBtn).Click();
			}
		}

		public void ClickBuySmileyBear(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(bearBuyBtn).Click();
			}
		}

		public void ClickBuyFunnyCow(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(cowBuyBtn).Click();
			}
		}

		public void ClickBuyValentineBear(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(valentineyBuyBtn).Click();
			}
		}
		public void ClickBuySmileyFace(int count)
		{
			for (int x = 1; x <= count; x++)
			{
				driver.FindElement(smileyBuyBtn).Click();
			}
		}
		
	}
}
