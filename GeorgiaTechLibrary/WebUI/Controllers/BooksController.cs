using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books;
using Application.Books.Commands;
using Application.Books.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BooksController : ApiControllerBase
    {
        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<BookDto>> GetBooks([FromQuery] GetBooksQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooksByTitle([FromQuery] GetBooksByTitleQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
