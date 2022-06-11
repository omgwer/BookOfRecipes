namespace Infrastructure.Data
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
