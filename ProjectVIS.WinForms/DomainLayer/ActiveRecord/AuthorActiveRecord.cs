using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.TableModule
{
    public class AuthorActiveRecord
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

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
            bookGateWay.Insert(this.Name, this.Surname);
        }

        public static AuthorActiveRecord MapResultsetToObject(DataRow dr)
        {
            AuthorActiveRecord NewCustomer = new AuthorActiveRecord();
            NewCustomer.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewCustomer.Name = dr.ItemArray[1].ToString();
            NewCustomer.Surname = dr.ItemArray[2].ToString();

            return NewCustomer;
        }
    }
}
