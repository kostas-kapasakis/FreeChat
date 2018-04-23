# FreeChat


Asp .NET MVC5 web application using 
-Entity Framework 6 -code first approach
-Javascript-JQuery
-SignalR 2.2.1
-Autofac DI
-AutoMapper
-Implement Repository Pattern by using 3 different projects
	-FreeChat.Core includes all the core business of the application
		Domain Models ,Services,Contracts
	-FreeChat.Persistence includes all the contracts's impementations
		Repositories,UnitOfWorks,DbContext class
	-FreeChat.Web is the Start up project.




Steps to get you going with the Solution
1)After cloning the repository head to the package manager console and hit the restore packages button
2)Also execute the command dotnet restore

I have provided to the app an DbInitializer so that it will have an administrator user with its corresponding role and an example user with also a role.

Admin User
username:administrator@gmail.com
password:Admin!@3

Example User
username:exampleuser@gmail.com
password:Example!@3






