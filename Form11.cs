using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
       
        private string connection = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";
        public class Manager
        {
            private string connection;
            public Manager(string connection)
            {
                this.connection = connection;
            }
            public bool Inicilizate(string login, string password)
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open(); string query = "SELECT COUNT(*) FROM identification WHERE login = @Login AND password = @Password";
                    SqlCommand command = new SqlCommand(query, connect); command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }

            public void RegisterUser(string login, string password)
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open(); string query = "INSERT INTO identification (login, password) VALUES (@Login, @Password)";
                    SqlCommand command = new SqlCommand(query, connect); command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void registrate_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
            {
                string login = textBoxLogin.Text;
                string password = textBoxPassword.Text;
                Manager manager = new Manager(connection);
                manager.RegisterUser(login, password);
                MessageBox.Show(this, "Вы успешно зарегистрированы", "", MessageBoxButtons.OK);
            }
          string  log = textBoxLogin.Text;
          string pas = textBoxPassword.Text;
            Form10 form10 = new Form10(log,pas);
            form10.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Form10 form10_1 = new Form10();
            form10_1.Show();
            Hide();
        }
    }
}
