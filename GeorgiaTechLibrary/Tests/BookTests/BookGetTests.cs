using Domain.Models;
using Application.Books.Queries;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgiaTechLibrary.Tests
{
    using static Testing;

    public class BookGetTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllBooks()
        {
            await AddAsync(new Book
            {
                ISBN = "69",
                Title = "Big Book",
                Year = 1969,
                Language = "Ugandan",
                Edition = 1,
                Binding = "What",
                Can_Lend = true,
                Is_Interesting = false
            });

            var query = new GetBooksQuery();

            var result = await SendAsync(query);

            result.ToList().Should().HaveCount(1);
        }
    }
}