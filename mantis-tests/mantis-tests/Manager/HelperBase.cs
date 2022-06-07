﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        protected bool acceptNextAlert;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsElementPresent(IWebElement element, By by)
        {
            try
            {
                element.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        /// <summary>
        /// Заполняем текстовы input
        /// </summary>
        /// <param name="locator">Локатор</param>
        /// <param name="text">Текст</param>
        public void FeelingTextInput(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        /// <summary>
        /// Обработка элементов селекта
        /// </summary>
        /// <param name="locator">Локатор</param>
        /// <param name="select">Текст селекта</param>
        public void SetSelectByText(By locator, string select)
        {
            if (select != null)
            {
                driver.FindElement(locator).Click();
                new SelectElement(driver.FindElement(locator)).SelectByText(select);
            }
        }
        /// <summary>
        /// Обработка элементов селекта
        /// </summary>
        /// <param name="locator">Локатор</param>
        /// <param name="value">параметр атрибута value</param>
        public void SetSelectByValue(By locator, string value)
        {
            if (value != null)
            {
                driver.FindElement(locator).Click();
                new SelectElement(driver.FindElement(locator)).SelectByValue(value);
            }
        }
        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
