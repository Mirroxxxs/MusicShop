using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            Form2 regist = new Form2();
            regist.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 input = new Form3();
            input.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
            Form10 form10 = new Form10();
            form10.Show();
            Hide();
        }
    }
}
