using Microsoft.EntityFrameworkCore;
using MOM.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private MOM_Context _db;
        private static DbSet<TEntity> _dbSet;

        public GenericRepository(MOM_Context context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();

        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }


    }
}
