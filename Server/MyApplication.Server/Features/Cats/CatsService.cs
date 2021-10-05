namespace MyApplication.Server.Features.Cats
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Data.Models;
    using Features.Cats.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CatsService : ICatsService
    {
        private readonly MyApplicationDbContext db;

        public CatsService(MyApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CatListingServiceModel>> GetAllCatsAsync()
        {
            return await this.db.Cats.Select(c => new CatListingServiceModel
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Description = c.Description
            })
              .ToListAsync();
        }

        public async Task<IEnumerable<CatListingServiceModel>> CatsByUserAsync(string userId)
        {
            return  await this.db.Cats.Where(c => c.UserId == userId)
                 .Select(c => new CatListingServiceModel
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
                Description = model.Description.Trim(),
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            await this.db.Cats.AddAsync(cat);
            await this.db.SaveChangesAsync();
            return cat.Id;
        }

        public async Task<CatDetailsServiceModel> ById(int id)
       => await this.db.Cats.Where(c => c.Id == id)
            .Select(c => new CatDetailsServiceModel
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Description = c.Description,
                UserId = c.UserId
            })
             .FirstOrDefaultAsync();

        public async Task<bool> Update(string userId, int catId,string description)
        {
            var catToUpdate = await this.db.Cats.Where(c => c.Id == catId && c.UserId == userId)
                 .FirstOrDefaultAsync();

            if (catToUpdate == null) 
            {
                return false;
            }

            catToUpdate.Description = description.Trim();
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(string userId, int catId)
        {
            var catToDelete = await this.db.Cats.Where(c => c.Id == catId && c.UserId == userId).FirstOrDefaultAsync();

            if (catToDelete == null) 
            {
                return false; 
            }

            this.db.Cats.Remove(catToDelete);
            await this.db.SaveChangesAsync();
            return true;
            
        }
    }
}
