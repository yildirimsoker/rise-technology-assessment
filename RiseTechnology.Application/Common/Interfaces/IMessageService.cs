namespace RiseTechnology.Application.Common.Interfaces
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
