using Application.Books.Commands;
using Domain.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests.Application.IntegrationTests.Books.Commands
{
    using static Testing;

    public class CreateBookTest : TestBase
    {
        [Test]
        public async Task ShouldCreateBook()
        {
            var command = new CreateBookCommand
            {
                ISBN = "355118969-6",
                Title = "Red Riding Hood",
                Year = 1985,
                Language = "English",
                Edition = 5,
                Binding = "hardcover",
                Can_Lend = true,
                Is_Interesting = false
            };

            var id = await SendAsync(command);

            var book = await FindAsync<Book>(id);

            book.Should().NotBeNull();
            book.Title.Should().Be(command.Title);
        }
    }
}