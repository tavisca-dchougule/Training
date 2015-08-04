using EMS.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.DataAccessLayer.DBConnectionPool
{
    public class DBPool                           // Singleton Class
    {
        private IDbConnection[] _connections = null;
        private const int POOL_SIZE = 100;
        private const int MAX_IDLE_TIME = 10;
        private int[] _locks = null;
        private DateTime[] _dates = null;
        private string _machineName = null;
        private string _dbName = null;
        private string _dbId = null;
        private string _dbPassword = null;
        private static DBPool _connectionPool = null;
        private DBPool()
        {
            _connections = new IDbConnection[100];
            _locks = new int[100];
            _dates = new DateTime[100];

            _machineName = ConfigurationManager.AppSettings["MachineName"];
            _dbName = ConfigurationManager.AppSettings["DBName"];
            _dbId = ConfigurationManager.AppSettings["DBId"];
            _dbPassword = ConfigurationManager.AppSettings["DBPassword"];

        }
        public IDbConnection GetConnection(out int identifier)
        {
            for (int i = 0; i < POOL_SIZE; i++)
            {
                if (Interlocked.CompareExchange(ref _locks[i], 1, 0) == 0)
                {
                    if (_dates[i] != DateTime.MinValue && (DateTime.UtcNow - _dates[i]).TotalMinutes > MAX_IDLE_TIME)
                    {
                        _connections[i].Dispose();
                        _connections[i] = null;
                    }

                    if (_connections[i] == null)
                    {
                        IDbConnection conn = CreateConnection();
                        _connections[i] = conn;
                        conn.Open();
                    }

                    _dates[i] = DateTime.UtcNow;
                    identifier = i;
                    return _connections[i];
                }
            }

            throw new Exception("No free connections");
        }
        private IDbConnection CreateConnection()
        {
            return new SqlConnection("Data Source=" + _machineName + ";Initial Catalog=" + _dbName + ";Persist Security Info=True;User ID=" + _dbId + ";Password=" + _dbPassword);
        }
        public void FreeConnection(int identifier)
        {
            if (identifier < 0 || identifier >= POOL_SIZE)
                return;
            Interlocked.Exchange(ref _locks[identifier], 0);
        }
        public static DBPool GetDBPoolInstance()
        {
            if (_connectionPool == null)
                _connectionPool = new DBPool();
            return _connectionPool;
        }
    }
}
