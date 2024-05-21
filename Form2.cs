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

        // Строка подключения к базе данных
        private string connection = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        // Обработчик события нажатия кнопки "Назад"
        private void button2_Click(object sender, EventArgs e)
        {
            // Создание экземпляра главной формы и ее отображение
            Form1 form1 = new Form1();
            form1.Show();

            // Скрытие текущей формы
            Hide();
        }

        // Класс для работы с базой данных
        public class Manager
        {
            private string connection;

            public Manager(string connection)
            {
                this.connection = connection;
            }

            // Метод для инициализации пользователя
            public bool Inicilizate(string login, string password)
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string query = "SELECT COUNT(*) FROM identification WHERE login = @Login AND password = @Password";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }

            // Метод для регистрации пользователя
            public void RegisterUser(string login, string password)
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    string query = "INSERT INTO identification (login, password) VALUES (@Login, @Password)";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Обработчик события нажатия кнопки "Зарегистрироваться"
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

                // Скрытие текущей формы
                Hide();
            }
        }

        // Переменная для отображения пароля
        private bool isPasswordVisible = false;

        // Обработчик события нажатия кнопки "Показать пароль"
        private void buttonPasswordVisible_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                textBoxPassword.PasswordChar = '*';
                isPasswordVisible = false;
            }
            else
            {
                // Показать текст пароля
                textBoxPassword.PasswordChar = '\0';
                isPasswordVisible = true;
            }
        }
    }
}
