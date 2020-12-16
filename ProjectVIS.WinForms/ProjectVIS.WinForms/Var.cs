using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.ActiveRecord;

namespace ProjectVIS.WinForms
{
    static class Var
    {
        public static LibrarianActiveRecord knihovnik
        {
            get
            {
                return LibrarianActiveRecord.Find()[0];
            }
        }
    }
}
