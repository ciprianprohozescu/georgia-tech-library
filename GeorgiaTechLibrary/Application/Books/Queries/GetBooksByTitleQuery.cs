using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Books.Queries
{
    public class GetBooksByTitleQuery : IRequest<IEnumerable<BookDto>>
    {
        public string Title { get; set; } = "";
    }

    public class GetBooksByTitleQueryHandler : IRequestHandler<GetBooksByTitleQuery, IEnumerable<BookDto>>
    {
        private readonly ILibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksByTitleQueryHandler(ILibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksByTitleQuery request, CancellationToken cancellationToken)
        {
            return await _context.Book
                .Where(book => book.Title.Contains(request.Title))
                .OrderBy(book => book.Title)
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
