namespace Extension.CustomMiddleware
{
    public static class MiddlewareResolver
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
