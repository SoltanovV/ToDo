using System.Net;
using System.Text.Json;
using AspBackend.Models.Settings;

namespace AspBackend.Middelwares ;

    public class ExceptionHanlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHanlingMiddleware> _logger;

        public ExceptionHanlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHanlingMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (WorkingDataException ex)
            {
                await HadleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
                // catch (WorkingDataException ex)
                // {
                //     await HadleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
                // }
            catch (Exception ex)
            {
                await HadleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
            }
        }

        private async Task HadleExceptionAsync(HttpContext context, string exMessage, HttpStatusCode statusCode)
        {
            _logger.LogError(exMessage);

            var responce = context.Response;

            responce.ContentType = "application/json";
            responce.StatusCode = (int)statusCode;

            ErrorBody error = new()
            {
                StatusCode = (int)statusCode,
                Message = exMessage
            };

            var result = JsonSerializer.Serialize(error);

            await responce.WriteAsJsonAsync(result);
        }
    }