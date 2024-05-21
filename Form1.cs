using System;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Регистрация"
        private void register_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы для регистрации
            Form2 regist = new Form2();

            // Отображение формы для регистрации и скрытие текущей формы
            regist.Show();
            Hide();
        }

        // Обработчик события нажатия кнопки "Ввод"
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы для ввода
            Form3 input = new Form3();

            // Отображение формы для ввода и скрытие текущей формы
            input.Show();
            Hide();
        }

        // Обработчик события нажатия кнопки "Выход"
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Закрытие приложения
            Application.Exit();
        }

        // Обработчик события нажатия на метку
        private void Admin_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы №10
            Form10 form10 = new Form10();

            // Отображение формы №10 и скрытие текущей формы
            form10.Show();
            Hide();
        }
    }
}
