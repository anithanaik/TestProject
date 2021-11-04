using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary1
{
    public class CommonsGroups
    {
        IWebDriver groupsDriver;
        UserInfo UserInfo;
        public CommonsGroups(IWebDriver driver)
        {
            groupsDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(groupsDriver, TimeSpan.FromSeconds(90)));
            UserInfo = new UserInfo(groupsDriver);
        }


        #region Group Page Elements
        //public string searchGroupName = "QA";
        //public string groupName = "QA Conversation Testing";
        //public string privateGroupName = "QA Conversation Private Testing";


        public string ConversationGroupName = "NCU Community Forum";
        public string PrivateGroupName = "NCU Faculty Senate";
        public string CommunityGroup = "Academic success center";
        // string conversationGroup = "QA Conversation Testing";


        public string actualMessage = "You have successfully joined this group";
        public string discoverGroupHeader = "DISCOVER GROUPS";
        public string memberMenu = "people";
        public string inviteeemail1 = "tempM.Farry9827@o365.ncu.edu,";
        public string inviteeemail2 = "tempM.Whitton5774@o365.ncu.edu";
        public string invalidemail1 = "invalidemail1@o365.ncu.edu,";
        public string invalidemail2 = "invalidemail2@o365.ncu.edu";

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        public IWebElement conversationFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-user-s-groups-block-1']/div[2]/div/footer/a")]
        public IWebElement discoverGroupsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1")]
        public IWebElement discoverPageTitle { get; set; }

        //[FindsBy(How = How.Id, Using = "group-search")]
        //public IWebElement filterGroupsSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"group-search\"]")]
        public IWebElement filterGroupsSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='navigation']/div/div[1]/a")]
        public IWebElement personalCommonsHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-submit']")]
        public IWebElement joinleaveGroup { get; set; }

        [FindsBy(How = How.LinkText, Using = "My groups")]
        public IWebElement myGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='group-header']/div/div/a/h2")]
        public IWebElement selectedGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/div/div/header/input")]
        public IWebElement newlyJoinedGroup { get; set; }

        [FindsBy(How = How.ClassName, Using = "light-add-content")]
        public IWebElement addContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[1]/div[4]/a")]
        public IWebElement member { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='membership']/li/a")]
        public IWebElement leaveGroupLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-list > div > div > div > div> ul > li")]
        public IList<IWebElement> groupList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/div/div/div/ul/li")]
        public IList<IWebElement> myGroupsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#messages > div > div > div.status-messages > div")]
        public IWebElement successMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-header > div > div.flex.flex-align-center.relative.flex-row > div.manage > a > i")]
        public IWebElement groupMenuLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#manage > li > a > i")]
        public IList<IWebElement> groupSubMenus { get; set; }


        //[FindsBy(How = How.XPath, Using = "//i[@class='material-icons left']")]
        //public IWebElement filterMembers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-group-members-page-1 > ul > li > div.collapsible-header > a > i")]
        public IWebElement filterMembers { get; set; }



        [FindsBy(How = How.Id, Using = "edit-field-name-value")]
        public IWebElement filterMembersSearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-submit-group-members")]
        public IWebElement filterMembersApplyBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".views-field.views-field-group-roles > ul > li")]
        public IWebElement memberRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Edit member')]")]
        public IWebElement editMemberRoleDD { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-group-roles']/div[2]/label[@class='option']")]
        public IWebElement stewardCheckBtnClick { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#edit-group-roles-community-steward")]
        //public IWebElement stewardCheckBtn { get; set; }
        // [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-community-steward")]
        [FindsBy(How = How.CssSelector, Using = "input[id$=-steward]")]
        //  "edit-group-roles-community-open-steward"
        public IWebElement StewardCheckBtn { get; set; }

        // [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-community-steward + label")]
        [FindsBy(How = How.CssSelector, Using = "input[id$=-steward] + label")]
        public IWebElement StewardCheckLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-conversation-steward")]
        public IWebElement StewardConGrpCheckBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-conversation-steward +label")]
        public IWebElement StewardConGrpCheckLabel { get; set; }
                       
        [FindsBy(How = How.CssSelector, Using = "#edit-submit")]
        public IWebElement saveBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".badge.ncu-red-color-back.new.no-after")]
        public IWebElement stewardIcon { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".material-icons.processed.tooltipped")]
        public IWebElement stewardListIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='stewards-list']//li ")]
        public IList<IWebElement> stewardList { get; set; }

        [FindsBy(How = How.CssSelector, Using = " .truncate")]
        public IWebElement stewardName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".m-0")]
        public IWebElement GroupIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='large material-icons']")]
        public IWebElement plusIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Conversation']")]
        public IWebElement postConversationIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='manage']/a/i")]
        public IWebElement MenuIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='manage']/ul/li[7]")]
        public IWebElement InviteDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn:nth-of-type(2) .material-icons")]
        public IWebElement InviteUserBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "textarea#edit-emails")]
        public IWebElement EmailTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='js-form-item form-item js-form-type-select form-item-group-invite-template js-form-item-group-invite-template input-field']/div/div/input")] // "input.select-dropdown.valid")]
        public IWebElement EmailTemplate { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='dropdown-content select-dropdown']/li")]
        public IList<IWebElement> EmailTemplateDrpDwnList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".js-form-item-group-invite-template li:nth-of-type(2) span")]
        public IWebElement EmailTemplateDrpDwnoption2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement InviteSubmitBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".status-messages__item")]
        public IWebElement statusmessage { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-group-invitations-page-1']/ul/li/div/a")]
        public IWebElement inviteSearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-group-invitations-page-1']/ul/li/div[2]/div/div/input")]
        public IWebElement Invitee { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-group-invitations-page-1']/ul/li/div[2]/div/div[2]/button")]
        public IWebElement ApplyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='block-views-block-user-s-groups-block-1']/div[2]/div//ul[@class='list']/li[2]/div//span/a[@href='/group/center-for-teaching-and-learning']")]
        public IWebElement CTLLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='cke_1_contents']/iframe")]

        public IWebElement ConvsFrame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html > body[class*='cke_editable']")]

        public IWebElement inputMessage { get; set; }


        [FindsBy(How = How.CssSelector, Using = "[aria-labelledby='cke_34_label'] .cke_button__drupalimage_icon")]

        public IWebElement wysiwygImg { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//input[@name='files[fid]']")]

        public IWebElement wysiwygupload { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".js-form-item-attributes-alt .form-text")]

        public IWebElement wysiwygText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='editor-image-dialog-form']//button[@name='op']")]

        public IWebElement SaveEmbImg { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//button[@id='edit-submit']")]

        public IWebElement postBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "/html//nav[@id='navigation']//a[@title='home']")]

        public IWebElement GoToHomePgae { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > article[role='article'] .contextual > .trigger.visually-hidden")]

        public IWebElement EditLastPostBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > article[role='article'] .contextual > .contextual-links > li:nth-of-type(1) > a")]

        public IWebElement EditPostLink { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input#edit-field-tags-target-id")]

        public IWebElement TagField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]

        public IWebElement SaveBttn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".nav__search #edit-search-api-fulltext")]

        public IWebElement GotoSearch { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#edit-submit-search-results")]

        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body")]

        public IWebElement ResultsBody { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='cke_1_contents']/iframe")]

        public IWebElement editPostFrame { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='views-infinite-scroll-content-wrapper clearfix']/div[3]/article/div/div[2]/div[2]/a")]
        public IWebElement clickComment { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/p")]
        public IWebElement description { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement post { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-infinite-scroll-content-wrapper clearfix']/div[3]/article/div/header/div/a")]
        public IWebElement verifyName { get; set; }

        #endregion Group Page Elements

        #region verifydiscoverGroups
        public void VerifydiscoverGroups( string GroupName)

        {
            Assert.IsTrue(discoverGroupsLink.Displayed);
            Console.WriteLine("Discover Groups link available");
            discoverGroupsLink.Click();
            Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
            filterGroupsSearch.Clear();           
            filterGroupsSearch.SendKeys(GroupName);
            Console.WriteLine("***** Group Searched ****");
        }

        //public void DiscoverAndSearchGroups(string groupName)
        //{
        //    Assert.IsTrue(discoverGroupsLink.Displayed);
        //    Console.WriteLine("Discover Groups link available");
        //    discoverGroupsLink.Click();
        //    Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
        //    filterGroupsSearch.Clear();
        //    filterGroupsSearch.SendKeys(groupName);
        //}

        #endregion verifydiscoverGroups
                  
       #region Join and Open Group

        public void JoinGroup(string groupName = "")
        {
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    if (cardLines[0].Equals(groupName) && cardLines[5].Contains("Join"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                        IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        groupsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        joinleaveGroup.Click();
                        break;
                    }
                    if (cardLines[0].Equals(PrivateGroupName) && cardLines[5].Contains("Private"))
                    {
                        Console.WriteLine("Group Name : " + groupName);
                        IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        break;
                    }
                    i++;
                }
            }

        }

        public void JoinConversationGroup()
        {
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    if (cardLines[0].Equals(ConversationGroupName) && cardLines[5].Contains("Join"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                        //"#group-list > div> div > div > div> ul > li > div > span > div > div > a.view"
                        
                        //IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        IWebElement joinMember = group.FindElement(By.CssSelector("div > span > div > div >span"));
                        string txt = joinMember.Text;
                        joinMember.Click();
                        groupsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        joinleaveGroup.Click();
                        Console.WriteLine("*************** Group Joined **************");
                        break;
                    }
                    if (cardLines[0].Equals(PrivateGroupName) && cardLines[5].Contains("Private"))
                    {
                        Console.WriteLine("Group Name : " + ConversationGroupName);
                        
                        IWebElement joinMember = group.FindElement(By.CssSelector("div > span > div > div >span.text-icon-container"));
                        //IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        Console.WriteLine("*************** Group Joined **************");
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        break;
                    }
                    if (cardLines[0].Equals(ConversationGroupName) && cardLines[5].Contains("You are a member"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                        IWebElement viewGoup = group.FindElement(By.CssSelector("div > span > div > div > span"));
                        viewGoup.Click();
                        groupsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        //joinleaveGroup.Click();
                        Console.WriteLine("*************** Group View Open **************");
                        break;
                    }

                    i++;
                }

            }
        }
        public void VerifyPrivateGroup()
        {
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    if (cardLines[0].Equals(PrivateGroupName) && cardLines[6].Contains("Private"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                        IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span[1]"));
                        joinMember.Click();
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        break;
                    }
                    i++;
                }

            }
        }

        public void OpenJoinedGroup_ByGroupName(string groupName)
        {
            myGroups.Click();
            newlyJoinedGroup.SendKeys(groupName);

            for (int i = 0; i < myGroupsList.Count; i++)
            {
                if (myGroupsList[i].Text.ToLower().Equals(groupName.ToLower()))
                {
                    myGroupsList[i].Click();
                    break;
                }
            }
            Assert.AreEqual(selectedGroup.Text.ToLower(), groupName.ToLower());
            Console.WriteLine("Selected Group : " + selectedGroup.Text);
        }

        public void OpenJoinedGroup()
        {
            myGroups.Click();
            newlyJoinedGroup.SendKeys(ConversationGroupName);

            for (int i = 0; i < myGroupsList.Count; i++)
            {
                if (myGroupsList[i].Text.Equals(ConversationGroupName))
                {
                    myGroupsList[i].Click();
                    Console.WriteLine("*************** Group Opened **************");
                    break;
                }
            }
            Assert.AreEqual(selectedGroup.Text, ConversationGroupName);
            Console.WriteLine("Selected Group : " + selectedGroup.Text);
        }

        public void JoinAndOpenGroup(string GroupName)
        {
            VerifydiscoverGroups(GroupName);
            JoinConversationGroup();
            OpenJoinedGroup();
            Thread.Sleep(2000);
            
        }

        public void commenton2ndPost()
        {
            clickComment.Click();
            Thread.Sleep(3000);

            groupsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            groupsDriver.SwitchTo().Frame(conversationFrame);
            description.Click();
            Actions a = new Actions(groupsDriver);
            a.Click(description).SendKeys("Test").Build().Perform();
            groupsDriver.SwitchTo().DefaultContent();

            Thread.Sleep(3000);
            post.Click();
            
        }

        public void VerifyNavigate()
        {
            if (verifyName.Displayed)
            {
                Console.WriteLine(verifyName.Text);
                Console.WriteLine("User is in focus");
            }
            else {
                Console.WriteLine("User not in focus");
            }

        }



        public void OpenJoinedGroup_SetStewardRole(string groupName)
        {
            OpenJoinedGroup_ByGroupName(groupName);
            groupMenuLink.Click();
            OpenGroupMenu(memberMenu);
            Console.WriteLine(UserInfo.userName.Text);
            filterMembers.Click();
            filterMembersSearchField.SendKeys(UserInfo.userName.Text);
           // filterMembersApplyBtn.ClickButton();
            MakeMemberSteward(true, false);
            VerifyStewardIcon(true);
        }


        #endregion Join and Open Group


        #region leavegroup
        public void Leavegroup()
        {
            member.Click();
            leaveGroupLink.Click();
            groupsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(1000);
               joinleaveGroup.Click();
            Console.WriteLine("*************** Group Leave **************");

        }
        #endregion leavegroup

        #region Manage Group
        public void OpenGroupMenu(string subGroupMenu)
        {
            Console.WriteLine(groupSubMenus.Count);

            for (int i = 0; i < groupSubMenus.Count; i++)
            {
                if (groupSubMenus[i].Text.Contains(subGroupMenu))
                {
                    groupSubMenus[i].Click();
                    break;
                }
            }
        }

        #endregion Manage Group

        #region Manage Member Role 
        public void MakeMemberSteward(bool isSteward)
        {
            editMemberRoleDD.Click();

            if (isSteward)
            {
                Console.WriteLine("Granting Steward Acess");
                //  bool stewardFlag = stewardCheckBtn.Selected;
                if (StewardCheckBtn.Selected)
                {
                    Console.WriteLine("Already a steward");
                }
                else
                {
                    stewardCheckBtnClick.Click();

                    Console.WriteLine("Steward access granted");
                }
            }
            else
            {
                Console.WriteLine("Revoking steward Access");
                //  bool stewardFlag = stewardCheckBtn.Selected;
                if (StewardCheckBtn.Selected)
                {
                    Thread.Sleep(2000);
                    stewardCheckBtnClick.Click();
                    Console.WriteLine("Steward access Revoked");
                }
                else
                {
                    Console.WriteLine("Not a steward in first place");
                }

            }
            saveBtn.Click();

        }


        public void MakeMemberSteward(bool isSteward, bool isConGrp)
        {

            editMemberRoleDD.Click();
            Console.WriteLine("******** Set Steward Role for Group ********");

            if (isSteward)
            {
                Console.WriteLine("Granting Steward Acess");             
                if (StewardCheckBtn.Selected)
                {
                    Console.WriteLine("Already a steward");
                }
                else
                {
                    StewardCheckLabel.Click();

                    Console.WriteLine("Steward access granted");
                }
            }
            else
            {
                Console.WriteLine("Revoking steward Access");               
                if (StewardCheckBtn.Selected)
                {
                    Thread.Sleep(2000);
                    StewardCheckLabel.Click();
                    Console.WriteLine("Steward access Revoked");
                }
                else
                {
                    Console.WriteLine("Not a steward in first place");
                }

            }
            saveBtn.Click();

        }

        #endregion Manage Member Role 

        public void VerifyStewardIcon(bool iconPresent)
        {
            Console.WriteLine("******* Verify Steward Icon ******");
            if (iconPresent)
            {
                Assert.IsTrue(stewardIcon.Displayed);
                Console.WriteLine("Steward Icon is displayed");
            }
            else
            {
                Console.WriteLine("Steward Icon is not displayed");
            }
        }



        public void StewardProfileClick()
        {
            stewardListIcon.Click();
            int stewardCounts = stewardList.Count;
            Console.WriteLine("No of stewards are :" + stewardCounts); // Number of stewards

            string stewardNameText = stewardName.Text; // Name of the steward in String

            for (int i = 0; i < stewardList.Count; i++)
            {
                if (stewardList[i].Text.Contains(stewardNameText))
                {
                    Console.WriteLine("Found the member : " + stewardList[i].Text);
                    IWebElement profile = stewardList[i];
                    profile.Click();        // Clicking on the steward profile
                    break;
                }
            }
        }

        public void postConversationtoGroup()
        {
            plusIcon.Click();
            postConversationIcon.Click();
            Console.WriteLine("Clicked on Post conversation");
        }

        public void filterGroupInvite()
        {
            Console.WriteLine("******** Verify Group Invite Filter  *******");
            MenuIcon.Click();
            Thread.Sleep(500);
            InviteDropdown.Click();
            Thread.Sleep(500);
            inviteSearchBtn.Click();
            Invitee.SendKeys("a");
            ApplyBtn.Click();
            Thread.Sleep(1000);

            inviteSearchBtn.Click();
            Invitee.Clear();
            Invitee.SendKeys("1");
            Thread.Sleep(2000);
            ApplyBtn.Click();
            Thread.Sleep(1000);

            inviteSearchBtn.Click();
            Invitee.Clear();
            Invitee.SendKeys(".");
            ApplyBtn.Click();
            Thread.Sleep(1000);
        }


        public void SendGroupInvite(String Inviteeemail1, String Inviteeemail2)
        {

            MenuIcon.Click();
            Thread.Sleep(500);
            InviteDropdown.Click();
            Thread.Sleep(500);
            InviteUserBtn.Click();
            Console.WriteLine("Invite Users Form is open.");
            EmailTextArea.SendKeys(Inviteeemail1);
            EmailTextArea.SendKeys(Inviteeemail2);
            EmailTemplate.Click();
            Thread.Sleep(1000);
            EmailTemplateDrpDwnoption2.Click();            
            PageServices.WaitForPageToCompletelyLoaded(groupsDriver, 60);
            InviteSubmitBtn.Click();
            string StatusMessage = statusmessage.GetAttribute("innerText");
            if (StatusMessage.Contains("Invitation has been sent"))
            {
                Console.WriteLine("Invitation Sent Successfully and Verified");
            }
            else if (StatusMessage.Contains("error has been found"))
            {
                Console.WriteLine("Error Message Verified");
            }
            else
            {
                Console.WriteLine("Test Case Fail");
            }
                        
            
        }

        #region EditAddTagLastPost
        public void EditAddTagLastPost()
        {
            GoToHomePgae.Click();
            PageServices.WaitForPageToCompletelyLoaded(groupsDriver, 60);
            EditLastPostBtn.Click();
            EditPostLink.Click();
            Thread.Sleep(3000);
            Console.WriteLine("Activity Post is open in Edit Mode.");
            PageServices.ScrollPageUptoBottom(groupsDriver);
            string tagcontent = "#AAMFT19";
            Actions a = new Actions(groupsDriver);
            groupsDriver.SwitchTo().Frame(editPostFrame);
            a.Click(inputMessage).SendKeys(tagcontent).Build().Perform();
            groupsDriver.SwitchTo().DefaultContent(); 
            SaveBttn.Click();
            PageServices.WaitForPageToCompletelyLoaded(groupsDriver, 60);
            GotoSearch.Clear();
            GotoSearch.SendKeys(tagcontent);
            Thread.Sleep(2000);
            btnSearch.Submit();
            int resultcount = 0;
            while (ResultsBody.Text.Contains(tagcontent))
            {
                resultcount++;
                if (resultcount == 2)
                {
                    break;
                }
            }
            Console.WriteLine("Result Body Contains Result");
           
        }

        #endregion EditAddTagLastPost

        #region WYSIWYGPost
        public void WYSIWYGPost(string uploadProfileImage)
        {
            Thread.Sleep(5000);
            CTLLink.Click();
            plusIcon.Click();
            postConversationIcon.Click();
            Thread.Sleep(2000);
           
            Actions b = new Actions(groupsDriver);
            groupsDriver.SwitchTo().Frame(ConvsFrame);
            b.Click(inputMessage).SendKeys("Just for Testing WYSIWYG with Image1.").Build().Perform();
            Thread.Sleep(3000);
            groupsDriver.SwitchTo().DefaultContent();
            Console.WriteLine("Clicked on Post conversation");
            wysiwygImg.Click();
            Console.WriteLine("Image Embed option is open");
            Thread.Sleep(3000);
            wysiwygupload.SendKeys(uploadProfileImage);
            Console.WriteLine("Image is Selected");
            Thread.Sleep(2000);
            wysiwygText.Click();
            wysiwygText.SendKeys("Just for testing");
            Thread.Sleep(1000);
            SaveEmbImg.Click();
            Thread.Sleep(2000);
            Console.WriteLine("Image is embedded");
            Actions a = new Actions(groupsDriver);
            groupsDriver.SwitchTo().Frame(ConvsFrame);
            a.Click(inputMessage).SendKeys("Testing WYSIWYG Testing 1 Testing 2 Testing 3 ").Build().Perform();
            groupsDriver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            postBtn.Click();
            Console.WriteLine("Embedded Image Message Typed and Posted");

        }

        #endregion WYSIWYGPost     
        
        
    }
}