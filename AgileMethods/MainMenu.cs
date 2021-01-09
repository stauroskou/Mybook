using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgileMethods
{
    public partial class MainMenu : Form
    {
        public static Form test = new ViewProfile(Program.tek);
        public static string[] person1 = new string[8];
        public static string[] person2 = new string[8];
        public static string[] person3 = new string[8];
          
        
        public static string profilePic;

        public MainMenu()
        {
            InitializeComponent();

            
            try
            {
                pictureBox1.Image = Image.FromFile(Login.imagePath);
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(Program.tek))
                {
                    pictureBox1.Image = Image.FromFile(Program.ImagePath);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(Program.tek);
                }
            }
        }
        public MainMenu(string pic)
        {   
            InitializeComponent();
            try
            {
                pictureBox1.Image = Image.FromFile(pic);
                

            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(Program.tek))
                {
                    pictureBox1.Image = Image.FromFile(Login.imagePath);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(Program.tek);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void MainMenu_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            label1.Text = Program.Username;
            try
            {
                string[] lines = File.ReadAllLines(Program.path);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split('~');
                    if (!(fields[0] == Login.id1))
                    {
                        person1[0] = fields[0];
                        person1[1] = fields[1];
                        person1[2] = fields[2];
                        person1[3] = fields[3];
                        person1[4] = fields[4];
                        person1[5] = fields[6];
                        person1[6] = fields[7];
                        person1[7] = fields[8];

                    }
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split('~');
                    if (!(fields[0] == Login.id1 || fields[0] == person1[0]))
                    {
                        person2[0] = fields[0];
                        person2[1] = fields[1];
                        person2[2] = fields[2];
                        person2[3] = fields[3];
                        person2[4] = fields[4];
                        person2[5] = fields[6];
                        person2[6] = fields[7];
                        person2[7] = fields[8];
                    }
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split('~');
                    if (!(fields[0] == Login.id1 || fields[0] == person1[0] || fields[0] == person2[0]))
                    {
                        person3[0] = fields[0];
                        person3[1] = fields[1];
                        person3[2] = fields[2];
                        person3[3] = fields[3];
                        person3[4] = fields[4];
                        person3[5] = fields[6];
                        person3[6] = fields[7];
                        person3[7] = fields[8];
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            if (string.IsNullOrEmpty(person1[0]))
            {
                person1[1] = " ";
                label3.Text = person1[1];
                pictureBox2.Image = Image.FromFile(Program.ImagePath);
            }
            else
            {
                label3.Text = person1[1];
                pictureBox2.Image = Image.FromFile(person1[5]);
                button6.Visible = true;
            }

            if (string.IsNullOrEmpty(person2[0]))
            {
                person2[1] = " ";
                label4.Text = person2[1];
                pictureBox3.Image = Image.FromFile(Program.ImagePath);
            }
            else
            {
                label4.Text = person2[1];
                pictureBox3.Image = Image.FromFile(person2[5]);
                button7.Visible = true;
            }
            if (string.IsNullOrEmpty(person3[0]))
            {
                person3[1] = " ";
                label5.Text = person3[1];
                pictureBox4.Image = Image.FromFile(Program.ImagePath);
            }
            else
            {
                label5.Text = person3[1];
                pictureBox4.Image = Image.FromFile(person3[5]);
                button8.Visible = true;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                label2.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
                try
                {
                    File.Copy(label2.Text, Path.Combine("../../Images/", Path.GetFileName(label2.Text)), true);

                }
                catch (Exception)
                {

                }
                button3.Visible = true;

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            editRecord(Login.id1, Program.path, 1, Login.id1, Login.username, Login.firstname, Login.lastname, Login.email, Login.pswd, "../../Images/" + Path.GetFileName(label2.Text), Login.description, Login.joined);
            try
            {
                profilePic = "../../Images/" + Path.GetFileName(label2.Text);
                Program.tek = profilePic;

            }
            catch (Exception)
            {

                profilePic = Login.imagePath;
                Program.tek = profilePic;
                
            }
            label2.Text = "Saved!";
            button3.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public static void addRecord(string id, string username, string firstname, string lastname, string email, string password, string imagepath,string description, string joined,string filepath)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(@filepath, true))
                {
                    file.WriteLine(id + '~' + username + '~' + firstname + '~' + lastname + '~' + email + '~' + password + '~' + imagepath + '~' + description + '~' + joined);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void editRecord(string searchTerm, string filepath, int positionOfSearchTerm, string id,  string username, string firstname, string lastname,                                     string email, string password,string imagepath, string description, string joined)
        {
            positionOfSearchTerm--;
            string tempFile = "temp.csv";
            bool edited = false;

            try
            {
                string[] lines = File.ReadAllLines(Program.path);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split('~');
                    if (!(recordMatches(searchTerm,fields,positionOfSearchTerm)))
                    {
                        addRecord(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], tempFile);
                    }
                    else
                    {
                        if (!edited)
                        {
                            addRecord(id, username, firstname, lastname, email, password, imagepath, description, joined,tempFile);
                            edited = true;
                        }
                    }
                }
                File.Delete(@filepath);

                File.Move(tempFile, filepath);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Woopsie", ex);
            }
        }
        public static bool recordMatches(string SearchTerm, string[] record, int positionSearchTerm)
        {
            if (record[positionSearchTerm].Equals(SearchTerm))
            {
                return true;
            }
            return false;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ProfileSettings form = new ProfileSettings();
            form.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string desc;
            if (string.IsNullOrEmpty(AddDescription.changedDescription))
            {
                desc = Login.description;
            }
            else
            {
                desc = AddDescription.changedDescription;
            }
            ViewProfile open = new ViewProfile(Program.tek, desc);
            open.Show();
            this.Dispose();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Person1 person1 = new Person1();
            person1.Show();

            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Person2 person2 = new Person2();
            person2.Show();

            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Person3 person3 = new Person3();
            person3.Show();

            this.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();

            this.Dispose();
        }
    }
}
