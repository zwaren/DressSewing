using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public List<StoreMaterialViewModel> StoreMaterials { get; set; }
    }
}
