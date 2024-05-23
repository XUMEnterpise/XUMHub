using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XUMHUB.Core
{
    class DbManager : INotifyPropertyChanged
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Test_Program.Properties.Settings.homeConnectionString"].ConnectionString;

        private ObservableCollection<DataRow> _dataRows;

        public ObservableCollection<DataRow> DataRows
        {
            get => _dataRows;
            set
            {
                _dataRows = value;
                OnPropertyChanged(nameof(DataRows));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task<bool> InsertQueryAsync(string query)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = connection.CreateCommand())
                {
                    await connection.OpenAsync();
                    command.CommandText = query;
                    Console.WriteLine("Rows affected " + await command.ExecuteNonQueryAsync());
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<DataTable> SelectAsync(string table)
        {
            try
            {
                var dt = new DataTable();
                string query = $"SELECT * FROM {table}";
                using (var connection = new SqlConnection(_connectionString))
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    await connection.OpenAsync();
                    await Task.Run(() => adapter.Fill(dt));
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DataTable> SelectSpecificAsync(string table, string column, string condition)
        {
            try
            {
                var dt = new DataTable();
                string query = $"SELECT * FROM {table} WHERE {column}='{condition}'";
                using (var connection = new SqlConnection(_connectionString))
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    await connection.OpenAsync();
                    await Task.Run(() => adapter.Fill(dt));
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DataTable> SelectWildAsync(string table, string column, string condition)
        {
            try
            {
                var dt = new DataTable();
                string query = $"SELECT * FROM {table} WHERE {column} LIKE '{condition}'";
                using (var connection = new SqlConnection(_connectionString))
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    await connection.OpenAsync();
                    await Task.Run(() => adapter.Fill(dt));
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task DeleteRowAsync(string table, string columnName, string condition)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand($"DELETE FROM {table} WHERE {columnName}={condition}", connection))
                    {
                        Console.WriteLine("Rows affected " + await command.ExecuteNonQueryAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        private async Task MoveToFinishedAsync(int id)
        {
            try
            {
                string query = $"UPDATE History SET IsTested = '1' WHERE Id='{id}'";
                await InsertQueryAsync(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task<bool> CheckIfExistsAsync(string table, string column, string value)
        {
            var dt = await SelectSpecificAsync(table, column, value);
            return dt != null && dt.Rows.Count > 0;
        }
    }
}
