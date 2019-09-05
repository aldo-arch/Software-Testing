using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    [Binding]
    public class Forgot_your_password
    {
        static void Main(string[] args)
        {

            Forgot_your_password suggestion = new Forgot_your_password();
            suggestion.GivenIAccessedTheLogInFunctionalityInGoogle();
            suggestion.WhenIPressForgotPassword();
            suggestion.ThenIShouldSeeDifferentOptionsAboutHowICanRestoreItByClickingTheNextOne();
        }
        public ChromeDriver _driver;

        [Given(@"I accessed the log in functionality in Google")]
        public void GivenIAccessedTheLogInFunctionalityInGoogle()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?hl=sq&passive=true&continue=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dlets%2Bse%26oq%3Dlets%2Bse%26aqs%3Dchrome..69i57.1175j0j1%26sourceid%3Dchrome%26ie%3DUTF-8&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
        }

        [When(@"I press forgot password")]
        public void WhenIPressForgotPassword()
        {
            Thread.Sleep(3000);
            var inputEmail = _driver.FindElementByCssSelector("input[type='email']");
            inputEmail.SendKeys("bryantnix95@gmail.com");
            inputEmail.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            var forget = _driver.FindElementByXPath("//*[@id='forgotPassword']/content/span");
            forget.Click();
        }
     
        [Then(@"I should see 4 different options about how i can restore it by clicking the next one")]
        public void ThenIShouldSeeDifferentOptionsAboutHowICanRestoreItByClickingTheNextOne()
        {
            Thread.Sleep(3000);
            var choice1 = _driver.FindElementByXPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/content/span");
            choice1.Click();
            Thread.Sleep(2000);
            var choice2 = _driver.FindElementByXPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/content/span");
            choice2.Click();
            Thread.Sleep(2000);
            var choice3 = _driver.FindElementByXPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/content/span");
            choice3.Click();
            Thread.Sleep(2000);
            var choice4 = _driver.FindElementByXPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/content/span");
            choice4.Click();

        }
    }
}
