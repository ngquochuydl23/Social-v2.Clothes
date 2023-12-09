namespace Social_v2.Clothes.Api.Infrastructure.Entities
{
    public abstract class Entity : IDeleteEntity, IHasCreationTime, ILastUpdatedTime
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateAt { get; set; }
        public DateTime LastUpdate { get; set; }
    }


    public abstract class Entity<TKey> : Entity
    {
        public TKey Id { get; set; }
    }
}
