Migration Management

In order to get database updates working remember to add Models as DbSet<Model> to EfContext class.
Then in Package Manager Console:

	The following line creates a new migration in Migrations folder
1) EntityFrameworkCore\Add-Migration <migration_name>

	The following line apply all migrations not already applied against database
2) EntityFrameworkCore\Updtate-Database


* More info: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/