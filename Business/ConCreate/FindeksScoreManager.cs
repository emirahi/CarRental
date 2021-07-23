using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class FindeksScoreManager : IFindeksScoreService
    {
        IFindeksScoreDal _findeksScoreDal;

        public FindeksScoreManager(IFindeksScoreDal findeksScoreDal)
        {
            _findeksScoreDal = findeksScoreDal;
        }

        public IResult Add(FindeksScore findeksScore)
        {
            _findeksScoreDal.Add(findeksScore);
            return new SuccessResult(Message.findeksScoreAdded);
        }

        public IDataResult<FindeksScore> CalculateFindeksScore(FindeksScore findeksScore)
        {
            findeksScore.Score = new Random().Next(900, 1900);

            return new SuccessDataResult<FindeksScore>(findeksScore);
        }

        public IResult Delete(FindeksScore findeksScore)
        {
            _findeksScoreDal.Delete(findeksScore);

            return new SuccessResult(Message.findeksScoreDelete);
        }

        public IDataResult<List<FindeksScore>> GetAll()
        {
            return new SuccessDataResult<List<FindeksScore>>(_findeksScoreDal.Ge());
        }

        public IDataResult<FindeksScore> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<FindeksScore>(_findeksScoreDal.Get(f => f.CustomerId == customerId));
        }

        public IDataResult<FindeksScore> GetById(int id)
        {
            return new SuccessDataResult<FindeksScore>(_findeksScoreDal.Get(f => f.Id == id));
        }

        public IResult Update(FindeksScore findeksScore)
        {
            _findeksScoreDal.Update(findeksScore);

            return new SuccessResult(Message.findeksScoreUpdate);
        }
    }
}
