using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using Proyecto01_InsidenciaTicket.Models;
using System.Windows;



namespace Proyecto01_InsidenciaTicket.Conexion.DataBase
{
    internal class SqlConn
    {
        public readonly string sqlstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConn() { }
        public ObservableCollection<Users> ViewUserDB()
        {
            ObservableCollection<Users> usertable = new ObservableCollection<Users>();
            string query = "select * from Users";
            SqlConnection sqlConn = new SqlConnection(sqlstring);
            SqlCommand acccionConn = new SqlCommand(query,sqlConn);
            using (sqlConn) 
            {
                try
                { 
                    sqlConn.Open();
                    SqlDataReader reader = acccionConn.ExecuteReader();
                    while (reader.Read()) 
                    {
                        usertable.Add(new Users()
                        {
                            _id = (int)reader["Id"],
                            _username = (string)reader["UserName"],
                            _password = (string)reader["Passwords"],
                        });
                    }
                    sqlConn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return usertable;
            }
        }
        public void AddUserDB(Users user)
        {
            string query = " Insert Into Users (Id,UserName,Passwords) values (@id , @username, @password)";
            SqlConnection sqlConn = new SqlConnection(sqlstring);
            using (sqlConn)
            {
                    sqlConn.Open();
                    SqlCommand acccionConn = new SqlCommand(query, sqlConn);
                    acccionConn.Parameters.AddWithValue("@id", user._id);
                    acccionConn.Parameters.AddWithValue("@username", user._username);
                    acccionConn.Parameters.AddWithValue("@password", user._password);
                try
                {
                    sqlConn.Open();
                    acccionConn.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void DeleteUserDB(Users user)
        {
            string query = "DELETE FROM Users WHERE Id = @id";
            SqlConnection sqlConn = new SqlConnection(sqlstring);
            using (sqlConn)
            {
                SqlCommand acccionConn = new SqlCommand(query, sqlConn);
                acccionConn.Parameters.AddWithValue("@id", user._id);
                try
                {
                    sqlConn.Open();
                    acccionConn.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void UpdateUserDB(Users user)
        {
            string query = "Update Users Set UserName=@username,Passwords=@password WHERE Id = @id";
            SqlConnection sqlConn = new SqlConnection(sqlstring);

            using (sqlConn)
            {
                    SqlCommand acccionConn = new SqlCommand(query, sqlConn);
                    acccionConn.Parameters.AddWithValue("@username", user._username);
                    acccionConn.Parameters.AddWithValue("@password", user._password);
                try
                {
                    sqlConn.Open();
                    acccionConn.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public bool ValidateUser(string username, string password)
        {
            bool isValidUser = false;
            string query = "SELECT COUNT(*) FROM Users WHERE UserName = @username AND Passwords = @password";

            using (SqlConnection connection = new SqlConnection(sqlstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    isValidUser = count > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return isValidUser;
        }

    }
}
