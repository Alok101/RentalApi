using Microsoft.AspNetCore.Builder;
using Rental.API.Infrastructures.Filters;

namespace Rental.API.Extensions
{
    public static class ApiResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseApiResponseAndExceptionWrapper(this IApplicationBuilder builder, ApiResponseOptions options = default)
        {
            options ??= new ApiResponseOptions();
            return builder.UseMiddleware<ApiResponseMiddleware>(options);
        }
        public static IApplicationBuilder UseAPIResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiResponseMiddleware>();
        }
    }
}
