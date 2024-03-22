using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using Project_PRN211_SE1729.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static Project_PRN211_SE1729.Program;

namespace Project_PRN211_SE1729
{
    public partial class Form1 : Form
    {
        private Project_PRN211Context _context = new Project_PRN211Context();
        public Form1()
        {
            InitializeComponent();
            loadData();
        }



        void loadData()
        {
            label1.Text = "Xin chào: " + ControlID.fullName;



            // Subject
            cbxSubject.DisplayMember = "Name";
            cbxSubject.ValueMember = "SId";
            List<Subject> subjectList = _context.Subjects.ToList();
            
            subjectList = subjectList.Where(x => x.TeacherId == ControlID.accountID).ToList();
            subjectList.Insert(0, new Subject
            {
                SId = 0,
                Name = "All subject"
            });
            cbxSubject.DataSource = subjectList;

            cbSubject.DisplayMember = "Name";
            cbSubject.ValueMember = "SId";
            cbSubject.DataSource = _context.Subjects.Where(x => x.TeacherId == ControlID.accountID).ToList();



            // Class
            cbxClass.DisplayMember = "Name";
            cbxClass.ValueMember = "ClassId";
            List<Class> listclass = _context.Classes.ToList();

            listclass = listclass.Where(x => x.TeacherId == ControlID.accountID).ToList();
            listclass.Insert(0, new Class
            {
                ClassId = 0,
                Name = "All class"
            });
            cbxClass.DataSource = listclass;
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "ClassId";
            cbClass.DataSource = _context.Classes.Where(x => x.TeacherId == ControlID.accountID).ToList();



            // type point
            cbxTypePoints.DisplayMember = "Name";
            cbxTypePoints.ValueMember = "TId";
            List<TypePoint> listType = _context.TypePoints.ToList();
            listType.Insert(0, new TypePoint
            {
                TId = 0,
                Name = "All type point"
            });
            cbxTypePoints.DataSource = listType;
            cbTypePoint.DisplayMember = "Name";
            cbTypePoint.ValueMember = "TId";
            cbTypePoint.DataSource = _context.TypePoints.ToList();

            DgvStudent();


            
        }




        void DgvStudent()
        {
            int subId = Convert.ToInt32(cbxSubject.SelectedValue);
            int classId = Convert.ToInt32(cbxClass.SelectedValue);
            int TypeId = Convert.ToInt32(cbxTypePoints.SelectedValue);
            string mssv = txtStudentId.Text;

            dgvListStudent.Rows.Clear();
            List<Mark> marks = _context.Marks
                .Where(x => (subId == 0 || x.SubId == subId)
                && (TypeId == 0 || x.TypeId == TypeId)
                && x.StudentId.ToLower().Contains(mssv.ToLower()))
                .Include(x => x.Sub).Where(x => x.Sub.TeacherId == ControlID.accountID)
                .Include(x => x.Student).Where(x => x.Student.ClassId == classId || classId == 0)
                .Include(x => x.Student.Class)
                .Include(x => x.Type)
                .ToList().ToList();

            foreach (Mark item in marks)
            {
                dgvListStudent.Rows.Add(item.Student.StudentId, item.Student.Name, item.Sub.Name, item.Point, item.Type.Name, item.Student.Class.Name);
            }
        }
        
        
        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvStudent();
        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvStudent();
        }

