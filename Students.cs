using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio13
{
    public class Students : Principal
    {
        public string ID { get; set; }

        public Students()
        {
        }

        public Students(string name, string lastName, string address, DateTime dateofBirth, string curso, string ID)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.dateofBirth = dateofBirth;
            this.curso = curso;
            this.ID = ID;
        }
    }
}