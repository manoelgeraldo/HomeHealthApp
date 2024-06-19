using Service.Mappings;

namespace API.H2A.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(PacienteMappingProfile));
        }
    }
}
