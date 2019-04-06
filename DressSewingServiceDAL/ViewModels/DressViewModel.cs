using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class DressViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string DressName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<DressMaterialViewModel> DressMaterials { get; set; }
    }
}
