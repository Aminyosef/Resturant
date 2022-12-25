using Resturant.DataBanse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant.Forms
{
    public partial class UserForm : Form
    {
        DBConnection db = new DBConnection();
        int UID = 0;
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {Cursor.Current = Cursors.WaitCursor;   
            var user = db.Users.FirstOrDefault();
            if (user != null)
            {
                txtemail.Text = user.Email;
                txtFullName.Text = user.FullName;
                txtPass.Text = user.Password;
                txtPhone.Text = user.Phone;
                txtUName.Text = user.UserName;

            }
            loaddata();
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtemail.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUName.Text = string.Empty;
            UID = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (txtUName.Text == string.Empty)
            {
                MessageBox.Show("Please Fill All Data");

                txtUName.Focus();
                return;
            }
            else if (txtFullName.Text == string.Empty)
            {
                MessageBox.Show("Please Fill All Data");

                txtFullName.Focus();
                return;
            }
            else if (txtPass.Text == string.Empty)
            {
                MessageBox.Show("Please Fill All Data");

                txtPass.Focus();
                return;
            }
            else if (txtemail.Text == string.Empty)
            {
                MessageBox.Show("Please Fill All Data");

                txtemail.Focus();
                return;
            }


            if (UID == 0)
            {
                User user = new User
                {
                    Email = txtemail.Text,
                    FullName = txtFullName.Text,
                    Password = txtPass.Text,
                    Phone = txtPhone.Text,
                    UserName = txtUName.Text
                };
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Data Saved");
                loaddata();
            }
            else
            { 
                var selected = db.Users.Find(UID);
                selected.Email = txtemail.Text;
                selected.FullName = txtFullName.Text;
                selected.Password = txtPass.Text;
                selected.Phone = txtPhone.Text;
                selected.UserName = txtUName.Text;
                db.SaveChanges();
                MessageBox.Show("Data Saved");
                loaddata();


            }
        }
        void loaddata()
        {
            var user = from us in db.Users
                       select new {No=us.id, us.UserName, us.FullName, us.Phone,us.Email };
            dataGridView1.DataSource= user.ToList();
        }

       

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != null)
            {
                txtUName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            }
            txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtFullName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            UID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var selected = db.Users.Find(UID);
            if (selected != null)
            {
                if (MessageBox.Show("Are You Sure to Delete selected user..??","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                   db.Users.Remove(selected);
                    db.SaveChanges();
                    MessageBox.Show("Data Deleted");
                }
              

            }
            
            loaddata();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            var search = db.Users.Where(x => x.FullName.Contains(txtSearch.Text) || x.Email.Contains(txtSearch.Text) || x.Phone.Contains(txtSearch.Text) || txtSearch.Text == null).ToList();
                        var result=from us in search select new { No = us.id, us.UserName, us.FullName, us.Phone, us.Email };
            dataGridView1.DataSource = result.ToList();

        }
    }
}
