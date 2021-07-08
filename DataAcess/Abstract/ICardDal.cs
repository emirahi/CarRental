using Core.DataAccess;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICardDal: IEntityRepositoryBase<Card>
    {
        CardDto IsSuccessCard(Card card);
    }
}
