using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace collectible_figures.tests {
    [TestClass]
    public class MainPageTests {
        private static string url = "http://localhost:50847/";
        private static ChromeDriver chromeDriver;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext) {
            chromeDriver = new ChromeDriver();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup() {
            chromeDriver.Close();
            chromeDriver.Dispose();
        }

        [TestInitialize]
        public void Initialize() {
            chromeDriver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void Cleanup() {
            
        }

        [TestMethod]
        public void CheckTitle() {
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
    }
}
