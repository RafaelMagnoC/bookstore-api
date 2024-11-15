using BookStore.App.Exceptions;

namespace BookStore.App.Middlewares
{
 public class CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
 {
  private readonly RequestDelegate _next = next;
  private readonly ILogger<CustomExceptionMiddleware> _logger = logger;

  public async Task InvokeAsync(HttpContext context)
  {
   try
   {
    await _next(context);
   }
   catch (NotAuthenticated exception)
   {
    _logger.LogError(exception, "Erro de autenticação.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status401Unauthorized);
   }
   catch (NotAuthorized exception)
   {
    _logger.LogError(exception, "Erro de autorização.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status403Forbidden);
   }
   catch (BadRequest exception)
   {
    _logger.LogError(exception, "Erro na requisição.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status400BadRequest);
   }
   catch (AvailableQuantity exception)
   {
    _logger.LogError(exception, "Produto sem saldo disponível.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status423Locked);
   }
   catch (NotFound exception)
   {
    _logger.LogError(exception, "Nenhum resultado encontrado.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status404NotFound);
   }
   catch (CreateException exception)
   {
    _logger.LogError(exception, "Um erro ocorreu durante a criação.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status422UnprocessableEntity);
   }
   catch (UpdateException exception)
   {
    _logger.LogError(exception, "Um erro ocorreu durante a atualização.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status422UnprocessableEntity);
   }
   catch (RemoveException exception)
   {
    _logger.LogError(exception, "Um erro ocorreu ao remover.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status422UnprocessableEntity);
   }
   catch (UniqueKeyException exception)
   {
    _logger.LogError(exception, "Chave única já existe.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status422UnprocessableEntity);
   }
   catch (InvalidCredential exception)
   {
    _logger.LogError(exception, "Chave única já existe.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status422UnprocessableEntity);
   }
   catch (Exception exception)
   {
    _logger.LogError(exception, "Erro interno.");
    await HandleExceptionAsync(context, exception, StatusCodes.Status500InternalServerError);
   }
  }

  private static Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode)
  {
   context.Response.ContentType = "application/json";
   context.Response.StatusCode = statusCode;

   var response = new
   {
    message = ex.Message,
    details = ex.StackTrace
   };

   return context.Response.WriteAsJsonAsync(response);
  }
 }

}
