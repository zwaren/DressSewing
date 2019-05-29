using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingModel
{
    public class Request
    {
        public int Id { get; set; }

        public int DesignerId { get; set; }

        public int DressId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public RequestStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Designer Designer { get; set; }

        public virtual Dress Dress { get; set; }
    }
}
