using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books;
using Application.Books.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BooksController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooks([FromQuery] GetBooksQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
