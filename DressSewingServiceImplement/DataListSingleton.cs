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
        public List<Designer> Designers { get; set; }
        public List<Material> Materials { get; set; }
        public List<Request> Requests { get; set; }
        public List<Dress> Dresses { get; set; }
        public List<DressMaterial> DressMaterials { get; set; }
        private DataListSingleton()
        {
            Designers = new List<Designer>();
			Materials = new List<Material>();
            Requests = new List<Request>();
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
