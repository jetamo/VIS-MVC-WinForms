using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.ActiveRecord
{
    public class AuthorActiveRecord
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public AuthorActiveRecord(int _id, string _name, string _surname)
        {
            ID = _id;
            Name = _name;
            Surname = _surname;
        }
        public AuthorActiveRecord(string _name, string _surname)
        {
            ID = null;
            Name = _name;
            Surname = _surname;
        }
        public AuthorActiveRecord()
        {
            ID = null;
            Name = null;
            Surname = null;
        }

        public static List<AuthorActiveRecord> Find()
        {
            List<AuthorActiveRecord> authorsList = new List<AuthorActiveRecord>();

            var authorGateWay = new AuthorTDG();
            DataTable dt = authorGateWay.Find();
            foreach (DataRow dr in dt.Rows)
                authorsList.Add(MapResultsetToObject(dr));
            
            return authorsList;
        }
        
        public void Save()
        {
            var bookGateWay = new AuthorTDG();
            int tmpId = bookGateWay.Insert(this.Name, this.Surname);
            ID = tmpId;
        }

        public static AuthorActiveRecord MapResultsetToObject(DataRow dr)
        {
            AuthorActiveRecord NewAuthor = new AuthorActiveRecord();
            NewAuthor.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewAuthor.Name = dr.ItemArray[1].ToString();
            NewAuthor.Surname = dr.ItemArray[2].ToString();

            return NewAuthor;
        }
    }
}
