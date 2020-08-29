// On Proconecta.Data Directory run this:

//Add migration
dotnet ef --startup-project "./../Proconecta.Api/" migrations add MigrationName -v

//Update database 
dotnet ef --startup-project "./../Proconecta.Api/" database update -v

//	Remove migrations
dotnet ef --startup-project "./../Proconecta.Api/" migrations remove -v