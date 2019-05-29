using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class DressMaterial
    {
        public int Id { get; set; }

        public int DressId { get; set; }

        public int MaterialId { get; set; }

        public string MaterialName { get; set; }

        public int Count { get; set; }

        public virtual Material Material { get; set; }

        public virtual Dress Dress { get; set; }
    }
}
