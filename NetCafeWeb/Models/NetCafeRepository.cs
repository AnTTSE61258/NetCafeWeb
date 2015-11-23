using NetCafeWeb;
using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
public class NetCafeRepository : IRepository<NetCafe>
{
    NetCafeEntities1 _netCafeContext;
    public NetCafeRepository()
    {
        _netCafeContext = new NetCafeEntities1();
    }
    public IEnumerable<NetCafe> List
    {
        get
        {
            return _netCafeContext.NetCafes;
        }
    }

    public void Add(NetCafe entity)
    {
        _netCafeContext.NetCafes.Add(entity);
        _netCafeContext.SaveChanges();
    }

    public void Delete(NetCafe entity)
    {
        _netCafeContext.NetCafes.Remove(entity);
        _netCafeContext.SaveChanges();
    }

    public NetCafe findById(int Id)
    {
        var query = (from r in _netCafeContext.NetCafes where r.NetCafeID == Id select r).FirstOrDefault();
        return query;
    }

    public void Update(NetCafe entity)
    {
        _netCafeContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        _netCafeContext.SaveChanges();
    }
    
}