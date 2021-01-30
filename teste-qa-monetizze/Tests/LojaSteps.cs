using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace teste_qa_monetizze.Tests
{
    [Binding]
    public class LojaSteps 
    {
        IWebDriver driver;
        WebDriverWait wait;
        private string url = "http://monetizzetesteqa.s3-website-us-east-1.amazonaws.com/shop.html";

        [BeforeScenario("FluxoDeCompra")]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            driver.Manage().Window.Maximize();
        }

        [AfterScenario("FluxoDeCompra")]
        public void Close()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

        [Given(@"usuario acessar a loja")]
        public void UsuarioAcessarALoja()
        {
            this.driver.Navigate().GoToUrl(url);
        }

        [Given(@"selecionar um vinho")]
        public void DadoSelecionarUmVinho()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Nossos Produtos']")));

                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                System.Threading.Thread.Sleep(5000);
                js.ExecuteScript("window.scrollBy(0,400);");

                Actions action = new Actions(driver);
                action.MoveByOffset(200, 500).Perform();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='wine-actions']")));
                driver.FindElement(By.XPath("//div[@class='wine-actions']")).Click();
                
                driver.FindElement(By.XPath("//a[@href='cart.html']")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        
        [When(@"adicionar duas ou mais quantidades do mesmo vinho")]
        public void QuandoAdicionarDuasOuMaisQuantidadesDoMesmoVinho()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//button[@type='button'])[2]")));
                driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"clicar em Prosseguir")]
        public void QuandoClicarEmProsseguir()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Prosseguir']")));
                driver.FindElement(By.XPath("//button[text()='Prosseguir']")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"preencher todos os campos obrigatorios")]
        public void QuandoPreencherTodosOsCamposObrigatorios()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Detalhes da compra']")));

            Random random = new Random();
            string nome = "nome_" + random.Next(100);
            string sobrenome = "sobrenome_" + random.Next(100);
            string endereco1 = "endereco1_" + random.Next(100);
            string endereco2 = "endereco2_" + random.Next(100);
            string estado_pais = "estado_pais_" + random.Next(100);
            string cep = random.Next(100).ToString();
            string email = "email_" + random.Next(100) + "@gmail.com";
            string telefone = random.Next(100).ToString();

            driver.FindElement(By.XPath("//select[@class='form-control']")).Click();
            driver.FindElement(By.XPath("//*[@id='c_country']/option[4]")).Click();
            driver.FindElement(By.XPath("//label[text()='Nome ']/following::input")).SendKeys(nome);
            driver.FindElement(By.XPath("//label[text()='Sobrenome ']/following::input")).SendKeys(sobrenome);
            driver.FindElement(By.XPath("//label[text()='Endereço ']/following::input")).SendKeys(endereco1);
            driver.FindElement(By.XPath("(//label[text()='Endereço ']/following::input)[2]")).SendKeys(endereco2);
            driver.FindElement(By.XPath("//label[text()='Estado/País ']/following::input")).SendKeys(estado_pais);
            driver.FindElement(By.XPath("//label[text()='CEP ']/following::input")).SendKeys(cep);
            driver.FindElement(By.XPath("//label[text()='Email ']/following::input")).SendKeys(email);
            driver.FindElement(By.XPath("//label[text()='Telefone ']/following::input")).SendKeys(telefone);

        }
        
        [When(@"clicar em Finalizar Compra")]
        public void QuandoClicarEmFinalizarCompra()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@type='submit']")));
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        
        [Then(@"o sistema deve exibir a mensagem de confirmação de compra")]
        public void EntaoOSistemaDeveExibirAMensagemDeConfirmacaoDeCompra()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='lead mb-5']")));
            String response = driver.FindElement(By.XPath("//p[@class='lead mb-5']")).Text;

            Assert.IsTrue(response.Contains("Seu pedido foi feito com sucesso!."));
        }
    }
}
