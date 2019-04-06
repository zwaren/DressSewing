using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    [DataContract]
    public class StoreMaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int StoreId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
