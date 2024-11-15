namespace BookStore.App.Exceptions
{
 public class CreateException : Exception
 {
  public int StatusCode { get; private set; } = 422;
  public CreateException() : base("Um erro ocorreu durante a criação.") { }

  public CreateException(string message) : base(message) { }

  public CreateException(string message, Exception innerException) : base(message, innerException) { }
 }
}
