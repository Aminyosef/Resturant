using Resturant.DataBanse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant.Forms
{
    public partial class CategoryFrm : Form
    {
        DBConnection db = new DBConnection();
        int UID = 0;
        public CategoryFrm()
        {
            InitializeComponent();
        }

        private void CategoryFrm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var user = db.Categories.FirstOrDefault();
            if (user != null)
            {

                txtUName.Text = user.Desc;
                UID = user.Id;
            }
            loaddata();
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtUName.Enabled = true; 
            txtUName.Text = string.Empty;
            txtUName.Focus();
            UID = 0;
        }
        void loaddata()
        {
            var user = from us in db.Categories
                       select us;
            dataGridView1.DataSource = user.ToList();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == string.Empty)
            {
                MessageBox.Show("Please Fill Data");
                txtUName.Focus();
                return;

            }
            else
            {
                if (UID == 0)
                {
                    Category category = new Category
                    {
                        Desc= txtUName.Text,
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();
                    MessageBox.Show("Data saved");
                    loaddata();
                    txtUName.Enabled = false;

                }
                else
                {
                    var upd=db.Categories.Find(UID);
                    upd.Desc = txtUName.Text;
                    db.SaveChanges();
                    MessageBox.Show("Data saved");
                    loaddata();
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   txtUName.Enabled=true;
            
            txtUName.Focus();
            txtUName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void CopyArrayByObject(object[] source, out object[] destSource)
        {
            destSource = source;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var search = db.Categories.Where(x => x.Desc.Contains(txtSearch.Text) || txtSearch.Text == null).ToList();
            var result = from us in search select new { No = us.Id, us.Desc };
            dataGridView1.DataSource = result.ToList();
        }
    }
}
