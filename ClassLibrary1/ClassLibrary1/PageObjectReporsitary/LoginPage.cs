using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System.Threading;

namespace ClassLibrary1
{
    public class LoginPage
    {
       IWebDriver commonsDriver;
       public string expectedGroupText = "My groups";

        public LoginPage(IWebDriver driver)
        {
            commonsDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(commonsDriver, TimeSpan.FromSeconds(90))); 
        }

        #region SSO Login Page Objects

        public string EnvInd = TestContext.Parameters.Get("Environment").ToString();

        [FindsBy(How = How.CssSelector, Using = "input#edit-input")]
        public IWebElement userNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-next")]
        public IWebElement nextButton { get; set; }

        //This element will be removed after Commons Sprint 2020 Sprint 12 deployement in All the Environment
        [FindsBy(How = How.Id, Using = "edit-sso-login")]
        public IWebElement ssoLoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "userNameInput")]
        public IWebElement inputUsername { get; set; }

        [FindsBy(How = How.Id, Using = "passwordInput")]
        public IWebElement inputPassword { get; set; }

        [FindsBy(How = How.Id, Using = "submitButton")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#loginArea > form#loginForm > div#error")]
        public IWebElement invalidUserError { get; set; }

        [FindsBy(How = How.ClassName, Using = "desktop-menu")]
        public IWebElement menu_bgcolor { get; set; }

        [FindsBy(How = How.LinkText, Using = "Service Desk")]
        public IWebElement serviceDeskLink { get; set; }

        
        #endregion SSO Login Page Objects

        #region Direct Login
        //[FindsBy(How = How.Id, Using = "edit-name")]
        //public IWebElement directInputUsername { get; set; }

        //[FindsBy(How = How.Id, Using = "edit-pass")]
        //public IWebElement directInputPassword { get; set; }

        //[FindsBy(How = How.Id, Using = "edit-submit")]


        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div>input#edit-name")]
        public IWebElement directInputUsername { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div>input#edit-pass")]
        public IWebElement directInputPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div>button#edit-submit")]
        public IWebElement directLogInButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div > div.form-item--error-message")]
        public IWebElement invalidDirectLoginError { get; set; }

        #endregion Direct Login

        #region Dashboard Page Objects
        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]
        public IWebElement myGroupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > header > div > div > div > div > span.circle.user-picture__default > a")]
        public IWebElement pCommonsProfilePict { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(1) > a")]
        public IWebElement lnkPosts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(2) > a")]
        public IWebElement lnkComments { get; set; }

        #endregion Dashboard Page Objects

        //Enter UserName or O365Email Id on the first form
        public void EnteruserName(string userName)
        {
            userNameField.SendKeys(userName);
        }

        public void ClicknextButton()
        {
            nextButton.Click();
        }

        //This Method will be removed after Commons Sprint 2020 Sprint 12 deployement in All the Environment
        public void ClickSSLoginButton()
        {
            ssoLoginButton.Click();
        }

        //public void VerifyMyGroupLink()
        //{
        //    Assert.IsTrue(myGroupText.Displayed);
        //    myGroupText.Click();


        //}

        public void Direct_Login(string userName, string password)
        {
            EnteruserName(userName);
            ClicknextButton();
            Thread.Sleep(1000);
            directInputPassword.SendKeys(password);
            directLogInButton.Click();
            /*
            if (EnvInd == "QA" || EnvInd == "UAT"||EnvInd=="AWS")
            {
                EnteruserName(userName);
                ClicknextButton();
                Thread.Sleep(1000);
                directInputPassword.SendKeys(password);
                directLogInButton.Click();
            }

            ////This section will be removed after Commons Sprint 2020 Sprint 12 deployement in All the Environment
            //else
            //{
            //    Thread.Sleep(1000);
            //    directInputUsername.SendKeys(userName);
            //    directInputPassword.SendKeys(password);
            //    directLogInButton.Click();
            //}

         */
        }

        public void ADFS_SSO_Login(string userName, string password)
        {
            inputUsername.SendKeys(userName);
            inputPassword.SendKeys(password);
            signInButton.Click();
        }

        public string MyGroupText()
        {
            string myGroup = myGroupText.GetAttribute("innerText").ToString();
            Console.WriteLine(myGroup);
            return myGroup;
        }


        public void VerifyMyGroupLink()
        {
            Assert.IsTrue(myGroupText.Displayed);
            myGroupText.Click();


        }

        public void SSO_Login(string userName, string password)
        {
            EnteruserName(userName);
            ClicknextButton();
            inputUsername.SendKeys(userName);
            inputPassword.SendKeys(password);
            signInButton.Click();
            //if (EnvInd == "QA" || EnvInd == "UAT"||EnvInd=="AWS")
            //{
            //    EnteruserName(userName);
            //    ClicknextButton();
            //    inputUsername.SendKeys(userName);
            //    inputPassword.SendKeys(password);
            //    signInButton.Click();
            //}

            ////This section will be removed after Commons Sprint 2020 Sprint 12 deployement in All the Environment
            //else
            //{
            //    ClickSSLoginButton();
            //    inputUsername.SendKeys(userName);
            //    inputPassword.SendKeys(password);
            //    signInButton.Click();
            //}
                                 

        }

        public void DirectLinkLogin(string userName, string password)
        {     
                inputUsername.SendKeys(userName);
                inputPassword.SendKeys(password);
                signInButton.Click();
                Thread.Sleep(3000);
        }


        public void EnvIndicator()
        {
            string color1 = menu_bgcolor.GetCssValue("background-color").ToString();
            Console.WriteLine("Verifying Top Menu Background Color1  " + color1);
            if (EnvInd == "QA")
            {
                Assert.AreEqual("rgba(177, 207, 64, 1)", color1);
            }
            else if (EnvInd == "UAT")
            {
                Assert.AreEqual("rgba(218, 165, 32, 1)", color1);
            }
            else if (EnvInd == "DEV")
            {
                Assert.AreEqual("rgba(132, 165, 248, 1)", color1);
            }
            else if (EnvInd == "Prod")
            {
                Assert.AreEqual("rgba(178, 34, 34, 1)", color1);
            }

            else Console.WriteLine("Please Recheck the Menu BGColor used for Environment Indicator");

        }



    }
}
