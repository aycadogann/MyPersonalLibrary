using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.DataAccess.Concrete.AdoNet
{
    public static class DbConnection
    {
        
        public static  SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyPersonalLibrary;Integrated Security=True");
    }
}