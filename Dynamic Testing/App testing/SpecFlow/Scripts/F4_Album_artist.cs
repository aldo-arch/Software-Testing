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
    public class Album_artist
    {
        static void Main(string[] args)
        {
            Album_artist album = new Album_artist();
            album.GivenIJustAccessedYouTubeByGoogleChromeBrowser();
            album.GivenISearchAboutMyFavoriteArtist();
            album.WhenISeeTheResultsICheckTheirAlbums();
            album.ThenIPlayOneOfTheirAlbums();
        }
        public ChromeDriver _driver;
        [Given(@"I just accessed YouTube by Google Chrome browser")]
        public void GivenIJustAccessedYouTubeByGoogleChromeBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.youtube.com");
        }
        
        [Given(@"I search about my favorite artist")]
        public void GivenISearchAboutMyFavoriteArtist()
        {
            var search = _driver.FindElementById("search");
            search.Click();
            search.SendKeys("AC-DC");
            search.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            int scrolldown = 0;
            //Pozicionohemi tek albumet
            while (scrolldown <= 17)
            {
                _driver.Keyboard.SendKeys(Keys.ArrowDown);
                scrolldown++;
            }
        }
        
        [When(@"I see the results,i check their albums")]
        public void WhenISeeTheResultsICheckTheirAlbums()
        {
            Thread.Sleep(3000);
            var next_button = _driver.FindElementByXPath("//*[@id='right-arrow']/yt-icon");
            Thread.Sleep(3000);
            next_button.Click();
            Thread.Sleep(2000);
            next_button.Click();
            Thread.Sleep(3000);
            var prev_button = _driver.FindElementByXPath("//*[@id='left-arrow']/yt-icon");
            Thread.Sleep(3000);
            prev_button.Click();
            Thread.Sleep(2000);
            prev_button.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I play one of their albums")]
        public void ThenIPlayOneOfTheirAlbums()
        {
            var first_album = _driver.FindElementByXPath(" //*[@id='card-title']/div");
            first_album.Click();
            Thread.Sleep(2000);
        }
    }
}
