namespace OnSales.Repository;
public interface IRepository<T, O> where T : class
{
    List<O> GetAll();
    O GetById(Guid id);
    Task Criar(Guid userId, T dto);
    Task Update(Guid id, Guid userId, T dto);
    Task<bool> Delete(Guid id);
}
