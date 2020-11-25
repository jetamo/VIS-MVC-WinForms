using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.TableDataGateWay
{
    public class BookTDG
    {
        public BookDTO GetBookByID(int id)
        {
            //return new BookDTO();
            return null; //temp
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            // Call to DB HERE
            return new List<BookDTO>();
        }

        public bool Insert(BookDTO book)
        {
            // Call to DB HERE
            return true;
        }
    }
}
