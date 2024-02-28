using BookCatalogDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogDomain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [Required]
        [StringLength(100)]
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }

        public Category Category { get; set; }
    }
}
