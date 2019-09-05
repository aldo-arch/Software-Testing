using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;

namespace Youtube_Suggestion_nr_3
{
    [Binding]
    public class Youtube_Suggestion_nr_3
    {
        static void Main(string[] args)
        {

            Youtube_Suggestion_nr_3 nr3 = new Youtube_Suggestion_nr_3();
            nr3.GivenIJustAccessedTheYouTubePageOnGoogleChrome();
            nr3.WhenTheSuggestionsAreAvailable();
            nr3.ThenIJustClickTheThirdSuggestionNoMatterWhat();

        }

        public ChromeDriver _driver;

        [Given(@"I just accessed the YouTube page on Google Chrome")]
        public void GivenIJustAccessedTheYouTubePageOnGoogleChrome()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.youtube.com");
        }
        
        [When(@"The suggestions are available")]
        public void WhenTheSuggestionsAreAvailable()
        {
            var searchbox = _driver.FindElement(By.Name("search_query"));
            searchbox.SendKeys("mr bean");
            searchbox.SendKeys(Keys.ArrowDown);
            
            searchbox.SendKeys(Keys.ArrowDown);
          
            searchbox.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            searchbox.SendKeys(Keys.Enter);
            
        }
        
        [Then(@"I just clicked the third suggestion \(no matter what\)")]
        public void ThenIJustClickTheThirdSuggestionNoMatterWhat()
        {
            Thread.Sleep(2000);
            int scrolldown = 0;
            while (scrolldown <= 10)
            {
                _driver.Keyboard.SendKeys(Keys.ArrowDown);
                scrolldown++;
            }
            
        }
    }
}
