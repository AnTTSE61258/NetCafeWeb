using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeWeb.Service
{
    interface IPCService
    {
        Boolean AddPC(PC addPC);
        Boolean EditPC(PC editPC);
        Boolean DeletePC(int ID);

        List<PC> FindByNetID(int NetCafeID);
        List<NetCafe> GetManageNet(string username);
        List<NetCafe> GetNetList();
        List<PC> GetPCList();
        PC GetEditPCByID(int PCID);
        NetCafe GetNetCafeByID(int NetCafeID);
    }
}
