using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Application.Interfaces;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Application.Books.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        private readonly ILibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(ILibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Book
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
