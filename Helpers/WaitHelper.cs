using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using TestGmail.Pages;

namespace TestGmail.Helpers
{
    static class WaitHelper
    {
        static public IWebElement WaitDisplayElements(IWebElement element, int timeout = 5000)
        {
            var waitTime = 100;
            DateTime tend = DateTime.Now.AddMilliseconds(timeout);
            do
            {
                System.Threading.Thread.Sleep(waitTime);
                if (element.Displayed)
                    return element;
            } while (DateTime.Now <= tend);

            Assert.Fail("Element {0} was not shown during time {1} ms.", element, timeout);
            return null;
        }


        static public void WaitHeader(string header, IWebDriver webDriver, int timeout = 5000)
        {
            var waitTime = 100;
            DateTime tend = DateTime.Now.AddMilliseconds(timeout);
            do
            {
                System.Threading.Thread.Sleep(waitTime);
                if (header == webDriver.FindElement(By.Id("headingText")).Text)
                    return;
            } while (DateTime.Now <= tend);

            Assert.Fail("Header {0} was not shown during time {1} ms.", header, timeout);
        }


    }
}
