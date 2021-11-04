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
  public class SearchPage
    {

        IWebDriver WebDriver;

        #region String Section
        public string titleName = "QA Testing Title Automation";
        public string expectSearchValue = "QA";
        public string expectSearchProfileSearch = "Profile";
        public string expectSearchMenu = "LinkedIn";
        public string expectSearchMenuPSY = "PSY";
        public string nonExpectSearchValue = "QAsfjkhdjkfdsfsdfjksdjkfds8230239823";
        public string noResult = "Your search did not yield any results.";
        public string noResultSuggestion = "Make sure all words are spelled correctly and try more general keywords.";
        public string expectSearchContentTitle = "Just for testing";
        public string expectSearchContentDescription = "#Testing$QA#TEST";

        #endregion String Section

        #region Search PageElement
        //[FindsBy(How = How.CssSelector, Using = "input[id^= 'edit-search-api-fulltext']")]
        [FindsBy(How = How.CssSelector, Using = "input[id^= 'edit-search-api-fulltext']")]
        public IWebElement inputSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[id^='edit-submit-search-results']")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div.no-results > p.no-results.text-align-left")]
        public IWebElement noSearchResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div> div > div.no-results >  p.no-results-sub.text-align-left")]
        public IWebElement noSearchResultSugesstion { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div.search-result-item")]
        public IList<IWebElement> searchResultCount { get; set; }

        [FindsBy(How =How.CssSelector,Using ="#content > div > div.views-element-container.contextual-region > div > header")]
        IWebElement lblTotalResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to next page']")]
        IWebElement btnNextPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to previous page']")]
        IWebElement btnPreviousPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to last page']")]
        IWebElement btnLastPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to first page']")]
        IWebElement btnFirstPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@data-tooltip='Group Steward'][1]")]
        public IWebElement stewardIcon { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#edit-search-api-fulltext--3")]
        //[FindsBy(How = How.CssSelector, Using = "input[data-drupal-selector='edit-search-api-fulltext']")]
        [FindsBy(How = How.CssSelector, Using = "input[id^= 'edit-search-api-fulltext']")]
        public IWebElement inputSearchMenuSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@value='- Any -']/..)[3]")]
        public IWebElement TypeFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@value='Relevance']/..)[3]")]
        public IWebElement SortByFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@value='Desc']/..)[3]")]
        public IWebElement OrderFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[3]")]
        public IWebElement FilterSearchButton { get; set; }

        /* Search - by Shashi  */
        [FindsBy(How = How.XPath, Using = "(//div[@class='post__content--body']/div/p[1])[1]")]
        public IWebElement verifyContenTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='post__content--body']/div/p[2])[1]")]
        public IWebElement verifyContentDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='intro-container']/a/h2)[1]")]
        public IWebElement verifyGroupTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='entity__intro--description']/p)[1]")]
        public IWebElement verifyGroupDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='user-picture__large']/../*[2]/h2)[1]")]
        public IWebElement verifyPersonTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='contextual']/button)[1]")]
        public IWebElement clickOnGruopPencilIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[2]/div/div[2]/div[1]/div[1]/div/ul/li")]
        IList<IWebElement> clickOnContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='collapsible-header']/a/span")]
        public IWebElement clickOnGroupFilterContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div)[3]")]
        public IWebElement clickOnGroupTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-actions']/button")]
        public IWebElement ClickOnApplyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[2])[3]")]
        public IWebElement selectConversationTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[3])[3]")]
        public IWebElement selectEventTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[4])[3]")]
        public IWebElement selectUploadTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[5])[3]")]
        public IWebElement selectVideoTypeContent { get; set; }

        #endregion Search PageElement


        public SearchPage(IWebDriver driver)
        {
            WebDriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(WebDriver, TimeSpan.FromSeconds(90)));
        }


        #region Page Methods
       
        public void ExpectedResultSearch(string expectSearchValue)
        {
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchValue +Keys.Enter);
            Thread.Sleep(3000);
            PageServices.WaitForPageToCompletelyLoaded(WebDriver, 120);
            //btnSearch.Submit();
            Console.WriteLine("Total number of search outcome: " + searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
            Console.WriteLine("****** Search with Result Complete *******");
        }
        public void ExpectedResultSearch2()
        {
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchProfileSearch + Keys.Enter);
            //Thread.Sleep(5000);
            PageServices.WaitForPageToCompletelyLoaded(WebDriver, 120);
            Console.WriteLine(searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
        }

        public void ExpectedResultFromSearchMenuSearch()
        {
            inputSearch.Clear();
           // inputSearchMenuSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchMenu + Keys.Enter);
            //inputSearchMenuSearch.SendKeys(expectSearchValue3 + Keys.Enter);
            // inputSearchMenuSearch.SendKeys(expectSearchValue3 + Keys.Enter);
            PageServices.WaitForPageToCompletelyLoaded(WebDriver, 120);
            Console.WriteLine(searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
        }

        public void VerifySearchOptionAvailableOnAlication()
        {
            Console.WriteLine("Searc OPtion  " +inputSearch.GetAttribute("innertext"));
            Assert.AreEqual(inputSearch.GetAttribute("innertext"), "Search");
        }
            
        public void ExpectedResultFromSearchMenuSearch2()
        {
            inputSearch.Clear();
            //inputSearchMenuSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchMenuPSY + Keys.Enter);
            PageServices.WaitForPageToCompletelyLoaded(WebDriver, 120);
            Console.WriteLine(searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
        }
        public void NoResultSearch()
        {
            inputSearch.Clear();
          
            inputSearch.SendKeys(nonExpectSearchValue);
            btnSearch.Submit();
            Console.WriteLine("Alert message: " + noSearchResult.Text);
            inputSearch.SendKeys(nonExpectSearchValue+Keys.Enter);
            // btnSearch.Submit();
            PageServices.WaitForPageToCompletelyLoaded(WebDriver, 120);
            Console.WriteLine(noSearchResult.Text);
            Console.WriteLine(noSearchResultSugesstion.Text);
            Assert.AreEqual(noResult.Trim(), noSearchResult.Text.Trim());
            Assert.AreEqual(noResultSuggestion.Trim(), noSearchResultSugesstion.Text.Trim());
            Thread.Sleep(500);
            Console.WriteLine("****** Search with No Result Complete *******");
        }


        public void ValidatePageNavigationOnSearchPage()
        {
            string resultHeader = lblTotalResult.Text;
            int pos = resultHeader.LastIndexOf(@"of ");
            string countRes = resultHeader.Substring(pos).Replace(@"of ", "");
            int x = int.Parse(countRes);
            if (x > 10)
            {
                btnNextPage.Click();
                Thread.Sleep(500);
                btnPreviousPage.Click();
                Thread.Sleep(500);
                btnLastPage.Click();
                Thread.Sleep(500);
                btnFirstPage.Click();              
            }
        }
        #endregion Page Methods

        public void SearchContentStewardIcon(string searchText)
        {

            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(searchText);
            btnSearch.Submit();
            Thread.Sleep(2000);          
            
            Assert.That(stewardIcon.Text, Does.Contain("star").IgnoreCase);
            String tooltipText = stewardIcon.GetAttribute("data-tooltip");
            Assert.That(tooltipText, Does.Contain("Group Steward").IgnoreCase);
            Console.WriteLine("Verified tool tip");
        }

        public void VerifyFiterOptions()
        {
            Assert.IsTrue(inputSearch.Displayed);
            Assert.IsTrue(TypeFilter.Displayed);
            Assert.IsTrue(SortByFilter.Displayed);
            Assert.IsTrue(OrderFilter.Displayed);
            OrderFilter.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(FilterSearchButton.Enabled);
            Console.WriteLine("Search result page has Filter option");
        }

        public void VerifyContentTitleText()
        {
            String ContenTitletext = verifyContenTitle.Text;            
            Assert.That(ContenTitletext, Does.Contain("LinkedIn").IgnoreCase);
        }

        public void VerifyContentDescriptionText()
        {
            String ContentDescriptiontext = verifyContentDescription.Text;
            Assert.That(ContentDescriptiontext, Does.Contain("LinkedIn").IgnoreCase);
        }

        public void VerifyGroupTitleText()
        {
            String GroupTitletext = verifyGroupTitle.Text;
            Assert.That(GroupTitletext, Does.Contain("PSY").IgnoreCase);
        }

        public void VerifyGroupDescriptionText()
        {
            String ContentDescriptiontext = verifyGroupDescription.Text;
            Assert.That(ContentDescriptiontext, Does.Contain("PSY").IgnoreCase);
        }

        public void VerifyPersonTitleText()
        {
            String personTitletext = verifyPersonTitle.Text;
            Assert.That(personTitletext, Does.Contain("PSY").IgnoreCase);
        }

        public void ClickOnGroupContent()
        {
            Thread.Sleep(3000);
            clickOnGruopPencilIcon.Click();
            Thread.Sleep(3000);
            int count = clickOnContent.Count;
            for (int i = 0; i < clickOnContent.Count; i++)
            {
                Console.WriteLine(clickOnContent[i].Text);
                if (clickOnContent[i].Text.Contains("Content"))
                {
                    clickOnContent[i].Click();
                    break;
                }
            }
            Thread.Sleep(2000);
            /*--Select Cnversation*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectConversationTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);

            /*--Select Event*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectEventTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);

            /*--Select upload*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectUploadTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);

            /*--Select video*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectVideoTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);
        }
    }
}