Feature: Scientific Calculator

Background: 
	Given I navigated to Scientific Calculator
	Then Calculator title is Scientific


Scenario: Open Trigonmetri Calculator
	When I click "trig" button
	Then the following options should be available
	|sin|cos|tan|sec|csc|cot|hypShift|trigShift|

Scenario: Open Functions Calculator
	When I click "func" button
	Then the following options should be available
	|abs|floor|ceil|rand|dms|degrees|