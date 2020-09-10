using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace jogo_da_velha.infraestrutura.Repositories
{
  public class RepositoryBase<Entity> : IDisposable, IRepositoryBase<Entity> where Entity : class
  {
    internal ApiContext Context;
    internal DbSet<Entity> DbSet;

    public RepositoryBase(ApiContext context)
    {
      this.Context = context;
      this.DbSet = context.Set<Entity>();
    }

    public void Save()
    {
      this.Context.SaveChanges();
    }

    public void Add(Entity entity, bool isSave = false)
    {
      DbSet.Add(entity);
      if (isSave)
        this.Save();
    }

    public void Edit(Entity entity, bool isSave = false)
    {
      var entry = Context.Entry(entity);
      var pkey = GetPrimaryKeyInfo<Entity>().GetValue(entity);

      if (entry.State == EntityState.Detached)
      {
        var set = Context.Set<Entity>();
        Entity attachedEntity = set.Find(pkey);
        if (attachedEntity != null)
        {
          var attachedEntry = Context.Entry(attachedEntity);
          attachedEntry.CurrentValues.SetValues(entity);
        }
        else
        {
          entry.State = EntityState.Modified;
        }
      }

      if (isSave)
        this.Save();
    }

    public void Delete(Entity entity)
    {
      if (Context.Entry(entity).State == EntityState.Detached)
        DbSet.Attach(entity);

      DbSet.Remove(entity);
      Save();
    }

    public void DeleteAll(Expression<Func<Entity, bool>> filter = null)
    {
      IQueryable<Entity> query = DbSet;
      List<Entity> listDelete = query.Where(filter).ToList();

      foreach (var item in listDelete)
      {
        DbSet.Remove(item);
      }

    }

    public void AddAll(List<Entity> entity, bool isSave = false)
    {
      foreach (var item in entity)
      {
        DbSet.Add(item);
      }

      if (isSave)
        this.Save();
    }

    public virtual List<Entity> Get(Expression<Func<Entity, bool>> filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null)
    {
      IQueryable<Entity> query = DbSet;

      if (filter != null)
        query = query.Where(filter);

      if (orderBy != null)
        return orderBy(query).ToList();
      else
        return query.ToList();
    }

    public void Dispose()
    {
      DbSet = null;
      Context.Dispose();
      GC.SuppressFinalize(this);
    }

    private PropertyInfo GetPrimaryKeyInfo<T>()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();
      foreach (PropertyInfo pI in properties)
      {
        Object[] attributes = pI.GetCustomAttributes(true);
        foreach (object attribute in attributes)
        {
          if (attribute is KeyAttribute)
            return pI;
        }
      }
      return null;
    }
  }
}

