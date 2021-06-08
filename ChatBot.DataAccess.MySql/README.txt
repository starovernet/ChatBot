I use entity framework core as ORM with code first approach, every time db model changed, need to run command to add migration, 
after that can run command to update database. To generate migration script can use command Generate Script.

Add migration:
dotnet ef migrations add Initial --context ChatBotDbContext

Update database:
dotnet ef database update

Generate Script:
dotnet ef migrations script 