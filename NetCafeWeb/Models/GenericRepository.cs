using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IEntity
{
    public string Id;
}
public interface IRepository<T> where T :class
{
    IEnumerable<T> List { get; }
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    T findById(int Id);
}
