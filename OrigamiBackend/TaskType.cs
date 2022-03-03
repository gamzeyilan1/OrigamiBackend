using System.ComponentModel.DataAnnotations;

namespace OrigamiBackend
{
    public class TaskType
    {
        public int Id { get; set; }
        
        [StringLength((20))]
        public string TaskName { get; set; }
        
    }
}