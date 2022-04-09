using System.Data.SqlClient;

namespace BackEnd.Settings.Globals
{
    public class ConnectionDB
    {
        public static SqlConnection getConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            string connectionString = configuration["ConnectionStrings:APME"];

            var conn = new SqlConnection(connectionString);
            return conn;
        }
        protected SqlConnection con = getConnection();
    }
}
