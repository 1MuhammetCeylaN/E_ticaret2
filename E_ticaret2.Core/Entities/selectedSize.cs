using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticaret2.Core.Entities
{
    public class selectedSize
    {
        public int selectedSizeId { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
    }
}
