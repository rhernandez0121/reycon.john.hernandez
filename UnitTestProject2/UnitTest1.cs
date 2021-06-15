using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel.WebApp;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1 : Base
	{
		[TestMethod]
		public void TestCase1()
		{
			HomePage home = new HomePage();
			home.OpenApplication();
			ContactPage contact = home.ClickContactButton();
			contact.ClickSubmitButton();
			Assert.IsTrue(contact.VerifyForeNameRequiredIsDisplayed());
			Assert.IsTrue(contact.VerifyEmailRequiredIsDisplayed());
			Assert.IsTrue(contact.VerifyMessageRequiredIsDisplayed());
			Assert.IsTrue(contact.VerifyHeadErrorIsDisplayed());
			contact.PopulateMandatoryFields("Reycon John Hernandez", "hernandez.reycon@gmail.com", "This is my test!");
			Assert.IsFalse(contact.VerifyForeNameRequiredIsDisplayed());
			Assert.IsFalse(contact.VerifyEmailRequiredIsDisplayed());
			Assert.IsFalse(contact.VerifyMessageRequiredIsDisplayed());
			Assert.IsTrue(contact.VerifyHeaderGreenIsDisplayed());
		}

		[TestMethod]
		public void TestCase2()
		{
			HomePage home = new HomePage();
			home.OpenApplication();
			ContactPage contact = home.ClickContactButton();
			contact.PopulateMandatoryFields("Reycon John Hernandez", "hernandez.reycon@gmail.com", "This is my test!");
			contact.ClickSubmitButton();
			Assert.IsTrue(contact.VerifyHeaderSuccessIsDisplayed());
		}

		[TestMethod]
		public void TestCase3()
		{
			HomePage home = new HomePage();
			home.OpenApplication();
			ShopPage shop = home.ClickShopButton();
			shop.ClickBuyFunnyCow(2);
			shop.ClickBuyFluffyBunny(1);
			CartPage cart = home.ClickCartButton();
			shop.InventoryItems();
			Assert.IsTrue(cart.VerifyOrderIsCorrect(" Funny Cow; Fluffy Bunny", "2;1"));
		}

		[TestMethod]
		public void TestCase4()
		{
			HomePage home = new HomePage();
			home.OpenApplication();
			ShopPage shop = home.ClickShopButton();
			shop.ClickBuyStuffedFrog(2);
			shop.ClickBuyFluffyBunny(5);
			shop.ClickBuyValentineBear(3);
			CartPage cart = home.ClickCartButton();
			shop.InventoryItems();
			Assert.IsTrue(cart.VerifyOrderIsCorrect(" Stuffed Frog; Fluffy Bunny; Valentine Bear", "2;5;3"));
			Assert.IsTrue(cart.VerifyTotalAmountIsCorrect());
		}

		[TestCleanup]
		public void TestCleanup()
		{
			driver.Close();
			driver.Quit();
		}
	}
}
