using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    public class DressBindingModel
    {
        public int Id { get; set; }
        public string DressName { get; set; }
        public decimal Price { get; set; }
        public List<DressMaterialBindingModel> DressMaterials { get; set; }
    }
}
