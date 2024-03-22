using Project_PRN211_SE1729.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project_PRN211_SE1729.Program;

namespace Project_PRN211_SE1729
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project_PRN211Context _context = new Project_PRN211Context();
            string userName = txtUserName.Text;
            string pass = txtPass.Text;
            if (userName.Trim().Equals("") && pass.Trim().Equals(""))
            {
                string message = "Not empty here";
                MessageBox.Show(message);
            }
            else
            {
                Account a = _context.Accounts.Where(x => x.UserName.ToLower() == userName.ToLower() && x.Password.ToLower() == pass.ToLower()).FirstOrDefault();

                Teacher t = _context.Teachers.Where(x => x.TeachId == a.TearcherId).FirstOrDefault();
                if (a != null)
                {
                    //đẩy rule vs accountID
                    ControlID.accountID = a.AccountId;
                    ControlID.fullName = t.Name;
                    //open home form
                    Form1 frm = new Form1();
                    this.Visible = false;
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    string message = "Account not exist or Password is incorrect";
                    MessageBox.Show(message);
                }
            }
        }
    }
}
