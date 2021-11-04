using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class NotificationSettings
    {
        IWebDriver notificDriver;

        public NotificationSettings(IWebDriver driver)
        {
            notificDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(notificDriver, TimeSpan.FromSeconds(90)));
        }


        #region expcted Text
        public string notificationSettings = "Notifications settings";
        public string emailFrequencyLegendText = "Email frequency";
        public string weeklyFrequency = "Weekly summary";
        public string dailyFrequency = "Daily summary";
        public string immediateFrequency = "Immediate";
        public string noEmail = "No email at all";
        public string activityLegendText = "Activity";
        public string postActivityText = "A new post is added to one of my groups";
        public string commentActivityText = "A new comment is added to the content I created";
        public string commentReplyActivityText = "A new comment or reply is added to content I commented on";
        public string postLikeAndReplyActivityText = "A member has liked a post, comment or reply I have made";
        public string privateLegendText = "Private messages";
        public string txtChkBoxIncludePrivateMsg = "Include private messages with my activity notifications";
        public string tagsLegendText = "Tags";
        public string noTagAlertText = "If you choose not to get notified when tagged, other users in The Commons will not be able to Tag you in any contribution. The purpose of a tag is to notify a member of a conversation.";
        public string saveNotificationSettingText = "Notification settings are changed successfully";
        public string Alumnidata = "Donna Rendon";

        #endregion expcted Text


        #region Notification Page Element
        [FindsBy(How = How.CssSelector, Using = "#edit-general > legend > span")]
        public IWebElement legendEmailFrequecy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-frequency")]
        public IWebElement inputEmailFrequecy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-activity > legend > span")]
        public IWebElement legendActivityFrequecy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-activity > div > div >input")]
        public IList<IWebElement> chkBoxActivityNotifctn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-activity > div > div >input +label")]
        public IList<IWebElement> chkBoxActivityNotifctnLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-private-message > legend > span")]
        public IWebElement legendPrivateMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-private-message > div > div > input")]
        public IWebElement chkBoxPrivateMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-private-message > div > div > input +label")]
        public IWebElement chkBoxPrivateMessageNotifctnLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-private-message > div > div > div > div > input")]
        public IWebElement privateMessageFrequencyDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_pm_frequency")]
        public IWebElement inputPrivateMsgFrequecy { get; set; }

        //

        [FindsBy(How = How.CssSelector, Using = "#edit-tagging > legend > span")]
        public IWebElement legendTagsText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-tagging > div > div > input")]
        public IWebElement chkBoxTagsInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-tagging > div > div > input +label")]
        public IWebElement chkBoxTagNotifctnLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-tagging > div > div > div > div > input")]
        public IWebElement tagFrequencyDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_tag_frequency")]
        public IWebElement inputTagFrequecy { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement btnSaveNotfcnSetting { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#messages > div > div > div.status-messages > div")]
        public IWebElement msgSaveNotificnMessage { get; set; }

        [FindsBy(How = How.Id, Using = "edit-membership-submit")]
        public IWebElement btnSaveAlumniMemDir { get; set; }

        
        #endregion Notification Page Element


        #region Notification Functionlity

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__other-links")]
        public IWebElement NineIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__other-links']/ul/li[4]/a")]
        public IWebElement PeopleText { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@action='/admin/people']/ul/li/div/a")]
        public IWebElement PeopleFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/form/ul//div[@class='collapsible-body']/div/div[6]/div/div/input")]
        public IWebElement UniversityRoleDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/form/ul//div[@class='collapsible-body']/div/div[6]/div/div/ul/li[5]/span")]
        public IWebElement StudentRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/form/ul//div[@class='collapsible-body']/div/div[6]/div/div/ul/li[4]/span")]
        public IWebElement AlumniRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/form/ul//div[@class='collapsible-body']/div/div[6]/div/div/ul/li[2]/span")]
        public IWebElement FacultyRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/form/ul//div[@class='collapsible-body']/div/div[6]/div/div/ul/li[3]/span")]
        public IWebElement TeamMemRole { get; set; }

        [FindsBy(How = How.XPath, Using = " //button[@id='edit-submit-user-admin-people']")]
        public IWebElement FilterBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@class='views-field views-field-operations']//li[@class='dropbutton - action']/a")]
        public IList<IWebElement> StudentList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-form-user-admin-people-page-1 > table > tbody > tr >td > a > span")]
        public IList<IWebElement> StudentName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#edit-field-name-value")]
        public IWebElement InputSearchFiled { get; set; }       

        [FindsBy(How = How.CssSelector, Using = "table[class*='responsive-enabled']>tbody>tr>td[headers=view-operations-table-column]>div>div[class=dropbutton-widget]>ul>li[class=dropbutton-action]>a")]
        public IWebElement StudentEditBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table[class*='responsive-enabled']>tbody>tr>td[headers=view-operations-table-column]>div>div[class=dropbutton-widget]>ul>li[class=dropbutton-toggle]>button")]
        public IWebElement StudentEditBtnCSS { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table[class*='responsive-enabled']>tbody>tr>td[headers=view-operations-table-column]>div>div[class=dropbutton-widget]>ul>li[class='dropbutton-action secondary-action']>a")]
        public IWebElement MasqueradeBtnCSS { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-form-user-admin-people-page-1']/table[2]/tbody/tr[1]/td[@class='views-field views-field-operations']//ul[@class='dropbutton']/li//a[contains(text(),'Masquerade')]")]
        public IWebElement MasqueradeBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#guidelines > div.modal-footer>a")]
        public IList<IWebElement> AcceptEGButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#directory-membership-preferences > div>a")]
        public IList<IWebElement> BtnSubmitOptInDrctry { get; set; }     


        //[FindsBy(How = How.XPath, Using = " //input[@id='edit-field-university-role-alumni']")]
        //public IWebElement AlumniCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = " //input[@id='edit-field-university-role-alumni']")]
        public IWebElement AlumniCheckBoxNew { get; set; }

        //[FindsBy(How = How.XPath, Using = " //input[@id='edit-field-university-role-alumni']")]
        //public IWebElement AlumniCheckBoxNew { get; set; }

        [FindsBy(How = How.XPath, Using = " //div[@id='edit-field-university-role']/div/label")]
        public IList<IWebElement> AlumniCheckBoxClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-personal']/a")]
        public IWebElement MemDirIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//section[@id='content']/div/ul/li[4]")]
        public IWebElement AlumniDir{ get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-directory-all']/ul/li/div/a/i")]
        public IWebElement filterBtn { get; set; }

        [FindsBy(How = How.XPath, Using = " //div[@class='dropbutton-widget']/ul/li/button")]
        public IList<IWebElement> DropdownMasq { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='dropbutton-widget']/ul/li[@class='dropbutton-action secondary-action']/a")]
        public IList<IWebElement> DropdownMasqBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-personal'][2]/a ")]
        public IWebElement ProfileIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-personal']/li/a ")]
        public IWebElement ProfileIconProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-personal']/li[7]/a ")]
        public IWebElement UnMasq { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='block-views-block-profile-block-1']//div[@class='card-panel alt indent entity__intro profile-tabs']")]
        public IWebElement AlumniInfoText { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='card-panel alt indent entity__intro profile-tabs']/span[@class='placard']")]
        public IWebElement Placard { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='card-panel alt indent entity__intro profile-tabs']/div[@class='card']/div[@class='content']/p[@class='school']")]
        //public IWebElement PlacardSchool { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-preference-alumni']/div/input")]
        public IWebElement AlumniDirPlacard { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//input[@id='edit-field-name-value']")]
        public IWebElement Alumniuser { get; set; }

        public void VerifyEmailLegendText()
        {
            string actualEmailLegendText = legendEmailFrequecy.GetAttribute("innerText");
            Console.WriteLine(actualEmailLegendText);
            Assert.AreEqual(emailFrequencyLegendText, actualEmailLegendText);
        }

        public void SetEmailFrequencyAndVerify(string emailFrequency)
        {
            VerifyEmailLegendText();
            IList<IWebElement> options = new SelectElement(inputEmailFrequecy).Options;
            for (int i = 0; i < options.Count; i++)
            {
                Assert.IsTrue(options[0].Text == immediateFrequency);
                Assert.IsTrue(options[1].Text == dailyFrequency);
                Assert.IsTrue(options[2].Text == weeklyFrequency);
            }
            inputEmailFrequecy.SendKeys(emailFrequency);
            string selectedOption = new SelectElement(inputEmailFrequecy).SelectedOption.Text;
            Console.WriteLine(selectedOption);
            Assert.AreEqual(emailFrequency, selectedOption);

        }

        public void VerifyActivityLegendText()
        {
            string actualActivityLegendText = legendActivityFrequecy.GetAttribute("innerText");
            Console.WriteLine(actualActivityLegendText);
            Assert.AreEqual(activityLegendText, actualActivityLegendText);
        }

        public void VerifyActivityNotificationSetting()
        {
            VerifyActivityLegendText();
            Assert.AreEqual(chkBoxActivityNotifctnLabel[0].Text, postActivityText);
            Assert.AreEqual(chkBoxActivityNotifctnLabel[1].Text, commentActivityText);
            Assert.AreEqual(chkBoxActivityNotifctnLabel[2].Text, commentReplyActivityText);
            Assert.AreEqual(chkBoxActivityNotifctnLabel[3].Text,postLikeAndReplyActivityText);

            int count = chkBoxActivityNotifctn.Count;
            Console.WriteLine(count);
            for (int i = 0; i < count; i++)
            {
                Assert.IsTrue(chkBoxActivityNotifctn[i].Selected);
                if (chkBoxActivityNotifctn[i].Selected)
                {
                    Console.WriteLine(chkBoxActivityNotifctnLabel[i].Text);
                    chkBoxActivityNotifctnLabel[i].Click();
                   // Thread.Sleep(100);
                    Assert.IsFalse(chkBoxActivityNotifctn[i].Selected);
                    Console.WriteLine(chkBoxActivityNotifctn[i].Selected);
                    if (!chkBoxActivityNotifctn[i].Selected)
                    {
                        chkBoxActivityNotifctnLabel[i].Click();
                        Console.WriteLine(chkBoxActivityNotifctn[i].Selected);
                    }
                }

            }

        }

        public void VerifyPrivateLegendText()
        {
            string actualprivateLegendText = legendPrivateMessage.GetAttribute("innerText");
            Console.WriteLine(actualprivateLegendText);
            Assert.AreEqual(privateLegendText, actualprivateLegendText);
        }

        public void VerifyPrivateFrequencySettings(string frequency)
        {
            VerifyPrivateLegendText();

            if (!chkBoxPrivateMessage.Selected)
            {
                Console.WriteLine(chkBoxPrivateMessageNotifctnLabel.Text);
                Assert.IsTrue(privateMessageFrequencyDropdown.Displayed);
                IList<IWebElement> options = new SelectElement(inputPrivateMsgFrequecy).Options;
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine(options[i].Text);
                    Assert.IsTrue(options[0].Text == immediateFrequency);
                    Assert.IsTrue(options[1].Text == dailyFrequency);
                    Assert.IsTrue(options[2].Text == weeklyFrequency);
                    Assert.IsTrue(options[3].Text == noEmail);
                }
                inputPrivateMsgFrequecy.SendKeys(frequency);
                string selectedOption = new SelectElement(inputPrivateMsgFrequecy).SelectedOption.Text;
                Console.WriteLine(selectedOption);
                Assert.AreEqual(frequency, selectedOption);
                chkBoxPrivateMessageNotifctnLabel.Click();
               // Thread.Sleep(100);
                Console.WriteLine(chkBoxPrivateMessage.Selected);

                if (chkBoxPrivateMessage.Selected)
                {
                    Assert.False(privateMessageFrequencyDropdown.Enabled);
                    chkBoxPrivateMessageNotifctnLabel.Click();
                   // Thread.Sleep(100);
                    Console.WriteLine(chkBoxPrivateMessage.Selected);
                    Assert.IsTrue(privateMessageFrequencyDropdown.Displayed);
                }
            }
        }



        public void VerifyTagsLegendText()
        {
            string actualTagsLegendText = legendTagsText.GetAttribute("innerText");
            Console.WriteLine(actualTagsLegendText);
            Assert.AreEqual(tagsLegendText, actualTagsLegendText);
        }

        public void VerifyTagsFrequencySettings(string frequency)
        {
            VerifyTagsLegendText();


            if (!chkBoxTagsInfo.Selected)
            {
                Assert.False(tagFrequencyDropdown.Enabled);
                chkBoxTagNotifctnLabel.Click();
               // Thread.Sleep(100);
                Console.WriteLine(chkBoxTagsInfo.Selected);
                Assert.True(tagFrequencyDropdown.Enabled);
                if (chkBoxTagsInfo.Selected)
                {
                    Console.WriteLine(chkBoxTagNotifctnLabel.Text);
                    Assert.True(tagFrequencyDropdown.Enabled);
                  //  Thread.Sleep(100);
                    IList<IWebElement> options = new SelectElement(inputTagFrequecy).Options;
                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.WriteLine(options[i].Text);
                        Assert.IsTrue(options[0].Text == immediateFrequency);
                        Assert.IsTrue(options[1].Text == dailyFrequency);
                    }
                    inputTagFrequecy.SendKeys(frequency);
                    string selectedOption = new SelectElement(inputTagFrequecy).SelectedOption.Text;
                    Console.WriteLine(selectedOption);
                    Assert.AreEqual(frequency, selectedOption);
                    chkBoxTagNotifctnLabel.Click();
                    Thread.Sleep(200);
                    IAlert alert = notificDriver.SwitchTo().Alert();
                    Console.WriteLine(alert.Text);
                    Assert.AreEqual(noTagAlertText, alert.Text);
                    alert.Accept();
                    Console.WriteLine(chkBoxTagsInfo.Selected);
                }

            }

        }
    

        public void SaveNotificationSetting()
        {
            btnSaveNotfcnSetting.Click();
        }

        public void VerifySaveNotificationMessage()
        {
            SaveNotificationSetting();
            string msg = msgSaveNotificnMessage.GetAttribute("innerText");
            string[] lines = msg.Split('\n');
            Console.WriteLine(lines[1]);           
            Console.WriteLine(saveNotificationSettingText);
            Assert.AreEqual(lines[1].Trim(),saveNotificationSettingText.Trim());
            //Assert.IsTrue(lines[1].Contains(saveNotificationSettingText));
            Thread.Sleep(100);


        }
        #endregion Notification Functionlity


        public void OpenPeoplePageAlumni()
        {
            NineIcon.Click();
            Thread.Sleep(1000);
            PeopleText.Click();
            Thread.Sleep(3000);
            PageServices.WaitForPageToCompletelyLoaded(notificDriver, 60);
            PeopleFilter.Click();
            // UniversityRoleDropdown.Click();
            Alumniuser.Clear();
            Alumniuser.SendKeys(Alumnidata);
            PageServices.WaitForPageToCompletelyLoaded(notificDriver, 60);
            Thread.Sleep(3000); 
        }



        //public void AssignAlumniRole()
        //{
        //    //StudentRole.Click();

        //    FilterBtn.Click();
        //    Thread.Sleep(1000);
        //    StudentEditBtn.Click();

        //    if (AlumniCheckBoxNew[2].Selected)
        //    {
        //        Console.WriteLine("Already an alumni");
        //    }

        //    else
        //    {
        //        AlumniCheckBoxNew[2].Click();
        //        Console.WriteLine("Made an Alumni");
        //    }
        //    btnSaveNotfcnSetting.Click(); // Common Save Button
        //}

        public string AlumniName() {


            String Alumni = "Test";
            return Alumni;
        }

        public void MasqueradeAlumnidata()
        {
            OpenPeoplePageAlumni();
            Thread.Sleep(4000);
            // AlumniRole.Click();
            Thread.Sleep(4000);

            //StudentRole.Click();

            FilterBtn.Click();
            Thread.Sleep(3000);
            //StudentEditBtn.Click();
            StudentEditBtnCSS.Click();
            MasqueradeBtnCSS.Click();
            try
            {

                Console.WriteLine("Opt in for Membership");
                int BtnCounts = BtnSubmitOptInDrctry.Count;
                for (int i = 0; i < BtnCounts; i++)
                {
                    if (BtnSubmitOptInDrctry[i].Displayed && BtnSubmitOptInDrctry[i].Text == "SUBMIT")
                    {
                        BtnSubmitOptInDrctry[i].Click();
                        Thread.Sleep(3000);
                        WebDriverExtensions.FindElement(notificDriver, By.CssSelector("#directory-membership-settings > div > a[title='Close']"), 90).Click();
                        break;
                    }

                }


              
                //Console.WriteLine(" Accept Guideline ");
                //IList<IWebElement> AcceptButton = WebDriverExtensions.FindElements(notificDriver, By.CssSelector("#guidelines > div.modal-footer>a"), 90);
                //for (int i = 0; i < AcceptButton.Count; i++)
                //{
                //    string txt = AcceptButton[i].Text;

                //    if (AcceptButton[i].Text == "ACCEPT")
                //    {
                //        AcceptButton[i].Click();
                //        break;
                //    }
                //}

            }
            catch
            {
                //Console.WriteLine(" Guideline already accepted");
                Console.WriteLine(" Already Member of Directory ");
            }
            //MasqueradeBtn.Click();
        }

        public void Masqueradefaculty()
        {
            OpenPeoplePage();
            Thread.Sleep(4000);
            FacultyRole.Click();
            Thread.Sleep(4000);

            //StudentRole.Click();

            FilterBtn.Click();
            Thread.Sleep(3000);
            //StudentEditBtn.Click();
            StudentEditBtnCSS.Click();
            MasqueradeBtnCSS.Click();
            try
            {

                Console.WriteLine("Opt in for Membership");
                int BtnCounts = BtnSubmitOptInDrctry.Count;
                for (int i = 0; i < BtnCounts; i++)
                {
                    if (BtnSubmitOptInDrctry[i].Displayed && BtnSubmitOptInDrctry[i].Text == "SUBMIT")
                    {
                        BtnSubmitOptInDrctry[i].Click();
                        Thread.Sleep(3000);
                        WebDriverExtensions.FindElement(notificDriver, By.CssSelector("#directory-membership-settings > div > a[title='Close']"), 90).Click();
                        break;
                    }

                }



                //Console.WriteLine(" Accept Guideline ");
                //IList<IWebElement> AcceptButton = WebDriverExtensions.FindElements(notificDriver, By.CssSelector("#guidelines > div.modal-footer>a"), 90);
                //for (int i = 0; i < AcceptButton.Count; i++)
                //{
                //    string txt = AcceptButton[i].Text;

                //    if (AcceptButton[i].Text == "ACCEPT")
                //    {
                //        AcceptButton[i].Click();
                //        break;
                //    }
                //}

            }
            catch
            {
                //Console.WriteLine(" Guideline already accepted");
                Console.WriteLine(" Already Member of Directory ");
            }
            //MasqueradeBtn.Click();
        }

        public void AssignAlumniDirSetting()
        {

            if (AlumniDirPlacard.Selected)
            {
                Console.WriteLine("Placard already selected Yes");
            }
            else
            {
                AlumniDirPlacard.Click();
                Console.WriteLine("Selected Yes for Alumni Directory Optin");
            }
            btnSaveAlumniMemDir.Click(); // Common Save Button
        }


        public void AssignAlumniRole()
        {

            if (AlumniCheckBoxNew.Selected)
            {
                Console.WriteLine("Already an alumni");
            }

            else
            {
                AlumniCheckBoxClick[2].Click();
                Console.WriteLine("Made an Alumni");
            }
            btnSaveNotfcnSetting.Click(); // Common Save Button
        }

        public void AssignAlumni_WithRole(string Role)
        {
            OpenPeoplePage();
            Thread.Sleep(2000);

            if (Role == "Student")
            {

                StudentRole.Click(); //Student
            }
            else if (Role == "Faculty")
            {
                FacultyRole.Click();

            }
            else if(Role=="Team")
            {
                TeamMemRole.Click();
            }
            
            Thread.Sleep(1000);
           // AssignAlumniRole();
           // VerifyAlumniIcon();

            FilterBtn.Click();
            Thread.Sleep(2000);          
            string userNAme  = StudentName[0].Text;
            StudentEditBtn.Click();

            if (AlumniCheckBoxNew.Selected)
            {
                Console.WriteLine("Already an alumni");
            }

            else
            {
                AlumniCheckBoxClick[2].Click();
                Console.WriteLine("Made an Alumni");
            }
            btnSaveNotfcnSetting.Click(); 

            VerifyAlumniIcon(userNAme);
        }
        public void VerifyAlumniIcon(string userName)
        {
            PeopleFilter.Click();
            //FilterBtn.Click();
            Thread.Sleep(1000);
            InputSearchFiled.SendKeys(userName);

            FilterBtn.Click();
            Thread.Sleep(2000);
            DropdownMasq[0].Click();
            Thread.Sleep(1000);
            DropdownMasqBtn[0].Click();            
          
           
            
            try
            {
                //Console.WriteLine(" Accept Guideline ");
                //int BtnCount = AcceptEGButton.Count;
                //// IList<IWebElement> AcceptButton = WebDriverExtensions.FindElements(notificDriver, By.CssSelector("#guidelines > div.modal-footer>a"), 90);
                //for (int i = 0; i < BtnCount; i++)
                //{
                //    string txt = AcceptEGButton[i].Text;

                //    if (AcceptEGButton[i].Text == "ACCEPT")
                //    {
                //        AcceptEGButton[i].Click();
                //        break;
                //    }
                //}

               

                Thread.Sleep(3000);
                Console.WriteLine("Opt in for Membership");
                int BtnCounts = BtnSubmitOptInDrctry.Count;
                for (int i = 0; i < BtnCounts; i++)
                {
                    if (BtnSubmitOptInDrctry[i].Displayed && BtnSubmitOptInDrctry[i].Text == "SUBMIT")
                    {
                        BtnSubmitOptInDrctry[i].Click();
                        break;
                    }

                }
                WebDriverExtensions.FindElement(notificDriver, By.CssSelector("#directory-membership-settings > div > a[title='Close']"), 90).Click();


                //string MasMsg = WebDriverExtensions.FindElement(notificDriver, By.CssSelector("#messages > div > div > div.status-messages > div"), 90).Text;
                //Assert.IsTrue(MasMsg.Contains("You are now masquerading as"));
            }
            catch { 

               // Console.WriteLine(" Accept Guideline ");
               // int BtnCount = AcceptEGButton.Count;
               //// IList<IWebElement> AcceptButton = WebDriverExtensions.FindElements(notificDriver, By.CssSelector("#guidelines > div.modal-footer>a"), 90);
               // for (int i=0;i<BtnCount ;i++)
               // {
               //     string txt = AcceptEGButton[i].Text;
                    
               //     if(AcceptEGButton[i].Text== "ACCEPT")
               //     {
               //         AcceptEGButton[i].Click();
               //         break;
               //     }
               // }

               // Console.WriteLine("Opt in for Membership");
               // int BtnCounts = BtnSubmitOptInDrctry.Count;
               // for (int i = 0; i < BtnCounts; i++)
               // {
               //     if (BtnSubmitOptInDrctry[i].Displayed && BtnSubmitOptInDrctry[i].Text == "SUBMIT")
               //     {
               //         BtnSubmitOptInDrctry[i].Click();
               //         break;
               //     }

               // }
               // WebDriverExtensions.FindElement(notificDriver, By.CssSelector("#directory-membership-settings > div > a[title='Close']"), 90).Click();




            }
            //catch
            //{
            //    Console.WriteLine(" ***Guideline already accepted & User Already Member of Directory **");
            //}
            ProfileIcon.Click();
            Thread.Sleep(1000);
            ProfileIconProfile.Click();

            //UnMasq.Click();
            Console.WriteLine("*************** Verify Alumni Icon *********************");
            string AlumniTxt = AlumniInfoText.Text;
            Console.WriteLine(AlumniTxt);
            //Assert.Contains(string "Alumni", string AlumniTxt);
            Assert.IsTrue(AlumniTxt.Contains("Alumni"));
        }

        public void MembershipDir()
        {
            MemDirIcon.Click();
        }

        public void AlumniMembershipDir()
        {
            AlumniDir.Click();
        }

        public void MakeAlumniRole()
        {
            if (AlumniCheckBoxNew.Selected)
             {
                Console.WriteLine("Already an alumni");
             }

            else
            {
                AlumniCheckBoxClick[2].Click();
                Console.WriteLine("Made an Alumni");
            }
            btnSaveNotfcnSetting.Click(); // Common Save Button
        }

        public void PlaycardInfo()
        {
            Assert.IsTrue(Placard.Displayed);
            Console.WriteLine("Playcard Info is dispalyed");
          
        }
    }
}
