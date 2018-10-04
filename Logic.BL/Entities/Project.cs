using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic.BL.Entities
{
    public class Project: Entity
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Name project is too long")]
        public virtual string Name { get; set; }        
    }
}
