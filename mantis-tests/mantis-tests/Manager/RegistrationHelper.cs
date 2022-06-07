using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        /// <summary>
        /// Конструктор хелпера принимает ApplicationManager
        /// </summary>
        /// <param name="manager">ApplicationManager</param>
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
        }
        /// <summary>
        /// Набор действий(шагов) для выполнения регистрации нового пользователя принимает объект класса AccountData
        /// </summary>
        /// <param name="newAccount">Объект класса AccountData</param>
        public void RegisterNewAccount(AccountData account)
        {
            FillRegisterForm(account);
            SubmitRegisterForm();
            string url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            CompleteRegistration();
        }
        /// <summary>
        /// Перейти на страницу регистрации нового пользователя
        /// </summary>
        public void GoToRegistrationPage()
        {
            driver.FindElement(By.CssSelector("div.toolbar a")).Click();
        }
        /// <summary>
        /// Заполнить форму регистрации на основании объекта класса AccountData
        /// </summary>
        /// <param name="newAccount">Объект класса AccountData</param>
        public void FillRegisterForm(AccountData newAccount)
        {
            driver.FindElement(By.Name("username")).SendKeys(newAccount.Username);
            driver.FindElement(By.Name("email")).SendKeys(newAccount.Email);
        }
        /// <summary>
        /// Нажать кнопку Зарегистрировать
        /// </summary>
        public void SubmitRegisterForm()
        {
            driver.FindElement(By.XPath("//input[@type=\"submit\"]")).Click();
        }
        /// <summary>
        /// Получаем сообщение из почты пользователя и забираем из него ссылку
        /// </summary>
        /// <param name="account">Объект класса AccountData</param>
        /// <returns>Возвращает ссылку</returns>
        private string GetConfirmationUrl(AccountData account)
        {
            string message = manager.Mailer.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }
        /// <summary>
        /// Переходим по ссылке из сообщеня на почте и заполняем форму
        /// </summary>
        /// <param name="url">Ссылка из почтового сообщения</param>
        /// <param name="account">Объект класса AccountData</param>
        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("realname")).SendKeys(account.RealName);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }
        /// <summary>
        /// Нажимаем кнопку изменить пользователя
        /// </summary>
        private void CompleteRegistration()
        {
            driver.FindElement(By.XPath("//button[@type=\"submit\"]")).Click();
        }
    }
}
