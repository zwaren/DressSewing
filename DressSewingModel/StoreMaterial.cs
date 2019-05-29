using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class StoreMaterial
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int MaterialId { get; set; }

        public int Count { get; set; }

        public virtual Store Store { get; set; }

        public virtual Material Material { get; set; }
    }
}
