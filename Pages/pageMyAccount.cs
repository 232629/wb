using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestGmail.Pages
{
    public class PageMyAccount : PageBase
    {
        public PageMyAccount(IWebDriver driver) : base(driver) { }

        public IWebElement LnkMail
        {
            get { return FindElement(By.CssSelector("a.WaidBe")); }
        }

    }
}
