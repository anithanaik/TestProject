using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumExtras;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ClassLibrary1
{
    public class Class1
    {
        #region variables

        public string invalidUser = "Test";
        string inValidPassword = "Test";
        string IIndSOSUser;// = "vsinhaadmin";
        string IIndSSOPassword;// = "vsinhaadmin";
        string recipientName = string.Empty;
        string recepeintName2;// = string.Empty; ;          
        string expectedReported = "Has been reported";
        //string alumniOptinURL = "https://commons.qa1.ncu.edu/alumni/optin";
        string expectedError;
        ExtentReports extent;
        ExtentHtmlReporter htmlReporter;
        ExtentTest test;
        public TestContext TestContext { get; set; }
        public string commonsAppURL;
        public string alumniOptInUrl;
        string environmentSetup;
        static string errorPath;
        static string reportPath;
        static string uploadFile;
        static string M4PUloadFile;
        static string uploadProfileImage;
        string browser;
        static string ssoUserName; //"A.Abiodun9916@o365.qa.ncu.edu";
        static string ssoPassword; // "Guest2011";
        static string nonSSOUserName; //"A.Abiodun9916@o365.qa.ncu.edu";
        static string nonSSOPassword; // "Guest2011";
        static string jfkssoUserName; //"A.Abiodun9916@o365.qa.ncu.edu";
        static string jfkssoPassword; // "Guest2011";
        string outlookURL;
        string o365UserName;
        string SysUserName;
        string SysUserPassword;
        Actions action;
        Screenshot ss;
        string path;
        string DescriptionText;
        string TitleText;
        string directLinkUrl;
        #endregion variables

        #region Class Instances
        CommonsGroups cmGrps;
        public IWebDriver driver;
        LoginPage loginPage;
        PersonalCommons personalCommons;
        GroupsActivity grpActivity;
        UserInfo userInfo;
        UserAccount userAcc;
        EditProfile editProf;
        NotificationSettings notificationSettings;
        PrivateMessage pvtMsg;
        SearchPage searchPage;
        DiscoverGroup discoverGroup;
        UserGroupContent userGrpContent;
        ConversationGroup conversationGroup;
        MyGroups myGroups;
        DirectoryGroupMessage directoryGroupMessage;
        MembershipDirectory membershipDirectory;
        Outlook outlook;


        #endregion Class Instances

       // public CommonsTest()
       public Class1()
        {
            browser = TestContext.Parameters.Get("Browser").ToString();

        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            environmentSetup = TestContext.Parameters.Get("Environment").ToString();

            environmentSetup = TestContext.Parameters.Get("Environment").ToString();
            errorPath = PageServices.SetReportAndLogPath().Item1;
            reportPath = PageServices.SetReportAndLogPath().Item2;
            Console.WriteLine(errorPath);
            Console.WriteLine(reportPath);
            uploadFile = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadPath").Trim();
            uploadProfileImage = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadImagePath").Trim();
            Console.WriteLine(reportPath);
            Console.WriteLine(uploadFile);
            M4PUloadFile = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadM4PPath").Trim();
            //htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter = new ExtentHtmlReporter(reportPath + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + "\\");
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Commons Automation Report " + environmentSetup;
            htmlReporter.Config.ReportName = "Commons Automation Report " + environmentSetup;
            // htmlReporter.Config.EnableTimeline = true;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Machine Name", Environment.MachineName.ToString());
            extent.AddSystemInfo("Platform Name", Environment.OSVersion.Platform.ToString());
            extent.AddSystemInfo("User Name", Environment.UserName.ToString());
            extent.AddSystemInfo("Browser", browser.ToString());
            outlookURL = TestContext.Parameters.Get("outLookWebMail").ToString();
            o365UserName = TestContext.Parameters.Get("o365UserName").ToString();
            SysUserName = TestContext.Parameters.Get("SystemUserName").ToString();
            SysUserPassword = TestContext.Parameters.Get("SystemPassword").ToString();
            commonsAppURL = TestContext.Parameters.Get("commonsAppUrl").ToString();
            alumniOptInUrl = TestContext.Parameters.Get("alumniOptInUrl").ToString();
            ssoUserName = TestContext.Parameters.Get("SSOUserName").ToString();
            ssoPassword = TestContext.Parameters.Get("SSOPassword").ToString();
            nonSSOUserName = TestContext.Parameters.Get("NonSSOUserName").ToString();
            nonSSOPassword = TestContext.Parameters.Get("NonSSOPassword").ToString();
            jfkssoUserName = TestContext.Parameters.Get("JFKSchoolUserName").ToString();
            jfkssoPassword = TestContext.Parameters.Get("JFKSchoolPassword").ToString();
            directLinkUrl = TestContext.Parameters.Get("directLinkUrl").ToString();

        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            test.Log(Status.Info);
            extent.Flush();
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("********************** Test Cases is Running against **********: [{0}] ", environmentSetup);
            Console.WriteLine("********************** URL Accessed is ************** : [{0}] ", commonsAppURL);
            Console.WriteLine("********************** You Can check Error from this Path *********** :  [{0}] ", errorPath);
            Console.WriteLine("********************** You Can check Report from this Path *********** :  [{0}] ", reportPath);
            driver = BrowserType.SelectBrowser(this.browser);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            cmGrps = new CommonsGroups(driver);
            personalCommons = new PersonalCommons(driver);
            grpActivity = new GroupsActivity(driver);
            userInfo = new UserInfo(driver);
            pvtMsg = new PrivateMessage(driver);
            notificationSettings = new NotificationSettings(driver);
            userAcc = new UserAccount(driver);
            searchPage = new SearchPage(driver);
            discoverGroup = new DiscoverGroup(driver);
            editProf = new EditProfile(driver);
            userGrpContent = new UserGroupContent(driver);
            conversationGroup = new ConversationGroup(driver);
            action = new Actions(driver);
            myGroups = new MyGroups(driver);

            directoryGroupMessage = new DirectoryGroupMessage(driver);
            membershipDirectory = new MembershipDirectory(driver);
            outlook = new Outlook(driver);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Category("AlumniVerification")]
        public void AlumniWelcometour()
        {
            try
            {
                driver.Navigate().GoToUrl(commonsAppURL);
                loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
                Console.WriteLine(nonSSOUserName + " logged in");

                //notificationSettings.AssignAlumniRole();
                notificationSettings.MasqueradeAlumnidata();
                userInfo.AccessAccountMenu();
                //userInfo.AccessUserAccountMenu(userInfo.membershipDirSettingsMenu);
                personalCommons.VerifyAlumniWelTour(); //Alumni Tour

                //driver.Navigate().GoToUrl(alumniOptInUrl);
                //personalCommons.VerifyAlumniOptin(); 
                Thread.Sleep(1000);
                userInfo.Logout();


            }
            catch (Exception ex)
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                path = errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                ss.SaveAsFile(path);
                TestContext.AddTestAttachment(path);
                test.Fail(ex.StackTrace);
                ErrorLog.SaveExeptionToLog(ex, TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup, errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xml");

            }

        }
        [Test, Category("AlumniVerification")]
        public void AlumniLoginAccess()
        {
            try
            {
                driver.Navigate().GoToUrl(commonsAppURL);
                loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
                Console.WriteLine(nonSSOUserName + " logged in");

                //notificationSettings.AssignAlumniRole();
                notificationSettings.MasqueradeAlumnidata();
                userInfo.AccessAccountMenu();
                //userInfo.AccessUserAccountMenu(userInfo.membershipDirSettingsMenu);
               // personalCommons.VerifyAlumniTour(); //Alumni Tour

                //driver.Navigate().GoToUrl(alumniOptInUrl);
                //personalCommons.VerifyAlumniOptin(); 
                Thread.Sleep(1000);
                userInfo.Logout();


            }
            catch (Exception ex)
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                path = errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                ss.SaveAsFile(path);
                TestContext.AddTestAttachment(path);
                test.Fail(ex.StackTrace);
                ErrorLog.SaveExeptionToLog(ex, TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup, errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xml");

            }

        }
        [Test, Category("AlumniVerification")]
        public void facultytour()
        {
            try
            {
                driver.Navigate().GoToUrl(commonsAppURL);
                loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
                Console.WriteLine(nonSSOUserName + " logged in");

                //notificationSettings.AssignAlumniRole();
                notificationSettings.Masqueradefaculty();
                userInfo.AccessAccountMenu();
                //userInfo.AccessUserAccountMenu(userInfo.membershipDirSettingsMenu);
                personalCommons.VerifyfacultyTour(); //Alumni Tour

                //driver.Navigate().GoToUrl(alumniOptInUrl);
                //personalCommons.VerifyAlumniOptin(); 
                Thread.Sleep(1000);
                userInfo.Logout();


            }
            catch (Exception ex)
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                path = errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                ss.SaveAsFile(path);
                TestContext.AddTestAttachment(path);
                test.Fail(ex.StackTrace);
                ErrorLog.SaveExeptionToLog(ex, TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup, errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xml");

            }

        }

        [TearDown]

        public void ShutDown()
        {
            try
            {
                driver.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(TestContext.CurrentContext.Result.Message, e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

    }


}

    

