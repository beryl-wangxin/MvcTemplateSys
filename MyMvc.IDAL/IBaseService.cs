using MyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//数据访问层接口
namespace MyMvc.IDAL
{
    public interface IBaseService<T>:IDisposable where T:BaseEntity
    {
        Task CreateAsync(T model, bool saved = true);
        Task EditAsync(T model, bool saved = true);
        Task RemoveAsync(T model, bool saved = true);
        Task RemoveAsync(Guid id, bool saved = true);
        Task Save(bool isvalid = true);
        T GetOneById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> expr);
        IQueryable<T> GetAllByPage(int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllByPage(Expression<Func<T,bool>> expr,int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllOreder(bool asc = true);
        IQueryable<T> GetAllOreder(Expression<Func<T,bool>> expr,bool asc = true);
        IQueryable<T> GetAllPageOrder(int pageSize = 10, int pageIndex = 0, bool asc = true);
        IQueryable<T> GetAllPageOrder(Expression<Func<T,bool>> expr,int pageSize = 10, int pageIndex = 0, bool asc = true);
    }
}
