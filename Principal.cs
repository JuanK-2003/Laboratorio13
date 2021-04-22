using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio13
{
    public class Principal
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime dateofBirth { get; set; }
        public string curso { get; set; }

        List<Students> students = new List<Students>();

        List<Teachers> teachers = new List<Teachers>();

        List<administrativeStaff> staffs = new List<administrativeStaff>();
        public List<Students> Students { get => students; set => students = value; }
        public List<Teachers> Teachers { get => teachers; set => teachers = value; }
        public List<administrativeStaff> Staffs { get => staffs; set => staffs = value; }

        public Principal()
        {
            Students = new List<Students>();
            Teachers = new List<Teachers>();
            Staffs = new List<administrativeStaff>();
        }

        public int calcAge()
        {
            int age = DateTime.Today.AddTicks(-dateofBirth.Ticks).Year - 1;
            return age;
        }
    }
}