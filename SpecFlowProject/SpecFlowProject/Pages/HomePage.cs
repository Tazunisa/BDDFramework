using OpenQA.Selenium;
using SpecFlowProject.Base;
namespace SpecFlowProject.Pages
{
    internal class HomePage:PageBase
    {

        public void NavigateToHomePage()
        {
            Driver.Url="https://www.britishairways.com/travel/home/public/en_gb/";
            WaitForPageLoad();
            //Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            BrowserSleep(7000);
            Driver.FindElement(By.Id("ensCloseBanner")).Click();
            Thread.Sleep(5000);
        }
    }
}
