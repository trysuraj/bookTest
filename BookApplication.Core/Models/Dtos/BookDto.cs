using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Core.Models.Dtos
{
    public class BookDto
    {
        
        public string Tittle { get; set; }

        public string Author { get; set; }
        
        public string Genre { get; set; }

        public int Publication { get; set; }
    }
}
