namespace Okala.Cryptocurrency.Domain.Common
{
    public interface IEntity { }
    public abstract class BaseEntity<TKey> : IEntity
    {
        protected BaseEntity()
        {
            CreateDate = DateTime.Now;
        }

        public virtual TKey Id { get; protected set; }
        public virtual DateTime CreateDate { get; private set; }
        public virtual DateTime LastUpdatedDate { get; private set; }

        public void UpdateLastUpdatedDate()
        {
            LastUpdatedDate = DateTime.Now;
        }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }

}