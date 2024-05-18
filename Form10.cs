using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicShop
{
    public partial class Form10 : Form
    {
        private string log;
        private string pas;
        public Form10(string log, string pas)
        {
            InitializeComponent();
            this.log = log;
            this.pas = pas;
        }

        public Form10()
        {
            InitializeComponent();
        }
     
        private void label4_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == log && textBoxPassword.Text == pas)
            {
                label4.Visible = false;
                Form12 form12 = new Form12();
                form12.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
