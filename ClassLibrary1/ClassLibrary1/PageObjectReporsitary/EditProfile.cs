using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class EditProfile
    {

        IWebDriver editProfileDriver;
        public EditProfile(IWebDriver driver)
        {
            editProfileDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(editProfileDriver, TimeSpan.FromSeconds(90)));
        }

        #region EditProfile Page Elements

        UserInfo userInfo;

        public string userNameInputText = "Ashia Abiodun";
        public string birthdayDate = "01/01/1988";
        public string testDescription = "Testing description";
        public string degreeText = "MBA";
        public string specializationText = "Marketing";
        public string universityText = "ASU";
        public string classYear = "2006";
        public string positionText = "Student";
        public string employerText = "EducationWorld";
        public string phoneNumber = "789-456-1230";
        public string address1Text = "Street address";
        public string cityText = "Scottsdale";
        public string zipCodeText = "55111";
        public string updateConfirmationText = "has been";
        public string educationText = "EDUCATION";
        public string empText = "EMPLOYMENT";
        public string contactText = "CONTACT";
        public string grouptext = "Group";

        // [FindsBy(How = How.XPath, Using = "//*[@id='profile-contextual']/a/button")]
        [FindsBy(How = How.CssSelector, Using = "#profile-contextual > a > button")]
        public IWebElement editButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='edit-group-personal']")]
        public IWebElement personalTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='edit-group-education']")]
        public IWebElement educationTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='edit-group-employment']")]
        public IWebElement employmentTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='edit-group-contact']")]
        public IWebElement contactTab { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-name-0-value")]
        public IWebElement userName { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-birthday-0-value-date")]
        public IWebElement enterBirthday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        public IWebElement aboutFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_2_contents']/iframe")]
        public IWebElement interestFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body")]
        public IWebElement description { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/p")]
        public IWebElement descriptionText { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement save { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-degree-0-value")]
        public IWebElement enterDegree { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-area-of-specialization-0-value")]
        public IWebElement enterSpecialization { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-university-name-0-value")]
        public IWebElement enterUniversity { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-class-0-value")]
        public IWebElement enterClass { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-in-progress-wrapper']/div/div/div/input")]
        public IWebElement status { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#edit-field-in-progress-wrapper > div > div > div > ul.dropdown-content.select-dropdown > li:nth-child(3) > span")]
        public IWebElement statusOption { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-position-0-value")]
        public IWebElement enterPostion { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-employer-0-value")]
        public IWebElement enterEmployer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-since-0-value']/div[2]/div/div[1]/input")]
        public IWebElement month { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-since-0-value']/div[2]/div/div[1]/ul/li[3]/span")]
        public IWebElement monthOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-since-0-value']/div[3]/div/div[1]/input")]
        public IWebElement year { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-since-0-value']/div[3]/div/div[1]/ul/li[113]/span")]
        public IWebElement yearOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-employment-status-wrapper']/div/div/div/input")]
        public IWebElement empStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-employment-status-wrapper']/div/div/div/ul/li[3]")]
        public IWebElement empStatusOptions { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='edit-field-address-0-address-country-code']/div/div/div[1]/input")]
        public IWebElement country { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-address-0-address-country-code']/div/div/div[1]/ul/li[246]/span")]
        public IWebElement countryOptions { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-cell-phone-number-0-value")]
        public IWebElement enterCellNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'edit-field-address-0-address-address-line1')]")]
        public IWebElement address1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'edit-field-address-0-address-locality')]")]
        public IWebElement city { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'edit-field-address-0-address-container2')]/div[2]/div/div[1]/input")]
        public IWebElement state { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'edit-field-address-0-address-container2')]/div[2]/div/div[1]/ul/li[5]/span")]
        public IWebElement stateOptions { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-address-0-address-postal-code")]
        public IWebElement zipCode { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-home-phone-number-0-value")]
        public IWebElement homePhone { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-work-phone-number-0-value")]
        public IWebElement workPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='messages']/div/div/div[2]/div")]
        public IWebElement updateMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Edit')]")]
        public IWebElement editProfileIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='profile__stream']")]
        public IWebElement profilePosts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='profile__comment_stream']")]
        public IWebElement commentsPosts { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-3']/ul/li/div[1]/a/span")]
        public IWebElement filterOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-comment-stream-default']/ul/li/div[1]/a/span")]
        public IWebElement filterOptionsComments { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-3']/ul/li/div[2]/div/div[1]/div/div/input")]
        public IWebElement filterType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-comment-stream-default']/ul/li/div[2]/div/div[2]/label")]
        public IWebElement groupLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(1) > div > div > ul > li:nth-child(1) >span")]
        public IWebElement anyFilter { get; set; }

        [FindsBy(How = How.Id, Using = "edit_gid_chosen")]
        public IWebElement groupFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_gid_chosen']/div/ul/li[1]")]
        public IWebElement anyGroup { get; set; }

        [FindsBy(How = How.Id, Using = "edit-combine")]
        public IWebElement searchText { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit-streams")]
        public IWebElement applyButton { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit-comment-stream")]
        public IWebElement applyCommentButton { get; set; }

        [FindsBy(How = How.Id, Using = "edit-comment-body-value")]
        public IWebElement searchComments { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='profile__education']")]
        public IWebElement educationTabLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='profile__employment']")]
        public IWebElement employmentTabLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='profile__contact']")]
        public IWebElement contactTabLabel { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-profile-picture-0-remove-button")]
        public IWebElement deletePicture { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id*='edit-field-profile-picture-0-upload']")]
        public IWebElement upload { get; set; }


        #endregion EditProfile Page Elements

        public void UserProfileSettings(string uploadProfileImage)
        {

            userInfo = new UserInfo(editProfileDriver);
            string uName = userInfo.userName.Text;
            Console.WriteLine(uName);
            userInfo.userName.Click();
            userInfo.userProfile.Click();
            string url = editProfileDriver.Url;
            Assert.That(url, Does.Contain("user").IgnoreCase);
            //Validate Browser tab with User name
            Assert.IsTrue(editProfileDriver.Title.Contains(uName));
            editButton.Click();
            Console.WriteLine("***** Modify Personal Information ******");
            personalTab.Click();
            userName.Clear();
            userName.SendKeys(userNameInputText);
            deletePicture.Click();
            upload.SendKeys(uploadProfileImage);
            Thread.Sleep(2000);
            editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            enterBirthday.Clear();
            enterBirthday.SendKeys(birthdayDate);
            editProfileDriver.SwitchTo().DefaultContent();
            editProfileDriver.SwitchTo().Frame(aboutFrame);
            AddDescription();
            editProfileDriver.SwitchTo().DefaultContent();
            editProfileDriver.SwitchTo().Frame(interestFrame);
            AddDescription();
            PageServices.ScrollPageUptoTop(editProfileDriver);
            Console.WriteLine("***** Modify Education Information ******");
            editProfileDriver.SwitchTo().DefaultContent();
            educationTab.Click();
            editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            enterDegree.Clear();
            enterDegree.SendKeys(degreeText);
            enterSpecialization.Clear();
            enterSpecialization.SendKeys(specializationText);
            enterUniversity.Clear();
            enterUniversity.SendKeys(universityText);
            enterClass.Clear();
            enterClass.SendKeys(classYear);
            status.Click();
            editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            /*This sleep is required as the options needs to be loaded*/
            Thread.Sleep(1000);
            statusOption.Click();
            PageServices.ScrollPageUptoTop(editProfileDriver);
            Console.WriteLine("***** Modify Employement Information ******");
            /*Employment Tab*/
            employmentTab.Click();
            editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            enterPostion.Clear();
            enterPostion.SendKeys(positionText);
            enterEmployer.Clear();
            enterEmployer.SendKeys(employerText);
            month.Click();
            monthOptions.Click();
            year.Click();
            yearOptions.Click();
            empStatus.Click();
            empStatusOptions.Click();
            PageServices.ScrollPageUptoTop(editProfileDriver);
            Console.WriteLine("***** Modify Contact Information ******");
            contactTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(editProfileDriver, 60);
            string NewZipCode = zipCode.GetAttribute("value");
            zipCode.Clear();
            zipCode.SendKeys(NewZipCode);
            //country.Click();
            //countryOptions.Click();
            /*This sleep is required as the options needs to be loaded*/
            //Thread.Sleep(2000);
            address1.Clear();
            address1.SendKeys(address1Text);
            //city.Clear();
            //city.SendKeys(cityText);
            //state.Click();
            //stateOptions.Click();
            enterCellNumber.Clear();
            enterCellNumber.SendKeys(phoneNumber);
            homePhone.Clear();
            homePhone.SendKeys(phoneNumber);
            workPhone.Clear();
            workPhone.SendKeys(phoneNumber);
            save.Click();
            //editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            PageServices.WaitForPageToCompletelyLoaded(editProfileDriver, 60);
            Thread.Sleep(2000);
            Assert.IsTrue(updateMessage.Text.Contains(updateConfirmationText));
            Assert.AreEqual("Edit", editProfileIcon.GetAttribute("title"));
            profilePosts.Click();
            filterOptions.Click();
            editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            filterType.Click();
            anyFilter.Click();

            //Below commented line of code is not working need to check
            //editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //groupFilter.Click();
            // anyGroup.Click();

            searchText.SendKeys(testDescription);
            applyButton.Click();
            PageServices.WaitForPageToCompletelyLoaded(editProfileDriver, 120);
            PageServices.ScrollPageUptoTop(editProfileDriver);
            Thread.Sleep(1000);
            commentsPosts.Click();
            Thread.Sleep(1000);
            filterOptionsComments.Click();
            searchComments.SendKeys(testDescription);
            Assert.AreEqual(grouptext, groupLabel.Text);
            applyCommentButton.Click();
            editProfileDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            PageServices.ScrollPageUptoTop(editProfileDriver);
            Assert.AreEqual(educationText, educationTabLabel.Text);
            Assert.AreEqual(empText, employmentTabLabel.Text);
            Assert.AreEqual(contactText, contactTabLabel.Text);
            Console.WriteLine("Compeleted Execution of Profile Page");
        }


        public void AddDescription()
        {
            description.Clear();
            description.Click();
            Thread.Sleep(3000);
            Actions a = new Actions(editProfileDriver);
            a.Click(descriptionText).SendKeys(testDescription).Build().Perform();
            Thread.Sleep(3000);
            editProfileDriver.SwitchTo().DefaultContent();

        }
    }
}
