using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio13
{
    public class administrativeStaff : Principal
    {
        public int IGSSnumber { get; set; }
        public string profession { get; set; }
        public DateTime startofWork { get; set; }
        public DateTime endofWork { get; set; }

        public administrativeStaff()
        {
        }
        public administrativeStaff(string name, string lastName, string address, DateTime dateofBirth, string curso, int IGSSnumber, string profession, DateTime startofWork, DateTime endofWork)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.dateofBirth = dateofBirth;
            this.curso = curso;
            this.IGSSnumber = IGSSnumber;
            this.profession = profession;
            this.startofWork = startofWork;
            this.endofWork = endofWork;
        }
    }
}