﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace TestProject1
{
    internal class SortWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void SortTable()
        {
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropDown.SelectByValue("20");

            IList<IWebElement> vegetableElements = driver.FindElements(By.XPath("//tr//td[1]"));
            ArrayList vegetaleNames = new ArrayList();
            foreach (IWebElement vegetable in vegetableElements)
            {
                vegetaleNames.Add(vegetable.Text);
            }
            foreach (String vegetableName in vegetaleNames)
            {
                TestContext.Progress.WriteLine(vegetableName);
            }

            vegetaleNames.Sort();
            TestContext.Progress.WriteLine("after sorting");
            foreach (String vegetableName in vegetaleNames) 
            {
                TestContext.Progress.WriteLine(vegetableName);
            }
            driver.FindElement(By.LinkText("Veg/fruit name")).Click();
            


        }
    }
}
