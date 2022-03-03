
using System.ComponentModel.DataAnnotations;

namespace OrigamiBackend
{
    public class Task
    {
        public int Id { get; set; }

        [StringLength((20))] 
        public string Status { get; set; } = string.Empty;
        
        [StringLength((200))]
        public string Comments { get; set; }= string.Empty;
        
        public int TaskTypeId { get; set; }
        
        public TaskType? TaskName { get; set; }
    }
}