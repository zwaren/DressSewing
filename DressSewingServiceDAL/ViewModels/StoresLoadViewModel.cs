using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class StoresLoadViewModel
    {
        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public IEnumerable<Tuple<string, int>> Materials { get; set; }
    }
}
