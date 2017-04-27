# README #

Axa Assesment (Back-end) by Héctor Javier Castillo Suazo (https://twitter.com/hjavixcs).

### What is this repository for? ###

* Visual Studio 2015 Solution (Web API 2). DDD Approach (Repositories, Mappers, Domain Entities, etc).
* Unit Testing (NUnit framework, NSubstitute)
* 1.0

### How do I get set up? ###

* Clone repository (or download source code)
* Respore Nuget Packages for the solution
* There is not database configuration
* Run Unit Tests (HJCS.Tests)
* Check if Web API project is set as Startup Project(HJCS.WebApi)
* Run the solution into Visual Studio
* Use Postman tool (https://www.getpostman.com/) to test the Web API (Or use Fiddler instead)

### Testing the Web API with Postman ###
**API Constraints:**

Get user data filtered by user id -> Can be accessed by users with role "users" and "admin":

* api/clients/**{id}**


Get user data filterd by user name -> Can be accessed by users with role "users" and "admin"

* api/clients/name/**{name}**


Get the list of policies linked to a user name -> Can be accessed by users with role "admin"

* api/clients/name/**{name}**/policies


Get the user linked to a policy number -> Can be accessed by users with role "admin"

* api/policies/**{policyId}**/client


(Under construction)

*Note*: The Web API is also published at Microsoft Azure Cloud (http://hjcsaxawebapi.azurewebsites.net/)


### Who do I talk to? ###

* Repo owner: javier.castillosuazo@gmail.com