#DOTNET 

# .NET - Minimal Project Structure

The most recommended structure for a .Net project is the following: 

```bash
myProject/
	|
	L Properties/ # Store configurations
		L launchSettings.json 
	L Controllers/
	L DTOs/ or Contracts/ 
	L Application/ 
	L Infrastructure/
	myProject.csproj
myProject.sln
```


* `Controllers/` folder: 
	* Stores MVC or API controllers with each method defining a current API endpoint. 
* `DTOs` or `Contracts` folder: 
	* Contains classes for determining data models for exchanging information in the API: 
		* Request and response models. 
* `Application` folder: 
	* Container business logic and orchestration of use cases, services that use external APIs and similar. 
* `Infrastructure` folder: 
	* Define the DB context, repository, migrations and implementations of database access. 