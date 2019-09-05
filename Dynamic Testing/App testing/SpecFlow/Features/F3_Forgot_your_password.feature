Feature: So i tried and i tried to remember my valid password
         but i just can't find it. So i want to see the alternatives that
		 Google offers to restore  my password. Lets see just 4 options.

@Forgot_your_password
Scenario: I try to log in but i can't because i don't 
		  rememeber my password. So let's see the options
		  that Google offers to restore it (or to generate a new one).

	Given I accessed the log in functionality in Google
	And I keep entering the wrong password so i want to restore it
	When I press forgot password
	Then I should see 4 different options about how i can restore it by clicking the next one
