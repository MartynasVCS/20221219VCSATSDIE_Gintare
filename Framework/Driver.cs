﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Framework
{
    public class Driver
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void OpenPage(string url)
        {
            driver.Url = url;
        }

        public static void Initialize()
        {
            driver = new ChromeDriver();
        }

        public static void CloseDriver()
        {
            driver.Quit();
        }

        public static void TakeScreenshot(string testMethodName)
        {
            string screenshotsDirectoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}screenshots";
            string screenshotName = $"{screenshotsDirectoryPath}\\-{testMethodName}-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.png";

            Directory.CreateDirectory(screenshotsDirectoryPath);
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
        }
    }
}