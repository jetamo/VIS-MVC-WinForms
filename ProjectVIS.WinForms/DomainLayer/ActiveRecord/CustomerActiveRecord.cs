using DataLayer;
using DataLayer.TableDataGateWay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DomainLayer.ActiveRecord
{
    public class CustomerActiveRecord
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public CustomerActiveRecord(int _id, string _name, string _surname, string _email)
        {
            ID = _id;
            Name = _name;
            Surname = _surname;
            Email = _email;
        }
        public CustomerActiveRecord(string _name, string _surname, string _email)
        {
            ID = null;
            Name = _name;
            Surname = _surname;
            Email = _email;
        }
        public CustomerActiveRecord()
        {
            ID = null; 
            Name = null;
            Surname = null;
            Email = null;
        }

        public static List<CustomerActiveRecord> Find()
        {
            List<CustomerActiveRecord> customersList = new List<CustomerActiveRecord>();

            var customerGateWay = new CustomerTDG();
            DataTable dt = customerGateWay.Find();
            foreach (DataRow dr in dt.Rows)
                customersList.Add(MapResultsetToObject(dr));
            
            return customersList;
        }
        
        public void Save()
        {
            var customerGateWay = new CustomerTDG();
            int tmpId = customerGateWay.Insert(Name, Surname, Email);
            ID = tmpId;
        }

        public static CustomerActiveRecord MapResultsetToObject(DataRow dr)
        {
            CustomerActiveRecord NewCustomer = new CustomerActiveRecord();
            NewCustomer.ID = Convert.ToInt32(dr.ItemArray[0].ToString());
            NewCustomer.Name = dr.ItemArray[1].ToString();
            NewCustomer.Surname = dr.ItemArray[2].ToString();
            NewCustomer.Email = dr.ItemArray[3].ToString();

            return NewCustomer;
        }
    }
}
