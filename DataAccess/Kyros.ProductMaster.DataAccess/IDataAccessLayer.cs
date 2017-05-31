using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Kyros.ProductMaster.DataAccess
{
    public interface IDataAccessLayer
    {
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        int ExecuteNonQuery(string storedProcedureName, IEnumerable<KeyValuePair<string,object>> storedProcedureParams = null);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        object ExecuteScalar(string storedProcedureName,IEnumerable<KeyValuePair<string,object>> storedProcedureParams = null);

        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        IDataReader ExecuteDataReader(string storedProcedureName, IEnumerable<KeyValuePair<string,object>> storedProcedureParams = null);

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string storedProcedureName, IEnumerable<KeyValuePair<string,object>> storedProcedureParams = null);
    }
}
