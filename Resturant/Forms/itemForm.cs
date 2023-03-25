using Resturant.DataBanse;
using Resturant.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Resturant.Forms
{
    public partial class itemForm : Form
    {
        DBConnection db = new DBConnection();
        int opId = 0;
        public itemForm()
        {
            InitializeComponent();
        }

        private void itemForm_Load(object sender, EventArgs e)
        {   
            Cursor.Current = Cursors.WaitCursor;
            FillComboBox();
            Cursor.Current = Cursors.Default;
           
        }
      
        private void btnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Images|*.png";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPic.Text = fileDialog.FileName;
                picBox.Image = new Bitmap(fileDialog.FileName);
            }
        }
       




       

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxCat.Text) || string.IsNullOrEmpty(txtPic.Text)||string.IsNullOrEmpty(txtName.Text)||string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("تاكد من المدخلات","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            byte[] imageData = File.ReadAllBytes(txtPic.Text);
            DateTime date= DateTime.Now.Date;
            var parameters = new[]
      {
        new SqlParameter("@cat", SqlDbType.Int) { Value = cbxCat.SelectedValue },
        new SqlParameter("@pic", SqlDbType.Binary) { Value = imageData },
       new SqlParameter("@nam", SqlDbType.NVarChar) { Value = txtName.Text },
        new SqlParameter("@price", SqlDbType.Decimal) { Value = txtPrice.Text },
        new SqlParameter("@note", SqlDbType.NVarChar) { Value = txtNote.Text },
        new SqlParameter("@date", SqlDbType.DateTime) { Value = date }


    };

            // Call the ExecuteNonQuery method of the CrudHelper class to add the object to the database
            var crudHelper = new CrudHelper();
            var query = "INSERT INTO Items (CatId, ItemImage,Name,Price,Note,Created) VALUES (@cat, @pic,@nam,@price,@note,@date)";
            crudHelper.ExecuteNonQuery(query, parameters);


            MessageBox.Show("The data has been saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         
        }
        private void FillComboBox()
        {
            ComboBoxHelper.FillComboBox(cbxCat, "Select * from Categories","Id","Desc");

        }

    }
    }

