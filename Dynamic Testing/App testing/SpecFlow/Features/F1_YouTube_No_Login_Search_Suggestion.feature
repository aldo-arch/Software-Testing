Feature: So i just need to search about something
		 on the YouTube search box and i just need
		 to test the suggestions.
		 Ex: I search about Mr.Bean and i do not click search
		 but I select the third suggestion and then I click enter.
		 This do not require log in.

@Youtube_no_login_search_suggestion_third
Scenario: Select the third suggestion from the YouTube searchbox
	Given I just accessed the YouTube page on Google Chrome
	And Im about to search something (depending on my interests)
	When The suggestions are available
	Then I just click the third suggestion (no matter what)
