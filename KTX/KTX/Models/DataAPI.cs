using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace WinFormsApp1.Models
{
    // SqlConnection
    // SqlCommand
    // SqlDataAdapter

    internal class DataAPI
    {
        private DataSet data;

        public DataAPI() { }

        public DataSet GetAlls(string table)
        {
            data = new DataSet();

            string query = "select * from " + table;
            if (table.Equals("Staff"))
                query = "select MaNhanVien, TenNhanVien, DiaChiNV, DienThoai from " + table;
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public DataSet Search(string query)
        {
            data = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public void GetData4ComboBox(string table, string column, ComboBox comboBox)
        {
            //data = new DataSet();
            string query = "select " + column + " from " + table;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string value = (string)reader[column].ToString();
                            comboBox.Items.Add(value);
                        }
                    }
                }
                connection.Close();
            }
        }
        public bool CheckID (string table,string column, string id) {
            string query = "select count(*) from " + table + " where " + column + " = '" + id + "'";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                int e = 0;
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                     e = (int)command.ExecuteScalar();
                }
                connection.Close();
                if (e > 0) return true;
            }
            return false;
        }
        public bool Login (string username, string password)
        {
            string query = "select count(*) from Staff where Username = '" + username + "' and Password = '" + password + "'";
            int e = 0; bool flag = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    e = (int)command.ExecuteScalar();
                    if (e > 0) flag = !flag;

                }
                connection.Close();
            }
            return flag;
            
        }
        public DataSet GetAllWhere(string table, string column, string value) {
            data = new DataSet();
            string query = "select * from " + table + " where " + column + " = @value";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public DataSet GetAll2Where(string table, string column, string value, string column2, string value2)
        {
            data = new DataSet();
            string query = "select * from " + table + " where " + column + " = '" + value + "' and " + column2 + " = '" + value2 + "'";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@value", value);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }


        public int GetCount(string table)
        {
            int value = 0;
            string query = "select COUNT(*) from " + table;

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                value = (int) command.ExecuteScalar();

                connection.Close();
            }


            return value;
        }
        public int GetCount(string table, string column, string value)
        {
            int e = 0;
            string query = "select COUNT(*) from " + table + " where " + column + " = '" + value +"'";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                e = (int)command.ExecuteScalar();

                connection.Close();
            }
            return e;
        }

        public bool InsertInto (string table, string value)
        {
            bool result = false;
            
            string query = "insert into " + table + " values " + value;

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            return result;
        }

        public bool Delete (string table, string column, string value)
        {
            bool result = false;

            //string query = "delete from " + table + " where @column = @value";
            string query = "delete from " + table + " where " + column + " = @value";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            return result;
        }

        public bool UpdateStudent (string table, string value)
        {
            bool result = false;

            /*UPDATE table_name
            SET column1 = value1, column2 = value2, ...
            WHERE condition;
            */
            string query = "update " + table + " set " + value + " where " + "conditions";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            return result;
        }
    }
}
