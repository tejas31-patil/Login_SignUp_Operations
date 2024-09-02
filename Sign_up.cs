using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_SignUp_Operations
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int roll =int.Parse(txtroll.Text);
            int contact = int.Parse(txtcontact.Text);
            string name=txtname.Text;
            string Address = txtaddress.Text;
            string email=txtemail.Text;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SS35PNP\\SQLEXPRESS;Initial Catalog=Login_SignUp_Operation;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"insert into Sign_up values({roll},'{name}','{Address}',{contact},'{email}')";
            cmd.CommandType = CommandType.Text;
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Welcome\n\nyour Login_id is="+roll+"\npassword is="+email);
               
            }
            else
            {
                MessageBox.Show("record not inserted...");
            }


        }
    }
}
