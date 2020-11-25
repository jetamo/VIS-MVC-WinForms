using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataLayer.TableDataGateWay
{
    public class BookDTO
    {
        public BookDTO(AuthorDTO _author, string _title, string _genres, int _year, int _available)
        {
            Author = _author;
            Title = _title;
            Genres = _genres;
            Year = _year;
            Available = _available;
        }
        public int ID { get; set; }
        public AuthorDTO Author { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public int Year { get; set; }
        public int Available { get; set; }
    }
}
