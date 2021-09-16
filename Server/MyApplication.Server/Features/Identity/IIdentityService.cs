namespace MyApplication.Server.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string username, string password);
    }
}
