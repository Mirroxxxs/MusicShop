using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // Строка подключения к базе данных
        private string connection = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

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

        // Обработчик события нажатия кнопки "Назад"
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Создание экземпляра главной формы и ее отображение
            Form1 form1 = new Form1();
            form1.Show();

            // Скрытие текущей формы
            Hide();
        }

        // Обработчик события нажатия кнопки "Войти"
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            Manager manager = new Manager(connection);

            if (manager.Inicilizate(login, password))
            {
                MessageBox.Show("Вы успешно вошли в систему!");
                Form4 form4 = new Form4();
                form4.Show();

                // Скрытие текущей формы
                Hide();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль!");
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
