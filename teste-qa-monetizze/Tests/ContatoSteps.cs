using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace teste_qa_monetizze.Tests
{
    [Binding]
    public class ContatoSteps
    {
        IWebDriver driver;
        WebDriverWait wait;
        private string url = "http://monetizzetesteqa.s3-website-us-east-1.amazonaws.com/";

        [BeforeScenario("FluxoDeContato")]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            driver.Manage().Window.Maximize();
        }

        [AfterScenario("FluxoDeContato")]
        public void Close()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

        [Given(@"um usuario acessar o sistema")]
        public void DadoUmUsuarioAcessarOSistema()
        {
            this.driver.Navigate().GoToUrl(url);
        }
        
        [Given(@"clicar em Contato")]
        public void DadoClicarEmContato()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//a[@href='contact.html'])[2]")));
                driver.FindElement(By.XPath("(//a[@href='contact.html'])[2]")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        
        [When(@"preencher as informações solicitadas")]
        public void QuandoPreencherAsInformacoesSolicitadas()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//h2[text()='Contato'])[2]")));

            Random random = new Random();
            string nome = "nome_" + random.Next(100);
            string sobrenome = "sobrenome" + random.Next(100);
            string email = "email_" + random.Next(100) + "@gmail.com";
            string telefone = "telefone_" + random.Next(100).ToString();
            string mensagem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            driver.FindElement(By.XPath("//input[@class='form-control form-control-lg']")).SendKeys(nome);
            driver.FindElement(By.XPath("(//input[@class='form-control form-control-lg'])[2]")).SendKeys(sobrenome);
            driver.FindElement(By.XPath("(//input[@class='form-control form-control-lg'])[3]")).SendKeys(email);
            driver.FindElement(By.XPath("//label[text()='Telefone']/following::input")).SendKeys(telefone);
            driver.FindElement(By.XPath("//label[text()='Mensagem']/following::textarea")).SendKeys(mensagem);


        }

        [When(@"clicar em Enviar")]
        public void QuandoClicarEmEnviar()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@class,'btn btn-primary')]")));
                driver.FindElement(By.XPath("//input[contains(@class,'btn btn-primary')]")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        
        [Then(@"o sistema deve exibe uma mensagem de agradecimento")]
        public void EntaoOSistemaDeveExibeUmaMensagemDeAgradecimento()
        {
            try
            {
                
            }
            catch (NoSuchElementException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail();
            }
        }
    }
}
