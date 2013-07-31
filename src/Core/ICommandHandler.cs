
namespace Nova.Core
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
