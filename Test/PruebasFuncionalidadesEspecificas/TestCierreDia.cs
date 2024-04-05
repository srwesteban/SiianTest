using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SiianTest.Test.PruebasFuncionalidadesEspecificas
{
    [TestClass]
    public class TestLoginNavegador
    {
        private ChromeOptions options;
        private IWebDriver driver;
        private readonly string baseUrl = "https://95bd-181-62-56-8.ngrok-free.app/NOM/Account/Login/";
        private readonly string username = "ADMINISTRADOR";
        private readonly string password = "Sii@n123*";

        [TestInitialize]
        public void Setup()
        {
            options = new ChromeOptions();
            options.AddArgument("--headless");
        }

        [TestMethod]
        public void LoginTest_SuccessfulLogin()
        {
            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl(baseUrl);

            IWebElement usernameField = WaitUntilElementIsVisible(By.Name("Username"));
            usernameField.SendKeys(username);

            IWebElement passwordField = driver.FindElement(By.CssSelector("input[type='password']"));
            passwordField.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            loginButton.Click();

            // Verificar si la página de inicio de sesión fue exitosa
            Assert.IsTrue(driver.Url.Contains("NOM"), "Login exitoso");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Cerrar el navegador
            if (driver != null)
            {
                driver.Quit();
            }
        }

        // Método para esperar a que un elemento sea visible en la página
        private IWebElement WaitUntilElementIsVisible(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(driver => driver.FindElement(locator));
        }
    }
}
