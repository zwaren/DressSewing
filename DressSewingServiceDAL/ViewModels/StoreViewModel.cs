using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }

		[DisplayName("Название склада")]
		public string StoreName { get; set; }

        public List<StoreMaterialViewModel> StoreMaterials { get; set; }
    }
}
