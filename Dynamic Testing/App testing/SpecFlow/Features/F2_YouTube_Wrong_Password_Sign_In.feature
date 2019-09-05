Feature: So i want to access my Google account on youtube
         by typing my email and the wrong password.
		 I want to see if there is any 'mechanism' to stop
		 me from accessing the log in function after i entered
		 the wrong password several times.


@YouTube_Wrong_Password_Sign_in
Scenario: I want to test the input validation by typing the
		  incorrect email or password.
		  
	Given I just accessed YouTube from Google Chrome
	And I want to access my account
	When I fill the forms with the wrong information
	Then i wont be able to continue to the next fields
