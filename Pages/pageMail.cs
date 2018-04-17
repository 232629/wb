using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestGmail.Pages
{
    public class PageMail : PageBase
    {
        public PageMail(IWebDriver driver) : base(driver) { }

        public IWebElement LnkAnswer
        {
            get { return FindElement(By.CssSelector("span.ams.bkH")); }
        }

        public IWebElement TxtBody
        {
            get { return FindElement(By.CssSelector("div.Am.Al.editable.LW-avf")); }
        }

        public IWebElement BtnSend
        {
            get { return FindElement(By.CssSelector("div.T-I.J-J5-Ji.aoO.T-I-atl.L3")); }
        }


        
    }
}
