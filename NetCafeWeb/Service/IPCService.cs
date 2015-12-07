using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeWeb.Service
{
    interface IPCService
    {
        bool AddPC(PC addPC);
        bool EditPC(PC editPC);
        bool DeletePC(int ID);

        List<PC> FindByNetID(int NetCafeID);
        List<NetCafe> GetManageNet(string username);
        List<NetCafe> GetNetList();
        List<PC> GetPCList();
        PC GetEditPCByID(int PCID);
        NetCafe GetNetCafeByID(int NetCafeID);
    }
}
