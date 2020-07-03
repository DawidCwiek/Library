using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
