using Resturant.Forms;
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

namespace Resturant
{
    public partial class Form1 : Form
    {   
        private Button currentButton;
        private Form activeForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
        private void OpenChildform(Form cForm,object btnSender)
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm= cForm;
            ActiveButton(btnSender);
            cForm.TopLevel = false;
            cForm.FormBorderStyle= FormBorderStyle.None;
            cForm.Dock= DockStyle.Fill;
            pnlMain.Controls.Add(cForm);
            pnlMain.Tag= cForm;
            cForm.BringToFront();
            cForm.Show();

        }
        private Color SelectThems()
        {
            if (currentButton.Text == "POS")
            {
                return Color.Green;
                

            }
            else if (currentButton.Text == "SetUp")
            {
                return Color.Brown;
            }
            else if (currentButton.Text == "Reporting")
            {
                return Color.Blue;
            }
            else if(currentButton.Text == "Options")
            {
                return Color.Red;
            }
            else
            {
                return Color.Gray;
            }
        }
        private void ActiveButton(object sender) 
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender )
                {
                    UnselectButton();
                    currentButton=(Button)sender;
                    Color color = SelectThems();
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Tahoma", 11F, FontStyle.Bold);
                    currentButton.Size = new System.Drawing.Size(192, 150);
                    pnlTitl.BackColor= color;
                    lblItem.Text=currentButton.Text;
                   

                }
            }
        }
        private void UnselectButton()
        {
            foreach (Control ctr in pnlMenu.Controls)
            {
                if (ctr.GetType()==typeof(Button))
                {
                   
                    ctr.BackColor = Color.White;
                    ctr.ForeColor = Color.Black;
                    ctr.Font = new Font("Tahoma", 8F, FontStyle.Regular);
                    ctr.Size = new System.Drawing.Size(192, 82);

                }
            }
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            
            OpenChildform(new MainForm(), sender);
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            OpenChildform(new MainSetup(),sender);

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildform(new Report(), sender);
           

        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            OpenChildform(new MainOptions(), sender);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://migawatt.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
