namespace BookingAndReservationApi.Interfaces;

public interface IRepository <TEntity> where  TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> Get(int Id);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(int Id, TEntity entity);
    bool Delete(int Id);
}