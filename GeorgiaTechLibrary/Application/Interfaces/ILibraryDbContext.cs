using System;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Interfaces
{
    public interface ILibraryDbContext
    {
        public DbSet<Book> Book { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
