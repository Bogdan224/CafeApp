using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Scripts
{
    public interface ISavable
    {
        bool Changes { get; set; }
        void SaveChanges();
    }
}
