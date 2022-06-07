using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected NavigationHelper navigationHelper;
        protected RegistrationHelper registrationHelper;
        protected FtpHelper ftpHelper;
        protected JamesHelper jamesHelper;
        protected MailerHelper mailerHelper;
        protected AuthHelper authHelper;
        protected ProjectManagementHelper projectManagementHelper;

        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://mantis.course.ru/";

            navigationHelper = new NavigationHelper(this, baseURL);
            registrationHelper = new RegistrationHelper(this);
            ftpHelper = new FtpHelper(this);
            jamesHelper = new JamesHelper(this);
            mailerHelper = new MailerHelper(this);
            authHelper = new AuthHelper(this);
            projectManagementHelper = new ProjectManagementHelper(this);

        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public IWebDriver Driver
        {
            get { return driver; }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoToHomePage();
                app.Value = newInstance;

            }
            return app.Value;
        }

        public NavigationHelper Navigation { get { return navigationHelper; } }
        public AuthHelper Auth { get { return authHelper; } }
        public RegistrationHelper Registration { get { return registrationHelper; } }
        public FtpHelper Ftp { get { return ftpHelper; } }
        public JamesHelper James { get { return jamesHelper; } }
        public MailerHelper Mailer { get { return mailerHelper; } }
        public ProjectManagementHelper ProjectManagement { get { return projectManagementHelper; } }
    }
}
