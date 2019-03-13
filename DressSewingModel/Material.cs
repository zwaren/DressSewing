using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string MaterialName { get; set; }
        
        [ForeignKey("MaterialId")]
        public virtual List<StoreMaterial> StoreMaterial { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<DressMaterial> DressMaterial { get; set; }
    }
}
