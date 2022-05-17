namespace BinocsTest.Core.Repository.Repositories.Configuration.Base
{
    public interface IRepoConfiguration<T>
    {
        public string ConnectionString
        {
            get;
        }
    }
}
