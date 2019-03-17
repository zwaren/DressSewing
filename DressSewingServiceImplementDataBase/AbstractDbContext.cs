using DressSewingModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceImplementDataBase
{
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext() : base("AbstractDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Designer> Designers { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Dress> Dresses { get; set; }
        public virtual DbSet<DressMaterial> DressMaterials { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreMaterial> StoreMaterials { get; set; }
    }
}
