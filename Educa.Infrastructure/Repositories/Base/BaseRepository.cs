using Educa.Domain.Entities.Base;
using Educa.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.Repositories.Base
{

    public class BaseRepository<TEntidade, TId> : IBaseRepository<TEntidade, TId>
          where TEntidade : EntidadeBase
          where TId : struct
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public TEntidade Add(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
            _context.SaveChanges(); return entidade;
        }
        public IEnumerable<TEntidade> AddList(IEnumerable<TEntidade> entidades)
        {
            _context.Set<TEntidade>().AddRange(entidades);
            _context.SaveChanges();
            return entidades;
        }
        public void Delete(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
            _context.SaveChanges();
        }
        public TEntidade Update(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
            return entidade;
        }
        public bool Exists(Func<TEntidade, bool> where) => _context.Set<TEntidade>().Any(where);
        public IQueryable<TEntidade> ListWhere(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties) => List(includeProperties).Where(where);
        public IQueryable<TEntidade> ListWhereAndSortedBy<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties) =>
         ascendente ? ListWhere(where, includeProperties).OrderBy(ordem) : ListWhere(where, includeProperties).OrderByDescending(ordem);
        public IQueryable<TEntidade> ListSortedBy<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
            => ascendente ? List(includeProperties).OrderBy(ordem) : List(includeProperties).OrderByDescending(ordem);
        public TEntidade GetBy(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties) => List(includeProperties).FirstOrDefault(where);
        public TEntidade GetById(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any()) return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            return _context.Set<TEntidade>().Find(id);
        }
        public IQueryable<TEntidade> List(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();
            if (includeProperties.Any()) return Include(_context.Set<TEntidade>(), includeProperties);
            return query;
        }
        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties) query = query.Include(property);
            return query;
        }
        public void Dispose() => _context.Dispose();
    }
}
