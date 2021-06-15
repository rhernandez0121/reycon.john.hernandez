using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PageModel.WebApp
{
	public class HomePage : Base
	{
		private By contactButton = By.Id("nav-contact");
		private By shopButton = By.Id("nav-shop");
		private By cartButton = By.Id("nav-cart");

		public HomePage()
		{ 
		}

		public ContactPage ClickContactButton()
		{
			Wait();
			driver.FindElement(contactButton).Click();
			return new ContactPage();
		}

		public ShopPage ClickShopButton()
		{
			Wait();
			driver.FindElement(shopButton).Click();
			return new ShopPage();
		}

		public CartPage ClickCartButton()
		{
			Wait();
			driver.FindElement(cartButton).Click();
			return new CartPage();
		}

		public void OpenApplication()
		{
			var options = new ChromeOptions();
			options.AddArguments("--start-maximized");
			driver = new ChromeDriver(options);
			driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
			Wait();
		}
	}
}
