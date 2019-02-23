using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    public class StoreMaterialBindingModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}
