using AppTest1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppTest1.DataAccess
{
    public class SqlRepository : DbContext, IRepository<Men>, IRepository<Women>, IRepository<MormonsPartner>
    {
        public SqlRepository(DbContextOptions options) : base(options)
        { }

        public DbSet<Men> Men { get; set; }
        public DbSet<Women> Women { get; set; }
        public DbSet<MormonsPartner> Partners { get; set; }

        List<Men> IRepository<Men>.GetAll()
        {
            return Men
                .Include(m => m.Partners)
                    //.ThenInclude(p => p.Where(w => w.Woman))
                .ToList();
        }

        Men IRepository<Men>.Get(int id)
        {
            return Men.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<Men>.Insert(Men model)
        {
            Men.Add(model);
            return SaveChanges();
        }

        void IRepository<Men>.Update(Men model)
        {
            Men.Update(model);
            SaveChanges();
        }

        void IRepository<Men>.Delete(int id)
        {
            var model = Men.FirstOrDefault(x => x.Id == id);
            Men.Remove(model);
            SaveChanges();
        }

        List<Women> IRepository<Women>.GetAll()
        {
            return Women.ToList();
        }

        Women IRepository<Women>.Get(int id)
        {
            return Women.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<Women>.Insert(Women model)
        {
            Women.Add(model);
            return SaveChanges();
        }

        void IRepository<Women>.Update(Women model)
        {
            Women.Update(model);
            SaveChanges();
        }

        void IRepository<Women>.Delete(int id)
        {
            var model = Women.FirstOrDefault(x => x.Id == id);
            Women.Remove(model);
            SaveChanges();
        }

        List<MormonsPartner> IRepository<MormonsPartner>.GetAll()
        {
            return Partners
                .Include(x => x.Man)
                .Include(x => x.Woman)
                .ToList();
        }

        MormonsPartner IRepository<MormonsPartner>.Get(int id)
        {
            return Partners.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<MormonsPartner>.Insert(MormonsPartner model)
        {
            Partners.Add(model);
            return SaveChanges();
        }

        void IRepository<MormonsPartner>.Update(MormonsPartner model)
        {
            Partners.Update(model);
            SaveChanges();
        }

        void IRepository<MormonsPartner>.Delete(int id)
        {
            var model = Partners.FirstOrDefault(x => x.Id == id);
            Partners.Remove(model);
            SaveChanges();
        }
    }
}
