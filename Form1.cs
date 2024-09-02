using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Login_SignUp_Operations
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            Sign_up f = new Sign_up();
            f.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            string username = txtusername.Text;
            string pass = txtpass.Text;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SS35PNP\\SQLEXPRESS;Initial Catalog=Login_SignUp_Operation;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Sign_Up where roll=@username and email=@pass";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                MessageBox.Show("LoGiN SuCeSsFuLlIy\nWelcome...." + username);

            } 
            else
            {
                MessageBox.Show("Invalid user id or password!!!");
            }

        }
    }
}
