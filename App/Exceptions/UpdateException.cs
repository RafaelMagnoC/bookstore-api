namespace BookStore.App.Exceptions
{
 public class UpdateException : Exception
 {
  public int StatusCode { get; private set; } = 422;
  public UpdateException() : base("Um erro ocorreu durante a atualização.") { }

  public UpdateException(string message) : base(message) { }

  public UpdateException(string message, Exception innerException) : base(message, innerException) { }
 }
}
