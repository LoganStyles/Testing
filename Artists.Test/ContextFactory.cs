using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Artists.Test;

public class ContextFactory : IDisposable
{

    private readonly SqliteConnection _connection;
    private readonly ArtistsContext _context;

    public ContextFactory()
    {
        this._connection = new SqliteConnection("DataSource=:memory:");
        this._connection.Open();
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
        _connection.Dispose();
    }
}