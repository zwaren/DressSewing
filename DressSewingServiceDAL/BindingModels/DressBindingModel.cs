using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    [DataContract]
    public class DressBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string DressName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<DressMaterialBindingModel> DressMaterials { get; set; }
    }
}
