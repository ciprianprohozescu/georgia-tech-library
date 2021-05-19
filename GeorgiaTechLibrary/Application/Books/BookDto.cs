using System;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;

namespace Application.Books
{
    public class BookDto : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }
        public int Edition { get; set; }
        public string Binding { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>()
                .ForMember(d => d.Year, opt => opt.MapFrom(s => (int)s.Year))
                .ForMember(d => d.Edition, opt => opt.MapFrom(s => (int)s.Edition));
        }
    }
}
