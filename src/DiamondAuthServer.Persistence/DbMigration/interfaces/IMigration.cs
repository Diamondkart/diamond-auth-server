namespace UserPlatform.Persistence.DbMigration.interfaces
{
    public interface IMigration
    {
        Task<bool> RunMigration();
    }
}