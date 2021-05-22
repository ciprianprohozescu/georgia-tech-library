using System;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace Infrastructure.Persistance
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Book { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
