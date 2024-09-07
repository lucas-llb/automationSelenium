using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationSelenium;

public class ExampleRobot
{
    private IWebDriver _driver;
    // Use your user data and profile to avoid authentication process
    private const string BrowserUserData = "C:\\Users\\lucas\\AppData\\Local\\Google\\Chrome\\User Data";
    public ExampleRobot()
    {
        var options = new ChromeOptions();
        options.AddArgument($"--user-data-dir={BrowserUserData}");
        options.AddArgument("--profile-directory=Profile 2");
        options.AddArgument("--remote-debugging-port=9292");
        _driver = new ChromeDriver(options);
    }

    public void TestWeb(string message, string user)
    {
        _driver.Navigate().GoToUrl("https://web.whatsapp.com/");
        
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        wait.Until(x => x.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[3]/div/div[3]/div[1]/div/div/div[1]/div/div")).Displayed == true);

        var elemenSearch = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[3]/div/div[1]/div/div[2]/div[2]/div/div/p"));
        elemenSearch.Click();
        elemenSearch.SendKeys(user);

        _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[3]/div/div[3]/div[1]/div/div/div[1]")).Click();

        var elementMessage = _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[4]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p"));
        elementMessage.Click();
        elementMessage.SendKeys(message);
        _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[4]/div/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span")).Click();
    }

}
