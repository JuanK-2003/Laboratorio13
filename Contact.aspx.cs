using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio13
{
    public partial class Contact : Page
    {
        static List<Principal> principal = new List<Principal>();
        static List<Students> students = new List<Students>();
        static List<Teachers> teachers = new List<Teachers>();
        static List<administrativeStaff> staffs = new List<administrativeStaff>();

        string studentFiles = "";
        string techersFiles = "";
        string staffFiles = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !IsPostBack )
            {
                studentFiles = Server.MapPath("Estudiantes.json");
                techersFiles = Server.MapPath("Profesores.json");
                staffFiles = Server.MapPath("Personal administrativo.json");

                if (validateFiles())
                {
                    using (StreamReader rd = new StreamReader(studentFiles))
                    {
                        students = JsonConvert.DeserializeObject<List<Students>>(rd.ReadToEnd());
                        this.GridViewStudents.DataSource = students;
                        this.GridViewStudents.DataBind();
                    }
                    using (StreamReader rd = new StreamReader(techersFiles))
                    {
                        teachers = JsonConvert.DeserializeObject<List<Teachers>>(rd.ReadToEnd());
                        this.GridViewTeachers.DataSource = teachers;
                        this.GridViewTeachers.DataBind();
                    }
                    using (StreamReader rd = new StreamReader(staffFiles))
                    {
                        staffs = JsonConvert.DeserializeObject<List<administrativeStaff>>(rd.ReadToEnd());
                        this.GridViewStaff.DataSource = staffs;
                        this.GridViewStaff.DataBind();
                    }
                    if (students == null)
                    {
                        students = new List<Students>();
                    }
                    if (teachers == null)
                    {
                        teachers = new List<Teachers>();
                    }
                    if (staffs == null)
                    {
                        staffs = new List<administrativeStaff>();
                    }
                }
                else
                {
                    File.Create(studentFiles);
                    File.Create(techersFiles);
                    File.Create(staffFiles);
                }
            }
            LabelNombre.Visible = false;
            TextNombre.Visible = false;
            ButtonGuardar.Visible = false;
        }

        protected bool validateFiles()
        {
            return File.Exists(studentFiles)
                && File.Exists(techersFiles)
                && File.Exists(staffFiles);
        }

        protected void saveAll()
        {
            using (StreamWriter sr = new StreamWriter(studentFiles))
            {
                sr.Write(JsonConvert.SerializeObject(students));
            }
            using (StreamWriter sr = new StreamWriter(techersFiles))
            {
                sr.Write(JsonConvert.SerializeObject(teachers));
            }
            using (StreamWriter sr = new StreamWriter(staffFiles))
            {
                sr.Write(JsonConvert.SerializeObject(staffs));
            }
        }

        protected void GridViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = GridViewStudents.SelectedIndex;
            GridViewStudents.DataSource = principal[selec].Students;
            GridViewStudents.DataBind();
        }

        protected void GridViewTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = GridViewTeachers.SelectedIndex;
            GridViewTeachers.DataSource = principal[selec].Teachers;
            GridViewTeachers.DataBind();
        }

        protected void GridViewStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = GridViewStaff.SelectedIndex;
            GridViewStaff.DataSource = principal[selec].Students;
            GridViewStaff.DataBind();
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int idStudents = GridViewStudents.SelectedIndex;
            students[idStudents].Students.RemoveAt(idStudents);
            saveAll();
            GridViewStudents.DataSource = principal[idStudents].Students;
            GridViewStudents.DataBind();

            int idTeachers = GridViewTeachers.SelectedIndex;
            teachers[idTeachers].Teachers.RemoveAt(idTeachers);
            saveAll();
            GridViewTeachers.DataSource = principal[idTeachers].Teachers;
            GridViewTeachers.DataBind();

            int idStaff = GridViewStaff.SelectedIndex;
            staffs[idStaff].Staffs.RemoveAt(idStaff);
            saveAll();
            GridViewStaff.DataSource = principal[idStaff].Staffs;
            GridViewStaff.DataBind();
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            int idStudents = GridViewStudents.SelectedIndex;
            LabelNombre.Visible = true;
            TextNombre.Visible = true;
            ButtonGuardar.Visible = true;
            TextNombre.Text = principal[idStudents].Students[idStudents].name;

            int idTeachers = GridViewTeachers.SelectedIndex;
            LabelNombre.Visible = true;
            TextNombre.Visible = true;
            ButtonGuardar.Visible = true;
            TextNombre.Text = principal[idTeachers].Teachers[idTeachers].name;

            int idStaff = GridViewStaff.SelectedIndex;
            LabelNombre.Visible = true;
            TextNombre.Visible = true;
            ButtonGuardar.Visible = true;
            TextNombre.Text = principal[idStaff].Staffs[idStaff].name;            
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            int idStudents = GridViewStudents.SelectedIndex;
            principal[idStudents].Students[idStudents].name = TextNombre.Text;
            saveAll();
            GridViewStudents.DataSource = principal[idStudents].Students;
            GridViewStudents.DataBind();

            int idTeachers = GridViewTeachers.SelectedIndex;
            principal[idTeachers].Teachers[idTeachers].name = TextNombre.Text;
            saveAll();
            GridViewTeachers.DataSource = principal[idTeachers].Teachers;
            GridViewTeachers.DataBind();

            int idStaff = GridViewStaff.SelectedIndex;
            principal[idStaff].Staffs[idStaff].name = TextNombre.Text;
            saveAll();
            GridViewStaff.DataSource = principal[idStaff].Staffs;
            GridViewStaff.DataBind();
        }
    }
}