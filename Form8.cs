using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace MusicShop
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=EGORKA\\SQLEXPRESS;Initial Catalog=MusicShop;Integrated Security=True;";

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "musicShopDataSet2.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.musicShopDataSet2.staff);

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
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Пожалуйста заполните все текстовые поля.");
                return;
            }

            // Получение данных из текстовых полей
            string lastName = textBox1.Text;
            string firstName = textBox2.Text;
            string midName = textBox3.Text;
            string post = textBox4.Text;
            if (DataExists(lastName, firstName, midName, post))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            // Добавление данных в базу данных
            AddDataToDatabase(lastName, firstName, midName, post);
        }
        private bool DataExists(string lastName, string firstName, string midName, string post)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM staff WHERE Last_Name = @LastName AND First_Name = @FirstName AND Mid_Name = @MidName AND post = @Post", conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MidName", midName);
                    cmd.Parameters.AddWithValue("@Post", post);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void AddDataToDatabase(string lastName, string firstName, string midName, string post)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO staff (Last_Name, First_Name, Mid_Name, post) VALUES (@LastName, @FirstName, @MidName, @Post)", conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MidName", midName);
                    cmd.Parameters.AddWithValue("@Post", post);
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
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM staff", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Пожалуйста, введите Id строки для удаления.");
                return;
            }

            int id = Convert.ToInt32(textBox5.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("DELETE FROM staff WHERE id_staff = @IdStaff", connection);
                command1.Parameters.AddWithValue("@IdStaff", id);

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
            this.staffTableAdapter.Fill(this.musicShopDataSet2.staff);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Пожалуйста заполните все текстовые поля.");
                return;
            }

            // Получение данных из текстовых полей
            int id = Convert.ToInt32(textBox5.Text);

            string lastName = textBox1.Text;
            string firstName = textBox2.Text;
            string midName = textBox3.Text;
            string post = textBox4.Text;
            if (DataExists(lastName, firstName, midName, post))
            {
                MessageBox.Show("Данные уже существуют в базе.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE staff SET Last_Name = @LastName, First_Name = @FirstName, Mid_Name = @MidName, post = @Post WHERE id_staff = @IdStaff", conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MidName", midName);
                    cmd.Parameters.AddWithValue("@Post", post);

                    cmd.Parameters.AddWithValue("@IdStaff", id);
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
            this.staffTableAdapter.Fill(this.musicShopDataSet2.staff);

        }
    }
}
