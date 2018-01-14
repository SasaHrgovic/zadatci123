using System;
using System.Collections.Generic;
using System.Text;

namespace Zadatci123.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool RemindMe { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
    }
}
