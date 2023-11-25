using ProtoolsStore.Services;

namespace _2WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (HttpException ex)
            {
                httpContext.Response.StatusCode = ex.StatusCodeNumeric;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    ex.StatusCodeNumeric,
                    ex.Message
                });

                httpContext.Response.StatusCode = 200;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Code = 200,
                    Message = "nice",
                });

                httpContext.Response.StatusCode = 404;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Code = 404,
                    Message = "notfound 404"
                });
            }
            catch (Exception ex)
            {
                // logger in there
                _logger.LogError(ex.ToString());

                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Code = 500,
                    Message = "error"
                });


            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
