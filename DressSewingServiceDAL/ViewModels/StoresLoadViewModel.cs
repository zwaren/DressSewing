using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.ViewModels
{
    public class StoresLoadViewModel
    {
        public string StoreName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Materials { get; set; }
    }
}
