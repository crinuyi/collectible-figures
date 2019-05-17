using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace collectible_figures.tests {
    [TestClass]
    public class SeleniumContentTests {
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
        public void CheckTitleOfMainPage() {
            Assert.AreEqual("Strona główna — Baza danych kolekcjonerskich figurek", chromeDriver.Title);
        }

        [TestMethod]
        public void CountAllLinks() {
            IList<IWebElement> links = chromeDriver.FindElementsByTagName("a");

            int result = 0;
            foreach (IWebElement link in links)
                result++;

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void CheckIfLinksAreNotBroken() {
            IList<IWebElement> links = chromeDriver.FindElementsByTagName("a");
            bool result = true;

            foreach (IWebElement link in links) {
                String url = link.GetAttribute("href");
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.AllowAutoRedirect = true;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if(httpWebResponse.StatusCode == HttpStatusCode.OK) {
                    httpWebResponse.Close();
                }
                else {
                    result = false;
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfTextAppearedAfterTryingToLogin() {
            IWebElement loginButton = chromeDriver.FindElementById("loginLink");
            loginButton.Click();
            IWebElement loginField = chromeDriver.FindElementById("UserName");
            loginField.SendKeys("someUser");
            IWebElement passwordField = chromeDriver.FindElementById("Password");
            passwordField.SendKeys("somepassword");
            passwordField.SendKeys(Keys.Enter);

            String result = chromeDriver.FindElementByXPath("//*[@id=\"loginForm\"]/form/div[1]/ul/li").Text;

            Assert.AreEqual("Nieprawidłowa próba logowania.", result);
        }

        [TestMethod]
        [Obsolete]
        public void CheckIfButtonIsClickable() {
            IWebElement button = chromeDriver.FindElementByXPath("/html/body/div[2]/div/div[1]/div/button");
            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 10));
            bool result;

            try {
                wait.Until(ExpectedConditions.ElementToBeClickable(button));
                result = true;
            } catch (Exception e) {
                result = false;
            }

            Assert.IsTrue(result);
        }
    }
}
