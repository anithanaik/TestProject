using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClassLibrary1
{

    public class MyGroups
    {

        IWebDriver myGroupsDriver;
        CommonsGroups CommonsGroups;
        DiscoverGroup DiscoverGroup;
        public string sortByName = "Sort by Name";
        public MyGroups(IWebDriver driver)
        {
            myGroupsDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(myGroupsDriver, TimeSpan.FromSeconds(90)));
            CommonsGroups = new CommonsGroups(myGroupsDriver);
            DiscoverGroup = new DiscoverGroup(myGroupsDriver);
        }

        #region MyGroups Menu elements


        string DefGrpAcdSucCent = "Academic Success Center"; // Default Group academic-success-center

        string DefGrpCentFrTeachLearn = "Center for Teaching and Learning"; // Default Group center-for-teaching-and-learning

        string DefGrpNcuCommFrum = "NCU Community Forum"; // Default Group ncu-community-forum

        string DefGrpLibrInsd = "Library Insider"; // Default Group library-insider

        //public string DefJFKSchoolName = "JFK School Of Law Community Forum"; // Default Group jfk-school-of-law-community-forum
        public string DefJFKSchoolName = "JFK School of Law Community Forum";
        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]
        public IWebElement MyGroupsTopMenu { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div#user-account-menu > ul > li:nth-of-type(5) > a")]
        public IWebElement GroupMembershipsLink { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div.nav__item:nth-child(4) > a:nth-child(1)")]
        //public IWebElement MyGroupsTopMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li.dropdown-content--users-groups:nth-child(3) > a:nth-child(1)")]
        public IWebElement AllMyGroupsSubMenu { get; set; }

        //[FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-groups']//input[@placeholder='Filter groups']")]
        //public IWebElement Filtergroups { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#group-list > div > input#group-search")]
        public IWebElement Filtergroups { get; set; }



        [FindsBy(How = How.CssSelector, Using = "[placeholder='Filter groups']")]
        public IWebElement FiltergroupsSearch{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-list > div > div > div > div> ul > li > div > a > div.card-image > span")]
        public IWebElement CardTitle { get; set; }

        //[FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-groups']/div/div/div/ul/li/a")]
        //public IWebElement CardTitle { get; set; }

        //[FindsBy(How = How.XPath, Using = "//nav[@id='navigation']//a[@title='home']")]
        //public IWebElement CardTitle { get; set; }


        [FindsBy(How = How.XPath, Using = "//nav[@id='navigation']//a[@title='home']")]
        public IWebElement CommonsHome { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div  .name > a")] // "/html//div[@id='block-views-block-user-s-groups-block-1']//ul[@class='list']")]
        public IList<IWebElement> GroupsListHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div > div > div> ul > li > div > div > span > a")] 
        public IList<IWebElement> LeftSideGrpList { get; set; }

        

        [FindsBy(How = How.CssSelector, Using = "#group-header > div > div > a > h2")]
        public IWebElement GroupHeaderTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".list  a")]
        public IWebElement GroupNameAfterSearchInFilter{ get; set; }

        [FindsBy(How = How.XPath, Using = "//div/div[1]/ul[@class='list']/li")]
        public IList<IWebElement> listofGrops { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > header > input")]
        public IWebElement FilterAttHome { get; set; }
        [FindsBy(How = How.XPath, Using = "/html//div[@id='block-views-block-user-s-groups-block-1']//ul[@class='list']")]
        public IWebElement JFKAtHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/div[1]/ul[@class='list']/li[5]")]
        public IWebElement MyGroupScrollbar { get; set; }


        [FindsBy(How = How.XPath, Using = "//ul[@id='active-memberships']//li/a/span")]
        public IList<IWebElement> ActiveMembershipsList { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//ul[@id='terminated-memberships']//li/a/span")]
        public IList<IWebElement> TerminatedMembershipsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > li > .btn.dropdown-button.processed > .material-icons.right")]
        public IWebElement ActiveMembershipsOption { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[1]/li/ul[@safeclass~'\bdropdown-content\b']/?/?/a[@innertext='Leave']")]
        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > li > .dropdown-content > li:nth-of-type(3) > a")]
        public IWebElement ActiveMembershipsOptionLeave { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > li > .dropdown-content > li")]
        public IList<IWebElement> ActiveMembershipsOptions { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement LeaveGroup { get; set; }

        
        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > li > a:nth-of-type(1) > span")]
        public IWebElement FirstGroup { get; set; }

        
        [FindsBy(How = How.XPath, Using = "/html//section[@id='group-header']//div[@class='relative flex']/div/a/span")]
        public IWebElement JoinGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement JoinGroupconfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='terminated-memberships']//li/span")]
        public IList<IWebElement> LeftOnDateList { get; set; }





        #endregion MyGroups Menu elements

        //public void Sort(string sortBy)
        //{
        //    WebDriverExtensions.FindElement(myGroupsDriver, By.CssSelector(cssSelectorSort + sortBy + "']"), 30).Click();
        //    // Thread.Sleep(1000);

        //}

        public void VerifyingSortingOrder()
        {
            PageServices.ScrollIntoElement(myGroupsDriver, MyGroupScrollbar);
           // PageServices.ScrollPageUptoBottom(myGroupsDriver);
            //Sort(sortByName);

            Console.WriteLine(listofGrops.Count);
            var list = listofGrops.ToArray();
            Thread.Sleep(3000);
            Assert.IsTrue(list.OrderBy(c => c.Text).SequenceEqual(list));

        }

        public void VerifyingScrollbarOnMyGroupMenu()
        {

            int licount = (listofGrops.Count);
         IWebElement MyGroupScrollbar1= myGroupsDriver.FindElement(By.XPath("//div/div[1]/ul[@class='list']/li["+licount+"]"));

            PageServices.ScrollIntoElement(myGroupsDriver, MyGroupScrollbar1);

        }


        #region VerifyDefaultGroupAtMyGroups
        public void VerifyDefaultGroupAtMyGroups()
        {

             Filtergroups.Clear();
            Filtergroups.SendKeys(DefGrpAcdSucCent);
            Thread.Sleep(1000);
            string CardGrTitle1 = CardTitle.GetAttribute("innerText");
            Assert.IsTrue(CardGrTitle1.ToUpper().Contains(DefGrpAcdSucCent.ToUpper()));
            Console.WriteLine(DefGrpAcdSucCent + " AND " + CardGrTitle1);
            Filtergroups.Clear();
            Filtergroups.SendKeys(DefGrpCentFrTeachLearn);
            Thread.Sleep(1000);
            /*
            string CardGrTitle2 = CardTitle.GetAttribute("innerText");
            Assert.AreEqual(DefGrpCentFrTeachLearn.ToUpper(), CardGrTitle2.ToUpper());
            Console.WriteLine(DefGrpCentFrTeachLearn + " AND " + CardGrTitle2);
            Filtergroups.Clear();
            Filtergroups.SendKeys(DefGrpLibrInsd);
            Thread.Sleep(1000);
            string CardGrTitle3 = CardTitle.GetAttribute("innerText");
            Assert.AreEqual(DefGrpLibrInsd.ToUpper(), CardGrTitle3.ToUpper());
            Console.WriteLine(DefGrpLibrInsd + " AND " + CardGrTitle3);*/

        }

        public void VerifyGrouplinksAtMyGroups()
        {

        FiltergroupsSearch.Clear();
        FiltergroupsSearch.SendKeys(DefGrpAcdSucCent);
            string CardGrTitle1 = GroupNameAfterSearchInFilter.GetAttribute("innerText");
            Assert.AreEqual(DefGrpAcdSucCent, CardGrTitle1);
            Console.WriteLine(DefGrpAcdSucCent + " AND " + CardGrTitle1);
        FiltergroupsSearch.Clear();
            FiltergroupsSearch.SendKeys(DefGrpCentFrTeachLearn);
            string CardGrTitle2 = GroupNameAfterSearchInFilter.GetAttribute("innerText");
            Assert.AreEqual(DefGrpCentFrTeachLearn, CardGrTitle2);
            Console.WriteLine(DefGrpCentFrTeachLearn + " AND " + CardGrTitle2);
            FiltergroupsSearch.Clear();
            FiltergroupsSearch.SendKeys(DefGrpLibrInsd);
            string CardGrTitle3 = GroupNameAfterSearchInFilter.GetAttribute("innerText");
            Assert.AreEqual(DefGrpLibrInsd, CardGrTitle3);
            Console.WriteLine(DefGrpLibrInsd + " AND " + CardGrTitle3);

        }

        public void VerifyFilterIsAvailableAndClickOnAnyGroup()
        {
            Assert.IsTrue(FiltergroupsSearch.Displayed);
            FiltergroupsSearch.SendKeys(DefGrpAcdSucCent);

            GroupNameAfterSearchInFilter.Click();
            PageServices.WaitForPageToCompletelyLoaded(myGroupsDriver, 200);
            string GroupHeaderTitleAfterGroupIsOpened = GroupHeaderTitle.GetAttribute("innerText");

            Assert.AreEqual(DefGrpAcdSucCent, GroupHeaderTitleAfterGroupIsOpened);


        }

        #endregion VerifyDefaultGroupAtMyGroups


        #region VerifyDefaultNCUGroupAtMyGroups
        public void VerifyDefaultNCUGroupAtMyGroups()
        {

            Filtergroups.Clear();
            Filtergroups.SendKeys(CommonsGroups.ConversationGroupName);
            string CardGrNCUTitle = CardTitle.GetAttribute("innerText");
            Assert.IsTrue(CardGrNCUTitle.ToUpper().Contains(CommonsGroups.ConversationGroupName.ToUpper()));
            //Assert.AreEqual(DefGrpNcuCommFrum, CardGrNCUTitle);
            Console.WriteLine(DefGrpNcuCommFrum + " AND " + CardGrNCUTitle);

        }

        #endregion VerifyDefaultNCUGroupAtMyGroups


        #region VerifyDefaultJFKGroupAtMyGroups

        public void OpenJFKGroupFromMyGroup()
        {
            CardTitle.Click();
                                         
        }

        public void VerifyDefaultJFKGroupAtMyGroups()
        {

            Filtergroups.Clear();
            Filtergroups.SendKeys(DefJFKSchoolName);
            string CardJFKGrTitle = CardTitle.GetAttribute("innerText");
           // Assert.AreEqual(DefJFKSchoolName, CardJFKGrTitle);
            Console.WriteLine(DefJFKSchoolName + " AND " + CardJFKGrTitle);
           


        }



        public void OpenOpenGrpFromLeftSide(string GroupName)
        {
            Thread.Sleep(500);
            FilterAttHome.Clear();
            FilterAttHome.SendKeys(GroupName);
            //string CardJFKGrTitle = CardTitle.GetAttribute("innerText");
            //Console.WriteLine(DefJFKSchoolName + " AND " + CardJFKGrTitle);
            int LeftSideGroupCount = LeftSideGrpList.Count;
          //  IList<IWebElement> ls = WebDriverExtensions.FindElements(myGroupsDriver, By.CssSelector("#block-views-block-user-s-groups-block-1 > div > div > div> ul > li > div > div > span > a"), 90);
            for(int i=0;i<LeftSideGroupCount;i++)
            {
                string txt = LeftOnDateList[i].Text;
                if(txt.Contains(GroupName))
                {
                    LeftOnDateList[i].Click();
                    break;
                }
            }
           

        }
        #endregion VerifyDefaultJFKGroupAtMyGroups


        #region GotoAllMyGroupspage
        public void GotoAllMyGroupspage()
        {

            Assert.IsTrue(MyGroupsTopMenu.Displayed);
            Console.WriteLine("My Groups link available on the Top Menu Bar");
            MyGroupsTopMenu.Click();
            Assert.IsTrue(AllMyGroupsSubMenu.Displayed);
            AllMyGroupsSubMenu.Click();

        }


        #endregion GotoAllMyGroupspage





        #region VerifyJFKSchoolAthome

        public void VerifyAndOpenGropFromHome(string GrpName)
        {
            int Groupsnamecount = GroupsListHome.Count();
            for (int i = 0; i < Groupsnamecount; i++)
            {
                string verifyString = GroupsListHome[i].Text;

                if (verifyString.Contains(GrpName))
                {
                    
                    Console.WriteLine(verifyString + "Is Exist");
                    Thread.Sleep(1000);
                    GroupsListHome[i].Click();
                    break;
                }
                else
                {
                    Console.WriteLine(verifyString);
                }
            }


        }
        #endregion VerifyJFKSchoolAthome

        #region VerifyAlumniGroupAthome

        public void VerifyAlumniGroupAthome()
        {
            int Groupsnamecount = GroupsListHome.Count();
            Console.WriteLine(Groupsnamecount);
            for (int i = 0; i < Groupsnamecount; i++)
            {

                string verifyString = GroupsListHome[i].GetAttribute("innerText").ToString();
                if (verifyString.Contains("Placeholder for Alumni Group"))
                {

                    Console.WriteLine(verifyString + " is implemented.");
                                       
                }
                else
                {
                    Console.WriteLine(verifyString);
                    
                }
            }


        }
        #endregion VerifyAlumniGroupAthome

        #region VerifyGroupMemberships

        public void GotoGroupMembershipPage()
        {
            GroupMembershipsLink.Click();
        }

        public void VerifyGroupMemberships()
        {
            int GroupNamesCount1 = ActiveMembershipsList.Count();
            Console.WriteLine(GroupNamesCount1);
            for (int i = 0; i < GroupNamesCount1; i++)
            {
                Console.WriteLine(ActiveMembershipsList[i].Text);
                
            }
        }


        public void VerifyGroupMembershipView()
        {
            ActiveMembershipsOption.Click();
            int ActiveMembershipsOptionsCount = ActiveMembershipsOptions.Count();
            for (int i = 0; i < ActiveMembershipsOptionsCount; i++)
            {
                string Option = ActiveMembershipsOptions[i].Text;

                if (Option.Contains("View"))
                {
                    ActiveMembershipsOptions[i].Click();
                    Console.WriteLine("View Group Success");
                    PageServices.WaitForPageToCompletelyLoaded(myGroupsDriver, 100);
                    break;
                }
                else
                {
                    Console.WriteLine(Option);
                }
            }
            
        }

        public void VerifyGroupMembershipLeaveJoinagain()
        {
            
            string FirstGroupName = FirstGroup.Text;
            Console.WriteLine(FirstGroupName);
            ActiveMembershipsOption.Click();
            int ActiveMembershipsOptionsCount = ActiveMembershipsOptions.Count();
            for (int i = 0; i < ActiveMembershipsOptionsCount; i++)
            {
                string Option = ActiveMembershipsOptions[i].Text;
               
                if (Option.Contains("Leave"))
                {
                    ActiveMembershipsOptions[i].Click();
                    break;
                }
                
            }
            LeaveGroup.Click();
            Console.WriteLine("Group Membership Leave Success");
            myGroupsDriver.FindElement(By.LinkText(FirstGroupName)).Click();
            Console.WriteLine("Group Left is visible in Terminated List and navigated to that group");
            JoinGroup.Click();
            JoinGroupconfirm.Click();
            Console.WriteLine("Re-join Success");
                          
        }

       
        public void VerifyGroupTerminatedMembershipsList()
        {

            int GroupNamesCount2 = TerminatedMembershipsList.Count();
            for (int i = 0; i < GroupNamesCount2; i++)
            {
                Console.WriteLine(TerminatedMembershipsList[i].Text);
            }

            int LeftOnDateListCount = LeftOnDateList.Count();
            for (int i = 0; i < LeftOnDateListCount; i++)
            {
                Console.WriteLine(LeftOnDateList[i].Text);

                string LastDate = LeftOnDateList[i].Text;
                if (LastDate.Contains("Left on " + DateTime.Now.ToString("MM/dd/yyyy")))
                {
                    Console.WriteLine("Left On Date Verified");
                }
            }

        }

        #endregion VerifyGroupMemberships
    }
}
