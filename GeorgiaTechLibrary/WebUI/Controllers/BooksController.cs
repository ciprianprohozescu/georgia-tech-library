using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BooksController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Book>> GetTodoItemsWithPagination([FromQuery] GetBooksQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
