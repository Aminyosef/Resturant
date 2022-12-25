using Resturant.DataBanse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant.Forms
{
    public partial class MainOptions : Form
    {
        DBConnection db = new DBConnection();
        int opId = 0;
        public MainOptions()
        {
            InitializeComponent();
           
        }

        private void MainOptions_Load(object sender, EventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            var firstoption = db.Options.FirstOrDefault(x => x.Id > 0);
            if (firstoption !=null)
            {
                txtPrintName.Text = firstoption.PrintName;
                txtRcp2.Text = firstoption.Recipt2;
                txtRcpt1.Text = firstoption.Recipt1;
                txtRestAdd1.Text = firstoption.RestAdd1;
                txtRestAdd2.Text = firstoption.RestAdd2;
                txtRestName.Text = firstoption.RestName;
                txtRestPhone.Text = firstoption.RestPhone;
                if (firstoption.RestLogo != null)
                picBox.Image = Image.FromStream(new MemoryStream(firstoption.RestLogo));
                opId = firstoption.Id;
            }
         
            Cursor= Cursors.Default;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you wish to save the data?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtRestName.Text == string.Empty)
                {
                    MessageBox.Show("Please fill the resturant name.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   txtRestName.Focus();
                    return;
                }
                if (opId<1)
                {
                    Option option = new Option
                    {
                        RestName = txtRestName.Text,
                        Recipt1 = txtRcpt1.Text,
                        Recipt2 = txtRcp2.Text,
                        RestPhone = txtRestPhone.Text,
                        RestAdd1 = txtRestAdd1.Text,
                        RestAdd2 = txtRestAdd2.Text,
                        PrintName = txtPrintName.Text


                    };
                    db.Options.Add(option);
                    db.SaveChanges();
                }
                else
                {
                    var upOption = db.Options.Find(opId);
                    upOption.RestName = txtRestName.Text;
                    upOption.RestPhone = txtRestPhone.Text;
                    upOption.RestAdd1 = txtRestAdd1.Text;
                    upOption.RestAdd2 = txtRestAdd2.Text;
                    upOption.PrintName = txtPrintName.Text;
                    upOption.Recipt1 = txtRcpt1.Text;
                    upOption.Recipt2 = txtRcp2.Text;
                    if (txtLogo.Text != string.Empty)
                        upOption.RestLogo = File.Exists(txtLogo.Text) ? File.ReadAllBytes(txtLogo.Text) : null;
                    db.SaveChanges();
                }
               
                MessageBox.Show("The data has been saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Images|*.png";
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                txtLogo.Text = fileDialog.FileName;
                picBox.Image=new Bitmap(fileDialog.FileName);
            }      
        }
    }
}
