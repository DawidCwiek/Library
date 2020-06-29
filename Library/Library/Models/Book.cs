using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Author { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string PublishingHouse { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
