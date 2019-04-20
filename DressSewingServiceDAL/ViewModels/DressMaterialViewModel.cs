using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class DressMaterialViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int DressId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public string MaterialName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
