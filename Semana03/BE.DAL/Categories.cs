using BE.DAL.DO.Interfaces;
using BE.DAL.EF;
using BE.DAL.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL
{
    public class Categories : ICRUD<data.Categories>
    {
        private Repository<data.Categories> repo;
        public Categories(NDbContext dbContext)
        {
            repo = new Repository<data.Categories>(dbContext);
        }
        public void Delete(data.Categories t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Categories> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Categories>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<data.Categories> GetOneByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public data.Categories GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public void Insert(data.Categories t)
        {
            repo.Insert(t);
        }

        public void Update(data.Categories t)
        {
            repo.Update(t);
        }
    }
}
