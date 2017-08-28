Solution details
================

## Dynamics 365 communication

First, we must implement a service to deal with OAuth to properly connect the user to the Dynamics 365 and receive a access token that will allow us to request the data.

To do that, a new DynamicsSignInManager overriding some of the SignInManager methods, allowed the integration between Dynamics 365 to the ASP.NET MVC Identity framework.

## Storage

To keep track of entity locks, we must be able to store them. For simplicity, the system is using Entity Framework with SQL Server

## Front end

Due to time constrains, it was adopted a solution based on razor and jQuery.

## SignalR (not implemented)

To keep clients updated regarding to locks, it is possible to rely on a socket techonology. allowing the customers to receive a notification when a entity previously locked were released.

## Branching strategy (not implemented)

The use of Microsoft Extensibility Framework (MEF) allow us to have a main solution and a different implementation for different customers. 

Depending on the customization necessities, it is possible to implement a extension interface with before/after actions on the system and use MVC action filters to implement the behaviours imported through MEF.

If the branching strategy is related to front end customizations, the solution can be even easier, with replacement of some base html/css files during the solution deployment.


## References

Basic OData info on Dynamics 365 for Finance and Operations, Enterprise edition
[https://docs.microsoft.com/en-us/dynamics365/unified-operations/dev-itpro/data-entities/odata?toc=dynamics365/unified-operations/fin-and-ops/toc.json]

How to consume the OData endpoints
[https://community.dynamics.com/crm/b/scaleablesolutionsblog/archive/2016/01/18/crud-operations-using-web-api]

UserPasswordCredential doesn't support .NET Core
[https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/issues/482]