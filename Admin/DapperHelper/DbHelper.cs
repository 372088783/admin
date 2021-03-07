using System.Collections;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
namespace admin.DapperHelper
{
    public class DbHelper
    {
        private IDbConnection _dbConnection = new MySqlConnection();

        public string ConnectionString => DbContext.ConnectionString;

        public DbHelper()
        {
            _dbConnection.ConnectionString = ConnectionString;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlText"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="comandTimeOut"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string sqlText, object param = null, IDbTransaction transaction = null, int? comandTimeOut = null, CommandType? commandType = null)
        {
            //CommandType.StoredProcedure  存储过程
            return _dbConnection.QueryFirst<T>(sqlText, param, transaction, comandTimeOut, commandType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlText"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="comandTimeOut"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable Query<T>(string sqlText, object param = null, IDbTransaction transaction = null, bool buffered = true, int? comandTimeOut = null, CommandType? commandType = null)
        {
            //buffered  默认启用缓存
            return _dbConnection.Query<T>(sqlText, param, transaction, buffered, comandTimeOut, commandType);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="comandTimeOut"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int Execute(string sqlText, object param = null, IDbTransaction transaction = null, int? comandTimeOut = null, CommandType? commandType = null)
        {
            //buffered  默认启用缓存
            return _dbConnection.Execute(sqlText, param, transaction, comandTimeOut, commandType);
        }



    }


}
