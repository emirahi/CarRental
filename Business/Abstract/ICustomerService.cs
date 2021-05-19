using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer entity);
        IResult update(Customer entity);
        IResult delete(Customer entity);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(Customer entity);
    }
}
