using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }
        public int Edition { get; set; }
        public string Binding { get; set; }
        public bool Can_Lend { get; set; }
        public bool Is_Interesting { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly ILibraryDbContext _context;

        public CreateBookCommandHandler(ILibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = new Book
            {
                ISBN = request.ISBN,
                Title = request.Title,
                Year = (Int16)request.Year,
                Language = request.Language,
                Edition = (Int16)request.Edition,
                Binding = request.Binding,
                Can_Lend = true,
                Is_Interesting = false,
            };

            _context.Book.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
