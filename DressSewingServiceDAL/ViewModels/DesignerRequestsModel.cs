using System.Runtime.Serialization;

namespace DressSewingServiceDAL.ViewModels
{
    [DataContract]
    public class DesignerRequestsModel
    {
        [DataMember]
        public string DesignerName { get; set; }

        [DataMember]
        public string DateCreate { get; set; }

        [DataMember]
        public string DressName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
