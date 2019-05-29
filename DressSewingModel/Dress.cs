using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class Dress
    {
        public int Id { get; set; }

        [Required]
        public string DressName { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("DressId")]
        public virtual List<Request> Requests { get; set; }

        [ForeignKey("DressId")]
        public virtual List<DressMaterial> DressMaterials { get; set; }
    }
}
