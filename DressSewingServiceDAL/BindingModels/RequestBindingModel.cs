using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }
        public int DesignerId { get; set; }
        public int DressId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
