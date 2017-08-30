Solution details
================

## Dynamics 365 communication

First, we must implement a service to deal with OAuth to properly connect the user to the Dynamics 365 and receive a access token that will allow us to request the data.

To do that, a new DynamicsSignInManager overriding some of the SignInManager methods, allowed the integration between Dynamics 365 to the ASP.NET MVC Identity framework.

## Business rules

The most important aspect of the business rules is related to the entity edition lock. Here is a summary of the implementation:
 - before edit an entity, the user requests a lock
 - after updating the entity, the lock is released, even if the update fails
 - the lock is valid for 30 minutes
 - if the user cancels the edit, the lock is released

## Storage

To keep track of entity locks, we must be able to store them. For simplicity, the system is using Entity Framework with SQL Server

## Front end

Due to time constrains, it was adopted a solution based on razor and jQuery.
For production purpose it should be avoided, because it will add serious dificulties to create a rich experience for the customer.

## SignalR/WebSockets (not implemented)

To keep clients updated regarding to locks, it is possible to rely on a socket techonology. allowing the customers to receive a notification when a entity previously locked were released.

## Branching strategy (not implemented)

The use of Microsoft Extensibility Framework (MEF) allow us to have a main solution and a different implementation for different customers. 

Depending on the customization necessities, it is possible to implement a extension interface with before/after actions on the system and consume them through MEF inside the main application. By this way we can keep things really separated, with our solution in one repository and customer's customizations in its own repositories.

If the branching strategy is related to front end customizations, the solution can be even easier, with replacement of some base html/css files during the solution deployment.

## Create and Delete entities

Due to the lack of time, those actions were not implemented. The implementation is really straightforward:
 - for delete, we must check if there is any lock for the entity, then execute a DELETE to the endpoint considering the entity primary key, the same way that is being done by the update endpoint
 - for insert, we must validate few fields that forms the primary key, then execute a POST with the entity
 - more details can be found here: [https://community.dynamics.com/crm/b/scaleablesolutionsblog/archive/2016/01/18/crud-operations-using-web-api]

## Screenshots

![Login page](https://raw.githubusercontent.com/tiagodeliberali/dynamicsodata/master/screenshots/login_page.png)
![Customer groups](https://raw.githubusercontent.com/tiagodeliberali/dynamicsodata/master/screenshots/customer_groups.png)
![Customer](https://raw.githubusercontent.com/tiagodeliberali/dynamicsodata/master/screenshots/customers.png)

## References

Basic OData info on Dynamics 365 for Finance and Operations, Enterprise edition
[https://docs.microsoft.com/en-us/dynamics365/unified-operations/dev-itpro/data-entities/odata?toc=dynamics365/unified-operations/fin-and-ops/toc.json]

How to consume the OData endpoints
[https://community.dynamics.com/crm/b/scaleablesolutionsblog/archive/2016/01/18/crud-operations-using-web-api]

UserPasswordCredential doesn't support .NET Core
[https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/issues/482]
