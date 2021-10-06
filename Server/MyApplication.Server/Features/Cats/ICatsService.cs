namespace MyApplication.Server.Features.Cats
{
    using MyApplication.Server.Features.Cats.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatsService
    {
        Task<int> CraeteCat(CreateRequestCatModel model, string userId);

        Task<IEnumerable<CatListingServiceModel>> CatsByUserAsync(string userId);

        Task<IEnumerable<CatListingServiceModel>> GetAllCatsAsync();

        Task<CatDetailsServiceModel> ById(int id);

        Task<bool> Update(string userId, int catId, string desctiption);

        Task<bool> Delete(string userId, int catId);


    }
}
