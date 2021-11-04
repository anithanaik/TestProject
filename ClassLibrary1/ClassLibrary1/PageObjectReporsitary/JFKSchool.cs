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

namespace ClassLibrary1
{
    public class JFKSchool
    {
        IWebDriver jfkschoolDriver;
        //UserInfo UserInfo;
        public JFKSchool(IWebDriver driver)
        {
            jfkschoolDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(jfkschoolDriver, TimeSpan.FromSeconds(90)));
            //UserInfo = new UserInfo(jfkschoolDriver);
        }


        #region JFKSchool Elements

        

        string DefGrpAcdSucCent = "Academic Success Center"; // Default Group academic-success-center

        string DefGrpCentFrTeachLearn = "Center For Teaching And Learning"; // Default Group center-for-teaching-and-learning

        public string DefJFKSchoolName = "JFK School Of Law Community Forum"; // Default Group jfk-school-of-law-community-forum

        string DefGrpLibrInsd = "Library Insider"; // Default Group library-insider

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]
        public IWebElement MyGroupsTopMenu { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div.nav__item:nth-child(4) > a:nth-child(1)")]
        //public IWebElement MyGroupsTopMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li.dropdown-content--users-groups:nth-child(3) > a:nth-child(1)")]
        public IWebElement AllMyGroupsSubMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-search")]
        public IWebElement Filtergroups { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".card-title")]
        public IWebElement CardTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav[@id='navigation']//a[@title='home']")]
        public IWebElement CommonsHome { get; set; }


        [FindsBy(How = How.XPath, Using = "/html//div[@id='block-views-block-user-s-groups-block-1']//ul[@class='list']")]
        public IList<IWebElement> GroupsListHome { get; set; }

        
        #endregion JFKSchool Elements


        #region VerifyDefaultJFKGroupAtMyGroups
        public void VerifyDefaultJFKGroupAtMyGroups()
        {
            
            Assert.IsTrue(MyGroupsTopMenu.Displayed);
            Console.WriteLine("My Groups link available on the Top Menu Bar");
            MyGroupsTopMenu.Click();
            Assert.IsTrue(AllMyGroupsSubMenu.Displayed);
            AllMyGroupsSubMenu.Click();
            Filtergroups.Clear();
            Filtergroups.SendKeys(DefGrpAcdSucCent);
            string CardGrTitle1 = CardTitle.GetAttribute("innerText");
            Assert.AreEqual(DefGrpAcdSucCent, CardGrTitle1);
            Console.WriteLine(DefGrpAcdSucCent + " AND " + CardGrTitle1);
            Filtergroups.Clear();
            Filtergroups.SendKeys(DefGrpCentFrTeachLearn);
            string CardGrTitle2 = CardTitle.GetAttribute("innerText");
            Assert.AreEqual(DefGrpCentFrTeachLearn, CardGrTitle2);
            Console.WriteLine(DefGrpCentFrTeachLearn + " AND " + CardGrTitle2);
            Filtergroups.Clear();
            Filtergroups.SendKeys(DefJFKSchoolName);
            string CardGrTitle3 = CardTitle.GetAttribute("innerText");
            Assert.AreEqual(DefJFKSchoolName, CardGrTitle3);
            Console.WriteLine(DefJFKSchoolName + " AND " + CardGrTitle3);
            Filtergroups.Clear();
            Filtergroups.SendKeys(DefGrpLibrInsd);
            string CardGrTitle4 = CardTitle.GetAttribute("innerText");
            Assert.AreEqual(DefGrpLibrInsd, CardGrTitle4);
            Console.WriteLine(DefGrpLibrInsd + " AND " + CardGrTitle4);

            CommonsHome.Click();
            Thread.Sleep(1000);
        }

        #endregion VerifyDefaultJFKGroupAtMyGroups

        #region VerifyJFKSchoolAthome

        public void VerifyJFKSchoolAthome()
        {
            int Groupsnamecount = GroupsListHome.Count();
            for (int i = 0; i < Groupsnamecount; i++)
            {
                string verifyString = GroupsListHome[i].Text;

                if (verifyString.Contains("JFK School of Law Community Forum"))
                {

                    Console.WriteLine(verifyString + "JFK School of Law Community Forum Implemented");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine(verifyString);
                }
            }

            
        }
        #endregion VerifyJFKSchoolAthome


    }
}
