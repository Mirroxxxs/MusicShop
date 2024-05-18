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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

    
      

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            Hide();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            Hide();
        }
      
        private void buttonSales_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            Hide();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        
        }

        private void End_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

  
    }
}
