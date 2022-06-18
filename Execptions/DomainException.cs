namespace Chess.Execptions
{
    public class DomainException : Exception
    {
        public DomainException(string message): base(message)
        {
        }
    }
}