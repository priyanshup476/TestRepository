using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InAndOut.Models
{
    public class Item
    {
       [Key]
        public int Id { get; set; }
        [DisplayName("Borrower Name")]
        public string Borrower { get; set; }

        public string Lender { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }
    }
}
