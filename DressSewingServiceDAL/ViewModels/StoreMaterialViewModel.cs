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
    public class StoreMaterialViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int StoreId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        [DisplayName("Название компонента")]
		public string MaterialName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
		public int Count { get; set; }
    }
}
