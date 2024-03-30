using System.Text.RegularExpressions;

namespace Clothes.Commons.Seedworks
{
    public abstract class Entity : IDeleteEntity, IHasCreationTime, ILastUpdatedTime
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateAt { get; set; }
        public DateTime LastUpdate { get; set; }

        public Entity()
        {
            CreateAt = DateTime.Now;
        }

        protected string GenerateHandleByTitle(string title)
        {
            // Convert title to lowercase
            title = title.ToLower();

            // Remove special characters, keep only alphanumeric characters and spaces
            title = Regex.Replace(title, @"[^a-z0-9\s]", "");

            // Replace spaces with dashes
            string handle = title.Replace(' ', '-');

            return handle;
        }
    }


    public abstract class Entity<TKey> : Entity
    {
        public TKey Id { get; set; }
    }
}
