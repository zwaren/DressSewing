using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class TailorViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TailorFIO { get; set; }
    }
}
