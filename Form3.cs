using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form3 : Form
    {
        public Form3()
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
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text; string password = textBoxPassword.Text;
            Manager manager = new Manager(connection);
            if (manager.Inicilizate(login, password))
            {
                MessageBox.Show("Вы успешно вошли в систему!");
                Form4 form4 = new Form4();
                form4.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль!");
            }
        
        }
        private bool isPasswordVisible = false;

   
        private void button3_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                textBoxPassword.PasswordChar = '*';
                isPasswordVisible = false;
            }
            else
            {
                // Показать текст
                textBoxPassword.PasswordChar = '\0';
                isPasswordVisible = true;
            }
        }
    }
}
