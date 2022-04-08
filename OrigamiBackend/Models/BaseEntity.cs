using System;

namespace OrigamiBackend
{
    public class BaseEntity
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int CreateBy { get; set; } 
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public int UpdateBy { get; set; }
        public bool isActive { get; set; } = true;
    }
}