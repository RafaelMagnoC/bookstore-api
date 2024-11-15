using System;

namespace BookStore.App.Exceptions
{
 public class NotAuthorized : Exception
 {
  public int StatusCode { get; private set; } = 403;
  public NotAuthorized() : base("Usuário não autorizado.") { }

  public NotAuthorized(string message) : base(message) { }

  public NotAuthorized(string message, Exception innerException) : base(message, innerException) { }
 }
}


