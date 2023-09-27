using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;

namespace ProductApi
{
    public class Connection
    {
        public MySqlConnection connection;
        private string Host;
        private string Db;
        private string User;
        private string Password;
        private string connectionstring;

        public Connection()
        {
            this.Host="localhost";
            this.Db="db";
            this.User="root";
            this.Password="";

            this.connectionstring = $"SERVER=\"{Host}\";DATABASE=\"{Db}\";UID=\"{User}\";PASSWORD=\"{Password}\";SslMode=None";
            connection = new MySqlConnection(connectionstring);
        }

        

    }
}
