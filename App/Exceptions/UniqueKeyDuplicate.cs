namespace BookStore.App.Exceptions
{
 public class UniqueKeyException : Exception
 {
  public int StatusCode { get; private set; } = 423;
  public UniqueKeyException() : base("chave única já existe.") { }

  public UniqueKeyException(string message) : base(message) { }

  public UniqueKeyException(string message, Exception innerException) : base(message, innerException) { }
 }
}
