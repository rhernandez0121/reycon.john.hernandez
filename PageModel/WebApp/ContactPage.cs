using OpenQA.Selenium;

namespace PageModel.WebApp
{
	public class ContactPage : Base
	{

		private By submitButton = By.XPath("//a[contains(@class, 'btn-primary')]");
		private By foreNameField = By.Id("forename");
		private By surNameField = By.Id("surname");
		private By emailField = By.Id("email");
		private By telephoneField = By.Id("telephone");
		private By messageField = By.Id("message");

		private By headerCompleted = By.XPath("//*[contains(@class, 'alert-info')]");
		private By headerError = By.XPath("//*[contains(@class, 'alert-error')]");
		private By headerSuccess = By.XPath("//*[contains(@class, 'alert-success')]");
		private By foreNameRequired = By.XPath("//*[text()='Forename is required']");
		private By messageRequired = By.XPath("//*[text()='Message is required']");
		private By emailRequired = By.XPath("//*[text()='Email is required']");

		public bool a = true;

		public ContactPage()
		{ 
		}

		public bool VerifyHeadErrorIsDisplayed()
		{
			return driver.FindElement(headerError).Displayed;
		}

		public bool VerifyForeNameRequiredIsDisplayed()
		{
			return driver.FindElements(foreNameRequired).Count != 0;
		}

		public bool VerifyMessageRequiredIsDisplayed()
		{
			return driver.FindElements(messageRequired).Count != 0;
		}

		public bool VerifyEmailRequiredIsDisplayed()
		{
			return driver.FindElements(emailRequired).Count != 0;
		}

		public bool VerifyHeaderGreenIsDisplayed()
		{
			return driver.FindElement(headerCompleted).Displayed;
		}

		public bool VerifyHeaderSuccessIsDisplayed()
		{
			Wait();
			return driver.FindElement(headerSuccess).Displayed;
		}

		public void ClickSubmitButton()
		{
			Wait();
			driver.FindElement(submitButton).Click();
		}

		public void EnterForeName(string name)
		{
			driver.FindElement(foreNameField).SendKeys(name);
		}

		public void EnterEmail(string email)
		{
			driver.FindElement(emailField).SendKeys(email);
		}

		public void EnterMessage(string message)
		{
			driver.FindElement(messageField).SendKeys(message);
		}

		public void PopulateMandatoryFields(string name, string email, string message)
		{
			Wait();
			EnterForeName(name);
			EnterEmail(email);
			EnterMessage(message);
		}
	}
}
