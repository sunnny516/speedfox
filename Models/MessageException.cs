namespace MuXunProxy.Models;

public class MessageException : Exception
{
    public MessageException()
    {
    }

    public MessageException(string message) : base(message)
    {
    }
}