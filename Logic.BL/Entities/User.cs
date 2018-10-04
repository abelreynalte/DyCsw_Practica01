using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic.BL.Entities
{
    public class User: Entity
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name user is too long")]
        public virtual string Name { get; set; }

        [Required]
        [RegularExpression(@"^(.+)@(.+)$", ErrorMessage = "Email is invalid")]
        public virtual string Email { get; set; }
    }
}
