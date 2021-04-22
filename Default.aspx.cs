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
    public partial class _Default : Page
    {
        static List<Students> students = new List<Students>();
        static List<Teachers> teachers = new List<Teachers>();
        static List<administrativeStaff> staffs = new List<administrativeStaff>();
        Principal principal = new Principal();

        string studentFiles = "";
        string techersFiles = "";
        string staffFiles = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if( RadioButtonStudent.Checked )
            {
                LabelAge.Visible = true;
                LabelCarne.Visible = true;
                TextID.Visible = true;
                LabelDPI.Visible = false;
                TextDPI.Visible = false;
                LabelTitle.Visible = false;
                TextTitle.Visible = false;
                LabelIGSS.Visible = false;
                TextIGSS.Visible = false;
                LabelProfession.Visible = false;
                TextProfession.Visible = false;
                LabelStar.Visible = false;
                CalendarStart.Visible = false;
                LabelEnd.Visible = false;
                CalendarEnd.Visible = false;
                ButtonTeacher.Visible = false;
                ButtonStaff.Visible = false;
                ButtonStudent.Visible = true;
            }
            if ( RadioButtonTeacher.Checked )
            {
                LabelAge.Visible = true;
                LabelCarne.Visible = false;
                TextID.Visible = false;
                LabelDPI.Visible = true;
                TextDPI.Visible = true;
                LabelTitle.Visible = true;
                TextTitle.Visible = true;
                LabelIGSS.Visible = false;
                TextIGSS.Visible = false;
                LabelProfession.Visible = false;
                TextProfession.Visible = false;
                LabelStar.Visible = false;
                CalendarStart.Visible = false;
                LabelEnd.Visible = false;
                CalendarEnd.Visible = false;
                ButtonStudent.Visible = false;
                ButtonStaff.Visible = false;
                ButtonTeacher.Visible = true;
            }
            if ( RadioButtonStaff.Checked )
            {
                LabelAge.Visible = true;
                LabelCarne.Visible = false;
                TextID.Visible = false;
                LabelDPI.Visible = false;
                TextDPI.Visible = false;
                LabelTitle.Visible = false;
                TextTitle.Visible = false;
                LabelIGSS.Visible = true;
                TextIGSS.Visible = true;
                LabelProfession.Visible = true;
                TextProfession.Visible = true;
                LabelStar.Visible = true;
                CalendarStart.Visible = true;
                LabelEnd.Visible = true;
                CalendarEnd.Visible = true;
                ButtonStaff.Visible = true;
                ButtonStudent.Visible = false;
                ButtonTeacher.Visible = false;
            }

            studentFiles = Server.MapPath("Estudiantes.json");
            techersFiles = Server.MapPath("Profesores.json");
            staffFiles = Server.MapPath("Personal administrativo.json");

            if ( validateFiles() )
            {
                using( StreamReader rd = new StreamReader(studentFiles) )
                {
                    students = JsonConvert.DeserializeObject<List<Students>>(rd.ReadToEnd());
                }
                using( StreamReader rd = new StreamReader(techersFiles) )
                {
                    teachers = JsonConvert.DeserializeObject<List<Teachers>>(rd.ReadToEnd());
                }
                using( StreamReader rd = new StreamReader(staffFiles) )
                {
                    staffs = JsonConvert.DeserializeObject<List<administrativeStaff>>(rd.ReadToEnd());
                }
                if( students == null )
                {
                    students = new List<Students>();
                }
                if( teachers == null )
                {
                    teachers = new List<Teachers>();
                }
                if( staffs == null )
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
            LabelAge.Text = "EDAD: " + principal.calcAge().ToString();
        }

        protected bool validateFiles()
        {
            return File.Exists(studentFiles)
                && File.Exists(techersFiles)
                && File.Exists(staffFiles);
        }

        protected void saveAll()
        {
            using (StreamWriter sr = new StreamWriter(studentFiles) )
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

        protected void ButtonStudent_Click(object sender, EventArgs e)
        {
            Students s = students.Find(x => x.curso == TextUniversity.Text);
            
            if( s.Students.Count == 0 )
            {
                students = s.Students;
            }

            Students st = new Students();
            st.name = TextName.Text;
            st.lastName = TextLastname.Text;
            st.address = TextAddress.Text;
            st.dateofBirth = CalendarBirth.SelectedDate;
            st.curso = TextUniversity.Text;
            st.ID = TextID.Text;

            students.Add(st);
            saveAll();

            TextName.Text = "";
            TextLastname.Text = "";
            TextAddress.Text = "";
            CalendarBirth.SelectedDate = DateTime.Now;
            TextID.Text = "";
        }

        protected void ButtonTeacher_Click(object sender, EventArgs e)
        {
            Teachers t = teachers.Find(y => y.curso == TextUniversity.Text);

            if( t.Teachers.Count == 0 )
            {
                teachers = t.Teachers;
            }

            Teachers te = new Teachers();
            te.name = TextName.Text;
            te.lastName = TextLastname.Text;
            te.address = TextAddress.Text;
            te.dateofBirth = CalendarBirth.SelectedDate;
            te.curso = TextUniversity.Text;
            te.ID = TextDPI.Text;
            te.Title = TextTitle.Text;

            teachers.Add(te);
            saveAll();

            TextName.Text = "";
            TextLastname.Text = "";
            TextAddress.Text = "";
            CalendarBirth.SelectedDate = DateTime.Now;
            TextDPI.Text = "";
            TextTitle.Text = "";
        }

        protected void ButtonStaff_Click(object sender, EventArgs e)
        {
            administrativeStaff a = staffs.Find(z => z.curso == TextUniversity.Text);

            if( a.Staffs.Count == 0 )
            {
                staffs = a.Staffs;
            }

            administrativeStaff sf = new administrativeStaff();
            sf.name = TextName.Text;
            sf.lastName = TextLastname.Text;
            sf.address = TextAddress.Text;
            sf.dateofBirth = CalendarBirth.SelectedDate;
            sf.curso = TextUniversity.Text;
            sf.IGSSnumber = int.Parse(TextIGSS.Text);
            sf.profession = TextProfession.Text;
            sf.startofWork = CalendarStart.SelectedDate;
            sf.endofWork = CalendarEnd.SelectedDate;

            staffs.Add(sf);
            saveAll();

            TextName.Text = "";
            TextLastname.Text = "";
            TextAddress.Text = "";
            CalendarBirth.SelectedDate = DateTime.Now;
            TextIGSS.Text = "";
            TextProfession.Text = "";
            CalendarStart.SelectedDate = DateTime.Now;
            CalendarEnd.SelectedDate = DateTime.Now;
        }

        protected void RadioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonStudent.Checked == true)
            {
                LabelAge.Visible = true;
                LabelCarne.Visible = true;
                TextID.Visible = true;
                LabelDPI.Visible = false;
                TextDPI.Visible = false;
                LabelTitle.Visible = false;
                TextTitle.Visible = false;
                LabelIGSS.Visible = false;
                TextIGSS.Visible = false;
                LabelProfession.Visible = false;
                TextProfession.Visible = false;
                LabelStar.Visible = false;
                CalendarStart.Visible = false;
                LabelEnd.Visible = false;
                CalendarEnd.Visible = false;
                ButtonTeacher.Visible = false;
                ButtonStaff.Visible = false;
                ButtonStudent.Visible = true;
            }
        }

        protected void RadioButtonTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonTeacher.Checked == true)
            {
                LabelAge.Visible = true;
                LabelCarne.Visible = false;
                TextID.Visible = false;
                LabelDPI.Visible = true;
                TextDPI.Visible = true;
                LabelTitle.Visible = true;
                TextTitle.Visible = true;
                LabelIGSS.Visible = false;
                TextIGSS.Visible = false;
                LabelProfession.Visible = false;
                TextProfession.Visible = false;
                LabelStar.Visible = false;
                CalendarStart.Visible = false;
                LabelEnd.Visible = false;
                CalendarEnd.Visible = false;
                ButtonStudent.Visible = false;
                ButtonStaff.Visible = false;
                ButtonTeacher.Visible = true;
            }
        }

        protected void RadioButtonStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonStaff.Checked == true)
            {
                LabelAge.Visible = true;
                LabelCarne.Visible = false;
                TextID.Visible = false;
                LabelDPI.Visible = false;
                TextDPI.Visible = false;
                LabelTitle.Visible = false;
                TextTitle.Visible = false;
                LabelIGSS.Visible = true;
                TextIGSS.Visible = true;
                LabelProfession.Visible = true;
                TextProfession.Visible = true;
                LabelStar.Visible = true;
                CalendarStart.Visible = true;
                LabelEnd.Visible = true;
                CalendarEnd.Visible = true;
                ButtonStaff.Visible = true;
                ButtonStudent.Visible = false;
                ButtonTeacher.Visible = false;
            }
        }
    }
}