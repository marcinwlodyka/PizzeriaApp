using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PizzeriaApp.Models;

public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args = null)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>();

        return new AppDbContext(options.Options);
    }
}