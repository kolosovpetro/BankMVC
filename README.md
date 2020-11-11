# Programming Assignment

In the following assignment you will be required to create a simple web
application using the following frameworks/tools:
- ASP.NET MVC 5
- WebAPI 2
- Entity Framework 6
- SQLServer
- Any SPA or plain JS/JQuery

Instructions:
1. Create a web application (very simple HTML design, you can use simple lines, no need responsive) that emulates ATM.
2. The application should be a single page application that shows simple actions with ATM.
3. You can use any SPA or you can use simple JS or JQuery.
4. Create a database (MS SQL) with two tables:
  - 4.1 Customer – contains information about a customer:
  - 4.1.1 UserName
  - 4.1.2 PIN (4 symbols) – should be hashed
  - 4.1.3 Balance
  - 4.2 History – contains information about transaction history
5. The application should support the following actions:
6. First screen:
  - 6.1 Show two fields: UserName and PIN
  - 6.2 If the user enters correct UserName and PIN show next
screen
7. Second screen contains two buttons: Cash and Balance
8. If a user selects Balance you need to ask PIN (just a PIN) again and
if PIN correct show balance
9. If a user selects Cash:
  - 9.1 Ask PIN
  - 9.2 Show several buttons: 50, 100, 200, Other Sum9.3 If a user selects 50, 100 or 200 then show message "Please take your money" and close screen after 10 secs
  - 9.4 If a user selects “Other sum” then show a screen with fields to enter sum and button “Cash”
  - 9.5 Next, the same like 9.3
10. If a user takes cash, you must check balance before. If there is no enough money, you have to show appropriate message. 

Will be plus, if you will be able to create screen, where a user can see transaction history.