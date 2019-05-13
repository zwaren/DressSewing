using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressSewingServiceDAL.Attributies
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomMethodAttribute : Attribute
    {
        public CustomMethodAttribute(string descript)
        {
            Description = string.Format("Описание метода: ", descript);
        }
        public string Description { get; private set; }
    }
}
