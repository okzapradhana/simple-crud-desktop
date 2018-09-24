using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {

        private Form1 form1;
        private Boolean convert;
        private int id;

        public Form4(Form1 ParentForm)
        {
            InitializeComponent();
            form1 = ParentForm;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            string query = "UPDATE user set first_name = @firstName, last_name = @lastName, address = @address WHERE id = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(query, form1.connect);

            form1.connect.Open();
            mySqlCommand.Parameters.AddWithValue("@firstName", firstNameBox.Text);
            mySqlCommand.Parameters.AddWithValue("@lastName", lastNameBox.Text);
            mySqlCommand.Parameters.AddWithValue("@address", addressBox.Text);
            mySqlCommand.Parameters.AddWithValue("@id", id);

            mySqlCommand.ExecuteNonQuery();
            form1.connect.Close();
            MessageBox.Show("Data successfully updated!");

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameBox.Text) || string.IsNullOrWhiteSpace(lastNameBox.Text) || string.IsNullOrWhiteSpace(addressBox.Text))
            {
                MessageBox.Show("All fields must not be empty");
            }
            else
            {
                string saveQuery = "INSERT into user (first_name, last_name, address) VALUES(@firstName, @lastName, @address)";
                MySqlCommand mySqlCommand = new MySqlCommand(saveQuery, form1.connect);
                form1.connect.Open();
                mySqlCommand.Parameters.AddWithValue("@firstName", firstNameBox.Text);
                mySqlCommand.Parameters.AddWithValue("@lastName", lastNameBox.Text);
                mySqlCommand.Parameters.AddWithValue("@address", addressBox.Text);
                mySqlCommand.ExecuteNonQuery();

                form1.connect.Close();
                MessageBox.Show("Data successfully inserted to database");
                firstNameBox.Clear();
                lastNameBox.Clear();
                addressBox.Clear();

                
                
            }
        }

        private void hapusButton_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM user WHERE id = @id";
            MySqlCommand mySqlCommand = new MySqlCommand(query, form1.connect);

            form1.connect.Open();
            mySqlCommand.Parameters.AddWithValue("@id", id);

            mySqlCommand.ExecuteNonQuery();
            form1.connect.Close();
            MessageBox.Show("Data successfully deleted!");
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM user";
            MySqlDataReader mySqlDataReader;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("First Name");
            dataTable.Columns.Add("Last Name");
            dataTable.Columns.Add("Address");

            try
            {
                form1.connect.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, form1.connect);
                mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    dataTable.Rows.Add(mySqlDataReader[0], mySqlDataReader[1], mySqlDataReader[2], mySqlDataReader[3]);


                    dataGridView1.DataSource = dataTable;

                }
                mySqlDataReader.Close();
                form1.connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                convert = Int32.TryParse(row.Cells[0].Value.ToString(), out id);
                Debug.WriteLine(id);
                firstNameBox.Text = row.Cells[1].Value.ToString();
                lastNameBox.Text = row.Cells[2].Value.ToString();
                addressBox.Text = row.Cells[3].Value.ToString();



            }
        }
    }
}
