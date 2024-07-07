using Contracts;
using Hellang.Middleware.ProblemDetails;
using Services;

namespace API
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddHttpClient()
                .AddSingleton<IAPIService, APIService>()
                .AddSingleton<IStringSearch, StringSearch>()
                .AddSingleton<ITextSearchService, TextSearchService>();
        }

        public static IServiceCollection ConfigureProblemDetails(this IServiceCollection services,
           IHostEnvironment env)
        {
            return services.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = (ctx, ex) => env.IsDevelopment();
            });
        }
    }
}
