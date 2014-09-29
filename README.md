AspNet.Identity.Dapper
======================

AspNet Identity 2.0 Storage Provider using Dapper. A drop in replacement for EF.

1. Create Member database using scripts in the database project. Note, the db has been modified from the standard AspNet database tables. The architects of AspNet Identity designed it with this in mind. My modifications are mostly cosmetic and consist of table name changes and the primary key on the Member table is an int rather than the default string. Otherwise all remaining columns in all tables are identical to AspNet default tables. I designed it this way to demonstrate how easy it is to use your own table design with Identity 2.0. Note, when changing db table names or columns remember to modify the queries in the table classes. 
2. Open the solution in VS 2013. Update web.config to point to the location of your database
3. Run the solution.
4. Note, the solution includes a working MVC5 website that has already been wired up to use Dapper rather than EF. EF has been completely removed from the sample site. Of course if you need it you can always add it back via NuGet.
