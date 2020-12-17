using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.ActiveRecord
{
    public class BookActiveRecord
    {
        public int? ID { get; set; }
        public AuthorActiveRecord Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? Available { get; set; }

        public override string ToString()
        {
            return Title;
        }

        public BookActiveRecord(int _id, AuthorActiveRecord _author, string _title, string _genre, int _available)
        {
            ID = _id;
            Author = _author;
            Title = _title;
            Genre = _genre;
            Available = _available;
        }
        public BookActiveRecord(AuthorActiveRecord _author, string _title, string _genre, int _available)
        {
            ID = null;
            Author = _author;
            Title = _title;
            Genre = _genre;
            Available = _available;
        }
        public BookActiveRecord()
        {
            ID = null;
            Author = null;
            Title = null;
            Genre = null;
            Available = null;
        }

        public static List<BookActiveRecord> Find()
        {
            List<BookActiveRecord> booksList = new List<BookActiveRecord>();

            var bookGateWay = new BookTDG();
            DataTable dt = bookGateWay.Find();
            foreach (DataRow dr in dt.Rows)
                booksList.Add(MapResultsetToObject(dr));
            
            return booksList;
        }

        public static BookActiveRecord Find(int _id)
        {
            BookActiveRecord book = new BookActiveRecord();

            var bookGateWay = new BookTDG();
            DataTable dt = bookGateWay.GetBookByID(_id);
            book = MapResultsetToObject(dt.Rows[0]);
            
            return book;
        }
        
        public void Save()
        {
            var bookGateWay = new BookTDG();
            if (ID != null)
                bookGateWay.Update((int)this.ID, (int)this.Author.ID, this.Title, this.Genre, (int)this.Available);
            else
            {
                int tmpId = bookGateWay.Insert((int)this.Author.ID, this.Title, this.Genre, (int)this.Available);
                ID = tmpId;
            }
        }

        public static BookActiveRecord MapResultsetToObject(DataRow dr)
        {
            BookActiveRecord NewBook = new BookActiveRecord();
            var authorTemp = new AuthorTDG();
            NewBook.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewBook.Author = AuthorActiveRecord.MapResultsetToObject(authorTemp.GetAuthorByID(Convert.ToInt32(dr.ItemArray[1].ToString())).Rows[0]);
            NewBook.Title = dr.ItemArray[2].ToString();
            NewBook.Genre = dr.ItemArray[3].ToString();
            NewBook.Available = Convert.ToInt32(dr.ItemArray[4].ToString());

            return NewBook;
        }
    }
}
