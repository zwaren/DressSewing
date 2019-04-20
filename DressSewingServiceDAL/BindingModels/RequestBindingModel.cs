using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    [DataContract]
    public class RequestBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int DesignerId { get; set; }

        [DataMember]
        public int DressId { get; set; }

        [DataMember]
        public int? TailorId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}
