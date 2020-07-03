using Library.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.Validation;

namespace Library.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Start Date"), DataType(DataType.Date)]
        [DateBiggerThanOrEqualToToday]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        [Display(Name = "Max Date"), DataType(DataType.Date)]
        [DateBiggerThanOrEqualToToday]
        public DateTime MaxDate { get; set; } = DateTime.Now.Date.AddDays(30);


        [Display(Name = "End Date"), DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
