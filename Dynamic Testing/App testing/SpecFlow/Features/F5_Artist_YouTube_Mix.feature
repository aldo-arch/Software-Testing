Feature: Just playing the YouTube mix for the artist

@Artist_YouTube_Mix
Scenario: After i search for an artist on Youtube i will play the YouTube Mix for that artist
	Given I accessed YouTube by Chrome browser
	And I searched about my favorite artist
	When I see the results i click on the YouTube mix
	Then I listen to the mix
