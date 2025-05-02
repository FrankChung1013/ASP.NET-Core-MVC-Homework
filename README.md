EF DB first command 
===
Scaffold-DbContext "Server=<<YourSqlServer>>;Database=<<YourDb>>;User Id=<<YourUserId>>;Password=<<YourPassWorld>>;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir <<MigrateDir>>