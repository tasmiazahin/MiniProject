# MiniProject
## Create a application where a user can add time report of their project work and store data to postgressql database

The goals of the project is to create a simple time reporting application where a consultant add their work hours on different projects
they work on. Those reports can be also updated afterwards. No user login functionality required to minimise the scope. Learning how to work
with multiple database tables and their relationship is the primary goal of the assignment.



### Functionalities

* Added a functionalities where user can select the menu using keyboard up and down arrow.
* Create a person to  table
* Create a project to table
* Create time report to table
* Update person record
* Update project record
* Update time report record
 
### Technology stack

* C#
* PostgressSQL database
* Dapper
* NpgSQL


### Challanges
Not taking id (primary key of the table) as user input was one of the requirement. If any user enter a project name with a lot characters, it would be
hard to type it when they want to update the record again.

To update record from tz_project_person table, I allowed to user to input project_id and person_id to target a unique record of the table. 


### To be improved

* Application should allow to add multiple entry of time report for same project.
