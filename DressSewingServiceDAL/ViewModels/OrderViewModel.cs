using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientFIO { get; set; }
        public int DressId { get; set; }
        public string DressName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string DateImplement { get; set; }
    }
}
