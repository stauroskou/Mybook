using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AgileMethods
{
    public partial class ChangeUsername : Form
    {
        public static string changedUsername;
        public ChangeUsername()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfileSettings profileSettings = new ProfileSettings();
            profileSettings.Show();

            this.Dispose();
        }

        private void ChangeUsername_Load(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {
            bool uniqueName = uniquename(textBox2.Text, Program.path);
            string pop;
            string fn;
            string ln;
            string eml;
            string psd;
            if (string.IsNullOrEmpty(ChangeSurname.changedSurname))
            {
                ln = Login.lastname;
            }
            else
            {
                ln = ChangeSurname.changedSurname;
            }
            if (string.IsNullOrEmpty(ChangeFirstname.changedFirstname))
            {
                fn = Login.firstname;
            }
            else
            {
                fn = ChangeFirstname.changedFirstname;
            }
            if (string.IsNullOrEmpty(ChangeEmail.changedEmail))
            {
                eml = Login.email;
            }
            else
            {
                eml = ChangeEmail.changedEmail;
            }
            if (string.IsNullOrEmpty(ChangePassword.changedPassword))
            {
                psd = Login.pswd;
            }
            else
            {
                psd = ChangePassword.changedPassword;
            }

            if (uniqueName)
            {
                if (string.IsNullOrEmpty(Program.tek))
                {
                    pop = Login.imagePath;
                }
                else
                {
                    pop = Program.tek;
                }
                if (textBox1.Text == Login.pswd && textBox2.Text.Length > 0)
                {
                    editRecord(Login.id1, Program.path, 1, Login.id1, textBox2.Text, fn, ln, eml, psd, pop, Login.description, Login.joined);
                    changedUsername = textBox2.Text;
                    MessageBox.Show("Username Changed!");
                }
                else
                {
                    MessageBox.Show("Wrong password");
                } 
            }
            else
            {
                MessageBox.Show("Username already exist");
            }

            

        }
        public static void addRecord(string id, string username, string firstname, string lastname, string email, string password, string imagepath, string description, string joined, string filepath)
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
        public static void editRecord(string searchTerm, string filepath, int positionOfSearchTerm, string id, string username, string firstname, string lastname, string email, string password, string imagepath, string description, string joined)
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
                    if (!(recordMatches(searchTerm, fields, positionOfSearchTerm)))
                    {
                        addRecord(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], tempFile);
                    }
                    else
                    {
                        if (!edited)
                        {
                            addRecord(id, username, firstname, lastname, email, password, imagepath, description, joined, tempFile);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
