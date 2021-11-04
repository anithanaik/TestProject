using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Data;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary1
{ 
    public class MembershipDirectory
    {

        IWebDriver MembershipDirectoryDriver;

        public MembershipDirectory(IWebDriver driver)
        {
            MembershipDirectoryDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(MembershipDirectoryDriver, TimeSpan.FromSeconds(90)));
        }

        #region MembershipDirectory elements

        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div:nth-child(4) > a")]
        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div[class='nav__item nav__user-personal']>a[href='/membership-directory']")]
        public IWebElement DirectoryTopMenu { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-directory-all']/ul/li/div[1]/a/span")]
        [FindsBy(How = How.CssSelector, Using = ".text-icon-container span")]
        public IWebElement FilterExpand { get; set; }


        [FindsBy(How = How.Name, Using = "Reset")]
        public IWebElement Reset { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>select#edit-state")]
        public IWebElement  StatesdropdownList { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-submit-directory']")]
        public IWebElement ApplyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-header']/div[@class='location']")]
        public IWebElement CardInfo { get; set; }


        //[FindsBy(How = How.XPath, Using = "//section[@id='content']/div/ul//a[@href='/membership-directory/student']")]
        [FindsBy(How = How.LinkText, Using = "STUDENT")]
        public IWebElement MemDirStudentTab { get; set; }

        //[FindsBy(How = How.XPath, Using = "//section[@id='content']/div/ul//a[@href='/membership-directory/faculty']")]
        [FindsBy(How = How.LinkText, Using = "FACULTY")]
        public IWebElement MemDirFacultyTab { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//form[@id='views-exposed-form-directory-student']/ul[@class='collapsible exposed-form-collapsible']//span[.='Filter']")]
        public IWebElement ExpandFilterStd { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//form[@id='views-exposed-form-directory-faculty']/ul[@class='collapsible exposed-form-collapsible']//span[.='Filter']")]
        public IWebElement ExpandFilterFclt { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']/div[@class='school']")]
        public IWebElement MemCardSchoolName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit_school_chosen']/a[@class='chosen-single']")]
        public IWebElement memdir { get; set; }


        //[FindsBy(How = How.XPath, Using = "//div[@id='edit_school_chosen']/div[@class='chosen-drop']/ul/li")]
        //public IList<IWebElement> options { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-school']>div")]
        public IWebElement SchoolDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > h1")]
        public IWebElement MemeberShipTitile { get; set; }

        [FindsBy(How =How.CssSelector,Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-school']>div>div>ul>li")]
        IList<IWebElement> schollList { get; set; }
        #endregion MembershipDirectory elements


        #region GotoMembershipDirectorypage

        public void GotoMembershipDirectorypage()
        {
            DirectoryTopMenu.Click();
            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            string MemberShipPageTitile = MemeberShipTitile.GetAttribute("innerText");
            Console.WriteLine(MemberShipPageTitile);
            Assert.AreEqual("MEMBERSHIP DIRECTORY", MemberShipPageTitile);
        }

        #endregion GotoMembershipDirectorypage

        #region VerifyStatesNAimplementation_All
        public void VerifyStatesNAimplementation_All()
        {

            FilterExpand.Click();
            Thread.Sleep(2000);
          
            Console.WriteLine("States drop down field is clicked.");
            SelectElement options = new SelectElement(StatesdropdownList);           
            Console.WriteLine("States options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("N/A"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(1000);
                    break;
                }
                

            }

            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            ApplyBtn.Click();
            Assert.IsTrue(CardInfo.Text.Contains(" "));
            Thread.Sleep(3000);
            Console.WriteLine("Not applicable state shows up blank space");


        }

        #endregion VerifyStatesNAimplementation_All


        public void Resetss()
        {
            Reset.Click();
        }


            public void SelectValueFromStateDropdown_All()
        {
            FilterExpand.Click();
            Thread.Sleep(2000);
            Console.WriteLine("States drop down field is clicked.");
            SelectElement options = new SelectElement(StatesdropdownList);
            Console.WriteLine("States options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("AR"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(3000);
                    break;
                }


            }

            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            ApplyBtn.Click();
            //Assert.IsTrue(CardInfo.Text.Contains("AR"));
            Thread.Sleep(3000);
            Console.WriteLine("Value Selected From State Dropdown_All and Results are displayed");


        }

        #region VerifyStatesNAimplementation_Student

        public void VerifyStatesNAimplementation_Student()
        {
            MemDirStudentTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            ExpandFilterStd.Click();
            Thread.Sleep(2000);
            SelectElement options = new SelectElement(StatesdropdownList);
             Console.WriteLine("States options are listed");

            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("N/A"))
                {

                   Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(1000);
                    break;
                }               
            }

            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            ApplyBtn.Click();
            Assert.IsTrue(CardInfo.Text.Contains(" "));
            Thread.Sleep(3000);
            Console.WriteLine("Not applicable state shows up blank space");
        }

        #endregion VerifyStatesNAimplementation_Student
        

        #region VerifyStatesNAimplementation_Faculty

        public void VerifyStatesNAimplementation_Faculty()
        {
            MemDirFacultyTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            ExpandFilterFclt.Click();
            Thread.Sleep(2000);
            SelectElement options = new SelectElement(StatesdropdownList);          
            Console.WriteLine("States options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);
            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("N/A"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
               

                PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
            ApplyBtn.Click();
            Assert.IsTrue(CardInfo.Text.Contains(" "));
            Thread.Sleep(3000);
            Console.WriteLine("Not applicable state shows up blank space");
        }

        #endregion VerifyStatesNAimplementation_Faculty

        #region VerifyLawSchoolMemDir

        public void VerifyLawSchoolMemDir()
        {
            FilterExpand.Click();
            Thread.Sleep(2000);          
            Console.WriteLine("School drop down field is clicked.");
            Console.WriteLine("School options are listed");
           
            SchoolDropDown.Click();
            Thread.Sleep(2000);        


            int schoolListCount = schollList.Count;

            for (int i = 0; i < schoolListCount; i++)
            {
                if (schollList[i].Text.Contains("School of Law"))
                {

                    Console.WriteLine(schollList[i].Text + "'School of Law' Implemented");
                    schollList[i].Click();
                    Thread.Sleep(2000);
                    break;
                }

            }

            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 160);
            ApplyBtn.Click();
            Thread.Sleep(3000);
            Console.WriteLine(MemCardSchoolName.Text);
            Assert.IsTrue(MemCardSchoolName.Text.Contains("School of Law"));
            Thread.Sleep(1000);
            Console.WriteLine("School of Law is displayed for the JFK User");
        }

        #endregion VerifyLawSchoolMemDir

        #region OpenMemDirStudentTab

        public void OpenMemDirStudentTab()
        {
            PageServices.ScrollPageUptoTop(MembershipDirectoryDriver);
            MemDirStudentTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
        }

        #endregion OpenMemDirStudentTab


        #region OpenMemDirFacultyTab

        public void OpenMemDirFacultyTab()
        {
            PageServices.ScrollPageUptoTop(MembershipDirectoryDriver);
            MemDirFacultyTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(MembershipDirectoryDriver, 60);
        }

        #endregion OpenMemDirFacultyTab

    }
}