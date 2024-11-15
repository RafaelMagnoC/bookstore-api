namespace BookStore.App.Exceptions
{
 public class AvailableQuantity : Exception
 {
  public int StatusCode { get; private set; } = 423;
  public AvailableQuantity() : base("Produto sem saldo disponível.") { }

  public AvailableQuantity(string message) : base(message) { }

  public AvailableQuantity(string message, Exception innerException) : base(message, innerException) { }
 }
}
