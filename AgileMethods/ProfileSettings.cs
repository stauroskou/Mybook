using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileMethods
{
    public partial class ProfileSettings : Form
    {
        public ProfileSettings()
        {
            InitializeComponent();
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu(Program.tek);
            form.Show();

            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeUsername changeUsername = new ChangeUsername();
            changeUsername.Show();

            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeFirstname changeFirstname = new ChangeFirstname();
            changeFirstname.Show();

            this.Dispose();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeSurname changeSurname = new ChangeSurname();
            changeSurname.Show();

            this.Dispose();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeEmail changeEmail = new ChangeEmail();
            changeEmail.Show();

            this.Dispose();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();

            this.Dispose();
        }

        private void ProfileSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
