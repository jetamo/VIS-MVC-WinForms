using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.TableModule
{
    public class BookModule
    {
        public void AddBook(AuthorDTO _author, string _title, string _genres, int _year, int _available)
        {
            var bookGateWay = new BookTDG();
            bookGateWay.Insert(new BookDTO(_author, _title, _genres, _year, _available));
        }
        public void AddAuthor(string _name, string _surname)
        {
            var bookGateWay = new AuthorTDG();
            bookGateWay.Insert(new AuthorDTO(_name, _surname));
        }
    }
}
