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

***

**Getting access token**

Select **POST** 

Enter URL http://localhost:**{port}**/token 

Click on **Body** select **x-www-form-urlencodedc** option and enter 3 parameter: 

1. Key: **username**, 	Value: **{Client name}**
1. Key: **password**, 		Value: **{Client EMail}**
1. Key: **grant_type**, 	Value: **password**

Click **Send** button

Will get **200 OK** and **access token**

![Alt text](https://image.ibb.co/bUHNd5/Getting_access_token.png)

> Note: Use the port on Web API is running. Also the Web API is published at Microsoft Azure Cloud, so you can use http://hjcsaxawebapi.azurewebsites.net/token

***

**Access restricted resource with access token**

Select **GET**

Enter URL http://localhost:**{port}**/**{route}** 

Click on **Header** and enter 1 parameter: 

1. Key: **Authorization**, 	Value: **{access_token}**

Click **Send** button

Will get **200 OK** and **data**

![Alt text](https://image.ibb.co/gDEPrQ/Access_restricted_resource_with_access_token.png)

> Note: Use the port on Web API is running. Also the Web API is published at Microsoft Azure Cloud, so you can use http://hjcsaxawebapi.azurewebsites.net/api /**{route}**


### Who do I talk to? ###

* Repo owner: javier.castillosuazo@gmail.com