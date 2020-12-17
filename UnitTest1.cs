using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DHPracticeTest
{
    public class Tests : System.IDisposable
    {
        string test1URL = "http://automationpractice.com/index.php";
        string test2URL = "https://reqres.in/api/users?page=2";

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = test1URL;

            System.Threading.Thread.Sleep(2000);

            IWebElement signInButton = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));
            signInButton.Click();
            System.Threading.Thread.Sleep(2000);


            IWebElement emailBox = driver.FindElement(By.Name("email"));
            emailBox.SendKeys("realrulo@gmail.com");
            System.Threading.Thread.Sleep(1000);

            IWebElement pwdBox = driver.FindElement(By.XPath("//*[@id='passwd']"));
            pwdBox.SendKeys("test123");
            System.Threading.Thread.Sleep(1000);

            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='SubmitLogin']"));
            loginButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement womenTab = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[6]/ul/li[1]/a"));
            womenTab.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement productImage = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[1]/div/a[1]/img"));
            productImage.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement addToCartButton = driver.FindElement(By.XPath("//*[@id='add_to_cart']"));
            addToCartButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement proceedCheckoutButton = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a"));
            proceedCheckoutButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement summaryCheckoutButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/p[2]/a[1]"));
            summaryCheckoutButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement addressCheckoutButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button"));
            addressCheckoutButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement termsOfServiceBox = driver.FindElement(By.XPath("//*[@id='cgv']"));
            termsOfServiceBox.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement shippingCheckoutButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/p/button"));
            shippingCheckoutButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement payByBankwire = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[3]/div[1]/div/p/a"));
            payByBankwire.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement confirmOrderButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button"));
            confirmOrderButton.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement confirmationMessage = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/p/strong"));
            string expectedMessage = "Your order on My Store is complete.";

            Assert.AreEqual(confirmationMessage.Text, expectedMessage);

        }

        [Test]
        public void Test2()
        {
            HttpRequestUtility httpRequestUtility = new HttpRequestUtility();
            string usersList = httpRequestUtility.GetRequest(test2URL);

            bool emailIsFound = false;

            if (usersList.Contains("michael.lawson@reqres.in"))
            {
                emailIsFound = true;
            }

            Assert.IsTrue(emailIsFound);

        }

        class HttpRequestUtility
        {
            public string GetRequest(String uri)
            {
                string response = "";

                //Create a HTTP Web Request Instance
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                
                httpWebRequest.Method = "GET";
                httpWebRequest.MaximumAutomaticRedirections = 3;
                httpWebRequest.Timeout = 10000;
                
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseStream = httpWebResponse.GetResponseStream();
                
                if (responseStream != null)
                {
                    var streamReader = new StreamReader(responseStream);
                    response = streamReader.ReadToEnd().ToString();
                }
                
                if (responseStream != null) responseStream.Close();

                return response;
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }

}