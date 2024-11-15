namespace BookStore.App.Exceptions
{
    public class InvalidCredential : Exception
    {
        public int StatusCode { get; private set; } = 401;
        public InvalidCredential() : base("Credenciais inválidas.") { }

        public InvalidCredential(string message) : base(message) { }

        public InvalidCredential(string message, Exception innerException) : base(message, innerException) { }
    }
}
