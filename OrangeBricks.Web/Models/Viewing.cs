using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public string BuyerId { get; set; }

        [Required]
        public DateTime When { get; set; }

        [Required]
        public ViewingStatus Status { get; set; }

        public virtual Property Property { get; set; }
    }
}