using System;

namespace BookStore.App.Exceptions
{
 public class BadRequest : Exception
 {
  public int StatusCode { get; private set; } = 400;
  public BadRequest() : base("A requisição contém erros.") { }

  public BadRequest(string message) : base(message) { }

  public BadRequest(string message, Exception innerException) : base(message, innerException) { }
 }
}
