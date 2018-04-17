using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using log4net;
using NUnit.Framework.Interfaces;
using TestGmail.Helpers;


namespace TestGmail
{
    [TestFixture]
    public partial class gMail
    {

        private IWebDriver webDriver;
        private string browser = "Mozilla";
        private static readonly string baseUrl = "https://accounts.google.com/";
        private Stopwatch timeTest = new Stopwatch();

        [OneTimeSetUp]
        public void BeforeTests()
        {
            switch (browser)
            {
                case "Mozilla":
                    var firefoxProfile = new FirefoxProfile
                    {
                        AcceptUntrustedCertificates = true,
                        EnableNativeEvents = true
                    };
                    webDriver = new FirefoxDriver(firefoxProfile);
                    break;

                case "Chrome":
                    ChromeOptions cOptions = new ChromeOptions();
                    cOptions.AddArguments("disable-infobars");
                    cOptions.AddArgument("--incognito");
                    webDriver = new ChromeDriver(cOptions);
                    break;

                default:
                    Log.Error("The browser was not specified in the app.config.");
                    break;

            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        [SetUp]
        public void BeforeEachTest()
        {
            //Logging the execution of the test
            timeTest.Reset();
            timeTest.Start();
            Log.Info("Start test {0}.", TestContext.CurrentContext.Test.FullName);
            webDriver.Navigate().GoToUrl(baseUrl);
        }




        [TearDown]
        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed && webDriver != null)
            {
                Log.Info("Test {0} failed.", TestContext.CurrentContext.Test.FullName);
                //Take snapshot
                ScreenShots.SaveScreenshotAllPage(webDriver, TestContext.CurrentContext.Test.Name.Replace("\"", "") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "."));
            }

            //Logging the test execution
            timeTest.Stop();
            Log.Info("Stop test {0}. Test status: {1}. Test time: {2} ms.", TestContext.CurrentContext.Test.FullName, TestContext.CurrentContext.Result.Outcome.Status, timeTest.Elapsed);
            webDriver.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(10000);


        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            if (webDriver != null)
            {
                webDriver.Close();
                webDriver.Quit();
            }
        }

    }
}
