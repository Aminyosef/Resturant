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
    public partial class MainSetup : Form
    {
        
        public MainSetup()
        {
            InitializeComponent();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void MainSetup_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           // OpenChildform(new Users(), sender);
           UserForm users=new UserForm();
            users.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryFrm category= new CategoryFrm();
            category.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            itemForm itemForm = new itemForm();
            itemForm.ShowDialog();
        }
    }
}
