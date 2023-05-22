using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Core.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Tittle { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Author { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Genre { get; set; }

        public int Publication { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
