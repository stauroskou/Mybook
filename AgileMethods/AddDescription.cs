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

namespace AgileMethods
{
    public partial class AddDescription : Form
    {
        public static string changedDescription;
        public AddDescription()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lp;
            if (string.IsNullOrEmpty(Program.tek))
            {
                lp = Login.imagePath;
            }
            else
            {
                lp = Program.tek;
            }
            ViewProfile viewProfile = new ViewProfile(lp, changedDescription);
            viewProfile.Show();

            this.Dispose();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string pop;
            string fn;
            string ln;
            string un;
            string eml;
            string psd;
            if (string.IsNullOrEmpty(ChangeUsername.changedUsername))
            {
                un = Login.username;
            }
            else
            {
                un = ChangeUsername.changedUsername;
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
            if (string.IsNullOrEmpty(Program.tek))
            {
                pop = Login.imagePath;
            }
            else
            {
                pop = Program.tek;
            }
            if (string.IsNullOrEmpty(ChangeSurname.changedSurname))
            {
                ln = Login.lastname;
            }
            else
            {
                ln = ChangeSurname.changedSurname;
            }
            if (textBox1.Text.Length >= 0)
            {
                editRecord(Login.id1, Program.path, 1, Login.id1, un, fn, ln, eml, psd, pop, textBox1.Text, Login.joined);
                changedDescription = textBox1.Text;
                MessageBox.Show("Descritpion Changed!");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void AddDescription_Load(object sender, EventArgs e)
        {

        }
    }
    
}
