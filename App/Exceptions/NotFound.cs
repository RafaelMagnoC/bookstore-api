namespace BookStore.App.Exceptions
{
 public class NotFound : Exception
 {
  public int StatusCode { get; private set; } = 404;
  public NotFound() : base("Nenhum resultado encontrado.") { }
  public NotFound(string message) : base(message) { }
  public NotFound(string message, Exception innerException) : base(message, innerException) { }
 }
}
