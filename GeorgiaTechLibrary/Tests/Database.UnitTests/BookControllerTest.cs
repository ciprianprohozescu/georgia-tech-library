using System;
using Xunit;
using Moq;
using Domain.Models;
using System.Collections.Generic;
using GenFu;

public class BookControllerTest
{
    [Fact]
    public void GetBooksTest()
    {
        //var service = new Mock<LibraryDbContext>();

        var books = GetFakeData();
        
    }

    private IEnumerable<Book> GetFakeData()
    {
        var i = 1;
        var books = A.ListOf<Book>(26);
        books.ForEach(x => x.Id = i++);
        return books;
    }
}