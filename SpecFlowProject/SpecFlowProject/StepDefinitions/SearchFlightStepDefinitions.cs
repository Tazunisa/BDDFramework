using BoDi;
using OpenQA.Selenium;
using SpecFlowProject.Pages;
using SpecFlowProject.Base;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
namespace SpecFlowProject.StepDefinitions
{

    [Binding]
     class SearchFlightStepDefinitions:PageBase
    {
       // public IWebDriver driver;
        private readonly IObjectContainer objectContainer;
         private HomePage homePage;
         private FlightsPage flightspage;

        public SearchFlightStepDefinitions(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        [BeforeScenario]
        public void InitializeWebDriver()
        {

           // this.driver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
            Driver.Manage().Window.Maximize();
        }

        [Given(@"I am on the British Airways homepage")]
        public void GivenIAmOnTheBritishAirwaysHomepage()
        {

           homePage = new HomePage();
           homePage.NavigateToHomePage();
        }

        [When(@"I click the Flights icon")]
        public void WhenIClickTheFlightsIcon()
        {
           flightspage= new FlightsPage();
           flightspage.ClickOnFlight();
        }


        [When(@"I enter ""([^""]*)"" as the from destination")]
        public void WhenIEnterAsTheFromDestination(string fromDest)
        {
            /* driver.FindElement(By.Name("searchEntry")).Click();
             Thread.Sleep(2000);
             driver.FindElement(By.Name("searchEntry")).SendKeys(london);
             Thread.Sleep(2000);
             driver.FindElement(By.Name("searchEntry")).SendKeys(Keys.Enter);*/
            flightspage.ClickOnFrom();
            Thread.Sleep(2000);
            flightspage.EnterFromDestination(fromDest);
            Thread.Sleep(2000);
        }
        [When(@"I enter ""([^""]*)"" as the to destination")]
        public void WhenIEnterAsTheToDestination(string toDest)
        {
            /* driver.FindElement(By.XPath("//label[@for='to']")).Click();
             Thread.Sleep(2000);
             driver.FindElement(By.XPath("//label[@for='to']//preceding::input[1]")).SendKeys("New York");
             Thread.Sleep(2000);
             driver.FindElement(By.XPath("//label[@for='to']//preceding::input[1]")).SendKeys(Keys.Enter);*/
            flightspage.ClickOnTo();
            Thread.Sleep(2000);
            flightspage.EnterToDestination(toDest);
            Thread.Sleep(2000);
        }
        [When(@"I enter ""([^""]*)"" as the departure date")]
        public void WhenIEnterAsTheDepartDate(string departureDate)
        {
            /*driver.FindElement(By.XPath("//*[@class='outbound date-selection']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@aria-label='Monday, 27 March, 2023']")).Click();
            Thread.Sleep(2000);*/
            flightspage.ClickOnDepartureDateField();
            Thread.Sleep(2000);
            flightspage.SelectDepartureDate(departureDate);
            Thread.Sleep(2000);
        }
        [When(@"I enter ""([^""]*)"" as the return date")]
        public void WhenIEnterAsTheReturnDate(string returnDate)
        {
            /*driver.FindElement(By.XPath("//*[@class='date-selection']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@aria-label='Friday, 31 March, 2023']")).Click();
            Thread.Sleep(2000);*/
            flightspage.ClickonReturnDateField();
            Thread.Sleep(2000);
            flightspage.SelectReturnDate(returnDate);
            Thread.Sleep(2000);

        }


        [When(@"I select ""([^""]*)"" adults from the Passengers drop down")]
        public void WhenISelectPassengersFromDropDown(int count)
        {
            /*driver.FindElement(By.XPath("//span[text()='Passengers']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@class='spinner-button increase']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Confirm']")).Click();
            Thread.Sleep(2000);*/
            flightspage.SelectPassengers();
        }
        [When(@"I select ""([^""]*)"" from the Travel class drop down")]
        public void WhenISelectTravelClassFromDropDown(string TravelClass)
        {
            /*driver.FindElement(By.XPath("//span[text()='Economy']")).Click();
            driver.FindElement(By.XPath("//label[text()='"+TravelClass+"']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[contains(text(),'travel class')]//following::button")).Click();*/
            flightspage.SelectTravelClass(TravelClass);
        }

       [When(@"I click the Search flight button")]
        public void WhenIClickonSearchFlightButton()
        {
           flightspage.ClickOnFlightSearchButton();
           //Thread.Sleep(2000);
            
        }



        [Then(@"I should see flight search results for London to New York")]
        public void ThenIShouldSeeFlightSearchResultsForLondonToNewYork()
        {
           
            Assert.IsTrue(Driver.Url.Contains("/flights/search"));
        }

    }
}