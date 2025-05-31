namespace LojaApi.Domain
{
    public interface IServCore<T> where T : Identificador
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
