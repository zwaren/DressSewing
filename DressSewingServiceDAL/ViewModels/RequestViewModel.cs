using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class RequestViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int DesignerId { get; set; }

        [DataMember]
        public string DesignerFIO { get; set; }

        [DataMember]
        public int DressId { get; set; }

        [DataMember]
        public string DressName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string DateCreate { get; set; }

        [DataMember]
        public string DateImplement { get; set; }
    }
}
