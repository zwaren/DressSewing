using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    public class DressViewModel
    {
        public int Id { get; set; }
        public string DressName { get; set; }
        public decimal Price { get; set; }
        public List<DressMaterialViewModel> DressMaterials { get; set; }
    }
}
