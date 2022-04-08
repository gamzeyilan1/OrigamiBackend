
using System.ComponentModel.DataAnnotations;

namespace OrigamiBackend
{
    public class Task: BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public bool IsUrgent { get; set; }
        public User User { get; set; }
    }
}