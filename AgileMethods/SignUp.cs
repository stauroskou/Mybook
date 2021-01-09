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


namespace AgileMethods.SignUp
{
    public partial class Signup : Form
    {
        Login openForm = new Login();
        public Signup()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Program.path;
            File.AppendAllText(path, "");
            string ID = GenerateId();
            bool uniqueName = uniquename(textBox1.Text, path);
            signup(ID, uniqueName, path, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, "../../Images/download.png"," ",DateTime.Now);
        }
        public static void addRecord(string id, string username, string firstname, string lastname, string email, string password, string imagepath,string filepath, string description, DateTime joinedDate)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(@filepath, true))
                {
                    file.WriteLine(id + '~' + username + '~' + firstname + '~' + lastname + '~' + email + '~' + password + '~' + imagepath + '~' + description + '~'+ joinedDate);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string GenerateId()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            openForm.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool uniquename(string str, string path)
        {
            try
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                if (text.Contains(str))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                return false;
            }
        }
        public void signup( string ID, bool unique, string path, string username, string firstname, string lastname, string email,
                            string password, string ImagePath, string descritpion, DateTime joinedDate)
        {
            if (username.Length <= 0 || password.Length <= 0 || firstname.Length <= 0 || lastname.Length <= 0 || email.Length <= 0)
            {
                MessageBox.Show("Please fill all spaces");
            }
            else if (!unique)
            {
                MessageBox.Show("Username already exists");
            }
            else
            {
                addRecord(ID, username, firstname, lastname, email, password, ImagePath, Program.path, descritpion, joinedDate);
                MessageBox.Show("Registered!");
                openForm.Show();
                Visible = false;
            }
        }
    }
}
