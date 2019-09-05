using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Text;

namespace YouTube_Wrong_Password_Sign_In
{
    [Binding]
    public class YouTube_Wrong_Password_Sign_In
    {
        static void Main(string[] args)
        {

            YouTube_Wrong_Password_Sign_In inputs = new YouTube_Wrong_Password_Sign_In();
            inputs.GivenIJustAccessedYouTubeFromGoogleChrome();
            inputs.GivenIWantToAccessMyAccount();
            inputs.WhenIFillTheFormsWithTheWrongInformation();
            inputs.ThenIWontBeAbleToContinueToTheNextFields();
        }
        public ChromeDriver _driver;

        [Given(@"I just accessed YouTube from Google Chrome")]
        public void GivenIJustAccessedYouTubeFromGoogleChrome()
        {
                _driver = new ChromeDriver();
                _driver.Navigate().GoToUrl("https://www.youtube.com");
        }
        
        [Given(@"I want to access my account")]
        public void GivenIWantToAccessMyAccount()
        {
            Thread.Sleep(3000);
            var Atags = _driver.FindElementsByCssSelector("a[href *= 'https://accounts.google.com/ServiceLogin?']");
            if (Atags.Count() != 0)
            {
                Atags.Where(c => c.Text.Contains("SIGN")).First().Click();
            }
        }
        
        [When(@"I fill the forms with the wrong information")]
        public void WhenIFillTheFormsWithTheWrongInformation()
        {
            Thread.Sleep(3000);
            var inputEmail = _driver.FindElementByCssSelector("input[type='email']");
            inputEmail.SendKeys("your_email");
            inputEmail.SendKeys(Keys.Enter);
        }

        [Then(@"i wont be able to continue to the next fields")]
        public void ThenIWontBeAbleToContinueToTheNextFields()
        {
            //Duhet të presim
            Thread.Sleep(3000);
            var inputPassword = _driver.FindElementByCssSelector("input[type='password']");
            inputPassword.SendKeys("yourpass");
            inputPassword.SendKeys(Keys.Enter);
        }
    }
}
