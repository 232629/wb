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
        public void SendMail()
        {
            #region Test Data

            string mail = "******@gmail.com";
            string password = "***********";

            #endregion

            PageSignIn pageSignIn = new PageSignIn(webDriver);
            WaitHelper.WaitHeader("Sign in", webDriver);
            pageSignIn.TxtEmail.SendKeys(mail);
            WaitHelper.WaitDisplayElements(pageSignIn.BtnNext);
            pageSignIn.BtnNext.Click();
            
            PageWelcome pageWelcome = new PageWelcome(webDriver);
            WaitHelper.WaitHeader("Welcome", webDriver);
            pageWelcome.TxtPassword.SendKeys(password);
            WaitHelper.WaitDisplayElements(pageWelcome.BtnNext);
            pageWelcome.BtnNext.Click();

            PageMyAccount pageMyAccount = new PageMyAccount(webDriver);
            WaitHelper.WaitDisplayElements(pageMyAccount.LnkMail);
            pageMyAccount.LnkMail.Click();

            PageMails pageMails = new PageMails(webDriver);
            WaitHelper.WaitDisplayElements(pageMails.BtnSend);
            pageMails.BtnSend.Click();
            WaitHelper.WaitDisplayElements(pageMails.TxtAddress);
            pageMails.TxtAddress.SendKeys(mail);
            pageMails.TxtSubject.SendKeys("Test");
            pageMails.TxtMessage.SendKeys("1234");
            pageMails.BtnPopUpSend.Click();

        }

    }
}
