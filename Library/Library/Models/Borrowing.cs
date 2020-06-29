using Library.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Borrowing
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Max Date"), DataType(DataType.Date)]
        public DateTime MaxDate { get; set; }

        [Display(Name = "End Date"), DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
