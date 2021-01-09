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
    public partial class Person2 : Form
    {
        public Person2()
        {
            InitializeComponent();
        }

        private void Person2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(MainMenu.person2[5]);
            label3.Text = MainMenu.person2[1];
            textBox1.Text = MainMenu.person2[6];
            label2.Text = MainMenu.person2[7];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu form = new MainMenu(Program.tek);
            form.Show();

            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
