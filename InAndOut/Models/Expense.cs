using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Expense")]
       
        public string ExpenseName { get; set; }

        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Amount must be greater than zero")]
        public int Amount { get; set; }

      
    }
}
