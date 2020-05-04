using System;
using System.Data.SqlClient;
using System.Windows;

namespace qsol.exportimport.Helpers
{
    public class CheckConnection
    {
        private readonly string _titel;
        private readonly bool _isShowSucceededMessage;

        public CheckConnection(string titel, bool isShowSucceededMessage=true)
        {
            _titel = titel;
            ErrorMessage = "";
            ConnectionString = "";
            _isShowSucceededMessage = isShowSucceededMessage;
        }

        public bool CheckSqlServerConnection(string serverName, string database, string userName, string password)
        {
            if (String.IsNullOrEmpty(serverName) || String.IsNullOrEmpty(database) ||
                String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                ErrorMessage = "Test connection failed.";
                MessageBox.Show(ErrorMessage, $"{_titel} connection", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            ConnectionString = $"Server={serverName};Database={database};UID={userName};Pwd={password}; MultipleActiveResultSets = True";
            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                        sqlConnection.Open();
                
                if(_isShowSucceededMessage)
                    MessageBox.Show("Test connection succeeded.", $"{_titel} connection", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
                
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Test connection failed.{Environment.NewLine}{ex.Message}";
                MessageBox.Show(ErrorMessage,
                    $"{_titel} connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
        }

        public string ErrorMessage { get; private set; }
        public string ConnectionString { get; private set; }
    }
}
