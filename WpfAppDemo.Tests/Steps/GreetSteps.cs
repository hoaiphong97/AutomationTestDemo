using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using NUnit.Framework;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace WpfAppDemo.Tests.Steps
{
    [Binding]
    public class GreetSteps
    {
        private Application _app;
        private AutomationBase _automation;
        private Window _mainWindow;
        private static readonly ActivitySource ActivitySource = new("SpecFlowTest");

        [Given(@"the demo app is running")]
        public void GivenTheDemoAppIsRunning()
        {
            var exePath = @"C:\Users\hoaip\Desktop\WpfAppDemo\WpfAppDemo\bin\Debug\net8.0-windows\WpfAppDemo.exe";
            _app = Application.Launch(exePath);
            _automation = new UIA3Automation();
            Retry.WhileNull(() => _app.GetMainWindow(_automation), TimeSpan.FromSeconds(5));
            _mainWindow = _app.GetMainWindow(_automation);
        }

        [When(@"I enter ""(.*)"" in the input box")]
        public void WhenIEnterInTheInputBox(string name)
        {
            using var activity = ActivitySource.StartActivity("WhenIEnterInTheInputBox");
            var inputBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("InputBox")).AsTextBox();
            inputBox.Enter(name);            
        }

        [When(@"I click the hello button")]
        public void WhenIClickTheHelloButton()
        {
            var button = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("HelloButton")).AsButton();
            button.Invoke();
        }

        [Then(@"I should see ""(.*)"" in the result text")]
        public void ThenIShouldSeeInTheResultText(string expectedText)
        {
            var result = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("ResultText")).AsLabel();
            _app.Close();
        }
    }
}
