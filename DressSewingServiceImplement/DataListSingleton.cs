using DressSewingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Material> Materials { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dress> Dresses { get; set; }
        public List<DressMaterial> DressMaterials { get; set; }
        private DataListSingleton()
        {
            Clients = new List<Client>();
			Materials = new List<Material>();
            Orders = new List<Order>();
			Dresses = new List<Dress>();
			DressMaterials = new List<DressMaterial>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
