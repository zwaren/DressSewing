using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class Tailor
    {
        public int Id { get; set; }

        [Required]
        public string TailorFIO { get; set; }

        [ForeignKey("TailorId")]
        public virtual List<Request> Requests { get; set; }
    }
}
