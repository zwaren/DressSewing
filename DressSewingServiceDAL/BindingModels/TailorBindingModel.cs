using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    [DataContract]
    public class TailorBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TailorFIO { get; set; }
    }
}
