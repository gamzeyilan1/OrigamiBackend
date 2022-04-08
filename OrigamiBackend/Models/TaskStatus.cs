using System;
using System.ComponentModel.DataAnnotations;

namespace OrigamiBackend
{
    public class TaskStatus: BaseEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
    }
}