using System;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Application.Interfaces;

namespace Infrastructure.Persistance
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Book { get; set; }
    }
}
