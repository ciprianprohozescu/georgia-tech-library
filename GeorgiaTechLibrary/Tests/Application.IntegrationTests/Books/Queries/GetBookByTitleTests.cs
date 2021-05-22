using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Books.Queries;
using Domain.Models;
using Application.Books;
using NUnit.Framework;

namespace Tests.Application.IntegrationTests.Books.Queries
{
    using static Testing;

    public class GetBookByTitleTests : TestBase
    {
        [Test]
        [TestCase("Red Riding Hood", "Red Riding Hood")]
        [TestCase("Red Riding Hood", "Blue Riding Hood")]
        public async Task GetBookByTitle(string bookTitle, string searchTitle)
        {
            await AddAsync(new Book
            {
                ISBN = "355118969-6",
                Title = bookTitle,
                Year = 1985,
                Language = "English",
                Edition = 5,
                Binding = "hardcover",
                Can_Lend = true,
                Is_Interesting = false
            }) ;

            var query = new GetBooksByTitleQuery();

            query.Title = searchTitle;

            var result = await SendAsync(query);
            
            if(bookTitle == searchTitle)
            {
                Assert.AreEqual(result.First<BookDto>().Title, bookTitle);
            }
            else
            {
                Assert.IsEmpty(result.ToList<BookDto>());
            }
        }
    }
}
