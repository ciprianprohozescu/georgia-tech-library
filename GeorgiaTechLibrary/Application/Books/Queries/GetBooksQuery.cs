using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Interfaces;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Application.Books.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<Book>>
    {
    }

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly ILibraryDbContext _context;

        public GetBooksQueryHandler(ILibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Book.ToListAsync();
        }
    }
}
