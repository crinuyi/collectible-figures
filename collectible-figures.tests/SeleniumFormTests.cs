using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectible_figures.seleniumTests {
    [TestClass]
    public class SeleniumFormTests {
        private static string url = "http://localhost:50847/";
        private ChromeDriver chromeDriver;

        [TestInitialize]
        public void Initialize() {
            chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void Cleanup() {
            chromeDriver.Close();
            chromeDriver = null;
        }

        [TestMethod]
        [Obsolete]
        public void CheckRegisterAndLogin() {
            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 10));

            //registering the user
            chromeDriver.FindElementById("registerLink").Click();
            chromeDriver.FindElementById("Email").SendKeys("test@email.com");
            chromeDriver.FindElementById("UserName").SendKeys("testUser");
            chromeDriver.FindElementById("Password").SendKeys("SamplePassword#1");
            chromeDriver.FindElementById("ConfirmPassword").SendKeys("SamplePassword#1");
            IWebElement setRole = chromeDriver.FindElementById("UserRoles");
            SelectElement select = new SelectElement(setRole);
            select.SelectByText("Moderator");
            chromeDriver.FindElementByXPath("/html/body/div[2]/form/div[7]/div/input").Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div[1]/a")));
            chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/a").Click();

            //login
            chromeDriver.FindElementById("loginLink").Click();
            chromeDriver.FindElementById("UserName").SendKeys("testUser");
            chromeDriver.FindElementById("Password").SendKeys("SamplePassword#1");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"loginForm\"]/form/div[4]/div/input")));
            chromeDriver.FindElementByXPath("//*[@id=\"loginForm\"]/form/div[4]/div/input").Click();

            //checkout
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a")));
            String result = chromeDriver.FindElementByXPath("//*[@id=\"logoutForm\"]/ul/li[1]/a").Text;

            Assert.AreEqual("Witaj, testUser!", result);
        }

        [TestMethod]
        [Obsolete]
        public void DeleteSeries() {
            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 10));
            //registering the user
            chromeDriver.FindElementById("registerLink").Click();
            chromeDriver.FindElementById("Email").SendKeys("test@email.com");
            chromeDriver.FindElementById("UserName").SendKeys("testUser");
            chromeDriver.FindElementById("Password").SendKeys("SamplePassword#1");
            chromeDriver.FindElementById("ConfirmPassword").SendKeys("SamplePassword#1");
            IWebElement setRole = chromeDriver.FindElementById("UserRoles");
            SelectElement select = new SelectElement(setRole);
            select.SelectByText("Moderator");
            chromeDriver.FindElementByXPath("/html/body/div[2]/form/div[7]/div/input").Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div[1]/a")));
            chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/a").Click();

            //login
            chromeDriver.FindElementById("loginLink").Click();
            chromeDriver.FindElementById("UserName").SendKeys("testUser");
            chromeDriver.FindElementById("Password").SendKeys("SamplePassword#1");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"loginForm\"]/form/div[4]/div/input")));
            chromeDriver.FindElementByXPath("//*[@id=\"loginForm\"]/form/div[4]/div/input").Click();
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/a[3]").Click();
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/div/button").Click();

            //adding series to the database
            wait.Until(ExpectedConditions.ElementExists(By.Id("Name")));
            chromeDriver.FindElementById("Name").SendKeys("Puella Magi Madoka Magica");
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/form/div/div[2]/div/input").Click();

            //removing series from the database
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/table/tbody/tr[1]/td[2]/button[2]").Click();
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/div/form/div/input").Click();

            //checking if element exists
            IReadOnlyCollection<IWebElement> seriesList = chromeDriver.FindElementsByXPath("/html/body/div[2]/div/div[2]/table");
            bool result = false;
            foreach (IWebElement series in seriesList) {
                Console.WriteLine(series.Text);
                if (series.Text.Contains("Puella Magi Madoka Magica")) {
                    result = true;
                    break;
                }
            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        [Obsolete]
        public void AddSeries() {
            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 10));
            //registering the user
            chromeDriver.FindElementById("registerLink").Click();
            chromeDriver.FindElementById("Email").SendKeys("test@email.com");
            chromeDriver.FindElementById("UserName").SendKeys("testUser");
            chromeDriver.FindElementById("Password").SendKeys("SamplePassword#1");
            chromeDriver.FindElementById("ConfirmPassword").SendKeys("SamplePassword#1");
            IWebElement setRole = chromeDriver.FindElementById("UserRoles");
            SelectElement select = new SelectElement(setRole);
            select.SelectByText("Moderator");
            chromeDriver.FindElementByXPath("/html/body/div[2]/form/div[7]/div/input").Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div[1]/a")));
            chromeDriver.FindElementByXPath("/html/body/div[1]/div/div[1]/a").Click();

            //login
            chromeDriver.FindElementById("loginLink").Click();
            chromeDriver.FindElementById("UserName").SendKeys("testUser");
            chromeDriver.FindElementById("Password").SendKeys("SamplePassword#1");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"loginForm\"]/form/div[4]/div/input")));
            chromeDriver.FindElementByXPath("//*[@id=\"loginForm\"]/form/div[4]/div/input").Click();
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/a[3]").Click();
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/div/button").Click();

            //adding series to the database
            wait.Until(ExpectedConditions.ElementExists(By.Id("Name")));
            chromeDriver.FindElementById("Name").SendKeys("Puella Magi Madoka Magica");
            chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[2]/form/div/div[2]/div/input").Click();

            //checking if element exists
            IReadOnlyCollection<IWebElement> seriesList = chromeDriver.FindElementsByXPath("/html/body/div[2]/div/div[2]/table");
            bool result = false;
            foreach(IWebElement series in seriesList) {
                Console.WriteLine(series.Text);
                if (series.Text.Contains("Puella Magi Madoka Magica")) {
                    result = true;
                    break;
                }
            }

            Assert.IsTrue(result);
        }
    }
}
