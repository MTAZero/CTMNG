namespace EXON.Data.Infrastructures
{
    public interface IDbFactory
    {
        RMDbContext Init();
    }
}