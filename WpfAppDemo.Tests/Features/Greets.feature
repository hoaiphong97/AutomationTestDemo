Feature: Greets

A short summary of the feature

@tag1
Scenario: Greet
	Given the demo app is running
	When I enter "Phong dep trai" in the input box
	When I click the hello button
	Then I should see ""Phong dep trai"" in the result text
