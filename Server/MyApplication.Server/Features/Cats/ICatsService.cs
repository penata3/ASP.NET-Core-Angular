namespace MyApplication.Server.Features.Cats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatsService
    {
        Task<int> CraeteCat(CreateCatModel model, string userId);

        Task<IEnumerable<CatResponseModel>> CatsByUser(string userId);

        Task<IEnumerable<CatResponseModel>> GetAllCatsAsync();
    }
}
