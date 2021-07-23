using Core.Utilities;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindeksScoreService
    {
        IDataResult<FindeksScore> GetById(int id);

        IDataResult<FindeksScore> GetByCustomerId(int customerId);

        IDataResult<List<FindeksScore>> GetAll();

        IResult Add(FindeksScore findeksScore);

        IResult Update(FindeksScore findeksScore);

        IResult Delete(FindeksScore findeksScore);

        IDataResult<FindeksScore> CalculateFindeksScore(FindeksScore findeksScore);
    }
}
