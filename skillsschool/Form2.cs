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

namespace skillsschool
{
    
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-A7BK3OE5;Initial Catalog=skills;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            comboBox1.Text = String.Empty;
            txtfirstname.Clear();
            txtlastname.Clear();
            txtdob.Clear();
            comboBox2.Text=String.Empty;
            txtaddress.Clear();
            txtemail.Clear();
            txtmnum.Clear();
            txthnum.Clear();
            txtparentname.Clear();
            txtnic.Clear();
            txtcnum.Clear();
            
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            string sqlsearch;
            sqlsearch = "select * from registration_table1  where regno='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtfirstname.Text = dr["firstname"].ToString();
                txtlastname.Text = dr["lastname"].ToString();
                txtdob.Text = dr["dateofbirth"].ToString();
                comboBox2.Text = dr["gender"].ToString();
                txtaddress.Text = dr["address"].ToString();
                txtemail.Text = dr["email"].ToString();
                txtmnum.Text = dr["mobilephone"].ToString();
                txthnum.Text = dr["homephone"].ToString();
                txtparentname.Text = dr["parentname"].ToString();
                txtnic.Text = dr["nic"].ToString();
                txtcnum.Text = dr["contactno"].ToString();
                comboBox1.Focus();
            }
            else
            {
                MessageBox.Show("invalid RegNo please check!!!!!", "check the message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into registration_table1 values (@regno,@firstname,@lastname,@dateofbirth,@gender,@address,@email,@mobilephone,@homephone,@parentname,@nic,@contactno)";
                cmd.Parameters.AddWithValue("@regno", comboBox1.Text);
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                cmd.Parameters.AddWithValue("@dateofbirth", txtdob.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@mobilephone", txtmnum.Text);
                cmd.Parameters.AddWithValue("@homephone", txthnum.Text);
                cmd.Parameters.AddWithValue("@parentname", txtparentname.Text);
                cmd.Parameters.AddWithValue("@nic", txtnic.Text);
                cmd.Parameters.AddWithValue("@contactno", txtcnum.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New record added");
                clear();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                conn.Open();
                string QUARY = "update registration_table1 set firstname='" + txtfirstname.Text + "',lastname='" + txtlastname.Text + "',dateofbirth='" + txtdob.Text + "',gender='" + comboBox2.Text + "',address='" + txtaddress.Text + "',email='" + txtemail.Text + "',mobilephone='" + txtmnum.Text + "',homephone='" + txthnum.Text + "',parentname='" + txtparentname.Text + "',nic='" + txtnic.Text +  "',contactno='" + txtcnum.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(QUARY, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Record Updated!!!");
                clear();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("delete registration_table1 where regno=@regno", conn);
                cmd.Parameters.AddWithValue("@regno", comboBox1.Text);
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                cmd.Parameters.AddWithValue("@dateofbirth", txtdob.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@mobilephone", txtmnum.Text);
                cmd.Parameters.AddWithValue("@homephone", txthnum.Text);
                cmd.Parameters.AddWithValue("@parentname", txtparentname.Text);
                cmd.Parameters.AddWithValue("@nic", txtnic.Text);
                cmd.Parameters.AddWithValue("@contactno", txtcnum.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted!!!!!!!");
                clear();
                conn.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string message = "Do you want to exit?";
            string title = "close form";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Form3 fr = new Form3();
                fr.Show();
                this.Hide();
            }
            else
            {
                Form2 fr = new Form2();
                fr.Show();
                this.Hide();
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
