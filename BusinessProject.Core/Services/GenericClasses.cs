using BusinessProject.DataModelLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessProject.Core.Services
{
   public class GenericClasses<Tentity> where Tentity : class
    {
        private readonly ApplicationContext _context;
        private DbSet<Tentity> _table;

        public GenericClasses(ApplicationContext context)
        {
            _context = context;
            _table = context.Set<Tentity>();
        }

        public virtual void Create(Tentity entity)
        {
            _table.Add(entity);
        }

        public virtual void Update(Tentity entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual Tentity GetById(object id)
        {
          return _table.Find(id);
        }

        public virtual void Delete(Tentity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);
        }

        public virtual void DeleteById(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public virtual void DeleteByRange(Expression<Func<Tentity, bool>> myexpression = null)
        {
            IQueryable<Tentity> query = _table;
            if (myexpression != null)
            {
                query = query.Where(myexpression);
            }
            _table.RemoveRange(query);
        }

        public virtual IEnumerable<Tentity> GetEntities(Expression<Func<Tentity, bool>> myexpression = null,
                                          Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> myOrderby = null,
                                          string joinString = "")
        {
            IQueryable<Tentity> query = _table;
            if (myexpression != null)
            {
                query = query.Where(myexpression);
            }
            if (myOrderby != null)
            {
                query = myOrderby(query);
            }
            if (joinString != "")
            {
                foreach (string item in joinString.Split(','))
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }
    }
}
