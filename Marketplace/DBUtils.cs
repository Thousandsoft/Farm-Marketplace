using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Marketplace
{
    class DBUtils
    {
        public static SQLiteConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-DT0K1JM";
            string database = "MarketplaceDB";
            string username = "market";
            string password = "145236";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
