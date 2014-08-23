using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Controllers
{
    public class QueryManager
    {

        private void Test()
        {
            string cs = @"server=localhost;userid=notfamous;
            password=firemonkey;database=nuretail";

            MySqlConnection c = null;

            try
            {
                c = new MySqlConnection(cs);
                c.Open();
                Console.WriteLine("MySQL version :" + c.ServerVersion.ToString());

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally
            {
                if (c != null)
                {
                    c.Close();
                }
            }
        }
    }
}
