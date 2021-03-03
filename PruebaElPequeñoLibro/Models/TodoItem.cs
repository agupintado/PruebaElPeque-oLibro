using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaElPequeñoLibro.Models
{
    public class TodoItem
    {

        public string UserId { get; set; }
        public Guid Id { get; set; }
        public bool IsDone { get; set; }

        [Required]
        public String Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }

    }
}
