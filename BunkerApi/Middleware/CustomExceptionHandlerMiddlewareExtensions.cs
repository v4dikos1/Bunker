namespace BunkerApi.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
