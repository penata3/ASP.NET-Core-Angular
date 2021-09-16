namespace MyApplication.Server.Features.Cats
{
    using System.Threading.Tasks;

    public interface ICatsService
    {
        Task<int> CraeteCat(CreateCatModel model, string userId);
    }
}
