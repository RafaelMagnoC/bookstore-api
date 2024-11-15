using System;

namespace BookStore.App.Exceptions
{
 public class NotAuthenticated : Exception
 {
  public int StatusCode { get; private set; } = 401;
  public NotAuthenticated() : base("Usuário não autenticado.") { }

  public NotAuthenticated(string message) : base(message) { }

  public NotAuthenticated(string message, Exception innerException) : base(message, innerException) { }
 }

}

