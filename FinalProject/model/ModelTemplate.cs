using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace FinalProject.model
{
    class ModelTemplate
    {
        private static SqlConnection conn;
        private SqlCommand command;
        private bool result;

        public static SqlConnection GetSqlConnection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source = LAPTOP-4NPDE09G;" +
                                    "Initial Catalog = MarketPlace;" +
                                    "Integrated Security = True;";
            return conn;
        }

        //constructor
        public ModelTemplate()
        {
            GetSqlConnection();
        }

        // template select data
        public DataSet Select(string tabel, string kondisi)
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                if (kondisi == null)
                {
                    command.CommandText = "SELECT * FROM " + tabel;
                }
                else
                {
                    command.CommandText = "SELECT * FROM " + tabel + " WHERE " + kondisi;
                }
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, tabel);
            }
            catch (SqlException)
            {
                ds = null;
            }
            conn.Close();
            return ds;
        }

        public Boolean Insert(string table, string data)
        {
            result = false;
            try
            {
                string query = "INSERT INTO " + table + " VALUES (" + data + ")";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        public Boolean Update(string table, string data, string kondisi)
        {
            result = false;
            try
            {
                string query = "UPDATE " + table + " SET " + data + "WHERE" + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        public Boolean Delete(string table, string kondisi)
        {
            result = false;
            try
            {
                string query = "DELETE FROM " + table + " WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }


        //testing koneksi database
        public void cekKoneksi()
        {

            //errorhandling
            GetSqlConnection();
            try
            {
                conn.Open();
                MessageBox.Show("koneksi sukses");
            }
            catch (SqlException se)
            {
                MessageBox.Show("koneksi failed" + se);
            }
        }


    }
}
