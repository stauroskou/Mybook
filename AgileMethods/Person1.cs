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
    public partial class Person1 : Form
    {
        public Person1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu(Program.tek);
            form.Show();

            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Person1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(MainMenu.person1[5]);
            label3.Text = MainMenu.person1[1];
            textBox1.Text = MainMenu.person1[6];
            label2.Text = MainMenu.person1[7];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
