using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestGmail.Pages
{
    public class PageSignIn : PageBase
    {
        public PageSignIn(IWebDriver driver) : base(driver) { }

        public IWebElement LblHeader
        {
            get { return FindElement(By.Id("headingText")); }
        }

        public IWebElement TxtEmail
        {
            get { return FindElement(By.Id("identifierId")); }
        }

        public IWebElement BtnNext
        {
            get { return FindElement(By.Id("identifierNext")); }
        }

    }
}
