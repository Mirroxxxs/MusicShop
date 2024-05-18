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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "musicShopDataSet2.sales". При необходимости она может быть перемещена или удалена.
            this.salesTableAdapter.Fill(this.musicShopDataSet2.sales);

        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на заполненность всех текстовых полей
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Пожалуйста заполните все текстовые поля.");
                return;
            }

            // Получение данных из текстовых полей
            int id_products, id_staff, amount;
            DateTime date;
            decimal cost;

            if (!int.TryParse(textBox1.Text, out id_products) ||
                !int.TryParse(textBox2.Text, out id_staff) ||
                !DateTime.TryParse(textBox3.Text, out date) ||
                !int.TryParse(textBox4.Text, out amount) ||
                !decimal.TryParse(textBox5.Text, out cost))
            {
                MessageBox.Show("Пожалуйста,введите верные типовые данные");
                return;
            }
            // Проверка наличия данных в базе данных
            if (DataExists(id_products, id_staff, date, amount, cost))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            // Добавление данных в базу данных
            AddDataToDatabase(id_products, id_staff, date, amount, cost);

        }
        private bool DataExists(int id_products, int id_staff, DateTime date, int amount, decimal cost)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM sales WHERE id_products = @IdProducts AND id_staff = @IdStaff AND date = @Date AND amount = @Amount AND cost = @Cost", conn))
                {
                    cmd.Parameters.AddWithValue("@IdProducts", id_products);
                    cmd.Parameters.AddWithValue("@IdStaff", id_staff);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Cost", cost);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void AddDataToDatabase(int id_products, int id_staff, DateTime date, int amount, decimal cost)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO sales (id_products, id_staff, date, amount, cost) VALUES (@IdProducts, @IdStaff, @Date, @Amount, @Cost)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdProducts", id_products);
                    cmd.Parameters.AddWithValue("@IdStaff", id_staff);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.ExecuteNonQuery();
                }
            }

            // Обновление DataGridView после добавления данных
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM sales", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Пожалуйста, введите Id строки для удаления.");
                return;
            }

            int id = Convert.ToInt32(textBox6.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("DELETE FROM sales WHERE id_sales = @IdSales", connection);
                command1.Parameters.AddWithValue("@IdSales", id);

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
            this.salesTableAdapter.Fill(this.musicShopDataSet2.sales);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
           string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
           string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Пожалуйста,заполните все текстовые поля.");
                return;
            }
            int id = Convert.ToInt32(textBox6.Text);

            int id_products, id_staff, amount;
            DateTime date;
            decimal cost;

            if (!int.TryParse(textBox1.Text, out id_products) ||
                !int.TryParse(textBox2.Text, out id_staff) ||
                !DateTime.TryParse(textBox3.Text, out date) ||
                !int.TryParse(textBox4.Text, out amount) ||
                !decimal.TryParse(textBox5.Text, out cost))
            {
                MessageBox.Show("Пожалуйста,введите верные типовые данные");
                return;
            }
            if (DataExists(id_products, id_staff, date, amount, cost))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE sales SET id_products = @IdProducts, id_staff = @IdStaff, date = @Date, amount = @Amount, cost = @Cost WHERE id_sales = @IdSales", conn))
                {
                    cmd.Parameters.AddWithValue("@IdProducts", id_products);
                    cmd.Parameters.AddWithValue("@IdStaff", id_staff);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.Parameters.AddWithValue("@IdSales", id);

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
            this.salesTableAdapter.Fill(this.musicShopDataSet2.sales);
        }
    }
}
