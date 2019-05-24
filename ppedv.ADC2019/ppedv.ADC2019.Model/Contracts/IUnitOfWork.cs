namespace ppedv.ADC2019.Model.Contracts
{
    public interface IUnitOfWork
    {
        IAutoRepository AutoRepository { get; }
        IRepository<T> GetRepo<T>() where T : Entity;
        void SaveAll();
    }
}
