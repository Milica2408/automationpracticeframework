﻿Feature: MyAccount
	As a user
	I want to be able to click on the Sign in link
	So I can login to my account

@mytag
Scenario: The user can log in to his account
	Given Click on the Sign in link
	And Fill in the Email address  with 'predicmilica@gmail.com' and Password 'milica2408'
	When Click on the Sign in button
	Then message 'Welcome to your account. Here you can manage all of your personal information and orders.' is displayed to the user

Scenario: User can create an account
    Given Click on the Sign in link
	And   In the Create an account section enter the Email adress
	When  Click on the Create an account button
	And   Fill in all required fields
	And   Click on the Register button
	Then  user will be logged in
	And   user's full name is displayed
