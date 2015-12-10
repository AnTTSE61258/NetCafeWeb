using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Service
{
    public class PCService : IPCService
    {
        public Boolean AddPC(PC addPC)
        {
            PCRepository repository = new PCRepository();
            if (repository.findByName(addPC.PCName))
            {
                return false;
            }
            else
            {
                try
                {
                    repository.Add(addPC);
                }
                catch (Exception e)
                {
                    e.GetHashCode();
                    return false;
                }
                return true;
            }
        }
        
        public bool checkDeletePC(int pcID)
        {
            OrderRepository orderRepo = new OrderRepository();

            var orderList = orderRepo.getOrderByPCID(pcID);
            if (orderList.Count == 0)
            {
                return true;
            }

            return false;
        }

        public Boolean DeletePC(int ID)
        {
            IRepository<PC> repository = new PCRepository();
            PC deletedPC = repository.findById(ID);

            if (deletedPC == null || !checkDeletePC(ID))
            {
                return false;
            }
            else
            {
                try
                {
                    repository.Delete(deletedPC);
                }
                catch (Exception e)
                {
                    e.GetHashCode();
                }
                return true;
            }


        }

        public Boolean EditPC(PC editPC)
        {
            IRepository<PC> repository = new PCRepository();
            PC pc = repository.findById(editPC.PCID);
            if (pc == null)
            {
                return false;
            }
            try
            {
                repository.Update(pc);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
            return true;
        }

        public PC GetEditPCByID(int PCID)
        {
            IRepository<PC> repository = new PCRepository();
            PC pc = repository.findById(PCID);
            return pc;
        }

        public List<NetCafe> GetManageNet(string username)
        {
            NetCafeRepository NetRepo = new NetCafeRepository();
            UserRepository UserRepo = new UserRepository();
            List<NetCafe> ManageNet = new List<NetCafe>();
            int SuperID = UserRepo.getIDByUsername(username);
            if (SuperID.ToString() == null)
            {
                return null;
            }
            else
            {
                try
                {
                    ManageNet = NetRepo.findBySuID(SuperID);
                }
                catch (Exception e)
                {
                    e.GetHashCode();
                    return null;
                }
                return ManageNet;
            }
        }

        public List<PC> FindByNetID(int NetCafeID)
        {
            PCRepository PCRepo = new PCRepository();
            List<PC> List = new List<PC>();
            if (NetCafeID.ToString() == null)
            {
                return null;
            }
            else
            {
                List = PCRepo.findByNetcafeID(NetCafeID);
            }
            return List;
        }

        public NetCafe GetNetCafeByID(int NetCafeID)
        {
            IRepository<NetCafe> repository = new NetCafeRepository();
            if (NetCafeID.ToString() == null)
            {
                return null;
            }
            else
            {
                NetCafe net = repository.findById(NetCafeID);
                return net;
            }
        }

        public List<NetCafe> GetNetList()
        {
            NetCafeRepository NetRepo = new NetCafeRepository();
            List<NetCafe> NetList = new List<NetCafe>();
            NetList = NetRepo.GetAvailableNetList();
            return NetList;
        }

        public List<PC> GetPCList()
        {
            PCRepository PCRepo = new PCRepository();
            List<PC> PCList = new List<PC>();
            PCList = PCRepo.PCList();
            return PCList;
        }

    }
}