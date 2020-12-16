using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.TableModule
{
    public class LibrarianActiveRecord
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public LibrarianActiveRecord(int _id, string _name, string _surname, string _email)
        {
            ID = _id;
            Name = _name;
            Surname = _surname;
            Email = _email;
        }
        public LibrarianActiveRecord(string _name, string _surname, string _email)
        {
            ID = null;
            Name = _name;
            Surname = _surname;
            Email = _email;
        }
        public LibrarianActiveRecord()
        {
            ID = null;
            Name = null;
            Surname = null;
            Email = null;
        }

        public static List<LibrarianActiveRecord> Find()
        {
            List<LibrarianActiveRecord> librariansList = new List<LibrarianActiveRecord>();

            var librarianGateWay = new LibrarianTDG();
            DataTable dt = librarianGateWay.Find();
            foreach (DataRow dr in dt.Rows)
                librariansList.Add(MapResultsetToObject(dr));
            
            return librariansList;
        }
        
        public void Save()
        {
            var librarianGateWay = new LibrarianTDG();
            int tmpId = librarianGateWay.Insert(Name, Surname, Email);
            ID = tmpId;
        }

        public static LibrarianActiveRecord MapResultsetToObject(DataRow dr)
        {
            LibrarianActiveRecord NewLibrarian = new LibrarianActiveRecord();
            NewLibrarian.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewLibrarian.Name = dr.ItemArray[1].ToString();
            NewLibrarian.Surname = dr.ItemArray[2].ToString();
            NewLibrarian.Email = dr.ItemArray[3].ToString();

            return NewLibrarian;
        }
    }
}
