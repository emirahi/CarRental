using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entity.DTOs;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfCardDal : EfEntityRepositoryBase<Card, CarProjectContext>, ICardDal
    {
        public CardDto IsSuccessCard(Card card)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cards
                             join p in context.Payments
                             on c.Id equals p.CardId
                             join u in context.Users
                             on c.UserId equals u.UsersId
                             where p.Status == true && u.Status == true &&
                             card.CreditCard == c.CreditCard && card.Cvv == c.Cvv &&
                             card.ExpiryDate == c.ExpiryDate && card.FullName == c.FullName
                             select new CardDto
                             {
                                 Id = c.Id,
                                 UserId = u.UsersId,
                                 FullName = u.FirstName + " " + u.LastName,
                                 Email = u.Email,
                                 CreditCard = c.CreditCard,
                                 Cvv = c.Cvv,
                                 ExpiryDate = c.ExpiryDate,
                                 Status = p.Status
                             };
                var data = result.FirstOrDefault();
                return data;
            }
        }
    }
}


