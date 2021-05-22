using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Books.Queries;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Application.IntegrationTests.Books.Queries
{
    using static Testing;

    public class GetBooksTests : TestBase
    {
        [Test]
        public async Task ShouldReturnOneBook()
        {
            await AddAsync(new Book
            {
                ISBN = "355118969-6",
                Title = "Red Riding Hood",
                Year = 1985,
                Language = "English",
                Edition = 5,
                Binding = "hardcover",
                Can_Lend = true,
                Is_Interesting = false
            }) ;

            var query = new GetBooksQuery();

            var result = await SendAsync(query);

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task ShouldReturnAllBooks()
        {
            await AddAsync(new Book
            {
                ISBN = "355118969-6",
                Title = "Red Riding Hood",
                Year = 1985,
                Language = "English",
                Edition = 5,
                Binding = "hardcover",
                Can_Lend = true,
                Is_Interesting = false
            }) ;

            await AddAsync(new Book
            {
                ISBN = "355118969-6",
                Title = "Red Riding Hood",
                Year = 1985,
                Language = "English",
                Edition = 6,
                Binding = "hardcover",
                Can_Lend = true,
                Is_Interesting = false
            }) ;

            await AddAsync(new Book
            {
                ISBN = "355118969-6",
                Title = "Red Riding Hood",
                Year = 1985,
                Language = "English",
                Edition = 7,
                Binding = "hardcover",
                Can_Lend = true,
                Is_Interesting = false
            }) ;

            var query = new GetBooksQuery();

            var result = await SendAsync(query);

            Assert.AreEqual(3, result.Count());
        }
    }
}
