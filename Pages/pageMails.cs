using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestGmail.Pages
{
    public class PageMails : PageBase
    {
        public PageMails(IWebDriver driver) : base(driver) { }

        public IWebElement BtnSend
        {
            get { return FindElement(By.CssSelector("div.T-I.J-J5-Ji.T-I-KE.L3")); }
        }


        public IWebElement PopUp
        {
            get { return FindElement(By.XPath("/html/body/div[13]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div")); }
        }

        public IWebElement TxtAddress
        {
            get { return FindElement(By.CssSelector("textarea[role='combobox']")); }
        }

        public IWebElement TxtSubject
        {
            get { return FindElement(By.CssSelector("input[name=subjectbox]")); }
        }

        public IWebElement TxtMessage
        {
            get { return FindElement(By.CssSelector("div.Am.Al.editable.LW-avf")); }
        }

        public IWebElement BtnPopUpSend
        {
            get { return FindElement(By.CssSelector("div.T-I.J-J5-Ji.aoO.T-I-atl.L3")); }
        }

        public IWebElement LnkIncoming
        {
            get { return FindElement(By.PartialLinkText("Входящие")); }
        }

        public IWebElement TblMails
        {
            get
            {
                return FindElement(By.CssSelector("table[class='F cf zt']"));
            }
        }
        

    }
}
