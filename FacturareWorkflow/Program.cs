using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

string ConnectionString = "Server=localhost;Database=PsscDb;Trusted_Connection=True;TrustServerCertificate=True";
var dbContextBuilder = new DbContextOptionsBuilder<DbContext>()
                                                .UseSqlServer(ConnectionString).Options;
using (var dbContext = new DbContext(dbContextBuilder))
{
    dbContext.Database.Migrate();
}