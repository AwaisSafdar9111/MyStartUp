using System.ComponentModel.DataAnnotations;

namespace PracticeProgram.Models
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public long? CreatedById { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public long? UpdatedById { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}
