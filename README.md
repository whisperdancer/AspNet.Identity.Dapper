AspNet.Identity.Dapper
======================

AspNet Identity 2.0 Storage Provider using Dapper
.A drop in replacement for EF.

1. Create Member database using scripts in the database project. Note, the db has been modified from the standard AspNet database tables. The architects of AspNet Identity designed it with this in mind. My modifications consist of table name changes and the primary key on the Member table is an int rather than the default string.
2. Open the solution in VS 2013. Update web.config to point to the location of your database
3. Run the solution.
4. Note, the solution includes a working MVC5 website that has already been wired up to use Dapper rather than EF.
