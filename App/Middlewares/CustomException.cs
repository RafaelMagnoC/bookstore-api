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
   catch (NotAuthenticated ex)
   {
    _logger.LogError(ex, "Erro de autenticação.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status401Unauthorized);
   }
   catch (NotAuthorized ex)
   {
    _logger.LogError(ex, "Erro de autorização.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status403Forbidden);
   }
   catch (BadRequest ex)
   {
    _logger.LogError(ex, "Erro na requisição.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest);
   }
   catch (AvailableQuantity ex)
   {
    _logger.LogError(ex, "Produto sem saldo disponível.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status423Locked);
   }
   catch (NotFound ex)
   {
    _logger.LogError(ex, "Nenhum resultado encontrado.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status404NotFound);
   }
   catch (CreateException ex)
   {
    _logger.LogError(ex, "Um erro ocorreu durante a criação.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status422UnprocessableEntity);
   }
   catch (UpdateException ex)
   {
    _logger.LogError(ex, "Um erro ocorreu durante a atualização.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status422UnprocessableEntity);
   }
   catch (RemoveException ex)
   {
    _logger.LogError(ex, "Um erro ocorreu ao remover.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status422UnprocessableEntity);
   }
   catch (UniqueKeyException ex)
   {
    _logger.LogError(ex, "Chave única já existe.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status422UnprocessableEntity);
   }
   catch (Exception ex)
   {
    _logger.LogError(ex, "Erro interno.");
    await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
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
