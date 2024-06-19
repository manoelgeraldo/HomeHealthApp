using Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace API.H2A.Configurations
{
    public static class DataContextAccessConfiguration
    {
        public static void AddDataContextAccessConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DataContextAccess>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
        }
    }
}
