namespace BookStore.App.Exceptions
{
 public class RemoveException : Exception
 {
  public int StatusCode { get; private set; } = 422;
  public RemoveException() : base("Um erro ocorreu ao remover.") { }

  public RemoveException(string message) : base(message) { }

  public RemoveException(string message, Exception innerException) : base(message, innerException) { }
 }
}
