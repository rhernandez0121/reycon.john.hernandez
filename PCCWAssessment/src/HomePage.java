import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

public class HomePage {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		WebDriver driver = new ChromeDriver();
		
		System.setProperty("webdriver.chrome.driver", "\\/PCCWAssessment/driver/chromedriver.exe");
		
		//Launch the website
		driver.get("https://practicetestautomation.com/practice-test-login");
		driver.manage().window().maximize();
		//WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));

		//set webelements for username, password, and submit button
		WebElement userNameField = driver.findElement(By.id("username"));
		WebElement passwordField = driver.findElement(By.id("password"));
		WebElement submitButton = driver.findElement(By.id("submit"));
		
		//enter student and Password123 as credentials
		userNameField.sendKeys("student");
		passwordField.sendKeys("Password123");
		submitButton.click();
		
		//webelement to verify if user successfully logged in
		WebElement home = driver.findElement(By.xpath("//*[text()='Logged In Successfully']"));
		
		try
		{
			if(home.isDisplayed()) {
			System.out.println("Congratulations!");
			driver.quit();
			}
		}catch(Exception e) {
			System.out.println("FAILED");
		}
	}
}
