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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "musicShopDataSet2.reports". При необходимости она может быть перемещена или удалена.
            this.reportsTableAdapter.Fill(this.musicShopDataSet2.reports);

        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Проверка на заполненность всех текстовых полей
            if (string.IsNullOrEmpty(IdSalesTextBox.Text) || string.IsNullOrEmpty(DateTextBox.Text) ||
                string.IsNullOrEmpty(RevenueTextBox.Text) || string.IsNullOrEmpty(ExpensesTextBox.Text) ||
                string.IsNullOrEmpty(ProfitTextBox.Text))
            {
                MessageBox.Show("Пожалуйста заполните все текстовые поля");
                return;
            }

            // Получение данных из текстовых полей
            int id_sales;
            DateTime period;
            decimal revenue, expenses, profit;

            if (!int.TryParse(IdSalesTextBox.Text, out id_sales) ||
                !DateTime.TryParse(DateTextBox.Text, out period) ||
                !decimal.TryParse(RevenueTextBox.Text, out revenue) ||
                !decimal.TryParse(ExpensesTextBox.Text, out expenses) ||
                !decimal.TryParse(ProfitTextBox.Text, out profit))
            {
                MessageBox.Show("Пожалуйста,введите верные типовые данные.");
                return;
            }

            // Проверка наличия данных в базе данных
            if (DataExists(id_sales, period, revenue, expenses, profit))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }

            // Добавление данных в базу данных
            AddDataToDatabase(id_sales, period, revenue, expenses, profit);
        }
        private bool DataExists(int id_sales, DateTime period, decimal revenue, decimal expenses, decimal profit)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM reports WHERE id_sales = @IdSales AND period = @Period AND revenue = @Revenue AND expenses = @Expenses AND profit = @Profit", conn))
                {
                    cmd.Parameters.AddWithValue("@IdSales", id_sales);
                    cmd.Parameters.AddWithValue("@Period", period);
                    cmd.Parameters.AddWithValue("@Revenue", revenue);
                    cmd.Parameters.AddWithValue("@Expenses", expenses);
                    cmd.Parameters.AddWithValue("@Profit", profit);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void AddDataToDatabase(int id_sales, DateTime period, decimal revenue, decimal expenses, decimal profit)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO reports (id_sales, period, revenue, expenses, profit) VALUES (@IdSales, @Period, @Revenue, @Expenses, @Profit)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdSales", id_sales);
                    cmd.Parameters.AddWithValue("@Period", period);
                    cmd.Parameters.AddWithValue("@Revenue", revenue);
                    cmd.Parameters.AddWithValue("@Expenses", expenses);
                    cmd.Parameters.AddWithValue("@Profit", profit);
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
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM reports", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ReportsGridView.DataSource = dt;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdReportTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите Id строки для удаления.");
                return;
            }

            int id = Convert.ToInt32(ProfitTextBox.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("DELETE FROM reports WHERE id_reporr = @IdReport", connection);
                command1.Parameters.AddWithValue("@IdReport", id);

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
            this.reportsTableAdapter.Fill(this.musicShopDataSet2.reports);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdSalesTextBox.Text) || string.IsNullOrEmpty(DateTextBox.Text) ||
               string.IsNullOrEmpty(RevenueTextBox.Text) || string.IsNullOrEmpty(ExpensesTextBox.Text) ||
               string.IsNullOrEmpty(ProfitTextBox.Text))
            {
                MessageBox.Show("Пожалуйста заполните все текстовые поля");
                return;
            }

            // Получение данных из текстовых полей
            int id = Convert.ToInt32(IdReportTextBox.Text);

            int id_sales;
            DateTime period;
            decimal revenue, expenses, profit;

            if (!int.TryParse(IdSalesTextBox.Text, out id_sales) ||
                !DateTime.TryParse(DateTextBox.Text, out period) ||
                !decimal.TryParse(RevenueTextBox.Text, out revenue) ||
                !decimal.TryParse(ExpensesTextBox.Text, out expenses) ||
                !decimal.TryParse(ProfitTextBox.Text, out profit))
            {
                MessageBox.Show("Пожалуйста,введите верные типовые данные.");
                return;
            }

            // Проверка наличия данных в базе данных
            if (DataExists(id_sales, period, revenue, expenses, profit))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE report SET id_sales = @IdSales, period = @Period, revenue = @Revenue, expenses = @Expenses, profit = @Profit WHERE id_report = @IdReport", conn))
                {
                    cmd.Parameters.AddWithValue("@IdSales", id_sales);
                    cmd.Parameters.AddWithValue("@Period", period);
                    cmd.Parameters.AddWithValue("@Revenue", revenue);
                    cmd.Parameters.AddWithValue("@Expenses", expenses);
                    cmd.Parameters.AddWithValue("@Profit", profit);
                    cmd.Parameters.AddWithValue("@IdReport", id);

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
            this.reportsTableAdapter.Fill(this.musicShopDataSet2.reports);

        }
    }
}
