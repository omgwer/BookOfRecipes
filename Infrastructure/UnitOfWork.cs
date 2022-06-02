using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeDbContext _dbContext;


        public UnitOfWork( RecipeDbContext todoDbContext )
        {
            _dbContext = todoDbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
