using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public interface IBaseService<T> where T : class,IEntity,new()
    {
        // Bütün Servicelerimde temel olan methodları temel bir service te topladım.
        IResult Add(T entity);
        IResult update(T entity);
        IResult delete(T entity);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(T entity);
    }
}
