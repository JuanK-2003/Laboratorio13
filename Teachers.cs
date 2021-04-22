using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio13
{
    public class Teachers : Principal
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public Teachers()
        {
        }

        public Teachers(string name, string lastName, string address, DateTime dateofBirth, string curso, string ID, string Title)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.dateofBirth = dateofBirth;
            this.curso = curso;
            this.ID = ID;
            this.Title = Title;
        }
    }
}