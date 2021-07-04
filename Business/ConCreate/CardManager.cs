using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult();
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult();
        }

        public IDataResult<List<Card>> GetAll()
        {
            var result = _cardDal.GetALL();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Card>>(result);
            }
            return new ErrorDataResult<List<Card>>(result);
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult();
        }
    }
}


