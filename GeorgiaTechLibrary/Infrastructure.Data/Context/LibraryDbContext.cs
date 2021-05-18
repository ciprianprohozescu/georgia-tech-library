using System;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Book { get; set; }
    }
}
