using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTvary
{
    public interface I2dObject        //zde pridano public!!!
    {      
        List<int> Strany { get; set; }

        double Plocha { get; }

        double Obvod { get; }
    }
}
