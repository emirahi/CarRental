using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, CarProjectContext>, IPaymentDal
    {
    }
}
