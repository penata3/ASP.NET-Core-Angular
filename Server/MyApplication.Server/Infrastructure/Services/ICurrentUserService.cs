namespace MyApplication.Server.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetId();

        string GetUsername();

    }
}
