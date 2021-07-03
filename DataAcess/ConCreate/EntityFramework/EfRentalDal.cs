using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.ConCreate.EntityFramework;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.ConCreate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarProjectContext>, IRentalDal
    {
        public List<RentalOfCar> GetAllRentalOfCars()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join customer in context.Customers
                             on r.CustomerId equals customer.CustomerId

                             join color in context.Colors
                             on  c.ColorId equals color.ColorId
                             
                             join user in context.Users
                             on customer.UserId equals user.UsersId

                             select new RentalOfCar
                             {
                                 CarId = c.Id,
                                 RentalsId = r.RentalsId,
                                 brandName = b.BrandName,
                                 colorName = color.ColorName,
                                 userName = user.FirstName + " " + user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();

            }
        }

        public RentalOfCar GetByCarId(int id)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join customer in context.Customers
                             on r.CustomerId equals customer.CustomerId

                             join color in context.Colors
                             on c.ColorId equals color.ColorId

                             join user in context.Users
                             on customer.UserId equals user.UsersId
                             where r.CarId == id
                             select new RentalOfCar
                             {
                                 CarId = c.Id,
                                 RentalsId = r.RentalsId,
                                 brandName = b.BrandName,
                                 colorName = color.ColorName,
                                 userName = user.FirstName + " " + user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.FirstOrDefault();

            }
        }

        public RentalDetailDto GetRentalByBrandModel(string brandModel)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.UsersId
                             join car in context.Cars
                             on r.CarId equals car.Id
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 CustomerId = c.CustomerId,
                                 CustomerName = u.FirstName + ' ' + u.LastName,
                                 RentalsId = r.RentalsId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                EfCarDal efCar = new EfCarDal();
                CarDetailDto carDetails = efCar.GetCarDetail().Find(item => item.BrandName == brandModel);
                return (RentalDetailDto)result.Where(item => item.CarId == carDetails.ColorId);
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.UsersId
                             join car in context.Cars
                             on r.CarId equals car.Id
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 CustomerId = c.CustomerId,
                                 RentalsId = r.RentalsId,
                                 CustomerName = u.FirstName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                                 
                             };
                return result.ToList();
            }
        }


    }
}
