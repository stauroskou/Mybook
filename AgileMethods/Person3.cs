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
    public partial class Person3 : Form
    {
        public Person3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu(Program.tek);
            form.Show();

            this.Dispose();
        }

        private void Person3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(MainMenu.person3[5]);
            label3.Text = MainMenu.person3[1];
            textBox1.Text = MainMenu.person3[6];
            label2.Text = MainMenu.person3[7];
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
