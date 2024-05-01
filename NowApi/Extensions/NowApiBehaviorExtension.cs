using Microsoft.AspNetCore.Mvc;

namespace NowApi.Extensions
{
    public static class NowApiBehaviorExtension
    {
        public static void BehaviorExtensionService(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
