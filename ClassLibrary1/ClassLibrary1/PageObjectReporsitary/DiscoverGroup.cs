using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace ClassLibrary1
{
   public class DiscoverGroup
    {
        IWebDriver discoverDriver;
        CommonsGroups cmGrps;

        #region Expected String
        public string pubicGroup = "Public";
        public string openGroup = "Open";
        public string privateGroup = "Private";
        public string viewString = "View";
        public string joinString = "Join";
        public string sortByRecommended = "Sort by Recommended";
        public string sortByCreated = "Sort by Created";
        public string sortByName = "Sort by Name";
        public string alreadyMember = "You are a member";

        #endregion Expected String

        #region Page Objects

        [FindsBy(How = How.CssSelector, Using = "#group-list > div:nth-child(2) > div > div > div:nth-child(2) > ul > li")]
                                                
        public IList<IWebElement> groups { get; set; }

        [FindsBy(How =How.CssSelector,Using = "#group-list > div:nth-child(2) > div > div > div:nth-child(2) > ul > li > div > span > div > div > a.view")]
        public IList<IWebElement> lnkView { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-list > div:nth-child(2) > div > div > div:nth-child(2) > ul > li > div > span > div > div > span > a")]
        public IList<IWebElement> lnkJoin { get; set; }
     
        [FindsBy(How = How.CssSelector, Using = "#group-list > div:nth-child(2) > div > div > div:nth-child(2) > ul > li > div > span > div > div >  span.text-icon-container")]
        public IList<IWebElement> pvtGroups { get; set; }

        public string cssSelectorSort = "div.sort-wrapper > span[title='";

        [FindsBy(How = How.CssSelector, Using = "#group-list > div:nth-child(2) > div > div > div:nth-child(2) > ul > li > div > span > div > div > span > span")]
        public IList<IWebElement> lblYourAreMember { get; set; }


        #endregion Page Objects


        public DiscoverGroup(IWebDriver driver)
        {
            discoverDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(discoverDriver, TimeSpan.FromSeconds(60)));
            cmGrps = new CommonsGroups(discoverDriver);
        }

        public void Sort(string sortBy)
        {
            WebDriverExtensions.FindElement(discoverDriver, By.CssSelector(cssSelectorSort + sortBy + "']"),30).Click();
            // Thread.Sleep(1000);
            Console.WriteLine("Sort: " + sortBy);
        }

        public void DiscoverGroup_VerifyViewAndJoinAndPrivate_Sorting(string groupType,bool isExistedMember)
        {
            cmGrps.filterGroupsSearch.Clear();
            cmGrps.filterGroupsSearch.SendKeys(groupType);
            Console.WriteLine(groupType);
            Sort(sortByName);                    
            Console.WriteLine(groups.Count);
            var list = groups.ToArray();
            Assert.IsTrue(list.OrderBy(c => c.Text).SequenceEqual(list));           
            Sort(sortByRecommended);                     
            Assert.IsTrue(list.OrderBy(c => c.Text).SequenceEqual(list));          
            Sort(sortByCreated);       
            Assert.IsTrue(list.OrderBy(c => c.Text).SequenceEqual(list));         
            int groupCount = 0;
            if (groupType == pubicGroup || groupType == openGroup)
            {            
               groupCount = groups.Count;
                for (int i = 0; i <=groupCount-1; i++)                 
                {
                    string viewText = lnkView[i].GetAttribute("innerText");
                    Console.WriteLine(viewText);
                    Assert.AreEqual(viewText, viewString);
                    string joinText = lnkJoin[i].GetAttribute("innerText");
                    Console.WriteLine(joinText);
                    Assert.AreEqual(joinText, joinString);
                }
             
            }
            if(groupType==privateGroup)
            {
                groupCount = groups.Count;
                Console.WriteLine(groupCount);

                for (int i = 0; i < groupCount-1; i++)
                {
                    string pvtText = pvtGroups[i].GetAttribute("innerText");
                    string[] lines = pvtText.Split('\n');
                    Console.WriteLine(lines[1]);                
                    Assert.AreEqual(lines[1].Trim(),privateGroup.Trim());                
                }

            }
            if(isExistedMember)
            {
                groupCount = groups.Count;
                for (int i = 0; i < groupCount; i++)
                {
                    string viewText = lnkView[i].GetAttribute("innerText");
                    Console.WriteLine(viewText);
                    Assert.AreEqual(viewText, viewString);
                    string alreadyText = lblYourAreMember[i].GetAttribute("innerText");
                    Console.WriteLine(alreadyText);
                    Assert.AreEqual(alreadyText, alreadyMember);
                }
            }
        }


        public void DiscoverAndJoinGroup(string groupName = "")
        {
            Assert.IsTrue(cmGrps.discoverGroupsLink.Displayed);
            Console.WriteLine("Discover Groups link available");
            Assert.IsTrue(cmGrps.discoverGroupsLink.Displayed);
           cmGrps. discoverGroupsLink.Click();
            Assert.AreEqual(cmGrps.discoverPageTitle.Text, cmGrps.discoverGroupHeader);
            cmGrps.filterGroupsSearch.Clear();
            discoverDriver.Navigate().Refresh();
            Thread.Sleep(1000);
            cmGrps.filterGroupsSearch.SendKeys(groupName);
           
          int groupCount = 0;
            groupCount = groups.Count;
            for (int i = 0; i < groupCount; i++)
            {
                string viewText = lnkView[i].GetAttribute("innerText");
                Console.WriteLine(viewText);
                Assert.AreEqual(viewText, viewString);
                if(!discoverDriver.PageSource.Contains("You are a member"))
                {
                    string joinText = lnkJoin[i].GetAttribute("innerText");
                    Console.WriteLine(joinText);
                    Assert.AreEqual(joinText, joinString);
                    lnkJoin[i].Click();
                    cmGrps.joinleaveGroup.Click();

                }
                
               
            }
        }

    }
}
