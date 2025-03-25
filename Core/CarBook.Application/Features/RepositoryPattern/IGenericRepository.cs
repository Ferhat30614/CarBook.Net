using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<Comment> GetAll();
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetCommentsByBlogId(int id);
        int GetCountCommentByBlog(int id);
    }
}
