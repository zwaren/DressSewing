using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DressSewingServiceDAL.BindingModels
{
    [DataContract]
    public class DesignerBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string DesignerFIO { get; set; }
    }
}
