using System;
using System.Collections.Generic;

namespace TaskListWebApp.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsCompleted { get; set; }
        public string UserId { get; set; }
    }
}
