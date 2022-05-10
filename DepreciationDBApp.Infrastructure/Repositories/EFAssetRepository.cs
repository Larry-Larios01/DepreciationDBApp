using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDbContext depreciationDbContext;

        public EFAssetRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Asset t)
        {
            depreciationDbContext.Assets.Add(t);
            depreciationDbContext.SaveChanges();
        }

        public bool Delete(Asset t)
        {
            if (t == null)
            {
                return false;
            }
            else
            {
                depreciationDbContext.Assets.Remove(t);
                depreciationDbContext.SaveChanges();
                return true;
            }
            
        }

        public Asset FindByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Asset FindById(int id)
        {
            var ids = depreciationDbContext.Assets.FirstOrDefault(p => p.Id == id);
            return ids;
        }

        public List<Asset> FindByName(string name)
        {
            var names = depreciationDbContext.Assets.Where(p => p.Name == name);
            return names.ToList();
        }

        public List<Asset> GetAll()
        {
            return depreciationDbContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            depreciationDbContext.Assets.Update(t);
            depreciationDbContext.SaveChanges();
        }
    }
}
