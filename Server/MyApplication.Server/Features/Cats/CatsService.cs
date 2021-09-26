using Microsoft.EntityFrameworkCore;
using MyApplication.Server.Data;
using MyApplication.Server.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Server.Features.Cats
{
    public class CatsService : ICatsService
    {
        private readonly MyApplicationDbContext db;

        public CatsService(MyApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<MyCatsResponseModel>> CatsByUsert(string userId)
        {
            return  await this.db.Cats.Where(c => c.UserId == userId)
                 .Select(c => new MyCatsResponseModel
                 {
                     Id = c.Id,
                     ImageUrl = c.ImageUrl,
                     Description = c.Description
                 })
                 .ToListAsync();
        }

        public async Task<int> CraeteCat(CreateCatModel model, string userId)
        {
            var cat = new Cat()
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            await this.db.Cats.AddAsync(cat);
            await this.db.SaveChangesAsync();
            return cat.Id;
        }
    }
}
