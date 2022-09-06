using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Artists.Test;

public class EmployeeTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly ArtistsContext _context;

    public EmployeeTests()
    {
        this._connection = new SqliteConnection("DataSource=:memory:");
        this._connection.Open();

        this._context = CreateContext();
    }

    [Fact]
    public void VerifyThatEmployeesExist()
    {

        var employeeCount = this._context.Employees.Count();
        if (employeeCount != 0)
        {
            Assert.Equal(3, employeeCount);
        }
    }

    public ArtistsContext CreateContext()
    {

        var options = new DbContextOptionsBuilder<ArtistsContext>()
                        .UseSqlite(this._connection)
                        .Options;

        var context = new ArtistsContext(options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.AddRange(
            new Employee { FirstName = "Joe", LastName = "Rock", Age = 36 },
            new Employee { FirstName = "Martha", LastName = "Lucas", Age = 40 },
            new Employee { FirstName = "Jules", LastName = "Abrams", Age = 19 }
        );
        context.SaveChanges();

        return context;
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
    }
}