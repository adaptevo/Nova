using Nova.Core.Domain;

namespace Nova.Core.Services.Context
{
    public interface IUserContext
    {
        User CurrentUser { get; }
    }
}
