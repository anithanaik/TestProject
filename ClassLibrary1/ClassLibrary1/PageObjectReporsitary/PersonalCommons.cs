using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PersonalCommons
    {
        IWebDriver commonDriver;
        GroupsActivity grpActivity;
        UserInfo userInfo;


        public PersonalCommons(IWebDriver driver)
        {

            commonDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(commonDriver, TimeSpan.FromSeconds(90)));
            // grpActivity = new GroupsActivity(commonDriver);
            userInfo = new UserInfo(commonDriver);
        }

        #region Expected Texts
        public string expectedGroupText = "My groups";
        public string expectedPostLinkText = "POSTS";
        public string expectedPrsnalText = "Personal Commons";
        public string expectedUserNameOnPersonal;
        public string expectedUserNameOnProfilePage;
        public string expectedPvtMsgHeaderText = "PRIVATE MESSAGES";
        public string expectedMyInvitationHeaderText = "MY INVITATIONS";
        public string expectedTrainingAndfSupportHeaderText = "COMMONS RESOURCES AND SUPPORT";
        public string expectedCodeOfConductHeaderText = "CODE OF CONDUCT POLICY";
        public string expectedTourHeaderText = "TOUR THE COMMONS";
        public string expectedEngagementText = "engagement guidelines";
        public string expectedServiceDeskEmail = "servicedesk@ncu.edu";
        public string expectedFeedbckEmail = "commons@ncu.edu";
        public string expectedAlumniText = "alumni";
        public string expectedAlumniTourText = "Welcome";
        public string expectedAlumnititle = "WELCOME ALUMNUS TO THE COMMONS!";
        public string expectedAlumnigroupstitle = "GROUPS";


        #endregion Expected Texts

        #region Dashboard Page Objects
        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]
        public IWebElement myGroupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.nav__item:nth-child(1) > a:nth-child(1)")]
        public IWebElement lnkPersonalCommons { get; set; }


        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__logo > a")]
        //public IWebElement lnkPersonalCommons { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > header > div > div > div > div > span:nth-child(2) > a")]
        public IWebElement lblUserNameOnPersonalCommons { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div > div > header > div > div > div > div > span[class*='user-picture__default'] a")]
        //[FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > header > div > div > div > div > span.circle.user-picture__default > a")]
        public IWebElement pCommonsProfilePict { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(1) > a")]
        public IWebElement lnkPosts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(2) > a")]
        public IWebElement lnkComments { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='tour-profile-link']")]
        public IWebElement lnkProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div.views-row > div > div > h2")]
        public IWebElement lblUserNameOnProfilePage { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul/li[2]/a[contains(@href,'inbox')]")]
        public IWebElement lnkInbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-pagetitle-2 > h3")]
        public IWebElement lblPrivateMsgHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul/li[3]/a[contains(@href,'invitations')]")]
        public IWebElement lnkInvites { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > header > div > h2")]
        public IWebElement lblMyInvitationHeaderText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > div:nth-child(3) > ul > li")]
        public IList<IWebElement> lstGroups { get; set; }

        public string lblGrpNameCSS = "div > div > span > a";

        public string plusIconPostInGrpCSS = "div > div.allowed-content__container";

        [FindsBy(How = How.CssSelector, Using = "#group-header > div > div > a > h2")]
        public IWebElement lblGroupNameOnGrpHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-user-s-groups-block-1']/div[2]/div/div[2]/ul/li[4]/div/div[1]/span/a")]
        public IWebElement lbllibraryGroupNameOnGrpHeader { get; set; }


        [FindsBy(How = How.LinkText, Using = "NCU Community Forum")]
        public IWebElement lblNCUCommunityGroupNameOnGrpHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-user-s-groups-block-1']/div[2]/div/div[2]/ul/li[1]/div/div[1]/span/a")]
        public IWebElement Groupacademiccenter { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='alumni-optin']/p")]
        public IWebElement aluniOptin { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-confirmation-1']")]
        public IWebElement aluniOptinYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='browser-default']/li[3]/a")]
        public IWebElement alumniTour { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@id='tour-tip-welcome-commons-label']")]
        public IWebElement alumniTourText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role = 'dialog'] > h2#tour-tip-welcome-alumnus-to-the-commons-label")]
        public IWebElement alumniTourTitle { get; set; }
        

        [FindsBy(How = How.XPath, Using = "/html/body/div[11]/div/a[1]")]
        public IWebElement alumniTourNextbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[12]/div/a[1]")]
        public IWebElement alumniTourgrpbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div/a[1]")]
        public IWebElement alumniTouractivitybtn { get; set; }
        

        [FindsBy(How = How.XPath, Using = "/html/body/div[14]/div/a[1]")]
        public IWebElement alumniTourTopnavigationbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[15]/div/a[1]")]
        public IWebElement alumniTourpersonalcommonbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[16]/div/a[1]")]
        public IWebElement alumniTouradditionalsupportbtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role = 'dialog'] > h2#tour-tip-groups-label")]
        public IWebElement alumniTourgroupstitle { get; set; }

               

        #endregion Dashboard Page Objects

        #region Footer Section Page Objects

        [FindsBy(How = How.CssSelector, Using = "#footer > section > a")]
        public IList<IWebElement> lnkFooter { get; set; }

        public string lnkHome = "Home";
        public string lnkTrainingAndSupport = "Training and support";
        public string lnkServiceDesk = "Service desk";
        public string lnkFeedback = "Report an Issue";
        public string lnkCodeOfConduct = "Code of conduct";
        public string lnkEngagementGuidelines = "Engagement guidelines";
        public string lnkTours = "Tours";

        [FindsBy(How = How.CssSelector, Using = "#content > div > section > h1 > span")]
        public IWebElement lblTrainingAndSupportHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#page-title")]
        public IWebElement lblCodeOfConduct { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#content > div")]
        public IWebElement lblEngagementGuideContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-pagetitle-2 > h3")]
        public IWebElement lblToursContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='edit-preference-alumni-1']")]
        public IWebElement alumniDirOptin { get; set; }

        [FindsBy(How = How.Id, Using = "edit-membership-submit")]
        public IWebElement btnSave { get; set; }


        [FindsBy(How = How.XPath, Using = "//ul[@class='tabs light nub center-align processed']/li/a")]
        public IList<IWebElement> dirTabName { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-directory-all']/ul/li/div/a/i")]
        public IWebElement filterBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-directory-alumni']/ul/li/div/a/i")]
        public IWebElement filterBtnAlumni { get; set; }

        [FindsBy(How = How.Id, Using = "edit-name")]
        public IWebElement nameEnter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-specialization")]
        public IWebElement specializationEnter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-email")]
        public IWebElement eMailEnter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-city")]
        public IWebElement cityEnter { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[2]/div/div")]
        public IWebElement schoolDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[3]/div/div")]
        public IWebElement programDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[8]/div/div")]
        public IWebElement stateDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[9]/div/div")]
        public IWebElement countryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[10]/div/div")]
        public IWebElement millitaryDropdown { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[2]/div/div/ul/li[33]")]
        //public IWebElement programMBA { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[3]/div/div/ul/li/span")]
        public IList<IWebElement> programList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[8]/div/div/ul/li/span")]
        public IList<IWebElement> stateList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[9]/div/div/ul/li/span")]
        public IList<IWebElement> countryList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[10]/div/div/ul/li/span")]
        public IList<IWebElement> millitaryList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[2]/div/div/ul/li[3]")]
        public IWebElement schoolofBusiness { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement applyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@value='Reset']")]
        public IWebElement resetBtn { get; set; }

        [FindsBy(How = How.Id, Using = "navigation")]
        public IWebElement navigation { get; set; }
      

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']/div[@class='school']")]
        public IWebElement MemCardSchool { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']/div[@class='start-date']")]
        public IWebElement MemCardDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']")]
        public IWebElement MemCard { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/div/ul/li/div/div/div[@class='name']/a")]
        public IList<IWebElement> searchList { get; set; }

        #endregion Footer Section Page Objects

        #region Page Object Methods

        public void ClickOnProfilePicFromPersnlComns()
        {
            pCommonsProfilePict.Click();
        }

        public void ClickOnPersonalCommons()
        {
            lnkPersonalCommons.Click();
            PageServices.WaitForPageToCompletelyLoaded(commonDriver, 90);
            Thread.Sleep(2000);
        }

        public void VerifyPersonalCommonsLink()
        {
            //  Console.WriteLine("Personal Commons link  " +lnkPersonalCommons.GetAttribute("innertext"));
            Assert.IsTrue(lnkPersonalCommons.Displayed);
        }

        public void LandingPageLeftPane()
        {

            VerifyUserNameonPersonalCommons();
            VerifyPrivateInbox();
            VerifyMyInvitationOption();
            VerifyPostContentForGroupFromSideBar(0);
            VerifyPostContentForGroupFromSideBar(1);
            GroupNameLibraryGroupHeader();
            // GroupNameNCUcommunityGroupHeader();
            GroupNameASUGroupHeader();
            userInfo.ClickOnUserMenu();
            //userInfo.ClickOnSubMenu(userInfo.logoutSubMenu);


        }



        public void ClickOnPlusSignToPostInGroupOnSideBar(int index)
        {
            IWebElement group = lstGroups[index].FindElement(By.CssSelector(plusIconPostInGrpCSS));
            group.Click();

        }

        public void VerifyUserNameonPersonalCommons()
        {
            expectedUserNameOnPersonal = UserNameOnPersonalCommons();
            ClickOnProfilePicFromPersnlComns();
            Assert.AreEqual(expectedPostLinkText, PostLinkText());
            Assert.IsTrue(PersonalLinkText().Contains(expectedPrsnalText));
            ClickOnPersonalCommons();
            lnkProfile.Click();
            expectedUserNameOnProfilePage = UserNameOnProfilePage();
            Assert.AreEqual(expectedUserNameOnPersonal, expectedUserNameOnProfilePage);
        }

        public void VerifyPrivateInbox()
        {
            ClickOnPersonalCommons();
            lnkInbox.Click();
            Assert.AreEqual(expectedPvtMsgHeaderText, PrivateMsgHeaderText());
        }


        public void VerifyMyInvitationOption()
        {
            ClickOnPersonalCommons();
            lnkInvites.Click();
            Assert.AreEqual(expectedMyInvitationHeaderText, MyInvitationHeaderText());
        }

        public void VerifyPostContentForGroupFromSideBar(int groupIndex)
        {
            ClickOnPersonalCommons();
            Thread.Sleep(2000);
            Assert.AreEqual(GetGroupNameSideBarAndClick(groupIndex, true), GroupNameOnGroupHeader());
            ClickOnPersonalCommons();
            ClickOnPlusSignToPostInGroupOnSideBar(groupIndex);

        }

        #region Text Getter Methods

        public string UserNameOnPersonalCommons()
        {
            string userName = lblUserNameOnPersonalCommons.GetAttribute("innerText").ToString();
            Console.WriteLine(userName);
            return userName;
        }

        public string UserNameOnProfilePage()
        {
            string userName = lblUserNameOnProfilePage.GetAttribute("innerText").ToString();
            Console.WriteLine(userName);
            return userName;
        }

        public string MyGroupText()
        {
            string myGroup = myGroupText.GetAttribute("innerText").ToString();
            Console.WriteLine(myGroup);
            return myGroup;
        }

        public string CommentLinkText()
        {
            string txtComment = lnkComments.GetAttribute("innerText").ToString();
            Console.WriteLine(txtComment);
            return txtComment;
        }

        public string PostLinkText()
        {
            string txtPost = lnkPosts.GetAttribute("innerText").ToString();
            Console.WriteLine(txtPost);
            return txtPost;
        }

        public string PersonalLinkText()
        {
            string txtPersonalCommns = lnkPersonalCommons.GetAttribute("innerText").ToString();
            Console.WriteLine(txtPersonalCommns);
            return txtPersonalCommns;
        }

        public string AlumnioptInText()
        {
            string txtAlumniOptIn = aluniOptin.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniOptIn);
            return txtAlumniOptIn;
        }

        public string AlumniTourText()
        {
            string txtAlumniTour = alumniTourText.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniTour);
            return txtAlumniTour;
        }

        public string AlumniTouTitle()
        {
            string txtAlumnititle = alumniTourTitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumnititle);
            return txtAlumnititle;
        }

        public string Alumnitourgrouptitle()
        {
            string txtAlumnigroupstitle = alumniTourgroupstitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumnigroupstitle);
            return txtAlumnigroupstitle;
        }

        public string AlumnioptInYesText()
        {
            string txtAlumniOptInYes = aluniOptinYes.GetAttribute("checked").ToString();
            Console.WriteLine(txtAlumniOptInYes);
            return txtAlumniOptInYes;
        }



        public string PrivateMsgHeaderText()
        {
            string txtPvtMsgText = lblPrivateMsgHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(txtPvtMsgText);
            return txtPvtMsgText;
        }

        public string MyInvitationHeaderText()
        {
            string txtMyInvitation = lblMyInvitationHeaderText.GetAttribute("innerText").ToString();
            Console.WriteLine(txtMyInvitation);
            return txtMyInvitation;
        }

        public string GetGroupNameSideBarAndClick(int index, bool wantToAccessGroup)
        {
            IWebElement group = lstGroups[index].FindElement(By.CssSelector(lblGrpNameCSS));
            string groupName = group.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            if (wantToAccessGroup)
            {
                group.Click();
            }
            return groupName;
        }


        public string GroupNameOnGroupHeader()
        {
            string groupName = lblGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }

        public string GroupNameLibraryGroupHeader()
        {
            string groupName = lbllibraryGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }

        public string GroupNameNCUcommunityGroupHeader()
        {
            string groupName = lblNCUCommunityGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }

        public string GroupNameASUGroupHeader()
        {
            string groupName = Groupacademiccenter.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }
        #endregion Text Getter Methods

        //#region Footer Section Method   
        

        //        public void ClickOnPlusSignToPostInGroupOnSideBar(int index)
        //        {
        //            IWebElement group = lstGroups[index].FindElement(By.CssSelector(plusIconPostInGrpCSS));
        //            group.Click();

        //        }

        //        public void VerifyUserNameonPersonalCommons()
        //        {
        //            expectedUserNameOnPersonal = UserNameOnPersonalCommons();
        //            ClickOnProfilePicFromPersnlComns();
        //            Assert.AreEqual(expectedPostLinkText, PostLinkText());
        //            Assert.IsTrue(PersonalLinkText().Contains(expectedPrsnalText));
        //            ClickOnPersonalCommons();
        //            lnkProfile.Click();
        //            expectedUserNameOnProfilePage = UserNameOnProfilePage();
        //            Assert.AreEqual(expectedUserNameOnPersonal, expectedUserNameOnProfilePage);
        //        }

        //        public void VerifyPrivateInbox()
        //        {
        //            ClickOnPersonalCommons();
        //            lnkInbox.Click();
        //            Assert.AreEqual(expectedPvtMsgHeaderText, PrivateMsgHeaderText());
        //        }


        //        public void VerifyMyInvitationOption()
        //        {
        //            ClickOnPersonalCommons();
        //            lnkInvites.Click();
        //            Assert.AreEqual(expectedMyInvitationHeaderText, MyInvitationHeaderText());
        //        }

        //        public void VerifyPostContentForGroupFromSideBar(int groupIndex)
        //        {
        //            ClickOnPersonalCommons();
        //            Thread.Sleep(2000);
        //            Assert.AreEqual(GetGroupNameSideBarAndClick(groupIndex, true), GroupNameOnGroupHeader());
        //            ClickOnPersonalCommons();
        //            ClickOnPlusSignToPostInGroupOnSideBar(groupIndex);

        //        }

                //#region Text Getter Methods

                //public string UserNameOnPersonalCommons()
                //{
                //    string userName = lblUserNameOnPersonalCommons.GetAttribute("innerText").ToString();
                //    Console.WriteLine(userName);
                //    return userName;
                //}

                //public string UserNameOnProfilePage()
                //{
                //    string userName = lblUserNameOnProfilePage.GetAttribute("innerText").ToString();
                //    Console.WriteLine(userName);
                //    return userName;
                //}

                //public string MyGroupText()
                //{
                //    string myGroup = myGroupText.GetAttribute("innerText").ToString();
                //    Console.WriteLine(myGroup);
                //    return myGroup;
                //}

                //public string CommentLinkText()
                //{
                //    string txtComment = lnkComments.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtComment);
                //    return txtComment;
                //}
                //public string PostLinkText()
                //{
                //    string txtPost = lnkPosts.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtPost);
                //    return txtPost;
                //}

                //public string PersonalLinkText()
                //{
                //    string txtPersonalCommns = lnkPersonalCommons.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtPersonalCommns);
                //    return txtPersonalCommns;
                //}

                //public string AlumnioptInText()
                //{
                //    string txtAlumniOptIn = aluniOptin.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtAlumniOptIn);
                //    return txtAlumniOptIn;
                //}

                //public string AlumniTourText()
                //{
                //    string txtAlumniTour = alumniTourText.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtAlumniTour);
                //    return txtAlumniTour;
                //}

                //public string AlumnioptInYesText()
                //{
                //    string txtAlumniOptInYes = aluniOptinYes.GetAttribute("checked").ToString();
                //    Console.WriteLine(txtAlumniOptInYes);
                //    return txtAlumniOptInYes;
                //}



                //public string PrivateMsgHeaderText()
                //{
                //    string txtPvtMsgText = lblPrivateMsgHeader.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtPvtMsgText);
                //    return txtPvtMsgText;
                //}

                //public string MyInvitationHeaderText()
                //{
                //    string txtMyInvitation = lblMyInvitationHeaderText.GetAttribute("innerText").ToString();
                //    Console.WriteLine(txtMyInvitation);
                //    return txtMyInvitation;
                //}

                //public string GetGroupNameSideBarAndClick(int index, bool wantToAccessGroup)
                //{
                //    IWebElement group = lstGroups[index].FindElement(By.CssSelector(lblGrpNameCSS));
                //    string groupName = group.GetAttribute("innerText").ToString();
                //    Console.WriteLine(groupName);
                //    if (wantToAccessGroup)
                //    {
                //        group.Click();
                //    }
                //    return groupName;
                //}


                //public string GroupNameOnGroupHeader()
                //{
                //    string groupName = lblGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
                //    Console.WriteLine(groupName);
                //    return groupName;
                //}
                //#endregion Text Getter Methods

                #region Footer Section Method   
                public void VerifyFooterLinks()
                {
                    PageServices.WaitForPageToCompletelyLoaded(commonDriver, 60);
                    int linkCounts = lnkFooter.Count;
                    Console.WriteLine(linkCounts);
                    for (int i = 0; i < linkCounts; i++)
                    {
                        Console.WriteLine(lnkFooter[i].GetAttribute("innerText"));
                        if (lnkFooter[i].GetAttribute("innerText") == lnkHome)
                        {
                            lnkFooter[i].Click();
                            Thread.Sleep(2000);
                            Assert.IsTrue(PersonalLinkText().Contains(expectedPrsnalText));
                            ClickOnPersonalCommons();
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }

                        if (lnkFooter[i].GetAttribute("innerText") == lnkTrainingAndSupport)
                        {
                            lnkFooter[i].Click();
                            string actualText = lblTrainingAndSupportHeader.GetAttribute("innerText");
                            Console.WriteLine(actualText);
                            Assert.IsTrue(actualText.Contains(expectedTrainingAndfSupportHeaderText));
                            ClickOnPersonalCommons();
                            Thread.Sleep(3000);
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }

                        if (lnkFooter[i].GetAttribute("innerText") == lnkServiceDesk)
                        {
                            Console.WriteLine(lnkFooter[i].GetAttribute("href"));
                            Assert.IsTrue(lnkFooter[i].GetAttribute("href").Contains(expectedServiceDeskEmail));
                            ClickOnPersonalCommons();
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }

                        if (lnkFooter[i].GetAttribute("innerText") == lnkFeedback)
                        {
                            Console.WriteLine(lnkFooter[i].GetAttribute("href"));
                            Assert.IsTrue(lnkFooter[i].GetAttribute("href").Contains(expectedFeedbckEmail));
                            ClickOnPersonalCommons();
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }

                        if (lnkFooter[i].GetAttribute("innerText") == lnkCodeOfConduct)
                        {
                            lnkFooter[i].Click();
                            commonDriver.SwitchTo().Window(commonDriver.WindowHandles.Last());
                            string actualText = lblCodeOfConduct.GetAttribute("innerText");
                            Console.WriteLine(actualText);
                            Assert.IsTrue(actualText.Contains(expectedCodeOfConductHeaderText));
                            commonDriver.SwitchTo().Window(commonDriver.WindowHandles.Last()).Close();
                            commonDriver.SwitchTo().Window(commonDriver.WindowHandles.First());
                            ClickOnPersonalCommons();
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }

                        if (lnkFooter[i].GetAttribute("innerText") == lnkEngagementGuidelines)
                        {
                            lnkFooter[i].Click();
                            string actualText = lblEngagementGuideContent.GetAttribute("innerText");
                            Console.WriteLine(actualText);
                            Assert.IsTrue(actualText.Contains(expectedEngagementText));
                            ClickOnPersonalCommons();
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }

                        if (lnkFooter[i].GetAttribute("innerText") == lnkTours)
                        {
                            lnkFooter[i].Click();
                            string actualText = lblToursContent.GetAttribute("innerText");
                            Console.WriteLine(actualText);
                            Assert.IsTrue(actualText.Contains(expectedTourHeaderText));
                            ClickOnPersonalCommons();
                            PageServices.ScrollPageUptoBottom(commonDriver);
                            continue;
                        }
                    }
                }

                #endregion Footer Section Method 

                public void VerifyAlumniWelTour()
                {
                    ClickOnPersonalCommons();
                    PageServices.WaitForPageToCompletelyLoaded(commonDriver, 60);
                    // ClickOnPersonalCommons();
                    PageServices.ScrollPageUptoBottom(commonDriver);
                    int linkCounts = lnkFooter.Count;
                    Console.WriteLine(linkCounts);
                    for (int i = 0; i < linkCounts; i++)
                    {
                        Console.WriteLine(lnkFooter[i].GetAttribute("innerText"));
                        if (lnkFooter[i].GetAttribute("innerText") == lnkTours)
                        {
                            lnkFooter[i].Click();
                            string actualText = lblToursContent.GetAttribute("innerText");
                            Console.WriteLine(actualText);
                            Assert.IsTrue(actualText.Contains(expectedTourHeaderText));
                        }

                    }
                
                   alumniTour.Click();
                 //  Assert.IsTrue(AlumniTouTitle().Contains(expectedAlumniTourText));
                   Assert.IsTrue(AlumniTouTitle().Contains(expectedAlumnititle));
                  alumniTourNextbtn.Click();
                  Console.WriteLine(expectedAlumnititle);
                  Assert.IsTrue(Alumnitourgrouptitle().Contains(expectedAlumnigroupstitle));
                  alumniTourgrpbtn.Click();
                  Console.WriteLine(expectedAlumnigroupstitle);
                  alumniTouractivitybtn.Click();
                  Console.WriteLine("activity");
                  Thread.Sleep(4000);
                  alumniTourTopnavigationbtn.Click();
                  Console.WriteLine("topnavigation");
                  alumniTourpersonalcommonbtn.Click();
                  Console.WriteLine("personalcommon");
                  Thread.Sleep(3000);
                  alumniTouradditionalsupportbtn.Click();
                  Console.WriteLine("end");
                //ClickOnPersonalCommons();
        }

        public void VerifyfacultyTour()
        {
            ClickOnPersonalCommons();
            PageServices.WaitForPageToCompletelyLoaded(commonDriver, 60);
            // ClickOnPersonalCommons();
            PageServices.ScrollPageUptoBottom(commonDriver);
            int linkCounts = lnkFooter.Count;
            Console.WriteLine(linkCounts);
            for (int i = 0; i < linkCounts; i++)
            {
                Console.WriteLine(lnkFooter[i].GetAttribute("innerText"));
                if (lnkFooter[i].GetAttribute("innerText") == lnkTours)
                {
                    lnkFooter[i].Click();
                    string actualText = lblToursContent.GetAttribute("innerText");
                    Console.WriteLine(actualText);
                    Assert.IsTrue(actualText.Contains(expectedTourHeaderText));
                }

            }

            alumniTour.Click();
            Assert.IsTrue(AlumniTourText().Contains(expectedAlumniTourText));
            alumniTourNextbtn.Click();
            Console.WriteLine("FacultyWelcome");
            Thread.Sleep(3000);
            alumniTourgrpbtn.Click();
            Console.WriteLine("Facultygroup");
            alumniTouractivitybtn.Click();
            Console.WriteLine("Facultyactivity");
            Thread.Sleep(4000);
            alumniTourTopnavigationbtn.Click();
            Console.WriteLine("Facultytopnavigation");
            alumniTourpersonalcommonbtn.Click();
            Thread.Sleep(4000);
            Console.WriteLine("Facultypersonalcommon");
            Thread.Sleep(3000);
            alumniTouradditionalsupportbtn.Click();
            Console.WriteLine("Facultyend");
            //ClickOnPersonalCommons();
        }
        public void VerifyAlumniOptin()
                {
                    Assert.IsTrue(AlumnioptInText().Contains(expectedAlumniText));
                    Assert.IsTrue(AlumnioptInYesText().Contains("true"));

                }

        
                public void VerifyAlumniCardSelected()
                {
                    if (alumniDirOptin.Selected)
                    {
                         Console.WriteLine("Already selected");
                    }
                    else
                    {
                        alumniDirOptin.Click();
                        btnSave.Click();
                    }

                }

        public void SearchAlumni(string alumniName)
        {
            filterBtn.Click();
            nameEnter.SendKeys("Betsy Byrum");
            applyBtn.Click();
        }

        public void VerifyAlumniFilters()
        {
            NameFilter();
            SchoolFilter();
            ProgramFilter("MBA");

            specialisationFilter();

            eMailFilter();

            
        }

        public void VerifyAlumniStateFilters()
        {
                      
            cityFilter();
            StateFilter("CA");
            CountryFilter("US");
            MillitaryFilter("US Navy");

            Console.WriteLine("Last Line");
        }

        public void StateFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            stateDropdown.Click();
            Thread.Sleep(2000);
            int count = stateList.Count;
            Thread.Sleep(5000);
            for (int i = 0; i < count; i++)
            {
                if (stateList[i].Text.Equals(program))
                {
                    stateList[i].Click();
                }
            }
            Thread.Sleep(2000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" StateFilter completed");

        }

        public void CountryFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            countryDropdown.Click();
            Thread.Sleep(2000);
            int count = countryList.Count;
            Thread.Sleep(5000);
            for (int i = 0; i < count; i++)
            {
                if (countryList[i].Text.Equals(program))
                {
                    countryList[i].Click();
                }
            }
            Thread.Sleep(2000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" CountryFilter completed");
        }

        public void MillitaryFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            millitaryDropdown.Click();
            Thread.Sleep(1000);
            int count = millitaryList.Count;
            for (int i = 0; i < count; i++)
            {
                if (millitaryList[i].Text.Equals(program))
                {
                    millitaryList[i].Click();
                }
            }
            Thread.Sleep(2000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" MillitaryFilter completed");
        }

        public void cityFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            cityEnter.SendKeys("Orange");
            Thread.Sleep(2000);
            cityEnter.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" cityFilter completed");
        }

        public void eMailFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            eMailEnter.SendKeys("@o365");
            Thread.Sleep(1000);
            eMailEnter.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" eMailFilter completed");

        }

        public void specialisationFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            specializationEnter.SendKeys("Psychology");
            Thread.Sleep(1000);
            specializationEnter.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" specialisationFilter completed");
        }

        public void ProgramFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            programDropdown.Click();
            Thread.Sleep(1000);
            int count = programList.Count;
            for (int i=0;i< count;i++) {
                if (programList[i].Text.Equals(program)) {
                    programList[i].Click();
                }
            }
            Thread.Sleep(1000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" ProgramFilter completed");
        }

        public void SchoolFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            schoolDropdown.Click();
            Thread.Sleep(3000);
            schoolofBusiness.Click();
            Thread.Sleep(2000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine(" SchoolFilter completed");
        }

        public void NameFilter() {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            nameEnter.SendKeys("Dr.");
            Thread.Sleep(1000);
            nameEnter.SendKeys(Keys.Enter);
            //navigation.Click();
            //applyBtn.Click();

            Thread.Sleep(3000);
            int count = searchList.Count();
            Thread.Sleep(3000);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (searchList[i].Text.Contains("Dr."))
                    {
                        Console.WriteLine("Name Verified and the name is " + searchList[i].Text);
                    }

                }
            }
            else
            {
                Console.WriteLine("Search did not yeild any result");
            }
            Thread.Sleep(1000);
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            resetBtn.Click();
            Thread.Sleep(1000);
        }

        public void VerifySearchResult()
        {
            
                int count = searchList.Count();
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine("Verified and the name is " + searchList[i].Text);
                    }
                }
                else
                {
                    Console.WriteLine("Search did not yeild any result");
                }


            Thread.Sleep(2000);
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            resetBtn.Click();
            Thread.Sleep(4000);
            PageServices.WaitForPageToCompletelyLoaded(commonDriver, 90);
        }

        public void VerifyPlacardInfo()
        {
            //Assert.IsTrue(MemCardSchool.Text.Contains("School"));
            Assert.IsTrue(MemCardSchool.Displayed);
            Console.WriteLine("School Verified");
            Assert.IsTrue(MemCardDate.Displayed);
            //Assert.IsTrue(MemCardDate.Text.Contains("Started"));
            Console.WriteLine("Date Verified");
            Assert.IsTrue(MemCard.Displayed);
        }

       

        public void OpenDir(string dirName)
        {
            int count = dirTabName.Count;
            
            for (int i=0;i<= count; i++)
            {
                if (dirTabName[i].Text == dirName)
                    dirTabName[i].Click();
                }
                
            }
        }




        #endregion Page Object Methods



    }
        
    