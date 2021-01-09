using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgileMethods
{
    public partial class ViewProfile : Form
    {

        
        public ViewProfile(string pic)
        {
            InitializeComponent();

            label1.Text = Login.username;
            label3.Text = Login.joined;
            textBox1.Text = Login.description;
            
            try
            {
                pictureBox1.Image = Image.FromFile(pic);
            }
            catch (Exception)
            {

                pictureBox1.Image = Image.FromFile(Login.imagePath);
            }

        }
        public ViewProfile(string pic, string desc)
        {
            InitializeComponent();

            label1.Text = Login.username;
            label3.Text = Login.joined;
            textBox1.Text = desc;

            try
            {
                pictureBox1.Image = Image.FromFile(pic);
            }
            catch (Exception)
            {

                pictureBox1.Image = Image.FromFile(Login.imagePath);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ViewProfile_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MainMenu form = new MainMenu(Program.tek);
            form.Show();

            this.Dispose();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDescription addDescription = new AddDescription();
            addDescription.Show();

            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
