using System.ComponentModel.DataAnnotations;

namespace OrigamiBackend
{
    public class TaskCategory: BaseEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
    }
}