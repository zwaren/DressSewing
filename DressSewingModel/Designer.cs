using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class Designer
    {
        public int Id { get; set; }

        [Required]
        public string DesignerFIO { get; set; }

        public string Mail { get; set; }

        [ForeignKey("DesignerId")]
        public virtual List<Request> Requests { get; set; }

        [ForeignKey("DesignerId")]
        public virtual List<MessageInfo> MessageInfos { get; set; }
    }
}