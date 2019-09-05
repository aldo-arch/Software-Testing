Feature: Playing an album depending on the artist that i want.
		We don't have to log in.

@Album_artist
Scenario: After i searched  for my favorite artist i want to see some of their albums and play one of them
	Given I just accessed YouTube by Google Chrome browser
	And I search about my favorite artist
	When I see the results,i check their albums
	Then I play one of their albums
