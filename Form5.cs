using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace MusicShop
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "musicShopDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.musicShopDataSet.products);

        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Пожалуйста,заполните все текстовые поля.");
                return;
            }

            // Получение данных из текстовых полей
            int id_categories;
            string name = textBox2.Text;
            string description = textBox3.Text;
            decimal price;
            int amount;

            if (!int.TryParse(textBox1.Text, out id_categories) ||
                !decimal.TryParse(textBox4.Text, out price) ||
                !int.TryParse(textBox5.Text, out amount))
            {
                MessageBox.Show("Пожалуйста,введите верные типовые данные.");
                return;
            }
            if (DataExists(id_categories, name, description, price, amount))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }

            // Добавление данных в базу данных
            AddDataToDatabase(id_categories, name, description, price, amount);
        }
        private bool DataExists(int id_categories, string name, string description, decimal price, int amount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM products WHERE id_categories = @IdCategories AND name = @Name AND description = @Description AND price = @Price AND amount = @Amount", conn))
                {
                    cmd.Parameters.AddWithValue("@IdCategories", id_categories);
                    cmd.Pausing System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class Form5 : Form
    {
        private const string connectionString = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Загрузка данных в DataGridView при загрузке формы
            LoadData();
        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            // Переход к предыдущей форме при нажатии кнопки "Назад"
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Проверка заполненности всех текстовых полей
            if (string.IsNullOrWhiteSpace(IDCategoriesTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text) ||
               string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
               string.IsNullOrWhiteSpace(AmountTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все текстовые поля.");
                return;
            }

            // Получение данных из текстовых полей
            int id_categories;
            string name = NameTextBox.Text;
            string description = DescriptionTextBox.Text;
            decimal price;
            int amount;

            // Попытка преобразования введенных данных в соответствующие типы
            if (!int.TryParse(IDCategoriesTextBox.Text, out id_categories) ||
                !decimal.TryParse(PriceTextBox.Text, out price) ||
                !int.TryParse(AmountTextBox.Text, out amount))
            {
                MessageBox.Show("Пожалуйста, введите верные типовые данные.");
                return;
            }

            // Проверка наличия данных в базе
            if (DataExists(id_categories, name, description, price, amount))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }

            // Добавление данных в базу
            AddDataToDatabase(id_categories, name, description, price, amount);
        }

        private bool DataExists(int id_categories, string name, string description, decimal price, int amount)
        {
            // Проверка наличия данных в базе
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM products WHERE id_categories = @IdCategories AND name = @Name AND description = @Description AND price = @Price AND amount = @Amount", conn))
                {
                    cmd.Parameters.AddWithValue("@IdCategories", id_categories);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void AddDataToDatabase(int id_categories, string name, string description, decimal price, int amount)
        {
            // Добавление данных в базу
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO products (id_categories, name, description, price, amount) VALUES (@IdCategories, @Name, @Description, @Price, @Amount)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdCategories", id_categories);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.ExecuteNonQuery();
                }
            }

            // Обновление DataGridView после добавления данных
            LoadData();
        }

        private void LoadData()
        {
            // Загрузка данных в DataGridView из базы
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM products", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ProductsGridView.DataSource = dt;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Удаление данных из базы
            if (string.IsNullOrWhiteSpace(IDProductstTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите Id строки для удаления.");
                return;
            }

            int id = Convert.ToInt32(IDProductstTextBox.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("DELETE FROM products WHERE id_products = @IdProducts", connection);
                command1.Parameters.AddWithValue("@IdProducts", id);

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
            // Обновление данных в DataGridView после удаления
            LoadData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Обновление данных в базе
            if (string.IsNullOrWhiteSpace(IDCategoriesTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text) ||
             string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
             string.IsNullOrWhiteSpace(AmountTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все текстовые поля.");
                return;
            }
            int id = Convert.ToInt32(IDProductstTextBox.Text);
            int id_categories;
            string name = NameTextBox.Text;
            string description = DescriptionTextBox.Text;
            decimal price;
            int amount;

            if (!int.TryParse(IDCategoriesTextBox.Text, out id_categories) ||
                !decimal.TryParse(PriceTextBox.Text, out price) ||
                !int.TryParse(AmountTextBox.Text, out amount))
            {
                MessageBox.Show("Пожалуйста, введите верные типовые данные.");
                return;
            }
            if (DataExists(id_categories, name, description, price, amount))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE products SET id_categories = @IdCategories, name = @Name, description = @Description, price = @Price, amount = @Amount WHERE id_products = @IdProducts", conn))
                {
                    cmd.Parameters.AddWithValue("@IdCategories", id_categories);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@IdProducts", id);

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

            // Обновление DataGridView после обновления данных
            LoadData();
        }
    }
}
