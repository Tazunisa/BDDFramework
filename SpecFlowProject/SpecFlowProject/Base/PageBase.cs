using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Base
{
    internal class PageBase
    {
        public static IWebDriver Driver = new ChromeDriver();
        private WebDriverWait wait=null;
       // private object ExpectedConditions=null;

        public void ScrollToTop()
        {
            IJavaScriptExecutor jsDriver = ((IJavaScriptExecutor)Driver);
            jsDriver.ExecuteScript(string.Format("window.scroll(0, 0)"));
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor jsDriver = ((IJavaScriptExecutor)Driver);
            jsDriver.ExecuteScript(string.Format("window.scroll(0, document.body.scrollHeight)"));

        }



        public static void BrowserSleep(int x)
        {
            //int inSeconds = x*1000;
            Thread.Sleep(x);
        }



        public void WaitForPageLoad(int timer = 90)
        {
            string state = string.Empty;
            TimeSpan timeOut = TimeSpan.FromSeconds(timer);

            wait = new WebDriverWait(Driver, timeOut);
            wait.Until(d => {
                try
                {

                    state = ((IJavaScriptExecutor)Driver).ExecuteScript(@"return document.readyState").ToString();


                }
                catch (InvalidOperationException)
                {
                    //Ignore
                }
                catch (NoSuchWindowException)
                {
                    //when popup is closed, switch to last windows
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                }
                //In IE7 there are chances we may get state as loaded instead of complete
                return (state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase));
            });
        }


            


        public void WaitForTabToLoad()
        {
            var tabCount = Driver.WindowHandles.Count;
            while (tabCount < 1)
            {
                tabCount = Driver.WindowHandles.Count;
                if (tabCount > 1)
                {
                    break;
                }
            }
        }

        public bool WaitForElementToAppear(By element)
        {
            var count = 0;
            do
            {
                try
                {
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    count++;
                    if (count > 10) return false;
                    if (Driver.FindElement(element).Displayed)
                        return true;
                }
                catch (Exception)
                {
                    count++;
                    if (count > 10) return false;
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
            } while (true);
        }

 

  




        //The popup box sometimes appears and sometimes it does not
        public void PopUpAlertMessageConfirm()
        {
            try
            {
                IAlert confirmationAlert = Driver.SwitchTo().Alert();
                confirmationAlert.Accept();
            }
            catch
            {
                //do nothing
            }
        }

        public int ConvertStringToInt(string stringValue)
        {
            int intValue = Int32.Parse(stringValue);
            return intValue;

        }

        public double ConvertStringToDouble(string stringValue)
        {
            Double doubleValue = Convert.ToDouble(stringValue);
            return doubleValue;
        }

        public void WaitForAjax(IWebDriver driver, int timeoutSecs = 10, bool throwException = false)
        {
            for (var i = 0; i < timeoutSecs; i++)
            {
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }
            if (throwException)
            {
                throw new Exception("WebDriver timed out waiting for AJAX call to complete");
            }
        }


    }
}
