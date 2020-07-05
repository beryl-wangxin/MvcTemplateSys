using MyMvc.IDAL;
using MyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
//数据访问层
namespace MyMvc.DAL
{
    public class BaseService<T> : IBaseService<T> where T:BaseEntity,new()
    {
        private readonly MyContext _db;
        public BaseService(MyContext db)
        {
            _db = db;
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task CreateAsync(T model, bool saved = true)
        {
            
            try
            {
                _db.Set<T>().Add(model);
                if (saved) await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }
        
        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Modified;
            if (saved) await _db.SaveChangesAsync(); 
        }

        public async Task RemoveAsync(Guid id, bool saved = true)
        {
            T t = new T() { Id = id };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsEffective = false;
            if (saved) await _db.SaveChangesAsync();

        }
        public async Task RemoveAsync(T model, bool saved = true)
        {
            await RemoveAsync(model.Id, saved);

        }

        public async Task Save(bool isvalid = true)
        {
            if (isvalid)
            {
                _db.Configuration.ValidateOnSaveEnabled = false;
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
            await _db.SaveChangesAsync();
        }
        public T GetOneById(Guid id)
        {
            return GetAll().FirstOrDefault(m=>m.Id==id);
        }
        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsNoTracking().Where(m => !m.IsEffective);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expr)
        {
            return GetAll().Where(expr);
        }
       
        public IQueryable<T> GetAllOreder(bool asc = true)
        {
            var list = GetAll();
            if (asc)
                return list.OrderBy(m => m.CreateTime);
            else
                return list.OrderByDescending(m => m.CreateTime);
        }
        public IQueryable<T> GetAllOreder(Expression<Func<T, bool>> expr, bool asc = true)
        {
            var list = GetAll(expr);
            if (asc)
                return list.OrderBy(m => m.CreateTime);
            else
                return list.OrderByDescending(m => m.CreateTime);
        }
        public IQueryable<T> GetAllByPage(int pageSize = 10, int pageIndex = 0)
        {
            return GetAll().Skip(pageSize * pageIndex).Take(pageSize);
        }
        public IQueryable<T> GetAllByPage(Expression<Func<T, bool>> expr, int pageSize = 10, int pageIndex = 0)
        {
            return GetAll(expr).Skip(pageSize * pageIndex).Take(pageSize);
        }
        public IQueryable<T> GetAllPageOrder(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            var list = GetAll();
            if (asc)
                return list.OrderBy(m => m.CreateTime).Skip(pageSize * pageIndex).Take(pageSize);
            else
                return list.OrderByDescending(m => m.CreateTime).Skip(pageSize * pageIndex).Take(pageSize);
        }
        public IQueryable<T> GetAllPageOrder(Expression<Func<T, bool>> expr, int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            var list = GetAll(expr);
            if (asc)
                return list.OrderBy(m => m.CreateTime).Skip(pageSize * pageIndex).Take(pageSize);
            else
                return list.OrderByDescending(m => m.CreateTime).Skip(pageSize * pageIndex).Take(pageSize);
        }
       

        

        

        
    }
}