        private void cbxTypePoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvStudent();
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            DgvStudent();
        }



        private void dgvListStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }
            cbSubject.Enabled = false;
            txtID.Enabled = false;
            txtName.Enabled = false;
            cbClass.Enabled = false;
            cbTypePoint.Enabled = false;
            btnAdd.Enabled = false;
            txtID.Text = dgvListStudent.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            txtName.Text = dgvListStudent.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            string Sid = dgvListStudent.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            cbSubject.SelectedIndex = cbSubject.FindString(Sid);
            nudMark.Value = Convert.ToDecimal(dgvListStudent.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
            string Cid = dgvListStudent.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            cbClass.SelectedIndex = cbClass.FindString(Cid);
            string Tid = dgvListStudent.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            cbTypePoint.SelectedIndex = cbTypePoint.FindString(Tid);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        // add 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string txtSId = txtID.Text;
            string txtSName = txtName.Text;
            int Cid = Convert.ToInt32(cbClass.SelectedValue);
            int Tid = Convert.ToInt32(cbTypePoint.SelectedValue);
            int Sid = Convert.ToInt32(cbSubject.SelectedValue);
            Double point = Convert.ToDouble(nudMark.Value);

            // check empty
            if (txtSId.Trim() == "")
            {
                MessageBox.Show("Not empty ID here");
                return;
            }
            if (txtSName.Trim() == "")
            {
                MessageBox.Show("Not empty Name here");
                return;
            }

            List<Mark> listMark = _context.Marks.ToList();
            // check type exist
            foreach (Mark item in listMark)
            {
                if (item.StudentId == txtSId && item.TypeId == Tid && item.SubId == Sid)
                {
                    MessageBox.Show("Type point exist");
                    return;
                }
            }
            // check student exist
            Student checkExist = _context.Students.Where(x => x.StudentId == txtSId).FirstOrDefault();
            if (checkExist == null)
            {
                Student s = new Student();
                s.StudentId = txtSId;
                s.Name = txtSName;
                s.ClassId = Cid;
                _context.Students.Add(s);
            }
            // add mark
            Mark ma = new Mark();
            ma.StudentId = txtSId;
            ma.TypeId = Tid;
            ma.SubId = Sid;
            ma.Point = point;

            _context.Marks.Add(ma);
            _context.SaveChanges();
            MessageBox.Show("Add successfull");
            btnRefresh_Click(null, null);
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string txtSId = txtID.Text;
            string txtSName = txtName.Text;
            int Cid = Convert.ToInt32(cbClass.SelectedValue);
            int Tid = Convert.ToInt32(cbTypePoint.SelectedValue);
            int Sid = Convert.ToInt32(cbSubject.SelectedValue);
            Double point = Convert.ToDouble(nudMark.Value);

            if (txtSId.Trim() == "")
            {
                MessageBox.Show("Not empty ID here");
                return;
            }
            if (txtSName.Trim() == "")
            {
                MessageBox.Show("Not empty Name here");
                return;
            }
            // check student exist
            Student s = _context.Students.Where(x => x.StudentId == txtSId).FirstOrDefault();
            if (s == null)
            {
                MessageBox.Show("Not student exist");
                return;
            }
            _context.SaveChanges();
            // check mark of type point exist
            Mark ma = _context.Marks.Where(x => x.StudentId == txtSId && x.TypeId == Tid).FirstOrDefault();
            if (ma != null)
            {
                ma.Point = point;
                _context.SaveChanges();
            }


            MessageBox.Show("Update successfull");
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbSubject.Enabled = true;
            txtID.Enabled = true;
            txtName.Enabled = true;
            cbClass.Enabled = true;
            cbTypePoint.Enabled = true;
            btnAdd.Enabled = true;

            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            nudMark.Value = 0;
            cbClass.SelectedIndex = 0;
            cbTypePoint.SelectedIndex = 0;
            cbSubject.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Tid = Convert.ToInt32(cbTypePoint.SelectedValue);
            int Sid = Convert.ToInt32(cbSubject.SelectedValue);
            string txtSId = txtID.Text;
            if (txtSId.Trim() != "")
            {
                Mark m = _context.Marks.Where(x => x.StudentId.Equals(txtSId) && x.TypeId == Tid && x.SubId == Sid)
                .Include(x => x.Student)
                .Include(x => x.Type)
                .Include(x => x.Sub)
                .FirstOrDefault();

                DialogResult result = MessageBox.Show("Ban co chac xoa khong", "xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _context.Marks.Remove(m);
                    _context.SaveChanges();
                    MessageBox.Show("Delete thanh cong");
                    loadData();
                    btnRefresh_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("bạn chưa chọn bản ghi nào");

            }

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login frm = new Login();

            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string txtSid = txtID.Text.Trim();
            // find name by id
            if (txtSid != "")
            {
                Student s = _context.Students.Where(x => x.StudentId == txtSid).FirstOrDefault();
                // find class by student 
                if (s!= null)
                {
                    Class c = _context.Classes.Where(x => x.ClassId == s.ClassId).FirstOrDefault();

                    txtName.Enabled = false;
                    txtName.Text = s.Name;

                    cbClass.Enabled = false;
                    cbClass.SelectedValue = c.ClassId;

                }
                else
                {
                    txtName.Enabled = true;
                    cbClass.Enabled = true;

                }
            }
            else
            {
                txtName.Enabled = true;
                cbClass.Enabled = true;


            }
        }
    }
}