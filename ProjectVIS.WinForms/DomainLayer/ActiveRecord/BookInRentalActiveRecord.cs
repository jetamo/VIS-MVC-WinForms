using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.TableModule
{
    public class BookInRentalActiveRecord
    {
        public int? ID { get; set; }
        public BookActiveRecord Book { get; set; }
        public RentalActiveRecord Rental { get; set; }

        public BookInRentalActiveRecord(int _id, BookActiveRecord _book, RentalActiveRecord _rental)
        {
            ID = _id;
            Book = _book;
            Rental = _rental;
        }
        public BookInRentalActiveRecord(BookActiveRecord _book, RentalActiveRecord _rental)
        {
            ID = null;
            Book = _book;
            Rental = _rental;
        }
        public BookInRentalActiveRecord()
        {
            ID = null;
            Book = null;
            Rental = null;
        }

        public static List<BookInRentalActiveRecord> Find()
        {
            List<BookInRentalActiveRecord> booksInRentalList = new List<BookInRentalActiveRecord>();

            var bookInRentalGateWay = new BookInRentalTDG();
            DataTable dt = bookInRentalGateWay.Find();
            foreach (DataRow dr in dt.Rows)
                booksInRentalList.Add(MapResultsetToObject(dr));
            
            return booksInRentalList;
        }
        
        public void Save()
        {
            var bookInRentalGateWay = new BookInRentalTDG();
            bookInRentalGateWay.Insert((int)this.Book.ID, (int)this.Rental.ID);
        }

        public static BookInRentalActiveRecord MapResultsetToObject(DataRow dr)
        {
            BookInRentalActiveRecord NewBook = new BookInRentalActiveRecord();
            var bookTemp = new BookTDG();
            var rentalTemp = new RentalTDG();
            NewBook.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewBook.Book = BookActiveRecord.MapResultsetToObject(bookTemp.GetBookByID(Convert.ToInt32(dr.ItemArray[1].ToString())).Rows[0]);
            NewBook.Rental = RentalActiveRecord.MapResultsetToObject(rentalTemp.GetRentalByID(Convert.ToInt32(dr.ItemArray[2].ToString())).Rows[0]);

            return NewBook;
        }
    }
}
