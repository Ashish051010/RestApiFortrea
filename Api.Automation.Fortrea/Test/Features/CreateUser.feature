Feature: CreateUser

create a new user 

@tag1
Scenario: Create a new user with valid inputs 
	Given user with name "Peter"
	And user with job "Manager"
	When send request to create user 
	Then validate user is created
