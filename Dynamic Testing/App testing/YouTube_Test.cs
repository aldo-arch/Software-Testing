using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomatedTests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService(@"C:\Users\user\Desktop\pytest\chrome driver");
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications");
                ChromeDriver driver = new ChromeDriver(driverService, options);
                //Aplikacioni që do të testojmë - YouTube
                driver.Url = "https://www.youtube.com/";
                Thread.Sleep(3000);
                var Atags = driver.FindElementsByCssSelector("a[href *= 'https://accounts.google.com/ServiceLogin?']");
                if (Atags.Count() != 0)
                {
                    Atags.Where(c => c.Text.Contains("SIGN")).First().Click();
                }
                //Aksesimi i llogarisë sonë
                var inputEmail = driver.FindElementByCssSelector("input[type='email']");
                inputEmail.SendKeys("yourmail@gmail.com");
                inputEmail.SendKeys(Keys.Return);
                
                //Duhet të presim
                Thread.Sleep(3000);
                var inputPassword = driver.FindElementByCssSelector("input[type='password']");
                inputPassword.SendKeys("yourpass");
                inputPassword.SendKeys(Keys.Return);

                var spans = driver.FindElementsByTagName("span");
                var donespan = spans.Where(c => c.Text.Contains("DONE"));
                if (donespan.Count() != 0)
                {
                    //Nëse duhet verifikimi
                    donespan.First().Click();
                }
                Thread.Sleep(6000);
                //Kërkojmë për grupin Queen
                var search = driver.FindElementById("search");
                search.Click();
                search.SendKeys("Queen");
                search.SendKeys(Keys.Enter);
                Thread.Sleep(3000);
                //Në rezultatet që na afishohen interesohemi për videon (këngën) Bohemian Rhapsody
                var videos = driver.FindElementsByTagName("h3");
                var episode1 = videos.Where(c => c.Text.Contains("Bohemian Rhapsody"));
                if (episode1.Count() != 0)
                {
                    episode1.FirstOrDefault().Click();
                }
                //Nëse nuk e gjejmë elementin, ne e kërkojmë atë
                else
                {
                    search.Click();
                    Thread.Sleep(3000);
                    search.SendKeys(" Bohemian Rhapsody" + Keys.Enter);
                    episode1 = driver.FindElementsByTagName("h3").Where(c => c.Text.Contains("Bohemian Rhapsody"));
                    if (episode1.Count() != 0)
                    {
                        episode1.FirstOrDefault().Click();
                    }
                }
                //Klikojmë videon
                Thread.Sleep(3000);
                //Butoni like
                var likeButton = driver.FindElementByCssSelector("button[aria-label*='like']");
                likeButton.Click();
                //Aksesimi i elementëve të videos duke u bazuar në tastat (komandat) përkatëse
                //Aktivizimi/shfaqja e titrrave
                var cc = driver.FindElementByCssSelector("button[title='Subtitles/closed captions (c)']");
                //Aktivizimi i Theater Mode
                var t = driver.FindElementByCssSelector("button[title='Theater mode (t)']");
                t.Click();
                Thread.Sleep(3000);
                cc.Click();
                int volumedown = 0;
                //Ndryshimi i volumit
                while (volumedown <= 3)
                {
                    driver.Keyboard.SendKeys(Keys.ArrowDown);
                    volumedown++;
                }
                Thread.Sleep(3000);
                int seekright = 0;
                //Avancimi përpara në video bazuar në klikimet tona nga tastiera
                while (seekright <= 7)
                {
                    driver.Keyboard.SendKeys(Keys.ArrowRight);
                    seekright++;
                }
                //Play/pause bazuar në tastin 'Spacebar'
                driver.Keyboard.SendKeys(Keys.Space);
                Thread.Sleep(3000);
                t.Click();
                Thread.Sleep(3000);
                //Scroll nëpërmjet tastave 'arrow' për tu pozicionuar tek komenti
                int counter = 0;
                while (counter <= 15)
                {
                    driver.Keyboard.SendKeys(Keys.ArrowDown);
                    counter++;
                }
                Thread.Sleep(3000);
                //Pasi pozicionohemi realizojmë komentimin
                var comment = driver.FindElementById("simplebox-placeholder");
                comment.Click();
                var box = driver.FindElementById("contenteditable-textarea");
                box.SendKeys("Grupi G3 - MTS1819");
                Thread.Sleep(3000);
                var commentButton = driver.FindElementByCssSelector("paper-button[aria-label*='Comment']");
                commentButton.Click();
                Thread.Sleep(5000);
                while (counter != 3)
                {
                    driver.Keyboard.SendKeys(Keys.ArrowUp);
                    counter--;
                }
                //Aksesojmë profilin përkatës
                Thread.Sleep(3000);
                var profile = driver.FindElementByXPath("//*[@id='owner-name']/a");
                profile.Click();
                Thread.Sleep(3000);
                //Butoni 'Subscribe'
                //var subscribe = driver.FindElementByCssSelector("paper-button[aria-label='Subscribe to Queen Official.']");
                //subscribe.Click();
                //Thread.Sleep(5000);
                var avatar = driver.FindElementById("avatar-btn");
                avatar.Click();
                Thread.Sleep(3000);
                //Log out
                var labels = driver.FindElementsById("label");
                var signout=labels.Where(c => c.Text.Contains("Sign out"));
                if(signout.Count()!=0)
                {
                    signout.First().Click();
                }
           
                Thread.Sleep(3000);
                driver.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Ndodhi një gabim. Errori:" + ex.Message);
            }
        }
    }
}
