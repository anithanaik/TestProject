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
   public class PrivateMessage
    {
        IWebDriver pMsgdriver;
        public PrivateMessage(IWebDriver driver)
        {
            pMsgdriver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(pMsgdriver, TimeSpan.FromSeconds(90)));
        }

        #region Expcted Text

        public string createPrivateMsg = "Create private message";
        public string messageRequiredError = "Message is required.";
       // public string messageRequiredError = "Message field is required.";
        
        public string testMessage = "This is for testing! Please Ignore.";
        public int inboxSubMenuIndex = 0;
        public int archiveSubMenuIndex = 1;
        public int createMsgSubMenuIndex = 2;
        public string clcdateTime;
       


        #endregion Expcted Text

        #region Private Message Page Element

        [FindsBy(How = How.CssSelector, Using = "#private-message-menu > ul > li > a")]
        public IList<IWebElement> pvtMsgSubMenu { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#private-message-menu > ul > li:nth-child(5) > a")]
        public IWebElement subMenuPvtMsg{ get; set; }


        [FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div.views-row > div.contextual-region.profile.contextual-exposed.no-contextual-outline > div > h2")]
        public IWebElement userNameOnPvtMsgTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div > div > div > div > a")]
        public IWebElement btnPvtMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li.search-choice > span")]
        public IWebElement selectedRecipient { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value='Send']")]
        public IWebElement btnSendMessage { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#edit-message-0-value-error")]
        [FindsBy(How = How.CssSelector, Using = "#edit-message-wrapper")]
        public IWebElement lbrErrorMessageReqrd { get; set; }
       // "#edit-message-wrapper"

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen")]
        public IWebElement lstMember { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li")]
        public IWebElement mailToBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li > input")]
        public IWebElement inputMailToBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.no-ajax-indicator")]
        public IWebElement btnMarkAsRead { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > div > ul > li")]
        public IList<IWebElement> lstUserMember { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.btn >input#edit-field-attachment-0-upload")]
        public IWebElement btnUploadOrAttachFile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*= 'edit-field-attachment-0'] > span > a")]
        public IWebElement txtAttachedFile { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button[value*='Remove']")]
        public IWebElement btnRemoveAttachedFile { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "html > body")]
        //public IWebElement inputMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html > body[class*='cke_editable']")]
        public IWebElement inputMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-thread-']")]
        public IList< IWebElement> newMessageThread { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-thread-'] > ul > li > div > a > i")]
        public IWebElement btnDeleteMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-thread-'] > ul > li > div > btn")]
        public IWebElement btnReportMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div.ui-dialog-buttonset>button")]
        public IWebElement btnOKReportMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-'] > li > div.report > btn[title='Report'] > i")]
        public IList<IWebElement> lstNonReportedMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-'] > li > div.report > btn")]
        public IList<IWebElement> lstReportedMsg { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[value='Delete thread']")]
        public IWebElement btnDeleteMessageThread { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.m-right-small:nth-child(2) > i:nth-child(1)")]
        public IWebElement btnLeaveConversation { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-submit")]
        public IWebElement btnLeaveConversationThread { get; set; }

        // [FindsBy(How = How.CssSelector, Using = ".collection-header > h3:nth-child(1) > span:nth-child(4) > span:nth-child(2)")]
        [FindsBy(How = How.XPath, Using = "//ul[@class='collection with-header']/li/h3/span[2]/span")]
        public IWebElement LeaveConversationMsgThread { get; set; }


        #region Nested Element

        public By archiveSelector = By.CssSelector("ul > li > div > div > a");
        public By deleteSelector = By.CssSelector("ul > li > div > a");
        public By unArchiveSelector = By.CssSelector("ul > div > a");
        public By pvtMessage = By.CssSelector("ul > div[id*='private-message-']");

        #endregion Nested Element



        #endregion Private Message Page Element


        #region Private Message Page Method      

        public void VerifyPrivateMessageTab()
        {
            int cnt = pvtMsgSubMenu.Count;
            string msg = pvtMsgSubMenu[2].GetAttribute("innerText");
            string[] lines = msg.Split('\n');
            Console.WriteLine(lines[1].Trim());
            Assert.AreEqual(createPrivateMsg, lines[1].Trim());
        }
        public void AccessInboxOnPrivateMessage()
        {
            pvtMsgSubMenu[inboxSubMenuIndex].Click();
        }

        public void AccessArchivesOnPrivateMessage()
        {
            pvtMsgSubMenu[archiveSubMenuIndex].Click();
        }


        public string GetUserNameFromPvtMsgTab()
        {
            Thread.Sleep(3000);
            string uName = userNameOnPvtMsgTab.GetAttribute("innerText").Trim();
            Console.WriteLine(uName);          
            return uName;

        }

        public void ClickOnPrivateMessage()
        {
            btnPvtMessage.Click();
        }

        public string GetAutoAssignedRecipientName()
        {
            string recipientName = selectedRecipient.GetAttribute("innerText").Trim();
            Console.WriteLine(recipientName);
            return recipientName;

        }

        public void ClickToSendMessage()
        {
            btnSendMessage.Submit();//.Click();
        }

        public void ValidateMessageRequiredError()
        {
            string erroMsg = lbrErrorMessageReqrd.GetAttribute("innerText").Trim();
            Console.WriteLine(erroMsg);
           
            // return erroMsg;
            // Assert.AreEqual(messageRequiredError.Trim(), erroMsg);
            Assert.IsTrue(erroMsg.Contains(messageRequiredError));
            Console.WriteLine("Validation message :" + messageRequiredError);

        }
        public void TypeMessage(string testMessage)
        {
           
            pMsgdriver.SwitchTo().Frame(0);
            //inputMessage.SendKeys(testMessage);
            inputMessage.SendKeys(testMessage);
        }

        public void VerifyMailAttachmentFunctionality(string uploadFile )
        {
            btnUploadOrAttachFile.SendKeys(uploadFile);
            string attachedFile = txtAttachedFile.GetAttribute("innerText");
            Console.WriteLine("File attachted " + attachedFile);
            Assert.IsTrue(attachedFile != String.Empty);           
            btnRemoveAttachedFile.Click();
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 30);
            Thread.Sleep(2000);
            Console.WriteLine("Delete attachted File");
        }

        public void ValidateEmailRecipientWithSelectedRecipientName(string selectedUser)
        {
            //string fName = selectedUser;
            //int pos = fName.IndexOf(" ");
            //fName = fName.Substring(0,pos);
            Assert.AreEqual(selectedUser.ToLower(), GetUserNameFromPvtMsgTab().ToLower());
            Thread.Sleep(2000);
            ClickOnPrivateMessage();
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 60);
            // Assert.IsTrue(GetAutoAssignedRecipientName().Contains(fName));            
        }

        public void ValidateMessageRequired()
        {
            ClickToSendMessage();
            ValidateMessageRequiredError();            
        }

        public void AddRecepient_ByName(string  reciepentName)
        {
            mailToBox.Click();
            inputMailToBox.SendKeys(reciepentName);
            lstUserMember[0].Click();
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 30);
        }
        public void AddRecepient_ByName_ByJs(string reciepentName)
        {
            //mailToBox.Click();
            ((IJavaScriptExecutor)pMsgdriver).ExecuteScript("arguments[0].click();", mailToBox);
            inputMailToBox.SendKeys(reciepentName);
            //((IJavaScriptExecutor)pMsgdriver).ExecuteScript("arguments[0].setAtrribute(")
               //  ((IJavaScriptExecutor)pMsgdriver).ExecuteScript("arguments[0].setAttribute('value','" + reciepentName + "');", inputMailToBox);
            lstUserMember[0].Click();
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 30);
            Console.WriteLine("On 'To' field user can type the user name: " + reciepentName);
        }
        public void AddOtherRecepient(int index)
        {
            lstMember.Click();
            lstUserMember[index].Click();
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 30);
        }

        public void ValidateArchivesAndDeleteOptionAndArchiveMessage()
        {
            PageServices.ScrollPageUptoTop(pMsgdriver);          

            Actions mouse = new Actions(pMsgdriver);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();

            IWebElement archive = newMessageThread[0].FindElement(archiveSelector);
            Assert.IsTrue(archive.Displayed);
           
            IWebElement delete = newMessageThread[0].FindElement(deleteSelector);
            Assert.IsTrue(delete.Displayed);
            archive.Click();
        }

        public void TypeMessageAndSend(string txtMessage)
        {
            TypeMessage(txtMessage);
            pMsgdriver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            ClickToSendMessage();
        }

        public void AccessArchivedMessageAndUnarchive()
        {
            AccessArchivesOnPrivateMessage();
            Actions mouse = new Actions(pMsgdriver);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            IWebElement unarchive = newMessageThread[0].FindElement(unArchiveSelector);
            unarchive.Click();
            Console.WriteLine("Unarchive a thread");

        }

        public void ClickToMarkAsReadMessage()
        {
            btnMarkAsRead.Click();
            Console.WriteLine("Message Marked as MarkAsRead");
        }

        public void AccessInboxAndDeleteMessage()
        {
            Actions mouse = new Actions(pMsgdriver);
            AccessInboxOnPrivateMessage();
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            IWebElement msg = newMessageThread[0].FindElement(pvtMessage);
            msg.Click();
            PageServices.ScrollPageUptoTop(pMsgdriver);         
            mouse = new Actions(pMsgdriver);
            mouse.MoveToElement(btnDeleteMessage).Build().Perform();
            btnDeleteMessage.Click();
            btnDeleteMessageThread.Click();

        }

        public void AccessInboxAndLeaveConversation()
        {
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 30);
            Actions mouse = new Actions(pMsgdriver);
            
            AccessInboxOnPrivateMessage();
            PageServices.WaitForPageToCompletelyLoaded(pMsgdriver, 90);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            IWebElement msg = newMessageThread[0].FindElement(pvtMessage);
            msg.Click();
          //  Thread.Sleep(3000);
          //  PageServices.ScrollPageUptoTop(pMsgdriver);
            mouse = new Actions(pMsgdriver);
            mouse.MoveToElement(btnLeaveConversation).Build().Perform();
            btnLeaveConversation.Click();
           // Thread.Sleep(3000);
            btnLeaveConversationThread.Click();
            Console.WriteLine("User Leave the Conversation.");
            //Removing Date time as its failing due to few seconds also
            //DateTime lcdateTime = DateTime.Now;
            // clcdateTime = "(LEFT CONVERSATION "+(lcdateTime.ToString("MM/dd/yyyy - h:mm")) +")";
            // Console.WriteLine(clcdateTime);


        }

        public void VerifyUserLeftTimeStampInfo()
        {
            Actions mouse = new Actions(pMsgdriver);
            AccessInboxOnPrivateMessage();
            Thread.Sleep(2000);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            IWebElement msg = newMessageThread[0].FindElement(pvtMessage);
            msg.Click();
            Thread.Sleep(2000);
            PageServices.ScrollPageUptoTop(pMsgdriver);
            mouse = new Actions(pMsgdriver);
            string LeaveConversationMsg = LeaveConversationMsgThread.GetAttribute("innerText");
            //Assert.AreEqual(clcdateTime, LeaveConversationMsg);
            Assert.IsTrue(LeaveConversationMsg.Contains("LEFT CONVERSATION"));
            Console.WriteLine("Time stamp of user left the conversation :" +LeaveConversationMsg);

        }


        public void ReportMessage(string expectedReported)
        {
            Thread.Sleep(2000);
            newMessageThread[0].FindElement(pvtMessage).Click();
            PageServices.ScrollPageUptoTop(pMsgdriver);
            Thread.Sleep(3000);          // increase pause for onsite runs 
            btnReportMessage.Click();
            Thread.Sleep(3000);
            pMsgdriver.SwitchTo().DefaultContent();          
            btnOKReportMessage.Click();         
           // PageServices.ScrollPageUptoBottom(pMsgdriver);
            Thread.Sleep(3000);

            for (int i = lstNonReportedMsg.Count - 1; i > 0; i--)
            {
                if (lstNonReportedMsg[i].Text.Contains("warning"))
                {
                    Console.WriteLine(lstNonReportedMsg[i].GetAttribute("title"));
                    lstNonReportedMsg[i].Click();
                    Thread.Sleep(2000);                    
                    Console.WriteLine(lstReportedMsg[lstReportedMsg.Count - 1].GetAttribute("title"));
                    Assert.AreEqual(lstReportedMsg[lstReportedMsg.Count - 1].GetAttribute("title"), expectedReported);

                    break;
                }

            }
        }

        public void UploadAttachment(string uploadFile)
        {
            btnUploadOrAttachFile.SendKeys(uploadFile);
            string attachedFile = txtAttachedFile.GetAttribute("innerText");
            Console.WriteLine("File attachted " + attachedFile);
            Assert.IsTrue(attachedFile != String.Empty);
            TypeMessageAndSend(testMessage);           
        }

        public void ReVerifiedReportedMsg()
        {
            newMessageThread[0].FindElement(pvtMessage).Click();
            PageServices.ScrollPageUptoBottom(pMsgdriver);
            Console.WriteLine(lstReportedMsg[lstNonReportedMsg.Count - 1].GetAttribute("title"));

        }
        #endregion Private Message Page Method    


    }

   


}
