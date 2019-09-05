using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
namespace UnitTestProject1
{
    [Binding]
    public class Artist_YouTube_Mix
    {
        static void Main(string[] args)
        {
            Artist_YouTube_Mix the_mix = new Artist_YouTube_Mix();
            the_mix.GivenIAccessedYouTubeByChromeBrowser();
            the_mix.GivenISearchedAboutMyFavoriteArtist();
            the_mix.WhenISeeTheResultsIClickOnTheYouTubeMix();
            the_mix.ThenIListenToTheMix();
        }

        public ChromeDriver _driver;
        [Given(@"I accessed YouTube by Chrome browser")]
        public void GivenIAccessedYouTubeByChromeBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.youtube.com");
        }

        [Given(@"I searched about my favorite artist")]
        public void GivenISearchedAboutMyFavoriteArtist()
        {
            var searchbox = _driver.FindElement(By.Name("search_query"));
            searchbox.SendKeys("Europe");
            searchbox.SendKeys(Keys.Enter);
        }

        [When(@"I see the results i click on the YouTube mix")]
        public void WhenISeeTheResultsIClickOnTheYouTubeMix()
        {
            Thread.Sleep(2000);
            var mix = _driver.FindElementByXPath("//*[@id='section-left']");
            mix.Click();
            Thread.Sleep(3000);
        }

        [Then(@"I listen to the mix")]
        public void ThenIListenToTheMix()
        {
            Thread.Sleep(3000);
            int quality = 0;
            //Pozicionohemi tek albumet
            while (quality <= 6)
            {
                _driver.Keyboard.SendKeys(Keys.Tab);
                Thread.Sleep(1000);
                quality++;
                Thread.Sleep(1000);
            }
            _driver.Keyboard.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            _driver.Keyboard.SendKeys(Keys.Enter);
            int quality4 = 0;
            while (quality4 <= 4)
            {
                _driver.Keyboard.SendKeys(Keys.ArrowUp);
                Thread.Sleep(1000);
                quality4++;
                Thread.Sleep(1000);
            }
            _driver.Keyboard.SendKeys(Keys.Enter);

        }
    }
}
