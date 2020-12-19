using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.ActiveRecord;

namespace DomainLayer
{
    public static class Var
    {
        public static LibrarianActiveRecord knihovnik
        {
            get
            {
                return LibrarianActiveRecord.Find()[0];
            }
        }
        public static CustomerActiveRecord zakaznik
        {
            get
            {
                return CustomerActiveRecord.Find()[1];
            }
        }
    }
}
