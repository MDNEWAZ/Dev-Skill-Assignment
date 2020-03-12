using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Miu.Library.Data
{
    public class SqlServerDataProvider<T> : IDisposable
    {
        protected readonly SqlConnection _sqlConnection;

        public SqlServerDataProvider(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();
        }

        public IList<T> GetData(string sql)
        {
            var result = new List<T>();

            var command = new SqlCommand(sql, _sqlConnection);

            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                var itemType = typeof(T);
                var constructor = itemType.GetConstructor(new Type[] { });
                var instance = constructor.Invoke(new object[] { });
                var properties = itemType.GetProperties();
                foreach(var property in properties)
                {
                    property.SetValue(instance, reader[property.Name]);
                }

                result.Add((T)instance);
            }
            return result;
        }

        public void Dispose()
        {
            if (_sqlConnection != null)
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();

                _sqlConnection.Dispose();
            }
        }
    }
}
