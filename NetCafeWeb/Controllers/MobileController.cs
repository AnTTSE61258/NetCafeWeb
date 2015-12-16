using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCafeWeb.Models;
using NetCafeWeb.Service;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace NetCafeWeb.Controllers
{
    public class MobileController : Controller
    {
        NetCafeEntities1 _userContext;

        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }
        
        public string checkAccount(string username, string password)
        {
            MobileService service = new MobileService();
            return service.checkUser(username, password);
        }
        public string getPCs(string username, string password, int netCafeId)
        {
            MobileService service = new MobileService();
            //JavaScriptSerializer json = new JavaScriptSerializer();

            //string output = json.Serialize(service.getPcList(username, password, netCafeId));
            //Newtonsoft.Json.Linq.JObject o = new Newtonsoft.Json.Linq.JObject();
            //string json = JsonConvert.SerializeObject(service.getPcList(username, password, netCafeId));
            List<PCJson> pcs = service.getPcList(username, password, netCafeId);
            //  string json = JsonConvert.SerializeObject(pcs,Formatting.Indented);

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(pcs);
            return json;
        }
        public string getNetCafes(string username, string password)
        {
            NetCafeService netService = new NetCafeService();
            //JavaScriptSerializer json = new JavaScriptSerializer();

            //string output = json.Serialize(service.getPcList(username, password, netCafeId));
            //Newtonsoft.Json.Linq.JObject o = new Newtonsoft.Json.Linq.JObject();
            //string json = JsonConvert.SerializeObject(service.getPcList(username, password, netCafeId));
            List<NetCafe> netcafes = netService.getAllNetCafe();
            List<NetCafeJSon> netjsons = new List<NetCafeJSon>();
            //  string json = JsonConvert.SerializeObject(pcs,Formatting.Indented);
            foreach (NetCafe net in netcafes)
            {
                NetCafeJSon netj = new NetCafeJSon();
                netj.id = net.NetCafeID;
                netj.name = net.NetCafeName;
                netjsons.Add(netj);
            }


            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(netjsons);
            return json;
        }
    }
}