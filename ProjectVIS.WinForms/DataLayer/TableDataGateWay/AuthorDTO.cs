using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.TableDataGateWay
{
    public class AuthorDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public AuthorDTO(int _id, string _name, string _surname)
        {
            ID = _id;
            Name = _name;
            Surname = _surname;
        }
        public AuthorDTO(string _name, string _surname)
        {
            ID = null;
            Name = _name;
            Surname = _surname;
        }
        public AuthorDTO()
        {
            ID = null;
            Name = null;
            Surname = null;
        }
    }
}

