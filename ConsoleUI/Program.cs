using Business.ConCreate;
using DataAccess.ConCreate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new EfCarDal());
            var result = car.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.Id, item.BrandName, item.ColorName, item.DailyPrice);
                }
            }

        }
    }
}
