using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using System;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\rafalkorzeniec\Desktop\ChromeDriver\");
            driver.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver.Manage().Window.Size = new System.Drawing.Size(700, 700);

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(30);
        }
        
        [Test]
        public void IoannesDlugossiusTest()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            IWebElement searchField = driver.FindElement(By.Id("searchInput"));
            string searchEntry = "D³ugosz";
            searchField.SendKeys(searchEntry);
            searchField.Submit();

            driver.FindElement(By.CssSelector("#mw-content-text > div.mw-parser-output > ul:nth-child(3) > li:nth-child(5) > a")).Click();

            driver.Navigate().Back();
            driver.Navigate().Forward();
            
            string entryURL = "https://pl.wikipedia.org/wiki/Jan_D%C5%82ugosz/";
            string expectedURL = "https://pl.wikipedia.org/wiki/Jan_D%C5%82ugosz/";
            Assert.AreEqual(entryURL, expectedURL, "URL is not correct."); 
        }
        
        [Test]
        public void IoannesDlugossiusTitleTest()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            IWebElement searchField = driver.FindElement(By.Id("searchInput"));
            string searchEntry = "D³ugosz";
            searchField.SendKeys(searchEntry);
            searchField.Submit();

            driver.FindElement(By.CssSelector("#mw-content-text > div.mw-parser-output > ul:nth-child(3) > li:nth-child(5) > a")).Click();
            
            //string title = driver.Title;
            //Console.WriteLine(title);

            
            string expectedTitleDlugossius = "Jan D³ugosz – Wikipedia, wolna encyklopedia";
            Assert.AreEqual(expectedTitleDlugossius, driver.Title, "Title is not correct."); 
        }
        
        [Test]
        public void EpiscopusCracoviensisTest()
        {
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/wiki/Jan_D%C5%82ugosz");

            driver.FindElement(By.CssSelector("#mw-content-text > div.mw-parser-output > p:nth-child(15) > a:nth-child(1)")).Click();

            string entryURL = "https://pl.wikipedia.org/wiki/Zbigniew_Ole%C5%9Bnicki_(kardyna%C5%82)/";
            string expectedURL = "https://pl.wikipedia.org/wiki/Zbigniew_Ole%C5%9Bnicki_(kardyna%C5%82)/";
            Assert.AreEqual(entryURL, expectedURL, "URL is not correct.");
        }
        
        [Test]
        public void WladislausJagielloTitleTest()
        {
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/wiki/Zbigniew_Ole%C5%9Bnicki_(kardyna%C5%82)");

            driver.FindElement(By.CssSelector(".mw-parser-output > p:nth-child(4) > a:nth-child(12)")).Click();

            string expectedTitleWladislaus = "W³adys³aw II Jagie³³o – Wikipedia, wolna encyklopedia";
            Assert.AreEqual(expectedTitleWladislaus, driver.Title, "Title is not correct");


        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}