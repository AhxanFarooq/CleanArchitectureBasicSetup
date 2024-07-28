namespace NowApi.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void CorsPolicyConfiguration(this IServiceCollection services, IConfiguration configuration, string config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: config,
                    builder1 =>
                    {

                        //builder.WithOrigins(Configuration.GetSection("frontend:IpAndServerAddress").Value, "app://.").AllowAnyMethod()
                        //.AllowAnyHeader();
                        
                        builder1.WithOrigins(configuration.GetSection("frontend:IpAndServerAddress").Value).AllowAnyHeader().AllowAnyMethod();
                    });
            });
        }
    }
}
