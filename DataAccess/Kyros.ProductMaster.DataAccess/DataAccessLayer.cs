using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Kyros.ProductMaster.DataAccess.Resource;

namespace Kyros.ProductMaster.DataAccess
{
    public class DataAccessLayer : IDataAccessLayer
    {
        #region Implementation of IDataAccessLayer

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var sqlConnection = GetSqlConnection())
            {
                using (var sqlCommand = GetSqlCommand(sqlConnection,storedProcedureName,storedProcedureParams))
                {
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public object ExecuteScalar(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var sqlConnection = GetSqlConnection())
            {
                using (var sqlCommand = GetSqlCommand(sqlConnection, storedProcedureName, storedProcedureParams))
                {
                    return sqlCommand.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public IDataReader ExecuteDataReader(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var sqlConnection = GetSqlConnection())
            {
                using (var sqlCommand = GetSqlCommand(sqlConnection, storedProcedureName, storedProcedureParams))
                {
                    return sqlCommand.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var dataSet = new DataSet())
            {
                using (var sqlConnection = GetSqlConnection())
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(GetSqlCommand(sqlConnection, storedProcedureName, storedProcedureParams)))
                    {
                        sqlDataAdapter.Fill(dataSet);
                    }
                }

                return dataSet;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <returns></returns>
        private static string GetSqlConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[DataAccessResource.ConnString].ConnectionString;
        }

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetSqlConnection()
        {
            var sqlConnection = new SqlConnection(GetSqlConnectionString());

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            else
            {
                sqlConnection.Close();
            }

            return sqlConnection;
        }

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <param name="sqlConnection">The SQL connection.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        private static SqlCommand GetSqlCommand(SqlConnection sqlConnection, string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            var sqlCommand = new SqlCommand
                             {
                                 Connection = GetSqlConnection(),
                                 CommandText = storedProcedureName,
                                 CommandType = CommandType.StoredProcedure,
                             };

            if (storedProcedureParams == null)
            {
                return sqlCommand;
            }

            foreach (var storedProcedureParam in storedProcedureParams)
            {
                sqlCommand.Parameters.AddWithValue(storedProcedureParam.Key, storedProcedureParam.Value);
            }

            return sqlCommand;
        }

        #endregion
    }
}
