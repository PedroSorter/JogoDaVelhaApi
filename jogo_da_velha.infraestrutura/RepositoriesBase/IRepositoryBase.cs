using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace jogo_da_velha.infraestrutura.Repositories
{
  public interface IRepositoryBase<Entity> where Entity : class
  {
    void Add(Entity entity, bool isSave);
    void AddAll(List<Entity> entity, bool isSave);
    void Edit(Entity entity, bool isSave);
    void Delete(Entity entity);
    void DeleteAll(Expression<Func<Entity, bool>> filter = null);
    List<Entity> Get(Expression<Func<Entity, bool>> filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null);
    void Save();
  }
}
