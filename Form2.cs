using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace MusicShop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string connection = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
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
                Form4 form4 = new Form4();
                form4.Show();
                Hide();
            }
        }
        private bool isPasswordVisible = false;

        private void button1_Click(object sender, EventArgs e)
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
