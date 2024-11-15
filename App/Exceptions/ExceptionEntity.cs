namespace BookStore.App.Exceptions
{
 public class ExceptionEntity(string message, int statusCode)
 {
  public string Message { get; set; } = message;

  public int StatusCode { get; set; } = statusCode;
 }
}
