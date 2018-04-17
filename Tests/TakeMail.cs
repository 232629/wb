using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestGmail.Helpers;
using TestGmail.Pages;


namespace TestGmail
{
    [TestFixture]
    public partial class gMail
    {
        [Test]
        public void TakeMail()
        {
            #region Test Data

            string password = "***********";

            #endregion


            PageWelcome pageWelcome = new PageWelcome(webDriver);
            WaitHelper.WaitHeader("Hi Eugene", webDriver);
            pageWelcome.TxtPassword.SendKeys(password);
            WaitHelper.WaitDisplayElements(pageWelcome.BtnNext);
            pageWelcome.BtnNext.Click();

            PageMyAccount pageMyAccount = new PageMyAccount(webDriver);
            WaitHelper.WaitDisplayElements(pageMyAccount.LnkMail);
            pageMyAccount.LnkMail.Click();

            PageMails pageMails = new PageMails(webDriver);
            pageMails.LnkIncoming.Click();
            var mls = pageMails.TblMails.FindElements(By.TagName("tr"));
            foreach (var subject in mls)
            {
                if (subject.Text.Contains("Test"))
                {
                    subject.Click();
                    break;
                }
            }
               
            PageMail pageMail = new PageMail(webDriver);
            pageMail.LnkAnswer.Click();
            pageMail.TxtBody.SendKeys("4321");
            pageMail.BtnSend.Click();
                


        }

    }
}
