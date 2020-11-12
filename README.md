# Programming Assignment

## Task Description

In the following assignment you will be required to create a simple web application using the following frameworks/tools:
- ASP.NET MVC 5
- WebAPI 2
- Entity Framework 6
- SQLServer
- Any SPA or plain JS/JQuery

## Instructions:

- Create a web application (very simple HTML design, you can use simple lines, no need responsive) that emulates ATM.
- The application should be a single page application that shows simple actions with ATM.
- You can use any SPA or you can use simple JS or JQuery.
- Create a database (MS SQL) with two tables:
  - Customer – contains information about a customer:
    - UserName
	- PIN (4 symbols) – should be hashed
	- Balance
  - History – contains information about transaction history
- The application should support the following actions:
  - First screen:
    - Show two fields: UserName and PIN
	- If the user enters correct UserName and PIN show next screen
- Second screen contains two buttons: Cash and Balance
- If a user selects Balance you need to ask PIN (just a PIN) again and if PIN correct show balance
- If a user selects Cash:
  - Ask PIN
  - Show several buttons: 50, 100, 200, Other Sum
  - If a user selects 50, 100 or 200 then show message "Please take your money" and close screen after 10 secs
  - If a user selects "Other sum" then show a screen with fields to enter sum and button "Cash"
  - Next, the same like 9.3
- If a user takes cash, you must check balance before. If there is no enough money, you have to show appropriate message.

Will be plus, if you will be able to create screen, where a user can see transaction history.

## Online demo

- Heroku: https://bank-mvc.herokuapp.com
