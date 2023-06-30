using Application;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                Message = $"BusinessException. Error is {ex.Message}"
            });
        }
    }
}
