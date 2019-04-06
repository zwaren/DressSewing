using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class StoreViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название склада")]
		public string StoreName { get; set; }

        [DataMember]
        public List<StoreMaterialViewModel> StoreMaterials { get; set; }
    }
}
