using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.TableModule
{
    public class RentalActiveRecord
    {
        public int? ID { get; set; }
        public LibrarianActiveRecord Librarian { get; set; }
        public CustomerActiveRecord Customer { get; set; }
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        bool Vraceno { get; set; }

        public RentalActiveRecord(int _id, LibrarianActiveRecord _librarian, CustomerActiveRecord _customer, DateTime _rentalDate, DateTime _returnDate, bool _vraceno)
        {
            ID = _id;
            Librarian = _librarian;
            Customer = _customer;
            RentalDate = _rentalDate;
            ReturnDate = _returnDate;
            Vraceno = _vraceno;
        }
        public RentalActiveRecord(LibrarianActiveRecord _librarian, CustomerActiveRecord _customer, DateTime _rentalDate, DateTime _returnDate, bool _vraceno)
        {
            ID = null;
            Librarian = _librarian;
            Customer = _customer;
            RentalDate = _rentalDate;
            ReturnDate = _returnDate;
            Vraceno = _vraceno;
        }
        public RentalActiveRecord()
        {
            ID = null;
            Librarian = null;
            Customer = null;
            RentalDate = null;
            ReturnDate = null;
            Vraceno = false;
        }

        public static List<RentalActiveRecord> Find()
        {
            List<RentalActiveRecord> rentalsList = new List<RentalActiveRecord>();

            var rentalGateWay = new RentalTDG();
            DataTable dt = rentalGateWay.Find();
            foreach (DataRow dr in dt.Rows)
                rentalsList.Add(MapResultsetToObject(dr));
            
            return rentalsList;
        }
        
        public void Save()
        {
            var rentalGateWay = new RentalTDG();
            rentalGateWay.Insert((int)this.Librarian.ID, (int)this.Customer.ID, RentalDate, ReturnDate, Vraceno);
        }

        public static RentalActiveRecord MapResultsetToObject(DataRow dr)
        {
            RentalActiveRecord NewRental = new RentalActiveRecord();
            var librarianTemp = new LibrarianTDG();
            var customerTemp = new CustomerTDG();
            NewRental.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewRental.Librarian = LibrarianActiveRecord.MapResultsetToObject(librarianTemp.GetLibrarianByID(Convert.ToInt32(dr.ItemArray[1].ToString())).Rows[0]);
            NewRental.Customer = CustomerActiveRecord.MapResultsetToObject(customerTemp.GetCustomerByID(Convert.ToInt32(dr.ItemArray[2].ToString())).Rows[0]);
            NewRental.RentalDate = Convert.ToDateTime(dr.ItemArray[3].ToString());
            NewRental.ReturnDate = Convert.ToDateTime(dr.ItemArray[4].ToString());
            NewRental.Vraceno = Convert.ToBoolean(dr.ItemArray[5].ToString());

            return NewRental;
        }
    }
}
