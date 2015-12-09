using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeWeb.Service
{
    public interface IOrderInterface
    {

        OrderStatus isCanOrder(int pcid, DateTime startDate, int duration);
        List<NetCafe> getAllNetCafe();
    }
}
