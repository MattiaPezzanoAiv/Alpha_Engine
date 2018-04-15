using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaEngine
{
    public abstract class BaseObject
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
