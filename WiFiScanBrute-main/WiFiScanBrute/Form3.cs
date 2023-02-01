using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WiFiScanBrute
{
    public partial class Form3 : Form
    {
        private string fileName = string.Empty;



        public Form3()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bDDataSet.Роутеры". При необходимости она может быть перемещена или удалена.
            this.роутерыTableAdapter.Fill(this.bDDataSet.Роутеры);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=BD.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            // Запрос к БД
            dbConnection.Open();
            string query = "SELECT * FROM Роутеры";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            


            dbReader.Close();
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            // Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string data = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string number = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string model = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string fail = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string speed = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string signal = dataGridView1.Rows[index].Cells[7].Value.ToString();

            // Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=BD.mdb";  // строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);             // создаем соеденение

            try
            {
                // Выполянем запрос к БД
                dbConnection.Open();//открываем соеденение
                string query =   "INSERT INTO Роутеры VALUES (" + id + ", '" + name + "', '" + data + "', " + number + ", '" + model + "', '" + fail + "', " + speed + ", '" + signal + "')";//строка запроса
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

                // Выполняем запрос
                if (dbCommand.ExecuteNonQuery() != 1)
                    MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
                else
                    MessageBox.Show("Данные добавлены!", "Внимание!");
            }
            
            finally
            {
                // Закрываем соеденение с БД
                dbConnection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;


            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }


            // Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string data = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string number = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string model = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string fail = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string speed = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string signal = dataGridView1.Rows[index].Cells[7].Value.ToString();


            // Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=BD.mdb";  // строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);             // создаем соеденение


            dbConnection.Open();
            string query = $"delete from Роутеры where Код = "+ id + "";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        
    }
}
