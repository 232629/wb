using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestGmail.Pages
{
    public class PageWelcome : PageBase
    {
        public PageWelcome(IWebDriver driver) : base(driver) { }

        public IWebElement LblHeader
        {
            get { return FindElement(By.Id("headingText")); }
        }

        public IWebElement TxtPassword
        {
            get { return FindElement(By.Name("password")); }
        }

        public IWebElement BtnNext
        {
            get { return FindElement(By.Id("passwordNext")); }
        }

    }
}
