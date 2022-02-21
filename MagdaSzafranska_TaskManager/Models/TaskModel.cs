using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MagdaSzafranska_TaskManager.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
