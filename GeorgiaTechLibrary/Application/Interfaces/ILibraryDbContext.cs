using System;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ILibraryDbContext
    {
        public DbSet<Book> Book { get; set; }
    }
}
