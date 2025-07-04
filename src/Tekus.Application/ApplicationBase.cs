using Tekus.Domain;

namespace Tekus.Application
{
    public class ApplicationBase<T>
    {
        private readonly IDomainBase<T> _domainBase;
        public ApplicationBase(IDomainBase<T> domainBase)
        {
            ArgumentNullException.ThrowIfNull(domainBase, nameof(domainBase));
            _domainBase = domainBase;
        }

        public List<T> GetAll()
        {
            return _domainBase.GetAll();
        }

        public T? GetByID(int id)
        {
            return _domainBase.GetByID(id);
        }

        public T Insert(T entity)
        { 
            return _domainBase.Insert(entity);
        }

        public T Update(T entity)
        {
            return _domainBase.Update(entity);
        }

        public void Delete(int id)
        {
            _domainBase.Delete(id);
        }
    }
}
