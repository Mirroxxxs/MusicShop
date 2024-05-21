using System;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Продукты"
        private void buttonProducts_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы для работы с продуктами
            Form5 form5 = new Form5();
            form5.Show();

            // Скрытие текущей формы
            Hide();
        }

        // Обработчик события нажатия кнопки "Категории"
        private void buttonCategories_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы для работы с категориями
            Form6 form6 = new Form6();
            form6.Show();

            // Скрытие текущей формы
            Hide();
        }

        // Обработчик события нажатия кнопки "Продажи"
        private void buttonSales_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы для работы с продажами
            Form7 form7 = new Form7();
            form7.Show();

            // Скрытие текущей формы
            Hide();
        }

        // Обработчик события нажатия кнопки "Отчет"
        private void buttonReport_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы для просмотра отчета
            Form9 form9 = new Form9();
            form9.Show();

            // Скрытие текущей формы
            Hide();
        }

        // Обработчик события загрузки формы
        private void Form4_Load(object sender, EventArgs e)
        {
            // Метод загрузки формы
        }

        // Обработчик события нажатия кнопки "Выход"
        private void End_Click(object sender, EventArgs e)
        {
            // Создание и отображение главной формы
            Form1 form1 = new Form1();
            form1.Show();

            // Скрытие текущей формы
            Hide();
        }
    }
}
