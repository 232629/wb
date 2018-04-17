using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestGmail.Pages
{
    public class PageBase
    {
        private IWebDriver webDriver;
        protected PageBase(IWebDriver driver)
        {
            webDriver = driver;
        }

        protected IWebElement FindElement(By by)
        {
            return webDriver.FindElement(by);
        }


    }
}
