using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmptyASP.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter Stock")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Please enter Supplier")]
        public virtual Supplier supplier { get; set; }
        public bool IsDelete { get; set; }

    }
}