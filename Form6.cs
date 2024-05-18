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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicShop
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "musicShopDataSet1.categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.musicShopDataSet1.categories);

        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста заполните все текстовые поля");
                return;
            }

            // Получение данных из текстовых полей
            string name = textBox1.Text;

            if (DataExists(name))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            // Добавление данных в базу данных
            AddDataToDatabase(name);
            this.categoriesTableAdapter.Fill(this.musicShopDataSet1.categories);
        }
        private bool DataExists(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM categories WHERE name = @Name", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void AddDataToDatabase(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO categories (name) VALUES (@Name)", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.ExecuteNonQuery();
                }
            }

            // Обновление DataGridView после добавления данных
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, введите Id строки для удаления.");
                return;
            }

            int id = Convert.ToInt32(textBox2.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("DELETE FROM categories WHERE id_categories = @IdCategories", connection);
                command1.Parameters.AddWithValue("@IdCategories", id);

                int rowsAffected = command1.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Строка успешно удалена из базы данных.");
                }
                else
                {
                    MessageBox.Show("Не удалось найти строку с указанным Id.");
                }
            }
            this.categoriesTableAdapter.Fill(this.musicShopDataSet1.categories);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
             
            {
                MessageBox.Show("Пожалуйста,заполните все текстовые поля.");
                return;
            }
            int id = Convert.ToInt32(textBox2.Text);
           
            string name = textBox1.Text;
            if (DataExists(name))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE categories SET name = @Name WHERE id_categories = @IdCategories", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                   
                    cmd.Parameters.AddWithValue("@IdCategories", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Строка успешно обновлена в базе данных.");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти строку с указанным Id.");
                    }
                }
            }
            this.categoriesTableAdapter.Fill(this.musicShopDataSet1.categories);

        }
    }
}
