namespace EXON.Data.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private RMDbContext dbContext;

        public RMDbContext Init()
        {
            return dbContext ?? (dbContext = new RMDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}