using System.Net;
using System.Text.Json;
using ValetaxTest.Application.Exceptions;
using ValetaxTest.Application.Interfaces;

namespace ValetaxTest.Api;

public class ExceptionHandlingMiddleware(RequestDelegate next, 
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, IJournalWriter journalWriter)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception");

            if (context.Response.HasStarted)
                throw;

            var eventId = await journalWriter.WriteExceptionAsync(
                ex.Message,
                ex.ToString(),
                context.RequestAborted);

            await WriteResponseAsync(context, ex, eventId);
        }
    }

    private static Task WriteResponseAsync(HttpContext context, Exception exception,
        long eventId)
    {
        var statusCode = exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            SecureException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            type = exception.GetType().Name,
            id = eventId,
            data = new
            {
                message = exception.Message
            }
        };

        return context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}