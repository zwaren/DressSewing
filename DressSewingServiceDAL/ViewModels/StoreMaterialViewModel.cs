using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    public class StoreMaterialViewModel
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int MaterialId { get; set; }

		[DisplayName("Название компонента")]
		public string MaterialName { get; set; }

		[DisplayName("Количество")]
		public int Count { get; set; }
    }
}
