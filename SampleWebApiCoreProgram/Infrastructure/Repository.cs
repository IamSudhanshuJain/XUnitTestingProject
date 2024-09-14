using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entity;
        private readonly OrganizationContext _context;
        public Repository(OrganizationContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public T Get(object id)
        {
            return _entity.Find(id);
        }

        public void Save(T data)
        {
            _context.Add(data);
            _context.SaveChanges();
        }
        public void Update(T data)
        {
            _context.Attach(data);
            //_context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T data)
        {
            _context.Remove(data);
            _context.SaveChanges();
        }
    }

    public interface IRepository<T> where T : class
    {
        public T Get(object Id);
        public void Save(T Data);
        public void Update(T Data);
        public void Delete(T data);

    }
}
