using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class UserAccount
    {
        IWebDriver userAccountDriver;
        UserInfo userInfo;
        public UserAccount(IWebDriver driver)
        {
            userAccountDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(userAccountDriver, TimeSpan.FromSeconds(90)));
            userInfo = new UserInfo(userAccountDriver);
        }

       

        #region UserAccount Page Elements

        public string firstNameText = "First name";
        public string lastNameText = "Last name";
        public string firstNameInputText = "Ashia";
        public string lastNameInputText = "Abiodun";
        public string emailText = "Email address";
        public string timeZoneText = "Time zone";
        public string city = "New York";
        public string nameHoverText = "The first and last name are populated on account creation. If the users name is changed in other applications, it will not be picked up here. This will be changed in the future and these fields will be disabled.";
        public string emailHoverText = "A valid email address. All emails from the system will be sent to this address. The email address is not made public and will only be used if you wish to receive a new password or wish to receive certain news or notifications by email.";
        public string timeZoneHoverText = "Select the desired local time and time zone. Dates and times throughout this site will be displayed using this time zone.";

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-first-name-wrapper']/div/label")]
        public IWebElement firstNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-last-name-wrapper']/div/label")]
        public IWebElement lastNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-account']/div/label")]
        public IWebElement emailLabel { get; set; }        

        [FindsBy(How = How.Id, Using = "edit-field-first-name-0-value")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-last-name-0-value")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-timezone']/div/label")]
        public IWebElement timeZoneLabel { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_timezone__2_chosen']/a/span")]
        public IWebElement timeZoneOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_timezone__2_chosen']/div/div/input")]
        public IWebElement timeZoneInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_timezone__2_chosen']/div/ul/li[156]")]
        public IWebElement timeZoneSelected { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-first-name-0-value--description']/a")]
        public IWebElement firstNameToolTip { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-mail--description']/a")]
        public IWebElement emailToolTip { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-timezone--2--description']/a")]
        public IWebElement timeZoneToolTip { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement saveButton { get; set; }


        [FindsBy(How = How.ClassName, Using = "user-form")]
        public IWebElement userFormContent { get; set; }
               
        [FindsBy(How = How.Id, Using = "edit-current-pass")]
        public IWebElement txtCurrentPassword { get; set; }

        [FindsBy(How = How.Id, Using = "edit-pass-pass1")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "edit-pass-pass2")]
        public IWebElement txtConfirmPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#user-account-menu > ul > li:nth-of-type(4) > a")]
        public IWebElement AccessMembershipDirSetting { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='fieldset-legend']")]
        public IWebElement MembershipDirSettingRole { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#edit-default-fields-general.form-checkbox")]
        public IWebElement DefaultCheckMemDirSet { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='card-content']/div")]
        public IList<IWebElement> MemDirDefaultCardContents { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='markup-general']/div")]
        public IList<IWebElement> MemDirCardSetFields { get; set; }

        



        #endregion UserAccount Page Elements

        public void AccountSettings()
        {
            //userInfo = new UserInfo(userAccountDriver);
            //userInfo.userName.Click();
            //userAccountDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //userInfo.accountLink.Click();
            // Assert.That(userInfo.accountHeader.Text, Does.Contain("Account").IgnoreCase);
            Assert.IsTrue(userInfo.userAccountMenus[0].Text.Contains("Account"));
            Actions actions = new Actions(userAccountDriver);
            Assert.AreEqual(firstNameLabel.Text, firstNameText);
            //Madan :Due to the functionality change now field is not not editable
            //firstName.Clear();
            //firstName.SendKeys(firstNameInputText);
            actions.MoveToElement(firstNameToolTip).Build().Perform(); ;
            string nameToolTipText = firstNameToolTip.GetAttribute("data-tooltip");           
            Assert.AreEqual(nameToolTipText, nameHoverText);
            Assert.AreEqual(lastNameLabel.Text, lastNameText);
          
            //Madan :Due to the functionality change now name field is not not editable
            //lastName.Clear();
            //lastName.SendKeys(lastNameInputText);
            Assert.AreEqual(emailLabel.Text, emailText);

            //Verify Password Option not available for SSO User          
            Console.WriteLine(userFormContent.Text);
            Assert.IsFalse(userFormContent.Text.Contains("Current password"));
            Console.WriteLine("Password change option not available");
            
            actions.MoveToElement(emailToolTip).Build().Perform(); ;
            string emailtoolTipText = emailToolTip.GetAttribute("data-tooltip");            
            Assert.AreEqual(emailtoolTipText, emailHoverText);
            Assert.AreEqual(timeZoneLabel.Text, timeZoneText);
            actions.MoveToElement(timeZoneToolTip).Build().Perform(); ;
            string timeZonetoolTipText = timeZoneToolTip.GetAttribute("data-tooltip");
            Assert.AreEqual(timeZonetoolTipText, timeZoneHoverText);
            timeZoneOptions.Click();
            actions.MoveToElement(timeZoneSelected).Click().Build().Perform();
            saveButton.Click();
        }


        public void ChangePassword(string existedPassword,string newPassword)
        {
            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.accountSubMenu);
            txtCurrentPassword.SendKeys(existedPassword);
            Thread.Sleep(2000);
            txtPassword.SendKeys(newPassword);
            txtConfirmPassword.SendKeys(newPassword);
            Thread.Sleep(2000);
            saveButton.Click();
        }

        //public void Logout()
        //{
        //    userInfo.ClickOnUserMenu();
        //    userInfo.ClickOnSubMenu(userInfo.accountSubMenu); 
        //    userInfo.ClickOnSubMenu(userInfo.accountSubMenu);
        //}

        public void AccessMembershipDirectorySettings()
        {
            AccessMembershipDirSetting.Click();
        }

        public void MembershipDirectorySetting()
        {

            string RoleVariable = MembershipDirSettingRole.GetAttribute("innerText").ToString();

            if (RoleVariable == "Student Directory")
            {
                Console.WriteLine(RoleVariable);
                IWebElement checkbox = DefaultCheckMemDirSet;
                bool aValue = DefaultCheckMemDirSet.Selected;
                if (aValue == true)
                {
                    Console.WriteLine("Default card fields Check Box is Selected");
                    int DefCardContentCount = MemDirDefaultCardContents.Count();
                    for (int i = 0; i < DefCardContentCount; i++)
                    {
                        string ContentText1 = MemDirDefaultCardContents[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText1);
                        if (ContentText1.Contains("Program start date"))
                        {
                            Console.WriteLine("Program start date Implemented for Student");
                        }
                        else if (ContentText1.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Implemented for Student");
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Default card fields Check Box is not Selected");
                    int SetCardFieldsCount = MemDirCardSetFields.Count();
                    for (int i = 0; i < SetCardFieldsCount; i++)
                    {
                        string ContentText2 = MemDirCardSetFields[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText2);
                        if (ContentText2.Contains("Program start date"))
                        {
                            Console.WriteLine("Program start date Implemented for Student");
                        }
                        else if (ContentText2.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Implemented for Student");
                        }
                    }
                }


            }
            else if (RoleVariable == "Alumni Directory")
            {
                Console.WriteLine(RoleVariable);
                IWebElement checkbox = DefaultCheckMemDirSet;
                bool aValue = DefaultCheckMemDirSet.Selected;
                if (aValue == true)
                {
                    Console.WriteLine("Default card fields Check Box is Selected");
                    int DefCardContentCount = MemDirDefaultCardContents.Count();
                    for (int i = 0; i < DefCardContentCount; i++)
                    {
                        string ContentText3 = MemDirDefaultCardContents[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText3);
                        if (ContentText3.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Implemented for Alumni");
                        }
                        else if (ContentText3.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Alumni");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Default card fields Check Box is not Selected");
                    int SetCardFieldsCount = MemDirCardSetFields.Count();
                    for (int i = 0; i < SetCardFieldsCount; i++)
                    {
                        string ContentText4 = MemDirCardSetFields[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText4);
                        if (ContentText4.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Implemented for Alumni");
                        }
                        else if (ContentText4.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Alumni");
                        }
                    }
                }

            }
            else if (RoleVariable == "Faculty Directory")
            {
                Console.WriteLine(RoleVariable);
                IWebElement checkbox = DefaultCheckMemDirSet;
                bool aValue = DefaultCheckMemDirSet.Selected;
                if (aValue == true)
                {
                    Console.WriteLine("Default card fields Check Box is Selected");
                    int DefCardContentCount = MemDirDefaultCardContents.Count();
                    for (int i = 0; i < DefCardContentCount; i++)
                    {
                        string ContentText5 = MemDirDefaultCardContents[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText5);
                        if (ContentText5.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Program completion date is not available for Faculty");
                        }
                        if (ContentText5.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Current course is not available for Faculty");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Default card fields Check Box is not Selected");
                    int SetCardFieldsCount = MemDirCardSetFields.Count();
                    for (int i = 0; i < SetCardFieldsCount; i++)
                    {
                        string ContentText6 = MemDirCardSetFields[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText6);
                        if (ContentText6.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Program completion date is not available for Faculty");
                        }
                        if (ContentText6.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Current course is not available for Faculty");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Header of Membership Directory Roles");
            }
        }
    }
}
