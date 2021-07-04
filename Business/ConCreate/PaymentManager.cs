using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class PaymentManager:IPaymentService
    {
        private IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal payment)
        {
            _paymentDal = payment;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetALL();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Payment>>(result);
            }
            return new ErrorDataResult<List<Payment>>(result);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }
    }
}


