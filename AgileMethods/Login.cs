using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AgileMethods
{
    public partial class Login : Form
    {
        public static string pswd;
        public static string username;
        public static string id1;
        public static string firstname;
        public static string lastname;
        public static string email;
        public static string imagePath;
        public static string description;
        public static string joined;



        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignUp.Signup openform = new SignUp.Signup();
            openform.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Program.path;
            string text = File.ReadAllText(path, Encoding.UTF8);
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {

                    string[] a = null;
                    char[] splitchar = { '~' };
                    a = line.Split(splitchar);
                    if (textBox1.Text == a[1] && textBox2.Text == a[5])
                    {
                        id1 = a[0];
                        username = a[1];
                        firstname = a[2];
                        lastname = a[3];
                        email = a[4];
                        pswd = a[5];
                        imagePath = a[6];
                        description = a[7];
                        joined = a[8];
                        Program.Username = username;
                        MainMenu openform = new MainMenu();
                        openform.Show();
                        Visible = false;
                    }
                }
                if (textBox1.Text != username || textBox2.Text != pswd)
                {
                    MessageBox.Show("Wrong password or username");
                }
                streamReader.Close();
            }
        }
    }
}
