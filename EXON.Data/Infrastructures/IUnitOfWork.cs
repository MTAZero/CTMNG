namespace EXON.Data.Infrastructures
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}